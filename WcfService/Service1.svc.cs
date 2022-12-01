using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Insert(InsertUser user)
        {
            string msg;
            SqlConnection con = new SqlConnection("Data Source=IN-LP-TR-07\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
                SqlCommand cmd = new SqlCommand("Insert into UserTbl (Name,Roll) values (@Name,@Roll)", con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Roll", user.Roll);

            int res = cmd.ExecuteNonQuery();
            if(res == 1)
            {
                msg = "Insert Success";
            }
            else
            {
                msg = "Insert failed";
            }
            return msg;
        }

      
    }
}
