using System.Data;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace dotnet_api.Controllers
{
    [Route("[controller]")]
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
        
        public string DataTableToJSON(DataTable table)   
        {  
            var JSONString = new StringBuilder();  
            if (table.Rows.Count > 0)   
            {  
                JSONString.Append("[");  
                for (int i = 0; i < table.Rows.Count; i++)   
                {  
                    JSONString.Append("{");  
                    for (int j = 0; j < table.Columns.Count; j++)   
                    {  
                        if (j < table.Columns.Count - 1)   
                        {  
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");  
                        }   
                        else if (j == table.Columns.Count - 1)   
                        {  
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");  
                        }  
                    }  
                    if (i == table.Rows.Count - 1)   
                    {  
                        JSONString.Append("}");  
                    }   
                    else   
                    {  
                        JSONString.Append("},");  
                    }  
                }  
                JSONString.Append("]");  
            }  
            return JSONString.ToString();  
        }

        [HttpGet]
         public string TestRow(string Reg, string Per)
        {
            string queryString =
                "select id, code_mo, summav, sank_mek "
                + "from newuis.r_med_schet "
                + "where 1=1 "
                + $"and regionid = {Reg} "
                + "and year = 2020 "
                + $"and month = {Per.Substring(4, 1)} "
                + "and active = -1 "
                + "and companyid = 1 ";
            OracleConnection con = GetConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = queryString;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return DataTableToJSON(dt);
        }
    }     
}