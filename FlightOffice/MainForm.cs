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
    public partial class MainForm : Form
    {
        
        SqlConnection cn = LogOn.conn;
        SqlDataAdapter da;
        SqlCommand cmd1, cmd2;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6;
        DataTable dt7 = new DataTable();
        int v_Trip_No, v_Airplane_No;
        string Departure, Arrival, Airline, Comp_Name,pricF,pricB,pricE;
        double PF,PB,PE;


        public MainForm()
        {
            InitializeComponent();
            /////
            b2_Reservation.Enabled = false;
            b3_Modify.Enabled = false;
            b3_PassModi.Enabled = false;
            cb_DepartureCity.Items.Clear();

            da = new SqlDataAdapter("Select_Trip", LogOn.conn);
            da.Fill(dt1);
            dataGridView_Trips.DataSource = dt1;

            da = new SqlDataAdapter("Select_Company", LogOn.conn);
            da.Fill(dt2);
            cb_Airline.DataSource = dt2;
            cb_Airline.DisplayMember = "Company_Name";
            cb_Airline.ValueMember = "Company_NO";

            da = new SqlDataAdapter("SelectArrivalCity", LogOn.conn);
            da.Fill(dt3);
            cb_ArrivalCity.DataSource = dt3;
            cb_ArrivalCity.DisplayMember = "Arrival_City";

            da = new SqlDataAdapter("SelectDepartureCity", LogOn.conn);
            da.Fill(dt4);
            cb_DepartureCity.DataSource = dt4;
            cb_DepartureCity.DisplayMember = "Departure_City";

            cb_DepartureCity.SelectedIndex = -1;
            cb_ArrivalCity.SelectedIndex = -1;
            cb_Airline.SelectedIndex = -1;

            combPassenger_Type.Items.Add("Baby");
            combPassenger_Type.Items.Add("Young");
            combPassenger_Type.Items.Add("Adult");

        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Show();
            System.Threading.Thread.Sleep(5000);
            s.Close();
            this.SetPermission();
        }
      
        private void b1_Search_Click(object sender, EventArgs e)
        {
            dt6 = new DataTable();
            dt6.Clear();
            if (Departure != "" && Arrival != "" && Airline != "")
            {

                cmd1 = new SqlCommand("Select_Trip_De_Arr_Com", LogOn.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@params0", SqlDbType.NVarChar, 50);
                param[1] = new SqlParameter("@params1", SqlDbType.NVarChar, 50);
                param[2] = new SqlParameter("@params2", SqlDbType.NVarChar, 50);

                param[0].Value = Departure;
                param[1].Value = Arrival;
                param[2].Value = Airline;
                cmd1.Parameters.AddRange(param);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt6);
                dataGridView_Trips.DataSource = dt6;

            }
            else if (Departure != "" && Arrival != "")
            {
                cmd1 = new SqlCommand("Select_Trip_Arr_De", LogOn.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@params0", SqlDbType.NVarChar, 50);
                param[1] = new SqlParameter("@params1", SqlDbType.NVarChar, 50);

                param[0].Value = Departure;
                param[1].Value = Arrival;
                cmd1.Parameters.AddRange(param);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt6);
                dataGridView_Trips.DataSource = dt6;
            }
            else if (Arrival != "" && Airline != "")
            {

                cmd1 = new SqlCommand("Select_Trip_Arr_Com", LogOn.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@params0", SqlDbType.NVarChar, 50);
                param[1] = new SqlParameter("@params1", SqlDbType.NVarChar, 50);

                param[0].Value = Arrival;
                param[1].Value = Airline;
                cmd1.Parameters.AddRange(param);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt6);
                dataGridView_Trips.DataSource = dt6;


            }
            else if (Departure != "" && Airline != "")
            {
                cmd1 = new SqlCommand("Select_Trip_De_Com", LogOn.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@params0", SqlDbType.NVarChar, 50);
                param[1] = new SqlParameter("@params1", SqlDbType.NVarChar, 50);

                param[0].Value = Departure;
                param[1].Value = Airline;
                cmd1.Parameters.AddRange(param);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt6);
                dataGridView_Trips.DataSource = dt6;

            }
            else if (Departure != "")
            {
                cmd1 = new SqlCommand("Select_Trip_De", LogOn.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@params0", SqlDbType.NVarChar, 50);
                param.Value = Departure;
                cmd1.Parameters.Add(param);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt6);
                dataGridView_Trips.DataSource = dt6;
            }
            else if (Arrival != "")
            {

                cmd1 = new SqlCommand("Select_Trip_Arr", LogOn.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@params0", SqlDbType.NVarChar, 50);
                param.Value = Arrival;
                cmd1.Parameters.Add(param);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt6);
                dataGridView_Trips.DataSource = dt6;
            }
            else if (Airline != "")
            {
                cmd1 = new SqlCommand("TripComp", LogOn.conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@params0", SqlDbType.NVarChar, 50);
                param.Value = Airline;
                cmd1.Parameters.Add(param);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt6);
                dataGridView_Trips.DataSource = dt6;

            }

            cb_DepartureCity.SelectedIndex = -1;
            cb_ArrivalCity.SelectedIndex = -1;
            cb_Airline.SelectedIndex = -1;
        }

        private void cb_DepartureCity_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cb_ArrivalCity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cb_Airline_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_DepartureCity_SelectedValueChanged(object sender, EventArgs e)
        {
            Departure = cb_DepartureCity.Text.ToString();

        }

        private void cb_ArrivalCity_SelectedValueChanged(object sender, EventArgs e)
        {
            Arrival = cb_ArrivalCity.Text.ToString();
        }

        private void cb_Airline_SelectedValueChanged(object sender, EventArgs e)
        {
            Airline = cb_Airline.Text.ToString();
        }

        

        private void combPassenger_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            
              PF = 0;
              PB = 0;
              PE = 0;
              pricF="";
              pricB="";
              pricE="";
              if (combPassenger_Type.SelectedItem == "Baby")
              {
                  textBox_Discount.Text = 50.ToString();
                  pricF = textBox_Cost_FC.Text;
                  pricB = textBox_Cost_BC.Text;
                  pricE = textBox_Cost_EC.Text;
                  PF = Convert.ToDouble(pricF) * 0.5;
                  PB = Convert.ToDouble(pricB) * 0.5;
                  PE = Convert.ToDouble(pricE) * 0.5;
                  textBox_Cost_FC_AD.Text = (Convert.ToDouble(pricF) - PF).ToString();
                  textBox_Cost_BC_AD.Text = (Convert.ToDouble(pricB) - PB).ToString();
                  textBox_Cost_EC_AD.Text = (Convert.ToDouble(pricE) - PE).ToString();
              }
              else
                  if (combPassenger_Type.SelectedItem == "Young")
                  {
                      textBox_Discount.Text = 20.ToString();
                      pricF = textBox_Cost_FC.Text;
                      pricB = textBox_Cost_BC.Text;
                      pricE = textBox_Cost_EC.Text;
                      PF = Convert.ToDouble(pricF) * 0.2;
                      PB = Convert.ToDouble(pricB) * 0.2;
                      PE = Convert.ToDouble(pricE) * 0.2;
                      textBox_Cost_FC_AD.Text = (Convert.ToDouble(pricF) - PF).ToString();
                      textBox_Cost_BC_AD.Text = (Convert.ToDouble(pricB) - PB).ToString();
                      textBox_Cost_EC_AD.Text = (Convert.ToDouble(pricE) - PE).ToString();

                  }
                  else
                      if (combPassenger_Type.SelectedItem == "Adult")
                      {
                          textBox_Discount.Text = 10.ToString();
                          pricF = textBox_Cost_FC.Text;
                          pricB = textBox_Cost_BC.Text;
                          pricE = textBox_Cost_EC.Text;
                          PF = Convert.ToDouble(pricF) * 0.1;
                          PB = Convert.ToDouble(pricB) * 0.1;
                          PE = Convert.ToDouble(pricE) * 0.1;
                          textBox_Cost_FC_AD.Text = (Convert.ToDouble(pricF) - PF).ToString();
                          textBox_Cost_BC_AD.Text = (Convert.ToDouble(pricB) - PB).ToString();
                          textBox_Cost_EC_AD.Text = (Convert.ToDouble(pricE) - PE).ToString();
                      }
        }

   
   

        private void b3_PassModi_Click_1(object sender, EventArgs e)
        {
            PassModi DY = new PassModi();
            DY.Show();

        }

        private void b3_Modify_Click(object sender, EventArgs e)
        {
            Modify MD = new Modify();
            MD.Show();
        }

        private void b2_Reservation_Click(object sender, EventArgs e)
        {
            Reservation RS = new Reservation();
            RS.Show();
        }
        private void SetPermission()
        {
            for (int i = 0; i < LogOn.Per.Length; i++)
            {
                if (LogOn.Per[i] == 1)
                {
                    b3_Modify.Enabled = true;

                }
                if (LogOn.Per[i] == 2)
                {
                    b2_Reservation.Enabled = true;
                    b3_PassModi.Enabled = true;

                }
                if (LogOn.Per[i] == 3)
                {
                }
            }

        }

        private void dataGridView_Trips_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Cost_FC.DataBindings.Clear();
            textBox_Cost_BC.DataBindings.Clear();
            textBox_Cost_EC.DataBindings.Clear();
            dt4 = new DataTable();
            dt1 = new DataTable();
            dt2 = new DataTable();
            dt7 = new DataTable();
            v_Trip_No = (int)dataGridView_Trips.CurrentRow.Cells["Trip_No"].Value;

            v_Airplane_No = (int)dataGridView_Trips.CurrentRow.Cells["Airplane_No"].Value;
            Comp_Name = (string)dataGridView_Trips.CurrentRow.Cells["Company_Name"].Value;

            cmd1 = new SqlCommand("Pricess", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param1 = new SqlParameter[2];
            param1[0] = new SqlParameter("@param0", SqlDbType.Int);
            param1[1] = new SqlParameter("@param1", SqlDbType.Int);
            param1[0].Value = v_Airplane_No;
            param1[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param1);

            da = new SqlDataAdapter(cmd1);
            da.Fill(dt1);
            textBox_Cost_FC.DataBindings.Add("Text", dt1, "Price");
            //@@@@@@@
            // dt1 = new DataTable();
            cmd2 = new SqlCommand("PricessB", cn);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param2 = new SqlParameter[2];
            param2[0] = new SqlParameter("@param0", SqlDbType.Int);
            param2[1] = new SqlParameter("@param1", SqlDbType.Int);
            param2[0].Value = v_Airplane_No;
            param2[1].Value = v_Trip_No;
            cmd2.Parameters.AddRange(param2);
            da = new SqlDataAdapter(cmd2);
            da.Fill(dt2);
            textBox_Cost_BC.DataBindings.Add("Text", dt2, "Price");
            // @@@@@@@

            cmd1 = new SqlCommand("Select_CountSeats_ArrestedEC_B", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param3 = new SqlParameter[2];
            param3[0] = new SqlParameter("@param0", SqlDbType.Int);
            param3[1] = new SqlParameter("@param1", SqlDbType.Int);
            param3[0].Value = v_Airplane_No;
            param3[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param3);
            cn.Open();
            int NumArrSeat_EC_B; //= (int)cmd1.ExecuteScalar();
            int.TryParse(cmd1.ExecuteScalar().ToString(), out NumArrSeat_EC_B);
            cn.Close();


            //
            cmd1 = new SqlCommand("Select_CountSeats_EC_B", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param4 = new SqlParameter("@param0", SqlDbType.Int);
            param4.Value = v_Airplane_No;

            cmd1.Parameters.Add(param4);
            cn.Open();
            int NumSeat_EC_B = (int)cmd1.ExecuteScalar();
            cn.Close();

            /////@@@@VVVVVV
            cmd1 = new SqlCommand("Select_CountSeats_ArrestedEC_V", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param5 = new SqlParameter[2];
            param5[0] = new SqlParameter("@param0", SqlDbType.Int);
            param5[1] = new SqlParameter("@param1", SqlDbType.Int);
            param5[0].Value = v_Airplane_No;
            param5[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param5);
            cn.Open();
            int NumArrSeat_EC_V = (int)cmd1.ExecuteScalar();
            cn.Close();

            //////
            cmd1 = new SqlCommand("Select_CountSeats_EC_V", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param6 = new SqlParameter("@param0", SqlDbType.Int);
            param6.Value = v_Airplane_No;
            cmd1.Parameters.Add(param6);
            cn.Open();
            int NumSeat_EC_V = (int)cmd1.ExecuteScalar();
            cn.Close();
            //////@@@@TTTT
            cmd1 = new SqlCommand("Select_CountSeats_ArrestedEC_T", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param7 = new SqlParameter[2];
            param7[0] = new SqlParameter("@param0", SqlDbType.Int);
            param7[1] = new SqlParameter("@param1", SqlDbType.Int);
            param7[0].Value = v_Airplane_No;
            param7[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param7);
            cn.Open();
            int NumArrSeat_EC_T = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////
            cmd1 = new SqlCommand("Select_CountSeats_EC_T", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param8 = new SqlParameter("@param0", SqlDbType.Int);
            param8.Value = v_Airplane_No;
            cmd1.Parameters.Add(param8);
            cn.Open();
            int NumSeat_EC_T = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@@YYY

            cmd1 = new SqlCommand("Select_CountSeats_ArrestedEC_Y", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param9 = new SqlParameter[2];
            param9[0] = new SqlParameter("@param0", SqlDbType.Int);
            param9[1] = new SqlParameter("@param1", SqlDbType.Int);
            param9[0].Value = v_Airplane_No;
            param9[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param9);
            cn.Open();
            int NumArrSeat_EC_Y = (int)cmd1.ExecuteScalar();
            cn.Close();
            //////
            cmd1 = new SqlCommand("Select_CountSeats_EC_Y", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param10 = new SqlParameter("@param0", SqlDbType.Int);
            param10.Value = v_Airplane_No;
            cmd1.Parameters.Add(param10);
            cn.Open();
            int NumSeat_EC_Y = (int)cmd1.ExecuteScalar();
            cn.Close();
            ///////@@@@@RRRR
            cmd1 = new SqlCommand("Select_CountSeats_ArrestedEC_R", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param11 = new SqlParameter[2];
            param11[0] = new SqlParameter("@param0", SqlDbType.Int);
            param11[1] = new SqlParameter("@param1", SqlDbType.Int);
            param11[0].Value = v_Airplane_No;
            param11[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param11);
            cn.Open();
            int NumArrSeat_EC_R = (int)cmd1.ExecuteScalar();
            cn.Close();
            //////
            cmd1 = new SqlCommand("Select_CountSeats_EC_R", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param12 = new SqlParameter("@param0", SqlDbType.Int);
            param12.Value = v_Airplane_No;
            cmd1.Parameters.Add(param12);
            cn.Open();
            int NumSeat_EC_R = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@@FRist
            cmd1 = new SqlCommand("Select_CountSeats_ArrestedFC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param14 = new SqlParameter[2];
            param14[0] = new SqlParameter("@param0", SqlDbType.Int);
            param14[1] = new SqlParameter("@param1", SqlDbType.Int);
            param14[0].Value = v_Airplane_No;
            param14[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param14);
            cn.Open();
            int NumArrSeat_FC = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@@Bissnes
            cmd1 = new SqlCommand("Select_CountSeats_ArrestedBC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param15 = new SqlParameter[2];
            param15[0] = new SqlParameter("@param0", SqlDbType.Int);
            param15[1] = new SqlParameter("@param1", SqlDbType.Int);
            param15[0].Value = v_Airplane_No;
            param15[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param15);
            cn.Open();
            int NumArrSeat_BC = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@@First Seat 
            cmd1 = new SqlCommand("Select_CountSeats_FC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param16 = new SqlParameter("@param0", SqlDbType.Int);
            param16.Value = v_Airplane_No;
            cmd1.Parameters.Add(param16);
            cn.Open();
            int NumSeat_FC = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@BissinessSeat
            cmd1 = new SqlCommand("Select_CountSeats_BC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param17 = new SqlParameter("@param0", SqlDbType.Int);
            param17.Value = v_Airplane_No;
            cmd1.Parameters.Add(param17);
            cn.Open();
            int NumSeat_BC = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////SeatOfAllEconomyArressted
            cmd1 = new SqlCommand("CountSeats_Arrested_AllEC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param18 = new SqlParameter[2];
            param18[0] = new SqlParameter("@param0", SqlDbType.Int);
            param18[1] = new SqlParameter("@param1", SqlDbType.Int);
            param18[0].Value = v_Airplane_No;
            param18[1].Value = v_Trip_No;
            cmd1.Parameters.AddRange(param18);
            cn.Open();
            int NumArrSeatAll_EC = (int)cmd1.ExecuteScalar();
            cn.Close();
            //@@@@Economy
            cmd1 = new SqlCommand("Select_CountSeats_EC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param19 = new SqlParameter("@param0", SqlDbType.Int);
            param19.Value = v_Airplane_No;
            cmd1.Parameters.Add(param19);
            cn.Open();
            int NumSeat_EC = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@@Weight_FC
            cmd1 = new SqlCommand("SelectWeight_FC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param20 = new SqlParameter("@param0", SqlDbType.NVarChar, 50);
            param20.Value = Comp_Name;
            cmd1.Parameters.Add(param20);
            cn.Open();
            int Weight_FC = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@@Weight_BC
            cmd1 = new SqlCommand("SelectWeight_BC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param21 = new SqlParameter("@param0", SqlDbType.NVarChar, 50);
            param21.Value = Comp_Name;
            cmd1.Parameters.Add(param21);
            cn.Open();
            int Weight_BC = (int)cmd1.ExecuteScalar();
            cn.Close();
            ////@@@@@Weight_EC
            cmd1 = new SqlCommand("SelectWeight_EC", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param22 = new SqlParameter("@param0", SqlDbType.NVarChar, 50);
            param22.Value = Comp_Name;
            cmd1.Parameters.Add(param22);
            cn.Open();
            int Weight_EC = (int)cmd1.ExecuteScalar();
            cn.Close();


            if (NumArrSeat_EC_B < NumSeat_EC_B)
            {

                cmd1 = new SqlCommand("Pricess_EB_B", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param13 = new SqlParameter[2];
                param13[0] = new SqlParameter("@param0", SqlDbType.Int);
                param13[1] = new SqlParameter("@param1", SqlDbType.Int);
                param13[0].Value = v_Airplane_No;
                param13[1].Value = v_Trip_No;
                cmd1.Parameters.AddRange(param13);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt7);
                textBox_Cost_EC.DataBindings.Add("Text", dt7, "Price");
                // MessageBox.Show("jhh" + NumArrSeat_EC_B);

            }
            else if (NumArrSeat_EC_V < NumSeat_EC_V)
            {
                cmd1 = new SqlCommand("Pricess_EB_V", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param13 = new SqlParameter[2];
                param13[0] = new SqlParameter("@param0", SqlDbType.Int);
                param13[1] = new SqlParameter("@param1", SqlDbType.Int);
                param13[0].Value = v_Airplane_No;
                param13[1].Value = v_Trip_No;
                cmd1.Parameters.AddRange(param13);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt7);
                textBox_Cost_EC.DataBindings.Add("Text", dt7, "Price");

            }

            else if (NumArrSeat_EC_T < NumSeat_EC_T)
            {
                cmd1 = new SqlCommand("Pricess_EB_T", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param13 = new SqlParameter[2];
                param13[0] = new SqlParameter("@param0", SqlDbType.Int);
                param13[1] = new SqlParameter("@param1", SqlDbType.Int);
                param13[0].Value = v_Airplane_No;
                param13[1].Value = v_Trip_No;
                cmd1.Parameters.AddRange(param13);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt7);
                textBox_Cost_EC.DataBindings.Add("Text", dt7, "Price");

            }
            else if (NumArrSeat_EC_Y < NumSeat_EC_Y)
            {
                cmd1 = new SqlCommand("Pricess_EB_Y", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param13 = new SqlParameter[2];
                param13[0] = new SqlParameter("@param0", SqlDbType.Int);
                param13[1] = new SqlParameter("@param1", SqlDbType.Int);
                param13[0].Value = v_Airplane_No;
                param13[1].Value = v_Trip_No;
                cmd1.Parameters.AddRange(param13);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt7);
                textBox_Cost_EC.DataBindings.Add("Text", dt7, "Price");

            }

            else if (NumArrSeat_EC_R < NumSeat_EC_R)
            {
                cmd1 = new SqlCommand("Pricess_EB_R", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param13 = new SqlParameter[2];
                param13[0] = new SqlParameter("@param0", SqlDbType.Int);
                param13[1] = new SqlParameter("@param1", SqlDbType.Int);
                param13[0].Value = v_Airplane_No;
                param13[1].Value = v_Trip_No;
                cmd1.Parameters.AddRange(param13);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt7);
                textBox_Cost_EC.DataBindings.Add("Text", dt7, "Price");
            }

            cmd1 = new SqlCommand("SelectService", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter param23 = new SqlParameter("@param0", SqlDbType.NVarChar, 50);
            param23.Value = Comp_Name;
            cmd1.Parameters.Add(param23);
            da = new SqlDataAdapter(cmd1);
            da.Fill(dt4);
            dataGridView_Srvice.DataSource = dt4;


            int RemainSeat_FC = NumSeat_FC - NumArrSeat_FC;
            int RemainSeat_BC = NumSeat_BC - NumArrSeat_BC;
            int RemainSeat_EC = NumSeat_EC - NumArrSeatAll_EC;
            textBox_RemainSeats_FC.Text = RemainSeat_FC.ToString();
            textBox_RemainSeats_BC.Text = RemainSeat_BC.ToString();
            textBox_RemainSeats_EC.Text = RemainSeat_EC.ToString();
            textBox_Weight_FC.Text = Weight_FC.ToString();
            textBox_Weight_BC.Text = Weight_BC.ToString();
            textBox_Weight_EC.Text = Weight_EC.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
 
    }
}
   