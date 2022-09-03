using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PCB_BEE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bee b;

        private string file_path="";
        private FileStream fs;
        private StreamWriter sw ;
        private StreamReader stream ;
        private string[] spilts = new string[] { "\t" };
        private string[] spilts_x_y = new string[] { "-" };
        private string line;
        private string[] line_spilt_feeder, line_spilt_component, line_split_begin, spilt_x_y;
        public int type_of_pcb, num_of_bees, itration, num_of_opts = 1;         
        public double x_begin, y_begin;
        public double tur_time; public string comp1_type = "";
        public int count_feeders , count_components;
        public string file_result1 = "", file_result2 = "", file_result3 = "";


        private void loadBtn_Click(object sender, EventArgs e)              //read a file and load values
        {
        lable: OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                stream = new StreamReader(File.OpenRead(open.FileName));
                int index = 0;

                read();

                b = new Bee(type_of_pcb, count_feeders, count_components, x_begin, y_begin, tur_time);

                if (type_of_pcb == 1)
                {//set components
                    index = 0;
                    foreach (string item in line_spilt_component)
                    {
                        spilt_x_y = item.Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                        b.set_board_component(index, Convert.ToDouble(spilt_x_y[0]), double.Parse(spilt_x_y[1]), 0);
                        index++;
                    }
                    richTextBox1.Text += "\n The type of board's components:  " + comp1_type + "\n";
                    //print components
                    for (int i = 0; i < count_components; i++)
                        richTextBox1.Text += "\n component " + i + "\t\tx=" + b.board_comp1[i].x + "\ty=" + b.board_comp1[i].y;
                    richTextBox1.Text += "\n";

                }
                if (type_of_pcb == 2 || type_of_pcb == 3)
                {
                    //set components
                    index = 0;
                    foreach (string item in line_spilt_component)
                    {
                        spilt_x_y = item.Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                        b.set_board_component(index, double.Parse(spilt_x_y[0]), double.Parse(spilt_x_y[1]), int.Parse(spilt_x_y[2]));
                        index++;
                    }
                    //set feeders
                    index = 0;
                    foreach (string item in line_spilt_feeder)
                    {
                        spilt_x_y = item.Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                        b.set_feeder_component(type_of_pcb, index, double.Parse(spilt_x_y[0]), double.Parse(spilt_x_y[1]), int.Parse(spilt_x_y[2]));
                        index++;
                    }
                    //print components
                    for (int i = 0; i < count_components; i++)
                        richTextBox1.Text += "\n component " + i + "\t\tx=" + b.board_comp1[i].x + "\ty=" + b.board_comp1[i].y + "\tType=" + b.board_comp1[i].type;
                    richTextBox1.Text += "\n";

                }
                //print begin point
                if (type_of_pcb == 1 || type_of_pcb == 2)
                    richTextBox1.Text += "\n The begin position : " + "\tx=" + x_begin + "\ty=" + y_begin + "\n";

                if (type_of_pcb == 2)
                {//print feeders
                    for (int i = 0; i < count_feeders; i++)
                        richTextBox1.Text += "\n feeder " + i + "\t\tx=" + b.second.feeder[i].x + "\ty=" + b.second.feeder[i].y + "\ttype=" + b.second.feeder[i].type;
                    richTextBox1.Text += "\n";
                }
                if (type_of_pcb == 3)
                {//print feeders & turrent
                    for (int i = 0; i < count_feeders; i++)
                        richTextBox1.Text += "\n feeder " + i + "\t\tx=" + b.third.feeder[i].x + "\ty=" + b.third.feeder[i].y + "\ttype=" + b.third.feeder[i].type;
                    richTextBox1.Text += "\n\n turret time : " + tur_time + "\n";
                }
            }
            else
            {
                DialogResult returnto = MessageBox.Show("Select file of dataset", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (returnto == DialogResult.Yes) goto lable;
            }

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            type_of_pcb = Convert.ToInt32(type_comboBox.SelectedItem.ToString());
            num_of_bees = Convert.ToInt32(num_bees_textbox.Text);
            itration = Convert.ToInt32(itration_textbox.Text);
            
            Boolean feeder_arrang = feeder_arrang_checkbox.Checked;
            Boolean route_ngh = route_ngh_checkbox.Checked;

            if (route_ngh_checkbox.Checked)
                num_of_opts = Convert.ToInt32(opts_comboBox.SelectedItem.ToString());
           
            if (randomRadio.Checked)
                b.Run_Bee(num_of_bees, itration, type_of_pcb, feeder_arrang, route_ngh, num_of_opts);
            if (manualRadio.Checked)
            {
                int m = Convert.ToInt32(m_numBox.Value);   
                int e0 = Convert.ToInt32(e_numBox.Value);
                int n2 = Convert.ToInt32(n2_numBox.Value);
                int n1 = Convert.ToInt32(n1_numBox.Value);
                b.Run_Bee_Random(num_of_bees, itration, type_of_pcb, feeder_arrang, route_ngh, num_of_opts, m, e0, n2, n1);
            }

            print_and_save_to_file();
        }

        public void read()
        {
            type_of_pcb = int.Parse(type_comboBox.SelectedItem.ToString());
            if (type_of_pcb == 1 || type_of_pcb == 2)
            {
                line = stream.ReadLine();
                line_split_begin = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                spilt_x_y = line_split_begin[0].Split(spilts_x_y, StringSplitOptions.RemoveEmptyEntries);
                x_begin = double.Parse(spilt_x_y[0]);
                y_begin = double.Parse(spilt_x_y[1]);

                turret_textBox.Text = "0";
            }
            if (type_of_pcb == 2 || type_of_pcb == 3)
            {
                line = stream.ReadLine();
                line_spilt_feeder = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
                count_feeders = line_spilt_feeder.Length;

                num_feeders_textBox.Text = Convert.ToString(count_feeders);
            }
            line = stream.ReadLine();
            line_spilt_component = line.Split(spilts, StringSplitOptions.RemoveEmptyEntries);
            count_components = line_spilt_component.Length;

            if (type_of_pcb == 1)
            {
                line = stream.ReadLine();
                comp1_type = line;
                count_feeders = 0;
                num_feeders_textBox.Text = "1";
            }
            if(type_of_pcb == 3)
            {
                x_begin = y_begin = 0;
                //لقراءة زمن دوران الرأس
                line = stream.ReadLine();
                tur_time = Convert.ToDouble(line);
                turret_textBox.Text = Convert.ToString(tur_time);
               
            }
            num_comps_textBox.Text = Convert.ToString(count_components);
        }

        public void print_and_save_to_file()
        {

            file_path = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\result" + type_of_pcb + ".txt");
            fs = new FileStream(file_path, FileMode.Append);
            sw = new StreamWriter(fs);

            if (type_of_pcb == 1)
            {
                file_result1 = "";
                file_result1 += b.bee[0].fitness + "\t";

                richTextBox1.Text += "the Route is : ";
                for (int i = 0; i < b.bee[0].route.Count(); i++)
                {
                    file_result1 += "\t" + b.bee[0].route.ElementAt(i);
                    richTextBox1.Text += b.bee[0].route.ElementAt(i) + " ";
                }
                richTextBox1.Text += "\t fit= " + b.bee[0].fitness + "\n";

                m_numBox.Value  = b.m;
                e_numBox.Value  = b.e;
                n2_numBox.Value = b.n2;
                n1_numBox.Value = b.n1;

                file_result1 += "\t" + b.num_of_bees + "\t" + b.m + "\t" + b.e + "\t" + b.n2 + "\t" + b.n1 + "\t" + b.itration + "*";

                file_result1 = file_result1.Replace("*", Environment.NewLine);
                sw.Write(file_result1);
                sw.Close();

            }
            if (type_of_pcb == 2)
            {
                file_result2 = "";
                file_result2 += b.bee[0].fitness + "\t";

                richTextBox1.Text += "\n\n the Route is : ";
                for (int i = 0; i < b.bee[0].route.Count(); i++)
                {
                    file_result2 += "\t" + b.bee[0].route.ElementAt(i);
                    richTextBox1.Text += b.bee[0].route.ElementAt(i) + " ";
                }
                richTextBox1.Text += "\t fit= " + b.bee[0].fitness + "\n";

                richTextBox1.Text += "\n the feeder arrangment is : ";
                for (int i = 0; i < b.second.feeder.Count(); i++)
                {
                    file_result2 += "\t" + b.second.feeder[i].type;
                    richTextBox1.Text += b.second.feeder[i].type + " ";
                }

                m_numBox.Value = b.m;
                e_numBox.Value = b.e;
                n2_numBox.Value = b.n2;
                n1_numBox.Value = b.n1;

                file_result2 += "\t" + b.num_of_bees + "\t" + b.m + "\t" + b.e + "\t" + b.n2 + "\t" + b.n1 + "\t" + b.itration + "*";
                file_result2 = file_result2.Replace("*", Environment.NewLine);
                sw.Write(file_result2);
                sw.Close();
            }
            if (type_of_pcb == 3)
            {
                file_result3 = "";
                file_result3 += b.bee[0].fitness + "\t";

                richTextBox1.Text += "\n\n the Route is : ";
                for (int i = 0; i < b.bee[0].route.Count(); i++)
                {
                    file_result3 += "\t" + b.bee[0].route.ElementAt(i);
                    richTextBox1.Text += b.bee[0].route.ElementAt(i) + " ";
                }
                richTextBox1.Text += "\t fit= " + b.bee[0].fitness + "\n";

                richTextBox1.Text += "\n the feeder arrangment is : ";
                for (int i = 0; i < b.third.feeder.Count(); i++)
                {
                    file_result3 += "\t" + b.third.feeder[i].type;
                    richTextBox1.Text += b.third.feeder[i].type + " ";
                }

                m_numBox.Value = b.m;
                e_numBox.Value = b.e;
                n2_numBox.Value = b.n2;
                n1_numBox.Value = b.n1;

                file_result3 += "\t" + b.num_of_bees + "\t" + b.m + "\t" + b.e + "\t" + b.n2 + "\t" + b.n1 + "\t" + b.itration + "*";
                file_result3 = file_result3.Replace("*", Environment.NewLine);
                sw.Write(file_result3);
                sw.Close();
            }
        }

        private void num_bees_textbox_TextChanged(object sender, EventArgs e)
        {
            m_numBox.Maximum = Convert.ToInt32(num_bees_textbox.Text);
            n2_numBox.Maximum = Convert.ToInt32(num_bees_textbox.Text);
        }

        private void m_numBox_ValueChanged(object sender, EventArgs e)
        {
            e_numBox.Maximum = Convert.ToInt32(m_numBox.Value);
        }

        private void n2_numBox_ValueChanged(object sender, EventArgs e)
        {
            n1_numBox.Maximum = Convert.ToInt32(n2_numBox.Value);
        }

        private void randomRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (randomRadio.Checked)
            {
                m_numBox.Enabled =  false;
                e_numBox.Enabled =  false;
                n2_numBox.Enabled = false;
                n1_numBox.Enabled = false;
            }
            else
            {
                m_numBox.Enabled =  true;
                e_numBox.Enabled =  true;
                n2_numBox.Enabled = true;
                n1_numBox.Enabled = true;
            }
        }

        private void type_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_btn.Visible = true;
            draw_btn.Visible = true;
            if (type_comboBox.SelectedItem.ToString() == "2" || type_comboBox.SelectedItem.ToString() == "3")
            {
                feeder_arrang_checkbox.Visible = true;
                feeder_arrang_checkbox.Enabled = true;
            }
            else
                feeder_arrang_checkbox.Visible = false;
        }

        private void route_ngh_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (route_ngh_checkbox.Checked == true)
                opts_comboBox.Enabled = true;
            else
                opts_comboBox.Enabled = false;
        }

        private void draw_btn_Click(object sender, EventArgs e)
        {
            DrawFrm df = new DrawFrm(type_comboBox.Text);
            df.ShowDialog();
        }

    }
}
