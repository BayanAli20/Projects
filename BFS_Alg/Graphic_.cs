using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Graphic_Bayan
{
    class Graphic_
    {
        int nc;
        int lc;
        LinkedList<Line> lines;
        LinkedList<Node> nodes;
        //public LinkedList<Node> spring_Well;
        Queue<Node> open;
        Queue<Node> close;
        enum colorn { Red, Green };
        string R = colorn.Red.ToString();
        string G = colorn.Green.ToString();
        //string[] children = new string[nc];
        string Xml = "";
        bool notfind;
        //Node node;
       // Node n3;

        public int nodecount()
        {
            return nc;
        }
        public int linecount()
        {
            return lc;
        }
        public LinkedList<Node> linkN()
        {
            return nodes;
        }
        public Queue<Node> closed()
        {
            return close;
        }
        //public Queue<Node> opend()
        //{
        //    return open;
        //}
        public string ReadXml()
        {
            int nodesCount;
            int linesCount;
            nodes = new LinkedList<Node>();
            lines = new LinkedList<Line>();
            Xml = "";
            //spring_Well = new LinkedList<Node>();
            //  richTextBox1.Clear();
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "my text files|*.xml";

            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(od.FileName);
                XmlNode node1;
                XmlNodeList node2;
                Node n1;
                node1 = doc.DocumentElement;
                nodesCount = node1.ChildNodes[0].ChildNodes.Count;
                linesCount = node1.ChildNodes[1].ChildNodes.Count;
                nc = nodesCount;
                lc = linesCount;

                //  richTextBox1.Text += "The count of Lines is " + linesCount + "\n";

                for (int m = 0; m < nc; m++)
                {
                    node2 = node1.ChildNodes[0].ChildNodes;
                    if (node2.Item(m).Name == "node")
                    {
                        n1 = new Node();
                        node2 = node1.ChildNodes[0].ChildNodes[m].ChildNodes;
                        n1.name = node2.Item(0).InnerText.Trim();
                        nodes.AddLast(n1);


                    }
                }
                string name1;
                string name2;
                for (int m = 0; m < lc; m++)
                {
                    node2 = node1.ChildNodes[1].ChildNodes;
                    if (node2.Item(m).Name == "line")
                    {
                        Line l1 = new Line();
                        node2 = node1.ChildNodes[1].ChildNodes[m].ChildNodes;
                        l1.namee = node2.Item(0).InnerText.Trim();
                        name1 = node2.Item(1).InnerText.Trim();
                        for (int i = 0; i < nc; i++)
                        {
                            if (name1 == nodes.ElementAt(i).name)
                            {
                                l1.begin = nodes.ElementAt(i);
                                nodes.ElementAt(i).degree++;
                            }


                        }
                       
                        name2 = node2.Item(2).InnerText.Trim();
                        for (int i = 0; i < nc; i++)
                        {
                            if (name2 == nodes.ElementAt(i).name)
                            {
                                l1.end = nodes.ElementAt(i);
                                nodes.ElementAt(i).degree++;

                            }
                        }

                        lines.AddLast(l1);


                    }
                }

                Xml += "The count of nodes is " + nodesCount + "\n";
                Xml += "The count of Lines is " + linesCount + "\n";
                Xml += "The nodes : ";


                for (int i = 0; i < nc; i++)
                {
                    Xml += nodes.ElementAt(i).name;

                }
                Xml += "\nThe name of line    start node    end node\n";
                for (int i = 0; i < lc; i++)
                {

                    Xml += lines.ElementAt(i).namee;
                    Xml += "                                  " + lines.ElementAt(i).begin.name;
                    Xml += "                        " + lines.ElementAt(i).end.name+"\n";
                }



            }
            else
                Xml += "We Can Not Open The File";

            return Xml;
        }

        public string[] combo()  //  comboboxتابع يقوم بارجاع اسماء العقد لتعبئة ال 
        {
            string[] combobox = new string[nc];
            for (int j = 0; j < nc; j++)
                combobox[j] = nodes.ElementAt(j).name;
            return combobox;
        }

        int index;
        public int start(string nodename)
        {

            for (int i = 0; i < nc; i++)
            {
                if (nodes.ElementAt(i).name == nodename)
                {
                    nodes.ElementAt(i).father = new Node();
                    nodes.ElementAt(i).father.name = "I am Root";
                    nodes.ElementAt(i).color = R;
                    index = i;

                }
            }
            return index;
        }

        public void coloring(Node son, Node father)  //تابع يقوم بتلوين العقد
        {
         
            for (int z = 0; z < nc; z++)
            {
                if (nodes.ElementAt(z).name == son.name)
                {
                    nodes.ElementAt(z).father = new Node();
                    nodes.ElementAt(z).father.name = father.name;
                    for (int j = 0; j < nc; j++)
                    {
                        if (nodes.ElementAt(j).name == father.name)
                        {
                            if (nodes.ElementAt(j).color == R)

                                nodes.ElementAt(z).color = G;

                            if (nodes.ElementAt(j).color == G)
                                nodes.ElementAt(z).color = R;
                        }
                    }

                }
            }
        }
        
        public LinkedList<Node> newchildren(Node father)  // تابع يقوم باحضار أبناء العقدة
        {
            LinkedList<Node> children = new LinkedList<Node>();
          
            for (int i = 0; i < lc; i++)
            {
               
               if (lines.ElementAt(i).begin.name == father.name)
                {
                    children.AddLast(lines.ElementAt(i).end);  
                    
                  
                }

               if (lines.ElementAt(i).end.name == father.name)
                {
                   
                     children.AddLast(lines.ElementAt(i).begin); 
                   

                }

            }
            return children;
        }


        public bool nfind(Node child)    //close or open تابع يقوم بفحص اذا كانت العقدة المرسلة (الابن )موجودة بال 
        {
            bool notfind = true;


            for (int i = 0; i < open.Count || i < close.Count; i++)
            {

                if ((i < open.Count && open.ElementAt(i).name == child.name) || (i < close.Count && close.ElementAt(i).name == child.name))
                {
                    notfind = false;
                    return notfind;

                }

            }

            return notfind;
        }
       
        public string Bfs(int Root)  // تابع
        {
            string print = "";
            open = new Queue<Node>();
            close = new Queue<Node>();
            open.Enqueue(nodes.ElementAt(Root));
            while (open.Count != 0)
            {
                print += "\n open";
                for(int k=0; k<open.Count();k++)
                {
                  
                        print += "\t" + open.ElementAt(k).name;
                   
                }
               
                print += "\n close";
                for (int k = 0; k < close.Count(); k++)
                {
                   
                    if (close.Count() != 0)
                   
                        print += "\t" + close.ElementAt(k).name;
                   
                }                  
                Node x = new Node();
                x = open.First();
                close.Enqueue(x);
               LinkedList<Node> child = newchildren(x);
                for (int j = 0; j < child.Count(); j++)
                {
                    notfind = nfind(child.ElementAt(j));
                    if (notfind)
                    {
                        open.Enqueue(child.ElementAt(j));

                        coloring(child.ElementAt(j), x);
                    }
                }

                open.Dequeue();
            }
            return print;
        }



        public bool test ()    // مساويا لعدد العقد الموجودة في المخطط close تابع يختبر أولا اذا كان عدد العقد الموجودة في   
        {
            bool xx = true;
            if (close.Count() != nc)
                xx = false;
            return xx;
        }

        public bool Bip()   //تابع يخنبر اذا كان المخطط ذو قسمين ام لا  عن طريق فحص الخطوط
        {
            bool m = true;

            for (int r = 0; r < lc; r++)
            {
                if (lines.ElementAt(r).begin.color == lines.ElementAt(r).end.color)
                {
                    MessageBox.Show("The Graph Is Not BIPARTITE");
                    m = false;
                    break;
                }

            }
            return m;
        }

        public string show()   // close  تابع يطبع العقد الموجودة في الرتل 
        {
            string close1 = "";
            close1 +="The Nodes In CloseList\n";
            for (int j = 0; j < close.Count(); j++)
            {

                close1 +=  close.ElementAt(j).name + "\t";


            }
            return close1;
        }

        public string showfather()   //تابع يطبع العقد الأبناء والأباء
        {
            string father = "";
            father +="\nFather Each Node ";
            for (int j = 0; j < nc; j++)
            {
                father += "\n  Father  " + (j + 1) + " is  " + nodes.ElementAt(j).father.name;
            }
            return father;
        }

       


        public string showcolor()   //تابع يطبع العقد وألوانها
        {     string color="";
        color += "\nThe Graph Is BIPARTITE \n";
        color += "The Color Each Node\n";
            for (int r = 0; r < nc; r++)
            {

             color  += " " + (r + 1) + "  is  " + nodes.ElementAt(r).color +"\n";

            }
            color += "Notice: \n The Nodes Which In The Same Color Are In The Same Region\n   ";
            return color;
        }

        public string showdegree()
        {
            string degree = "";
            degree += "\n degree each node";
            for (int i = 0; i <nc; i++)
            {
                degree += " degree  "+(i + 1) +"is"+ nodes.ElementAt(i).degree + "\t";
            }
            return degree;
        }
      
    }

}
