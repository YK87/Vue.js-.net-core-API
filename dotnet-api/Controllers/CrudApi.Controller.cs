using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace dotnet_api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    
    public class CrudApiController : Controller 
    {
        public CrudApiController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = GetConnection();
        }

        private readonly IConfiguration _configuration;
        private readonly OracleConnection _connection;
        OracleConnection GetConnection()
        {
            var connectionString = _configuration.GetSection("ConnectionString").GetSection("RESOMED").Value;

            return new OracleConnection(connectionString);
        }

        [HttpGet]
        public JsonResult GetTaskLists() {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    List<TaskLists> tasklists = new List<TaskLists>();

                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "kan.pkg_crud.get_tasklists";
                    cmd.Parameters.Add("rc", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {                        
                        while (reader.Read())
                        {
                            var tasklist = new TaskLists()
                            {
                                Id = reader.GetInt32("ID"),
                                Text = reader.GetString("TEXT"),
                                IsImportant = reader.GetInt32("IS_IMPORTANT"),
                                DateStarted = reader.GetDateTime("D_BEG"),
                                DateFinished = reader.IsDBNull("D_END") ? (DateTime?) null : reader.GetDateTime("D_END"),                               
                                IsCompleted = reader.GetInt32("COMPLETED"),
                            };

                            tasklists.Add(tasklist);
                        }
                        reader.Dispose();
                    }
                    return Json(tasklists);
                }
            }
        }

        [HttpGet]
        public JsonResult GetTaskList(Int32 Id) {
            return Json("Get one");
        }

        [HttpPost]
        public void CreateTask(string Text) {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "kan.pkg_crud.create_tasklist";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_text", OracleDbType.Varchar2).Value = Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPut]
        public JsonResult UpdateTask(Int32 Id) {
            return Json("Updated");
        }

        [HttpDelete]
        public void DeleteTask(Int32 Id) {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "kan.pkg_crud.delete_tasklist";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }     
}