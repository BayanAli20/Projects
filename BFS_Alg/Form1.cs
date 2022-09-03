using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_Bayan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphic_ G = new Graphic_();
       Queue<Node> op ;
       Queue<Node> cl;

        private void button1_Click(object sender, EventArgs e)
        {
           comboBox1.Items.Clear();
           // G.nodes = new LinkedList<Node>();
           // G.lines = new LinkedList<Line>();
            richTextBox1.Clear();
            richTextBox2.Clear();
            string Xml = G.ReadXml();
            string[] node = new string[G.nodecount()];
            richTextBox1.Text += Xml;
            node = G.combo();
            for (int i = 0; i < G.nodecount(); i++)
            {
                comboBox1.Items.Add(node[i]);
            }
            string degree = "";
            degree = G.showdegree();
            richTextBox1.Text += "\n" + degree;
           
           // G.regular();
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            string opcl = "";
            richTextBox2.Clear();
            string ncombox;
            ncombox = comboBox1.SelectedItem.ToString();
            int start = G.start(ncombox);
            opcl=G.Bfs(start);
            richTextBox3.Text += opcl;


            if (G.test())
            {

                richTextBox2.Text += G.show();
                richTextBox2.Text += G.showfather();

                if (G.Bip())
                {
                    richTextBox2.Text += G.showcolor();

                }

            }

            else

                MessageBox.Show("I Can Not Travel In The Graph You Give Me There Are Unique Node");
          
           

        }  
    }
}
