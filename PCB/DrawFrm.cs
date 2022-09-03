using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCB_BEE
{
    public partial class DrawFrm : Form
    {
        
        public DrawFrm(string pcb_type)
        {
            InitializeComponent();
            this.pcb_type = Convert.ToInt32(pcb_type);
        }
        int pcb_type;

        Component[] board_components;
        Component[] feeders;
        Route last_rout , min_rout ;
        private int count_feeders, count_components, count_rf;
        private double x_begin, y_begin;
        private int current_type, next_type;
        private int amount_large = 8;

        private string file_path1="", file_path2="";
        private StreamReader stream_c, stream_rf;
        private Pen pen;
        private Graphics g;
        private string[] spilts = new string[] { "\t" };
        private string[] spilts_x_y = new string[] { "-" };
        private string line;
        private string[] line_spilt_fit_route_params, line_spilt_fit_route_feeders_params, line_spilt_component, line_spilt_feeder, line_split_begin, spilt_x_y;

        private double fit , min_fit ;

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            read_draw_last_route();
        }

        private void bestFit_btn_Click(object sender, EventArgs e)
        {
            read_draw_min_fit_route();
        }

        public void read_draw_last_route()
        {
            g = panel1.CreateGraphics();
            if (pcb_type == 1)
            {
                pen = new Pen(Color.Black, 6);
                read();
                
                while (!stream_rf.EndOfStream)
                    line = stream_rf.ReadLine();
                line_spilt_fit_route_params = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                count_rf = line_spilt_fit_route_params.Length;
                
                double fit = Convert.ToDouble(line_spilt_fit_route_params[0]);
                last_rout = new Route(count_components);
                last_rout.route = new List<int>();
                for (int i = 1; i < count_rf - 6; i++)
                    last_rout.route.Add(Convert.ToInt32(line_spilt_fit_route_params[i]));

                pen = new Pen(Color.Yellow, 4);
                g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(0)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(0)].y) * amount_large)));
                
                for (int i = 0; i < last_rout.route.Count - 1; i++)
                {
                    int j1 = last_rout.route.ElementAt(i);
                    int j2 = last_rout.route.ElementAt(i + 1);
                    g.DrawLine(pen, new Point((Convert.ToInt32(board_components[j1].x) * amount_large), (Convert.ToInt32(board_components[j1].y) * amount_large)), new Point((Convert.ToInt32(board_components[j2].x) * amount_large), (Convert.ToInt32(board_components[j2].y) * amount_large)));
                }
                g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components-1)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components-1)].y) * amount_large)));

                stream_c.Close();
                stream_rf.Close();
            }

            if (pcb_type == 2)
            {
                pen = new Pen(Color.Black, 6);
                read();
                
                while (!stream_rf.EndOfStream)
                    line = stream_rf.ReadLine();
                line_spilt_fit_route_feeders_params = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                count_rf = line_spilt_fit_route_feeders_params.Length;
                
                fit = double.Parse(line_spilt_fit_route_feeders_params[0]);
                last_rout = new Route(count_components);
                last_rout.route = new List<int>();
                for (int i = 1; i <= count_components; i++)
                    last_rout.route.Add(Convert.ToInt32(line_spilt_fit_route_feeders_params[i]));
                
                int index = 0;
                for (int j = count_components +1 ; j < count_rf - 6; j++)
                {
                    feeders[index].type = Convert.ToInt32(line_spilt_fit_route_feeders_params[j]);
                    index++;
                }
                pen = new Pen(Color.Yellow, 4);
                
                current_type = board_components[last_rout.route.ElementAt(0)].type;
                for (int i = 0; i < count_feeders; i++)
                    if (current_type == feeders[i].type)
                    {
                        g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(feeders[i].x) * amount_large), (Convert.ToInt32(feeders[i].y) * amount_large)));
                        break;
                    }
                
                for (int i = 0; i < last_rout.route.Count-1; i++)
                {
                    current_type = board_components[last_rout.route.ElementAt(i)].type;
                    next_type = board_components[last_rout.route.ElementAt(i+1)].type;
                    for (int s = 0; s < count_feeders; s++)
                    {
                        if (current_type == feeders[s].type)
                            g.DrawLine(pen, new Point((Convert.ToInt32(feeders[s].x) * amount_large), (Convert.ToInt32(feeders[s].y) * amount_large)), new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].y) * amount_large)));
                        if (next_type == feeders[s].type)
                            g.DrawLine(pen,new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].y) * amount_large)) , new Point((Convert.ToInt32(feeders[s].x) * amount_large), (Convert.ToInt32(feeders[s].y) * amount_large)) );
                        
                    }
                }
                next_type = board_components[last_rout.route.ElementAt(count_components - 1)].type;
                for (int i = 0; i < count_feeders; i++)
                    if (next_type == feeders[i].type)
                    {
                        g.DrawLine(pen, new Point((Convert.ToInt32(feeders[i].x) * amount_large), (Convert.ToInt32(feeders[i].y) * amount_large)), new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components - 1)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components - 1)].y) * amount_large)));
                        break;
                    }
                g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components - 1)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components - 1)].y) * amount_large)));
                
                stream_c.Close();
                stream_rf.Close();
            }

            if (pcb_type == 3)
            {
                pen = new Pen(Color.Black, 6);
                read();
                while (!stream_rf.EndOfStream)
                    line = stream_rf.ReadLine();
                line_spilt_fit_route_feeders_params = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                count_rf = line_spilt_fit_route_feeders_params.Length;

                fit = double.Parse(line_spilt_fit_route_feeders_params[0]);
                last_rout = new Route(count_components);
                last_rout.route = new List<int>();
                for (int i = 1; i <= count_components; i++)
                    last_rout.route.Add(Convert.ToInt32(line_spilt_fit_route_feeders_params[i]));

                int index = 0;
                for (int j = count_components + 1; j < count_rf - 6; j++)
                {
                    feeders[index].type = Convert.ToInt32(line_spilt_fit_route_feeders_params[j]);
                    index++;
                }
                pen = new Pen(Color.Yellow, 4);
                for (int i = 0; i < last_rout.route.Count - 1; i++)
                {
                    current_type = board_components[last_rout.route.ElementAt(i)].type;
                    next_type = board_components[last_rout.route.ElementAt(i + 1)].type;
                    for (int s = 0; s < count_feeders; s++)
                    {
                        if (current_type == feeders[s].type)
                            g.DrawLine(pen, new Point((Convert.ToInt32(feeders[s].x) * amount_large), (Convert.ToInt32(feeders[s].y) * amount_large)), new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].y) * amount_large)));
                        if (next_type == feeders[s].type)
                            g.DrawLine(pen, new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(i)].y) * amount_large)), new Point((Convert.ToInt32(feeders[s].x) * amount_large), (Convert.ToInt32(feeders[s].y) * amount_large)));
                    }
                }
                next_type = board_components[last_rout.route.ElementAt(count_components - 1)].type;
                for (int i = 0; i < count_feeders; i++)
                    if (next_type == feeders[i].type)
                    {
                        g.DrawLine(pen, new Point((Convert.ToInt32(feeders[i].x) * amount_large), (Convert.ToInt32(feeders[i].y) * amount_large)), new Point((Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components - 1)].x) * amount_large), (Convert.ToInt32(board_components[last_rout.route.ElementAt(count_components - 1)].y) * amount_large)));
                        break;
                    }
                stream_c.Close();
                stream_rf.Close();
            }            
        }
        
        
        public void read_draw_min_fit_route()
        {
            g = panel2.CreateGraphics();
            if (pcb_type == 1)
            {
                pen = new Pen(Color.Black, 6);
                
                read();
                find_min();

                file_path2 = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\result1.txt");
                stream_rf = new StreamReader(File.OpenRead(file_path2));

                while (!stream_rf.EndOfStream)
                {
                    line = stream_rf.ReadLine();
                    line_spilt_fit_route_params = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                    fit = double.Parse(line_spilt_fit_route_params[0]);

                    if (fit == min_fit)
                    {
                        min_rout = new Route(count_components);
                        min_rout.route = new List<int>();
                        for (int i = 1; i < count_rf - 6; i++)
                            min_rout.route.Add(Convert.ToInt32(line_spilt_fit_route_params[i]));

                        double n, m, e, n2, n1, itr;
                        n = Convert.ToInt32(line_spilt_fit_route_params[count_rf - 6]);
                        m = Convert.ToInt32(line_spilt_fit_route_params[count_rf - 5]);
                        e = Convert.ToInt32(line_spilt_fit_route_params[count_rf - 4]);
                        n2 = Convert.ToInt32(line_spilt_fit_route_params[count_rf - 3]);
                        n1 = Convert.ToInt32(line_spilt_fit_route_params[count_rf - 2]);
                        itr = Convert.ToInt32(line_spilt_fit_route_params[count_rf - 1]);

                        richTextBox1.Text += "\n the best root is : " ;
                        for (int i = 0; i < count_components; i++)
                            richTextBox1.Text += min_rout.route.ElementAt(i) + "   " ;
                        richTextBox1.Text += "\t with fit : " + fit 
                            + " n= " + n +"   m=" + m +"   e=" + e +"   n2= " + n2 +"   n1= " + n1 +"   itr= " + itr;                    
                    }
                }
                
                pen = new Pen(Color.Yellow, 4);

                g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(board_components[min_rout.route.ElementAt(0)].x) * amount_large), (Convert.ToInt32(board_components[min_rout.route.ElementAt(0)].y) * amount_large)));

                for (int i = 0; i < min_rout.route.Count - 1; i++)
                {
                    int j1 = min_rout.route.ElementAt(i);
                    int j2 = min_rout.route.ElementAt(i + 1);
                    g.DrawLine(pen, new Point((Convert.ToInt32(board_components[j1].x) * amount_large), (Convert.ToInt32(board_components[j1].y) * amount_large)), new Point((Convert.ToInt32(board_components[j2].x) * amount_large), (Convert.ToInt32(board_components[j2].y) * amount_large)));
                }
                g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(board_components[min_rout.route.ElementAt(count_components - 1)].x) * amount_large), (Convert.ToInt32(board_components[min_rout.route.ElementAt(count_components - 1)].y) * amount_large)));

                stream_rf.Close();
            }
            
            if (pcb_type == 2 || pcb_type == 3)
            {
                read();

                find_min();

                file_path2 = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\result" + pcb_type + ".txt");
                stream_rf = new StreamReader(File.OpenRead(file_path2));

                while (!stream_rf.EndOfStream)
                {
                    line = stream_rf.ReadLine();
                    line_spilt_fit_route_feeders_params = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                    fit = double.Parse(line_spilt_fit_route_feeders_params[0]);

                    if (fit == min_fit)
                    {
                        min_rout = new Route(count_components);
                        min_rout.route = new List<int>();
                        for (int i = 1; i < count_rf - 6 - count_feeders; i++)
                            min_rout.route.Add(Convert.ToInt32(line_spilt_fit_route_feeders_params[i]));
                        
                        string n, m, e, n2, n1, itr;
                        n = line_spilt_fit_route_feeders_params[count_rf - 6];
                        m = line_spilt_fit_route_feeders_params[count_rf - 5];
                        e = line_spilt_fit_route_feeders_params[count_rf - 4];
                        n2 = line_spilt_fit_route_feeders_params[count_rf - 3];
                        n1 = line_spilt_fit_route_feeders_params[count_rf - 2];
                        itr = line_spilt_fit_route_feeders_params[count_rf - 1];

                        richTextBox1.Text += "\n the best root : ";
                        for (int i = 0; i < min_rout.route.Count ; i++)
                            richTextBox1.Text += min_rout.route.ElementAt(i) + "   ";
                        richTextBox1.Text += "\t feeders : ";
                        for (int j = count_rf - 6 - count_feeders; j < count_rf - 6; j++)
                            richTextBox1.Text += line_spilt_fit_route_feeders_params[j] + "   ";
                        richTextBox1.Text += "\t with fit : " + fit
                            + "   n= " + n + "   m=" + m + "   e=" + e + "   n2= " + n2 + "   n1= " + n1 + "   itr= " + itr;
                    }
                }

                int current_type, next_type;
                pen = new Pen(Color.Yellow, 4);
                if (pcb_type == 2)
                {
                    current_type = min_rout.route.ElementAt(0);
                    current_type = board_components[current_type].type;
                    for (int i = 0; i < count_feeders; i++)
                        if (current_type == feeders[i].type)
                        {
                            g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(feeders[i].x) * amount_large), (Convert.ToInt32(feeders[i].y) * amount_large)));
                            break;
                        }
                }
                for (int i = 0; i < min_rout.route.Count - 1; i++)
                {
                    current_type = board_components[min_rout.route.ElementAt(i)].type;
                    next_type = board_components[min_rout.route.ElementAt(i + 1)].type;
                    for (int s = 0; s < count_feeders; s++)
                    {
                        if (current_type == feeders[s].type)
                            g.DrawLine(pen, new Point((Convert.ToInt32(feeders[s].x) * amount_large), (Convert.ToInt32(feeders[s].y) * amount_large)), new Point((Convert.ToInt32(board_components[min_rout.route.ElementAt(i)].x) * amount_large), (Convert.ToInt32(board_components[min_rout.route.ElementAt(i)].y) * amount_large)));
                        if (next_type == feeders[s].type)
                            g.DrawLine(pen, new Point((Convert.ToInt32(board_components[min_rout.route.ElementAt(i)].x) * amount_large), (Convert.ToInt32(board_components[min_rout.route.ElementAt(i)].y) * amount_large)), new Point((Convert.ToInt32(feeders[s].x) * amount_large), (Convert.ToInt32(feeders[s].y) * amount_large)));

                    }
                }
                next_type = board_components[min_rout.route.ElementAt(count_components - 1)].type;
                for (int i = 0; i < count_feeders; i++)
                    if (next_type == feeders[i].type)
                    {
                        g.DrawLine(pen, new Point((Convert.ToInt32(feeders[i].x) * amount_large), (Convert.ToInt32(feeders[i].y) * amount_large)), new Point((Convert.ToInt32(board_components[min_rout.route.ElementAt(count_components - 1)].x) * amount_large), (Convert.ToInt32(board_components[min_rout.route.ElementAt(count_components - 1)].y) * amount_large)));
                        break;
                    } 
                if(pcb_type == 2)
                    g.DrawLine(pen, new Point((Convert.ToInt32(x_begin) * amount_large), (Convert.ToInt32(y_begin) * amount_large)), new Point((Convert.ToInt32(board_components[min_rout.route.ElementAt(count_components - 1)].x) * amount_large), (Convert.ToInt32(board_components[min_rout.route.ElementAt(count_components - 1)].y) * amount_large)));

                stream_c.Close();
                stream_rf.Close();
            }
        }

        public void read()
        {
            if (pcb_type == 1)
            {

                file_path1 = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\bee1.txt");
                file_path2 = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\result1.txt");

                stream_c = new StreamReader(File.OpenRead(file_path1));
                stream_rf = new StreamReader(File.OpenRead(file_path2));

                line = stream_c.ReadLine();
                line_split_begin = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                spilt_x_y = line_split_begin[0].Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                x_begin = double.Parse(spilt_x_y[0]);
                y_begin = double.Parse(spilt_x_y[1]);

                line = stream_c.ReadLine();
                line_spilt_component = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                count_components = line_spilt_component.Length;
                board_components = new Component[count_components];
                for (int i = 0; i < board_components.Length; i++)
                    board_components[i] = new Component();

                int index = 0;
                foreach (string item in line_spilt_component)
                {
                    spilt_x_y = item.Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                    board_components[index].x = double.Parse(spilt_x_y[0]);
                    board_components[index].y = double.Parse(spilt_x_y[1]);
                    g.DrawRectangle(pen, (Convert.ToInt32(board_components[index].x)) * amount_large, (Convert.ToInt32(board_components[index].y)) * amount_large, 2, 2);
                    index++;
                }
                pen = new Pen(Color.Orange, 6);
                g.DrawRectangle(pen, (Convert.ToInt32(x_begin)) * amount_large, (Convert.ToInt32(y_begin)) * amount_large, 2, 2);


            }
            if (pcb_type == 2 || pcb_type == 3)
            {
                file_path1 = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\bee" + pcb_type + ".txt");
                file_path2 = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\result" + pcb_type + ".txt");

                stream_c = new StreamReader(File.OpenRead(file_path1));
                stream_rf = new StreamReader(File.OpenRead(file_path2));

                int index_f = 0, index_c = 0;

                if(pcb_type ==2)
                {
                    line = stream_c.ReadLine();
                    line_spilt_component = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                    spilt_x_y = line_spilt_component[0].Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                    x_begin = double.Parse(spilt_x_y[0]);
                    y_begin = double.Parse(spilt_x_y[1]);
                    pen = new Pen(Color.Orange, 6);
                    g.DrawRectangle(pen, (Convert.ToInt32(x_begin)) * amount_large, (Convert.ToInt32(y_begin)) * amount_large, 2, 2);
                }
                
                line = stream_c.ReadLine();
                line_spilt_feeder = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                line = stream_c.ReadLine();
                line_spilt_component = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                count_feeders = line_spilt_feeder.Length;
                count_components = line_spilt_component.Length;
                //if(pcb_type == 3)
                //{
                //    line = stream_c.ReadLine();
                //    double tur_time = Convert.ToDouble(line);
                //}
                feeders = new Component[count_feeders];
                board_components = new Component[count_components];
                for (int i = 0; i < count_components; i++)
                    board_components[i] = new Component();
                for (int j = 0; j < count_feeders; j++)
                    feeders[j] = new Component();

                pen = new Pen(Color.Black, 6);
                foreach (string item in line_spilt_component)
                {
                    spilt_x_y = item.Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                    board_components[index_c].x = double.Parse(spilt_x_y[0]);
                    board_components[index_c].y = double.Parse(spilt_x_y[1]);
                    board_components[index_c].type = int.Parse(spilt_x_y[2]);
                    g.DrawRectangle(pen, (Convert.ToInt32(board_components[index_c].x)) * amount_large, (Convert.ToInt32(board_components[index_c].y)) * amount_large, 2, 2);
                    index_c++;
                }
                pen = new Pen(Color.Red, 6);
                foreach (string item in line_spilt_feeder)
                {
                    spilt_x_y = item.Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                    feeders[index_f].x = double.Parse(spilt_x_y[0]);
                    feeders[index_f].y = double.Parse(spilt_x_y[1]);
                    feeders[index_f].type = int.Parse(spilt_x_y[2]);
                    g.DrawRectangle(pen, (Convert.ToInt32(feeders[index_f].x)) * amount_large, (Convert.ToInt32(feeders[index_f].y)) * amount_large, 2, 2);
                    index_f++;
                }
                
            }
        }

        public void find_min()
        {
            line = stream_rf.ReadLine();
            line_spilt_fit_route_params = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
            count_rf = line_spilt_fit_route_params.Length;

            min_fit = double.Parse(line_spilt_fit_route_params[0]);

            while (!stream_rf.EndOfStream)
            {
                line = stream_rf.ReadLine();
                line_spilt_fit_route_params = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                fit = double.Parse(line_spilt_fit_route_params[0]);
                if (fit < min_fit)
                    min_fit = fit;
            }

            stream_rf.Close();
        }


    }
}