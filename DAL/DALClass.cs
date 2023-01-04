using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.DAL
{
    public class DALClass
    {
        private readonly IConfiguration configuration;


        public DALClass(IConfiguration config)
        {
            this.configuration = config;
        }
        
            string BoxNo;
        public string BoxNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(IdNo) FROM box", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    BoxNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return BoxNo;
        }

        string ConNo;
        public string ConNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(ConId) FROM confirmationofappointment", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    ConNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return ConNo;
        }
        string ProNo;
        public string ProNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(CareerId) FROM careerprogression", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    ProNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return ProNo;
        }
        string LeaveNo;
        public string LeaveNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(Id) FROM leaves", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    LeaveNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return LeaveNo;
        }
        string RNo;
        public string RNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(RId) FROM retirementbiodata", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    RNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return RNo;
        }
        string RefNo;
        public string RefNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(RefNo) FROM Refrences", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    RefNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return RefNo;
        }
        string StaffNo;
        public string StaffNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(UserID) FROM AspNetUsers", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    StaffNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return StaffNo;
        }
        string DeptNo;
        public string DeptNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(DeptID) FROM department", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    DeptNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return DeptNo;
        }

        string MinuteNo;
        public string MinuteNoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(Id) FROM minuteregister", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    MinuteNo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return MinuteNo;
        }
        string RINo;
        public string RINoAuto()
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand com = new MySqlCommand("SELECT MAX(Id) FROM reportwriting", con);
                con.Open();
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read() == true)
                {
                    RINo = dr[0].ToString();//CAN USE ONLY 0 INDEX.
                }
                con.Close();
            }
            return RINo;
        }


        public void DeleteScheduled(int Id)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand("Delete scheduled  WHERE  ID = '" + Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateUserStatus(int Id)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand("Update box set UserStatus='" + "Read" + "'  WHERE  Id = '" + Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateStatus(int Id)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand("Update box set Status='" + "Read" + "'  WHERE  Id = '" + Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateStatus1(int Id)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand("Update box set Status1='" + "Read" + "'  WHERE  Id = '" + Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateStatus2(int Id)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand("Update box set Status2='" + "Read" + "'  WHERE  Id = '" + Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateStatus3(int Id)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand("Update box set Status3='" + "Read" + "'  WHERE  Id = '" + Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateStatus4(int Id)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand("Update box set Status4='" + "Read" + "'  WHERE  Id = '" + Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void NewScheduled(string _StaffName, string _Department, string _Unit, string _Schedule, string _UserID, int id, DateTime _Date, string _AllocatedBy, string _ScheduledType, DateTime _Expire, string _Status, string _Role, string _SectionName, string _Controllers, string _Actions, string _Description, string _SectionRole,string _AllocatedUserID)
        {
            string ConStr = configuration.GetConnectionString("NSPRIDATACONNECT");

            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO scheduled VALUES('" + _StaffName + "','" + _Department + "','" + _Unit + "','" + _Schedule + "','" + _UserID + "','" + id + "','" + _Date + "','" + _AllocatedBy + "','" + _ScheduledType + "','" + _Expire + "','" + _Status + "' ,'" + _Role + "','" + _SectionName + "','" + _Controllers + "','" + _Actions + "','" + _Description + "','" + _SectionRole + "','" + _AllocatedUserID + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
