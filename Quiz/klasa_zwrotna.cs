using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class klasa_zwrotna
    {
        private string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["kbc"].ConnectionString;
        /// <summary>
        /// Pobieranie z bazy pytan i odpowiedzi i wstawienie spacji aby odzielić słowa 
        /// </summary>
        public string scalarReturn(string q)
        {
            string s = " ";
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(q, conn);
                s = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                s = " ";
            }
            return s;
        }
    }
}