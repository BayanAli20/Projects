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
    public partial class Modify : Form
    {
        SqlDataAdapter da;
        SqlCommand cmd1, cmd2, cmd3, cmd4, cmd5;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt9 = new DataTable();
        int[] nn;

        Alter c = new Alter();
        int Trip_NO, Details_NO, Price, Airplane_NO;
        string Departure_City, Departure_Airport, Arrival_City, Arrival_Airport, Class_Name;
        DateTime Departure_Date, Arrival_Date;
        public Modify()
        {
            InitializeComponent();
            da = new SqlDataAdapter("SelectDepartureCity", LogOn.conn);
            da.Fill(dt1);
            cb_DCity.DataSource = dt1;
            cb_DCity.DisplayMember = "Departure_City";
            da = new SqlDataAdapter("SelectArrivalCity", LogOn.conn);
            da.Fill(dt3);
            cb_ACity.DataSource = dt3;
            cb_ACity.DisplayMember = "Arrival_City";
            da = new SqlDataAdapter("SelectCompanyName", LogOn.conn);
            da.Fill(dt5);
            cb_Airline.DataSource = dt5;
            cb_Airline.DisplayMember = "Company_Name";

            this.Refrech();
            dataGridView1.DataSource = dt9;
            cb_DCity.SelectedIndex = -1;
            cb_ACity.SelectedIndex = -1;
            cb_AAirport.SelectedIndex = -1;
            cb_DAirport.SelectedIndex = -1;
            cb_Airline.SelectedIndex = -1;
            cb_Airplane.SelectedIndex = -1;
            this.button2.Visible = false;
        }
        private void Trans(int classno, int Price, int Tripno)
        {
            for (int i = 1; i < 7; i++)
            {
                c.txt[0] = cb_DCity.Text;
                c.txt[1] = cb_DAirport.Text;
                c.txt[2] = cb_ACity.Text;
                c.txt[3] = cb_AAirport.Text;
                c.d1 = dtp_D.Value.Date + dateTimePicker1.Value.TimeOfDay;
                c.d2 = dtp_A.Value.Date + dateTimePicker2.Value.TimeOfDay;
                c.det[0] = int.Parse(cb_Airplane.Text);
                c.det[1] = classno;
                c.det[2] = Price;
                c.det[3] = Tripno;
            }
        }
        private void AddPricetoTXT()
        {
            nn = new int[7];
            for (int i = 0; i < 7; i++)
            {
                cmd5 = new SqlCommand("Select Price from Details where Trip_NO=" + Trip_NO + " and Airplane_NO= " + Airplane_NO + "and Class_No=" + (i + 1), LogOn.conn);
                LogOn.conn.Open();
                nn[i] = (int)cmd5.ExecuteScalar();
                LogOn.conn.Close();
            }
            textBox1.Text = nn[0].ToString();
            textBox2.Text = nn[1].ToString();
            textBox3.Text = nn[2].ToString();
            textBox4.Text = nn[3].ToString();
            textBox5.Text = nn[4].ToString();
            textBox6.Text = nn[5].ToString();
            textBox7.Text = nn[6].ToString();
        }

        private void cb_DCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt2.Clear();
            cmd1 = new SqlCommand("SelectDepartureAirpot", LogOn.conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param0 = new SqlParameter("@param0", SqlDbType.NVarChar, 50);
            param0.Value = cb_DCity.Text;
            cmd1.Parameters.Add(param0);
            da = new SqlDataAdapter(cmd1);
            da.Fill(dt2);
            cb_DAirport.DataSource = dt2;
            cb_DAirport.DisplayMember = "Departure_Airport";
        }

        private void cb_ACity_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt4.Clear();
            cmd2 = new SqlCommand("SelectArrivalAirpot", LogOn.conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@param0", SqlDbType.NVarChar, 50);
            param1.Value = cb_ACity.Text;
            cmd2.Parameters.Add(param1);
            da = new SqlDataAdapter(cmd2);
            da.Fill(dt4);
            cb_AAirport.DataSource = dt4;
            cb_AAirport.DisplayMember = "Arrival_Airport";
        }

        private void cb_Airline_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt6.Clear();
            cmd3 = new SqlCommand("SelectAirplaneNo_CompanyName", LogOn.conn);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlParameter param2 = new SqlParameter("@param0", SqlDbType.NVarChar, 50);
            param2.Value = cb_Airline.Text;
            cmd3.Parameters.Add(param2);
            da = new SqlDataAdapter(cmd3);
            da.Fill(dt6);
            cb_Airplane.DataSource = dt6;
            cb_Airplane.DisplayMember = "Airplane_NO";
        }
        void Refrech()
        {
            dt9.Clear();
            da = new SqlDataAdapter("SelectT", LogOn.conn);
            da.Fill(dt9);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.ClearTxtDet();
            this.Trans(0, 0, 0);
            c.updateTrip();
            this.Refrech();
            ////////price for sub class 
            this.Trans(1, int.Parse(textBox1.Text), Trip_NO);
            c.updateDetails();
            c.ClearTxtDet();
            this.Trans(2, int.Parse(textBox2.Text), Trip_NO);
            c.updateDetails();
            c.ClearTxtDet();
            this.Trans(3, int.Parse(textBox3.Text), Trip_NO);
            c.updateDetails();
            c.ClearTxtDet();
            this.Trans(4, int.Parse(textBox4.Text), Trip_NO);
            c.updateDetails();
            c.ClearTxtDet();
            this.Trans(5, int.Parse(textBox5.Text), Trip_NO);
            c.updateDetails();
            c.ClearTxtDet();
            this.Trans(6, int.Parse(textBox6.Text), Trip_NO);
            c.updateDetails();
            c.ClearTxtDet();
            this.Trans(7, int.Parse(textBox7.Text), Trip_NO);
            c.updateDetails();
            c.ClearTxtDet();
            this.Refrech();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            c.ClearTxtDet();
            cb_Airplane.DropDownStyle = ComboBoxStyle.DropDown;
            Details_NO = (int)dataGridView1.CurrentRow.Cells["Details_NO"].Value;
            Trip_NO = (int)dataGridView1.CurrentRow.Cells["Trip_NO"].Value;
            c.Trip_No = Trip_NO;
            Airplane_NO = (Int32)dataGridView1.CurrentRow.Cells["Airplane_NO"].Value;
            c.Airplane_NO = Airplane_NO;
            Departure_City = (string)dataGridView1.CurrentRow.Cells["Departure_City"].Value;
            Departure_Airport = (string)dataGridView1.CurrentRow.Cells["Departure_Airport"].Value;
            Arrival_City = (string)dataGridView1.CurrentRow.Cells["Arrival_City"].Value;
            Arrival_Airport = (string)dataGridView1.CurrentRow.Cells["Arrival_Airport"].Value;
            Departure_Date = (DateTime)dataGridView1.CurrentRow.Cells["Departure_Date"].Value;
            Arrival_Date = (DateTime)dataGridView1.CurrentRow.Cells["Arrival_Date"].Value;
            Class_Name = (string)dataGridView1.CurrentRow.Cells["Class_Name"].Value;
            cb_ACity.Text = Arrival_City;
            cb_DCity.Text = Departure_City;
            cb_AAirport.Text = Arrival_Airport;
            cb_DAirport.Text = Departure_Airport;
            cb_Airplane.Text = Airplane_NO.ToString();
            dtp_A.Value = Arrival_Date.Date;
            dtp_D.Value = Departure_Date.Date;
            dateTimePicker1.Value = Departure_Date;
            dateTimePicker2.Value = Arrival_Date;
            //price



            this.AddPricetoTXT();
            button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.ClearTxtDet();
            this.Trans(1, int.Parse(textBox1.Text), 0);
            c.InsertTrip();
            cmd4 = new SqlCommand("Select Max(Trip_No) from Trip", LogOn.conn);
            LogOn.conn.Open();
            int Trip_NO = (int)cmd4.ExecuteScalar();
            LogOn.conn.Close();
            this.Trans(1, int.Parse(textBox1.Text), Trip_NO);
            c.InsertDetails();
            c.ClearTxtDet();
            this.Trans(2, int.Parse(textBox2.Text), Trip_NO);
            c.InsertDetails();
            c.ClearTxtDet();
            this.Trans(3, int.Parse(textBox3.Text), Trip_NO);
            c.InsertDetails();
            c.ClearTxtDet();
            this.Trans(4, int.Parse(textBox4.Text), Trip_NO);
            c.InsertDetails();
            c.ClearTxtDet();
            this.Trans(5, int.Parse(textBox5.Text), Trip_NO);
            c.InsertDetails();
            c.ClearTxtDet();
            this.Trans(6, int.Parse(textBox6.Text), Trip_NO);
            c.InsertDetails();
            c.ClearTxtDet();
            this.Trans(7, int.Parse(textBox7.Text), Trip_NO);
            c.InsertDetails();
            MessageBox.Show("Added Succsessfully", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Refrech();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd1 = new SqlCommand("Details_Deleted", LogOn.conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@param0", SqlDbType.Int);
            param[0].Value = Trip_NO;
            param[1] = new SqlParameter("@param1", SqlDbType.Int);
            param[1].Value = Airplane_NO;
            cmd1.Parameters.AddRange(param);
            LogOn.conn.Open();
            cmd1.ExecuteNonQuery();
            LogOn.conn.Close();
        }

    }
}
