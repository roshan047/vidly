using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VR.Models
{
    public class DbRental
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon1"].ConnectionString);
        
        public void AddRental(Rental r)
        {
            SqlCommand cmd = new SqlCommand("AddRental", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cid", r.Cid);
            cmd.Parameters.AddWithValue("@Mname", "none");
            cmd.Parameters.AddWithValue("@RentalDate", r.DateRented);
            cmd.Parameters.AddWithValue("@Mid", r.Mid);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("Stock", con);
            cmd1.CommandType= CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Mid", r.Mid);

            
            cmd1.ExecuteNonQuery();
        }

        public List<Rental> RentalList()
        {
            SqlCommand cmd = new SqlCommand("ShowRental", con);
            cmd.CommandType = CommandType.StoredProcedure;                       
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Rental> list = new List<Rental>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Rental
                {
                    Id = Convert.ToInt32(dr[0]),
                    Cid = Convert.ToInt32(dr[1]),
                    DateRented = Convert.ToDateTime(dr[2]),
                    //Mname = Convert.ToString(dr[3]),
                    Mid = Convert.ToInt32(dr[4]),
                }
                );
               
            }
            return list;
        }

        public List<Customer> RentalNames(int id) 
        {
            SqlCommand cmd = new SqlCommand("MovieRentail1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mid", id);
            SqlDataAdapter adp= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<Customer> list = new List<Customer>();
            foreach(DataRow dr in dt.Rows) 
            {
                list.Add(new Customer
                {
                    Cid= Convert.ToInt32(dr[0]),
                    name= Convert.ToString(dr[1]),
                    //IsSubcribedToNewsletter = Convert.ToInt32(dr[2]),
                    //MembershipType = Convert.ToString(dr[3]),
                    //Mid = Convert.ToInt32(dr[4]),
                    //DateOfBirth = Convert.ToDateTime(dr[5]),

                });
            }
            return list;

        }

        public List<Movie> RendedMovie(int id) 
        {
            SqlCommand cmd = new SqlCommand("RendedMovie", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cid", id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<Movie> list = new List<Movie>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Movie
                {
                    name = Convert.ToString(dr[0]),
                });
            }
            return list;
        }
    }
}