using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Configuration.Internal;
using System.Collections;

namespace VR.Models
{
    public class DbCustomers
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon1"].ConnectionString);

        public int DeleteC(int id)
        {

            SqlCommand cmd = new SqlCommand("DeleteCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cid", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        public List<Customer> GetCustomers()
        {
            SqlCommand cmd = new SqlCommand("SelectCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Customer> Clist = new List<Customer>();
            foreach (DataRow dr in dt.Rows)
            {
                Clist.Add(new Customer
                {
                    Cid = Convert.ToInt32(dr[0]),
                    name = Convert.ToString(dr[1]),
                    IsSubcribedToNewsletter = Convert.ToInt32(dr[2]),
                    MembershipType = Convert.ToString(dr[3]),
                    Mid = Convert.ToInt32(dr[4]),
                    DateOfBirth = Convert.ToDateTime(dr[5]),

                });
            }
            return Clist;
        }


        public void AddCustomer(Customer c)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AddCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name", c.name);
            cmd.Parameters.AddWithValue("IsSubcribedToNewsletter", c.IsSubcribedToNewsletter);
            cmd.Parameters.AddWithValue("MembershipType", c.MembershipType);
            cmd.Parameters.AddWithValue("Mid", c.Mid);
            cmd.Parameters.AddWithValue("DateOfBirth", c.DateOfBirth);
            cmd.ExecuteNonQuery();
        }

        public void UpdateCustomer(Customer c)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name", c.name);
            cmd.Parameters.AddWithValue("IsSubcribedToNewsletter", c.IsSubcribedToNewsletter);
            cmd.Parameters.AddWithValue("MembershipType", c.MembershipType);
            cmd.Parameters.AddWithValue("Mid", c.Mid);
            cmd.Parameters.AddWithValue("DateOfBirth", c.DateOfBirth);
            cmd.Parameters.AddWithValue("Cid", c.Cid);
            cmd.ExecuteNonQuery();

        }

        public List<Customer> paging(int no) {
            con.Open();
            SqlCommand cmd = new SqlCommand("pagination2", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pagenumber", no);
            SqlDataAdapter adapter= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Customer> list = new List<Customer>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Customer
                {
                    Cid = Convert.ToInt32(dr[0]),
                    name = Convert.ToString(dr[1]),
                    IsSubcribedToNewsletter = Convert.ToInt32(dr[2]),
                    MembershipType = Convert.ToString(dr[3]),
                    Mid = Convert.ToInt32(dr[4]),
                    DateOfBirth = Convert.ToDateTime(dr[5]),

                });
            }
            return list;

        }

        public List<Customer> pagingRow(int no)
        {   con.Open();
            SqlCommand cmd = new SqlCommand("paging", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@index", no);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Customer> list = new List<Customer>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Customer
                {
                    no = Convert.ToInt32(dr[0]),
                    Cid = Convert.ToInt32(dr[1]),
                    name = Convert.ToString(dr[2]),
                    IsSubcribedToNewsletter = Convert.ToInt32(dr[3]),
                    MembershipType = Convert.ToString(dr[4]),
                    Mid = Convert.ToInt32(dr[5]),
                    DateOfBirth = Convert.ToDateTime(dr[6]),
                });
            }
            return list;
        }
    }
}