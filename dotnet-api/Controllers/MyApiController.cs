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
    
    public class MyApiController : Controller 
    {
        public MyApiController(IConfiguration configuration)
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
         public JsonResult GetBills(decimal Reg, DateTime Per)
        {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    List<Bills> bills = new List<Bills>();

                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "expmsk.pkg_reports.get_schets";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_regionid", OracleDbType.Decimal).Value = Reg;
                    cmd.Parameters.Add("p_date", OracleDbType.Date).Value = Per;
                    cmd.Parameters.Add("p_companyid", OracleDbType.Decimal).Value = 1;
                    cmd.Parameters.Add("rc", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {                        
                        while (reader.Read())
                        {
                            var bill = new Bills()
                            {
                                Id = reader.GetInt32("ID"),
                                Year = reader.GetInt32("YEAR"),
                                Month = reader.GetInt32("MONTH"),
                                RegionId = reader.GetInt32("REGIONID"),
                                RegionName = reader.GetString("REGION_NAME"),
                                CompanyId = reader.GetInt32("COMPANYID"),
                                CompanyName = reader.GetString("COMPANY_NAME"),
                                CodeMo = reader.GetString("CODE_MO"),
                                MoName = reader.GetString("LPU_NAME"),
                                AccountSum = reader.GetDecimal("SUMMAV"),
                                AccountDeduction = reader.GetDecimal("SANK_MEK")
                            };

                            bills.Add(bill);
                        }
                        reader.Dispose();
                    }
                    return Json(bills);
                }
            }
        }

        [HttpGet]
        public JsonResult GetTaskLists() {
            return Json("Get All");
        }

        [HttpGet]
        public JsonResult GetTaskList(Int32 Id) {
            return Json("Get one");
        }

        [HttpPost]
        public JsonResult CreateTask(TaskLists task) {
            return Json("Created new task");
        }

        [HttpPut]
        public JsonResult UpdateTask(Int32 Id) {
            return Json("Updated");
        }

        [HttpDelete]
        public JsonResult DeleteTask(Int32 Id) {
            return Json("Deleted");
        }
    }     
}