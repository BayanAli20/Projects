using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Flight_Offic_Final
{
    public partial class LogOn : Form
    {
        public LogOn()
        {
            InitializeComponent();

        }
        public static int User_NO;
        public static int[] Per = new int[3];
        public static string User_Name, Password,ComputerName;
        SqlCommand cmd1, cmd2, cmd3;
        SqlDataReader dr;
        public static SqlConnection conn = new SqlConnection("Data Source=" + ComputerName + " ;Initial Catalog=test;Persist Security Info =true ; User Id= sa ;Password= 11 ;");

        private void button1_Click(object sender, EventArgs e)
        {
            ComputerName = textBox3.Text;
            
                int i = 0;
                cmd1 = new SqlCommand("Select User_NO from UserM where User_Name='" + textBox1.Text + "'", conn);
                conn.Open();
                User_NO = (int)cmd1.ExecuteScalar();
                conn.Close();
                if (User_NO != 0)
                {
                    cmd2 = new SqlCommand("Select Password from UserM  where User_NO=" + User_NO, conn);
                    conn.Open();
                    Password = (string)cmd2.ExecuteScalar();
                    conn.Close();
                    if (Password.Trim() == textBox2.Text.Trim())
                    {
                        cmd3 = new SqlCommand("Select Per_NO from User_Per where User_NO=" + User_NO, conn);
                        conn.Open();
                        dr = cmd3.ExecuteReader();
                        while (dr.Read())
                        {
                            Per[i] = (int)dr[0];
                            i++;
                        }
                        dr.Close();
                        conn.Close();
                        MainForm f = new MainForm();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please reenter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Please reenter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
