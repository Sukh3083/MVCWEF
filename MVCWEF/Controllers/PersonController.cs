using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MVCWEF.Models;

namespace MVCWEF.Controllers
{
    public class PersonController : Controller
    {
        string connectionString = "server=localhost;user=root;password=root;database=crypto_db";
        // GET: PersonController
        [HttpGet]
        public ActionResult Index()
        {
            DataTable person = new DataTable();
            using(MySqlConnection connection = new MySqlConnection(connectionString)) {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("SELECT * FROM person", connection);
                mySqlDataAdapter.Fill(person);
            }
                return View(person);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel personModel)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "INSERT INTO Person (LastName, FirstName,Age,Salary,dob)" +
                    " VALUES(@LastName,@FirstName,@Age,@Salary,@DOB)";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlQuery, connection);
                mySqlCommand.Parameters.AddWithValue("@LastName", personModel.LastName);
                mySqlCommand.Parameters.AddWithValue("@FirstName", personModel.FirstName);
                mySqlCommand.Parameters.AddWithValue("@Age", personModel.Age);
                mySqlCommand.Parameters.AddWithValue("@Salary", personModel.Salary);
                mySqlCommand.Parameters.AddWithValue("@DOB", personModel.DOB);
                mySqlCommand.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            PersonModel personModel = new PersonModel();
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from person where ID=@PersonId";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, connection);
                mySqlDataAdapter.SelectCommand.Parameters.AddWithValue("@PersonId", id);
                mySqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)
            {
                personModel.Id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                personModel.LastName = dataTable.Rows[0][1].ToString();
                personModel.FirstName = dataTable.Rows[0][2].ToString();
                personModel.Age = Convert.ToInt32(dataTable.Rows[0][3].ToString());
                personModel.Salary = Convert.ToInt32(dataTable.Rows[0][4].ToString());
                personModel.DOB = Convert.ToDateTime(dataTable.Rows[0][5].ToString());
                return View(personModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonModel personModel)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "Update Person set LastName=@LastName, FirstName=@FirstName,Age=@Age,Salary=@Salary,dob=@dob" +
                    " where ID=@PersonId";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlQuery, connection);
                mySqlCommand.Parameters.AddWithValue("@LastName", personModel.LastName);
                mySqlCommand.Parameters.AddWithValue("@FirstName", personModel.FirstName);
                mySqlCommand.Parameters.AddWithValue("@Age", personModel.Age);
                mySqlCommand.Parameters.AddWithValue("@Salary", personModel.Salary);
                mySqlCommand.Parameters.AddWithValue("@DOB", personModel.DOB);
                mySqlCommand.Parameters.AddWithValue("@PersonId", personModel.Id);
                mySqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "Delete from person where ID=@PersonId";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlQuery, connection);
                mySqlCommand.Parameters.AddWithValue("@PersonId",id);
                mySqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

       
    }
}
