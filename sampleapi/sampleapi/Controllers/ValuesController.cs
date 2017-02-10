using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using sampleapi.Models;
using System.Data.SqlClient;
using System.Data;


namespace sampleapi.Controllers
{
    //[RoutePrefix("Values")]
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection();

        // GET api/values
        //[Route("Values/Get")]
        [HttpGet]
        public Student Get(int id)
        {
            SqlDataReader reader = null;
         
            con.ConnectionString = "Data Source=10.0.5.77;Initial Catalog=MyTestDatabase;User ID=IDDev;Password=IDDev;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from TestStudent where studentid=" + id + "";
            cmd.Connection = con;
            con.Open();
            reader = cmd.ExecuteReader();
            Student stu = null;
            while (reader.Read())
            {
                stu = new Student();
                stu.StudentId = Convert.ToInt16(reader.GetValue(0));
                stu.StudentName = reader.GetValue(1).ToString();
                stu.FatherName = reader.GetValue(2).ToString();
                stu.DOB = reader.GetValue(3).ToString();
                stu.ContactNumber = reader.GetValue(4).ToString();

            }
            con.Close();
          
            return stu;



        }

        [HttpPost]

        public void AddStudent( Student stu)
        {
            con.ConnectionString = "Data Source=10.0.5.77;Initial Catalog=MyTestDatabase;User ID=IDDev;Password=IDDev;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO TestStudent (StudentName,FatherName,DOB,ContactNumber) values (@StudentName,@Fathername,@DOB,@ContactNumber)";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@StudentName", stu.StudentName);
            cmd.Parameters.AddWithValue("@Fathername", stu.FatherName);
            cmd.Parameters.AddWithValue("@DOB", stu.DOB);
            cmd.Parameters.AddWithValue("@ContactNumber", stu.ContactNumber);
            con.Open();
            int rowInserted = cmd.ExecuteNonQuery();
            con.Close();

        }

       [HttpDelete]
        public void DeleteStudent(int id)
        {
            con.ConnectionString = "Data Source=10.0.5.77;Initial Catalog=MyTestDatabase;User ID=IDDev;Password=IDDev;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="Delete from TestStudent where Studentid="+id+"";
            cmd.Connection=con;
            con.Open();
            int rowDeleted=cmd.ExecuteNonQuery();
            con.Close();
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
