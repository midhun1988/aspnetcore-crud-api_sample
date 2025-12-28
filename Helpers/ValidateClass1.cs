using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRUDAPI.Helpers
{ 
    public class ValidateClass1
    {
        SqlConnection cn = new SqlConnection("Data Source=****;Password=****;User ID=**;Database=***");
        public string GetUname()
        {
            string uname = string.Empty;
            string sSql = "SELECT top 1 api_userkey ,api_passkey FROM [dbo].[tblUTASAPIKey]";
            SqlDataAdapter sd = new SqlDataAdapter(sSql, cn);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            uname = Convert.ToString(dt.Rows[0]["api_userkey"]);
            return uname;
        }

        public string GetPass()
        {
            string uname = string.Empty;
            string sSql = "SELECT top 1 api_userkey ,api_passkey FROM [dbo].[tblUTASAPIKey]";
            SqlDataAdapter sd = new SqlDataAdapter(sSql, cn);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            uname = Convert.ToString(dt.Rows[0]["api_passkey"]);
            return uname;
        }

        public bool chkusercnt(string uname1,string pass1)
        {
            bool val;
            string sSql = "SELECT count(*) as pass_cnt FROM [dbo].[tblUTASAPIKey] where api_userkey = '" + Convert.ToString(uname1) + "' and api_passkey = '" + Convert.ToString(pass1) + "' and flag = 1";
            SqlDataAdapter sd = new SqlDataAdapter(sSql, cn);
            DataTable dt = new DataTable();
            sd.Fill(dt);
           
            if(Convert.ToInt32(dt.Rows[0]["pass_cnt"]) > 0)
            {
                val = true;
            }
            else
            {
                val = false;
            }
            return val;
        }

    }
}
