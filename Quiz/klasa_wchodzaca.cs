using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Quiz
{
    class klasa_wchodzaca
    {
        private string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["quizapp"].ConnectionString;

        public string insert_srecord(pytania q)
        {
            string msg = "";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("[insert_questions]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@q_title", SqlDbType.NVarChar).Value = q.q_title;
                cmd.Parameters.Add("@q_opa", SqlDbType.NVarChar, 200).Value = q.q_opa;
                cmd.Parameters.Add("@q_opb", SqlDbType.NVarChar, 200).Value = q.q_opb;
                cmd.Parameters.Add("@q_opc", SqlDbType.NVarChar, 200).Value = q.q_opc;
                cmd.Parameters.Add("@q_opd", SqlDbType.NVarChar, 200).Value = q.q_opd;
                cmd.Parameters.Add("@q_opcorrect", SqlDbType.NVarChar, 200).Value = q.q_opcorrect;
                cmd.Parameters.Add("@q_addeddate", SqlDbType.NVarChar, 20).Value = q.q_addeddate;
                cmd.Parameters.Add("@q_fk_ad", SqlDbType.Int).Value = q.q_fk_ad;
                cmd.Parameters.Add("@q_fk_ex", SqlDbType.Int).Value = q.q_fk_ex;

                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "Baza załadowana!";
            }

            catch (Exception)
            {
                msg = "błąd ładowania bazy!";
            }

            finally
            {
                conn.Close();
            }

            return msg;
        }

    }
}
