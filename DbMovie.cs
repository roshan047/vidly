using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace VR.Models
{
    public class DbMovie
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon1"].ConnectionString);

        public List<Movie> GetMovies()
        {
            SqlCommand cmd = new SqlCommand("SelectMovie", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<Movie> Mlist = new List<Movie>();
            foreach (DataRow dr in dt.Rows)
            {
                Mlist.Add(new Movie
                {
                    Mid = Convert.ToInt32(dr[0]),
                    Genre = Convert.ToString(dr[1]),
                    Rel = Convert.ToDateTime(dr[2]),
                    upload = Convert.ToDateTime(dr[3]),
                    instock = Convert.ToInt32(dr[4]),
                    name = Convert.ToString(dr[5]),
                });
            }
            return Mlist;
        }


        public void AddM(Movie m)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AddMovie", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Genre", m.Genre);
            cmd.Parameters.AddWithValue("ReleasedDate", m.Rel);
            cmd.Parameters.AddWithValue("DateAdded", m.upload);
            cmd.Parameters.AddWithValue("InStock", m.instock);
            cmd.Parameters.AddWithValue("Mname", m.name);
            cmd.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DeleteMovie", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mid", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public int UpdateM(Movie m)
        {
            SqlCommand cmd = new SqlCommand("UpdateMovie", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mid", m.Mid);
            cmd.Parameters.AddWithValue("@Genre", m.Genre);
            cmd.Parameters.AddWithValue("@Rel",m.Rel);
            cmd.Parameters.AddWithValue("@Upload", m.upload);
            cmd.Parameters.AddWithValue("@InStock", m.instock);
            cmd.Parameters.AddWithValue("@Mname", m.name);
            con.Open();
            int i= cmd.ExecuteNonQuery();
            return i;
        }
    }
}