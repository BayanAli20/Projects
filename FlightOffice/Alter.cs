using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Flight_Offic_Final
{
    class Alter
    {
        public SqlCommand cmd, cmd1;
        String temp;
        public String[] txt = new String[4];
        public int[] det = new int[4];
        public string[] Prc = new string[7];
        public DateTime d1;
        public DateTime d2;
        public int Trip_No, Airplane_NO;
        public void ClearTxtDet()
        {
            for (int i = 0; i < 4; i++)
            {
                txt[i] = "";
                det[i] = 0;
            }
        }
        public void InsertTrip()
        {
            cmd = new SqlCommand("AddTrip", LogOn.conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[6];
            for (int i = 0; i < 4; i++)
            {
                temp = "@param" + i;
                param[i] = new SqlParameter(temp, System.Data.SqlDbType.NVarChar, 50);
                param[i].Value = txt[i];
            }
            param[4] = new SqlParameter("@param4", System.Data.SqlDbType.DateTime);
            param[4].Value = d1.Date;

            param[5] = new SqlParameter("@param5", System.Data.SqlDbType.DateTime);
            param[5].Value = d2.Date;

            cmd.Parameters.AddRange(param);
            LogOn.conn.Open();
            cmd.ExecuteNonQuery();
            LogOn.conn.Close();
        }
        public void InsertDetails()
        {
            cmd = new SqlCommand("InsertDetails", LogOn.conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[4];
            for (int i = 0; i < 4; i++)
            {
                temp = "@param" + i;
                param[i] = new SqlParameter(temp, System.Data.SqlDbType.Int);
                param[i].Value = det[i];
            }
            cmd.Parameters.AddRange(param);
            LogOn.conn.Open();
            cmd.ExecuteNonQuery();
            LogOn.conn.Close();
        }
        public void updateTrip()
        {
            cmd1 = new SqlCommand("updateTrip", LogOn.conn);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter[] param1 = new SqlParameter[7];
            param1[0] = new SqlParameter("@param0", System.Data.SqlDbType.NVarChar, 50);
            param1[0].Value = txt[0];
            param1[1] = new SqlParameter("@param1", System.Data.SqlDbType.NVarChar, 50);
            param1[1].Value = txt[1];
            param1[2] = new SqlParameter("@param2", System.Data.SqlDbType.NVarChar, 50);
            param1[2].Value = txt[2];
            param1[3] = new SqlParameter("@param3", System.Data.SqlDbType.NVarChar, 50);
            param1[3].Value = txt[3];
            param1[4] = new SqlParameter("@param4", System.Data.SqlDbType.DateTime);
            param1[4].Value = d1;
            param1[5] = new SqlParameter("@param5", System.Data.SqlDbType.DateTime);
            param1[5].Value = d2;
            param1[6] = new SqlParameter("@param6", System.Data.SqlDbType.Int);
            param1[6].Value = Trip_No;
            cmd1.Parameters.AddRange(param1);
            LogOn.conn.Open();
            cmd1.ExecuteNonQuery();
            LogOn.conn.Close();
        }
        public void updateDetails()
        {

            cmd = new SqlCommand("updateDetails", LogOn.conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter[] param2 = new SqlParameter[5];
            param2[0] = new SqlParameter("@param0", System.Data.SqlDbType.Int);
            param2[0].Value = det[0];
            param2[1] = new SqlParameter("@param1", System.Data.SqlDbType.Int);
            param2[1].Value = det[2];
            param2[2] = new SqlParameter("@param2", System.Data.SqlDbType.Int);
            param2[2].Value = Trip_No;
            param2[3] = new SqlParameter("@param3", System.Data.SqlDbType.Int);
            param2[3].Value = det[1];
            param2[4] = new SqlParameter("@param4", System.Data.SqlDbType.Int);
            param2[4].Value = Airplane_NO;
            cmd.Parameters.AddRange(param2);
            LogOn.conn.Open();
            cmd.ExecuteNonQuery();
            LogOn.conn.Close();
        }
        public void Price(string s, int p)
        {
            for (int i = 0; i < 7; i++)
            {
                Prc[i] = "";
            }
            if (s == "FirstClass")
            {
                Prc[0] = p.ToString();
            }
            else if (s == "BusinessClass")
            {
                Prc[1] = p.ToString();
            }
            else if (s == "EconomicClassY")
            {
                Prc[2] = p.ToString();
            }
            else if (s == "EconomicClassR")
            {
                Prc[3] = p.ToString();
            }
            else if (s == "EconomicClassT")
            {
                Prc[4] = p.ToString();
            }
            else if (s == "EconomicClassV")
            {
                Prc[5] = p.ToString();
            }
            else { Prc[6] = p.ToString(); }
        }
    }
}
