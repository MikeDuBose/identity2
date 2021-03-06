﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample1.Models
{
    public class DAL
    {
        private SqlConnection conn;
        

        public DAL(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        public int AddTask(UserTask u)
        {
            string addQuery = "INSERT INTO IdentityTasks (UserId, TaskDescription, DueDate, TaskStatus) ";
            addQuery += "VALUES(@UserId, @TaskDescription, @DueDate, @TaskStatus)";

            return conn.Execute(addQuery, u);
        }

        public IEnumerable<UserTask> GetAllTasksById(string userid)
        {
            
            string queryString = "SELECT * FROM IdentityTasks WHERE userid = @userid";
            return conn.Query<UserTask>(queryString, new { userid = userid });
        }

        public void CompleteTask(int id)
        {

            string queryString = "Update IdentityTasks SET TaskStatus = '1' WHERE id = @id";
            conn.QueryFirstOrDefault<UserTask>(queryString, new { id = id });
        }
    }
}
