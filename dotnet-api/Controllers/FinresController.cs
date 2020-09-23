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
    
    public class FinresController : Controller 
    {
        public FinresController(IConfiguration configuration)
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
        public JsonResult GetRegions() {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    List<FinresRegions> regions = new List<FinresRegions>();

                    con.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = 
                        "select distinct " +
                        "f.regionid " +
                        ",f.regionid || '-' || initcap(replace(d.subname, 'Г.', '')) regionName " +
                        "from newuis.fr_states f " +
                        ",newuis.dct_subjects d " +
                        "where 1=1 " +
                        "and f.regionid = d.id " +
                        "order by " +
                        "f.regionid";

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {                        
                        while (reader.Read())
                        {
                            var region = new FinresRegions()
                            {
                                RegionId = reader.GetInt32("REGIONID"),
                                RegionName = reader.GetString("REGIONNAME"),
                            };

                            regions.Add(region);
                        }
                        reader.Dispose();
                    }
                    return Json(regions);
                }
            }
        }

        [HttpGet]
        public JsonResult GetCompanies() {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    List<FinresCompanies> companies = new List<FinresCompanies>();

                    con.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = 
                        "select id companyid " +
                        ",id || '-' || shortname companyName " +
                        "from newuis.dct_companies " +
                        "order by id";

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {                        
                        while (reader.Read())
                        {
                            var company = new FinresCompanies()
                            {
                                CompanyId = reader.GetInt32("COMPANYID"),
                                CompanyName = reader.GetString("COMPANYNAME"),
                            };

                            companies.Add(company);
                        }
                        reader.Dispose();
                    }
                    return Json(companies);
                }
            }
        }

        [HttpGet]
        public JsonResult GetPeriods() {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    List<FinresPeriods> periods = new List<FinresPeriods>();

                    con.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = 
                        "select distinct " +
                        "otper period " +
                        "from newuis.fr_periods " +
                        "where 1=1 " +
                        "and otper <= trunc(sysdate) " +
                        "order by otper desc";

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {                        
                        while (reader.Read())
                        {
                            var period = new FinresPeriods()
                            {
                                Period = reader.GetDateTime("PERIOD"),
                            };

                            periods.Add(period);
                        }
                        reader.Dispose();
                    }
                    return Json(periods);
                }
            }
        }    

        [HttpGet]
        public JsonResult GetHeader(int reg) {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    List<FinresHeader> headers = new List<FinresHeader>();

                    con.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = 
                        "select name, code " +
                        "from newuis.fr_states " +
                        "where 1=1 " +
                            "and active = -1 " +
                            "and typeid = 1 " +
                            $"and regionid = {reg}" +
                        " order by displayorder";

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {                        
                        while (reader.Read())
                        {
                            var header = new FinresHeader()
                            {
                                Text = reader.GetString("NAME"),
                                Value = reader.GetString("CODE"),
                            };

                            headers.Add(header);
                        }
                        reader.Dispose();
                    }
                    return Json(headers);
                }
            }
        }

        [HttpGet]
        public JsonResult GetStates77(int comp, int reg, DateTime per) {
            using (OracleConnection con = GetConnection())
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    List<States77> states = new List<States77>();

                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "newuis.pkg_fr_util.get_fr_layout";
                    cmd.BindByName = true;
                    cmd.Parameters.Add("p_companyid", OracleDbType.Int32).Value = comp;
                    cmd.Parameters.Add("p_regionid", OracleDbType.Int32).Value = reg;
                    cmd.Parameters.Add("p_date", OracleDbType.Date).Value = per;
                    cmd.Parameters.Add("rc", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {                        
                        while (reader.Read())
                        {
                            var state = new States77()
                            {
                                IDMO = reader.GetString("IDMO"),
                                CODE_UR = reader.GetString("CODE_UR"),
                                NAME = reader.GetString("NAME"),
                                DEBT_BEG = reader.IsDBNull("DEBT_BEG") ? (Decimal?) null : reader.GetDecimal("DEBT_BEG"),
                                PREPAID_EXPENSE = reader.IsDBNull("PREPAID_EXPENSE") ? (Decimal?) null : reader.GetDecimal("PREPAID_EXPENSE"),
                                AVANS_POD = reader.IsDBNull("AVANS_POD") ? (Decimal?) null : reader.GetDecimal("AVANS_POD"),
                                MEK = reader.IsDBNull("MEK") ? (Decimal?) null : reader.GetDecimal("MEK"),
                                INTERMEDIATE_CALC = reader.IsDBNull("INTERMEDIATE_CALC") ? (Decimal?) null : reader.GetDecimal("INTERMEDIATE_CALC"),
                                MEE = reader.IsDBNull("MEE") ? (Decimal?) null : reader.GetDecimal("MEE"),
                                EKMP = reader.IsDBNull("EKMP") ? (Decimal?) null : reader.GetDecimal("EKMP"),
                                MEK_VOL = reader.IsDBNull("MEK_VOL") ? (Decimal?) null : reader.GetDecimal("MEK_VOL"),
                                SUM_SCHET = reader.IsDBNull("SUM_SCHET") ? (Decimal?) null : reader.GetDecimal("SUM_SCHET"),
                                OTHER_SANK = reader.IsDBNull("OTHER_SANK") ? (Decimal?) null : reader.GetDecimal("OTHER_SANK"),
                                SVD = reader.IsDBNull("SVD") ? (Decimal?) null : reader.GetDecimal("SVD"),
                                TOTAL_SUM = reader.IsDBNull("TOTAL_SUM") ? (Decimal?) null : reader.GetDecimal("TOTAL_SUM"),
                                CAN_PAY = reader.IsDBNull("CAN_PAY") ? (Decimal?) null : reader.GetDecimal("CAN_PAY"),
                                NSZ = reader.IsDBNull("NSZ") ? (Decimal?) null : reader.GetDecimal("NSZ"),
                                NSZ_PREV = reader.IsDBNull("NSZ_PREV") ? (Decimal?) null : reader.GetDecimal("NSZ_PREV"),
                                DEBT_END = reader.IsDBNull("DEBT_END") ? (Decimal?) null : reader.GetDecimal("DEBT_END")
                            };

                            states.Add(state);
                        }
                        reader.Dispose();
                    }
                    return Json(states);
                }
            }
        }
    }
}