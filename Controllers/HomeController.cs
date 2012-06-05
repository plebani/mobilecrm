﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mobileCRM.Controllers
{
    public class HomeController : Controller
    {
        private static string userName = "jtpohlwqgqnikwgt";
        private static string password = "UYr4CWLB4qUcGjWCkhdnwKvUBDGD5ADteEZydENFhiMbNYeeYdjpYdyjBEz7phEA";
        private static string dataSource = "dbd8982ffc646f4d9db795a06701352c7";
        private static string sampleDatabaseName = "Server=d8982ffc-646f-4d9d-b795-a06701352c73.sqlserver.sequelizer.com;Database=dbd8982ffc646f4d9db795a06701352c73;User ID=jtpohlwqgqnikwgt;Password=UYr4CWLB4qUcGjWCkhdnwKvUBDGD5ADteEZydENFhiMbNYeeYdjpYdyjBEz7phEA;";


        public ActionResult Index()
        {
            connectar();
            return View();
        }

        public bool connectar()
        {
            var uriString = ConfigurationManager.AppSettings["MOBILECRM"];
            var uri = new Uri(uriString);
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = uri.Host,
                InitialCatalog = uri.AbsolutePath.Trim('/'),
                UserID = uri.UserInfo.Split(':').First(),
                Password = uri.UserInfo.Split(':').Last(),
            }.ConnectionString;

            // Create a connection string for the sample database
            SqlConnectionStringBuilder connString2Builder;
            connString2Builder = new SqlConnectionStringBuilder();
            connString2Builder.DataSource = dataSource;
            connString2Builder.ConnectionString = connectionString;
            connString2Builder.Encrypt = true;
            connString2Builder.TrustServerCertificate = false;
            connString2Builder.UserID = userName;
            connString2Builder.Password = password;

            
            // Connect to the master database and create the sample database
            using (SqlConnection conn = new SqlConnection(connString2Builder.ToString()))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    conn.Open();

                    throw new Exception("Conectado...");
                    // Create the sample database
                    //string cmdText = String.Format("CREATE DATABASE {0}", sampleDatabaseName);
                    //command.CommandText = cmdText;
                    //command.ExecuteNonQuery();
                    //conn.Close();
                }
            }

            return true;
        }

    }
}
