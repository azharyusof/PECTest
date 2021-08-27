using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;

/// <summary>
/// Summary description for ErrorLog
/// </summary>
public class ErrorLog
{
    public static void WriteToEventLog(Exception ex, string absolutepath, string user)
    {
        try
        {
            string strCon2 = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(strCon2))
            {
                string ErrorMessgage = ex.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                string pagename = absolutepath;
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                con.Open();
                SqlCommand cmd = new SqlCommand("spErrorLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pagename", pagename);
                cmd.Parameters.AddWithValue("@method", method);
                cmd.Parameters.AddWithValue("@line_number", lineNumber);
                cmd.Parameters.AddWithValue("@error_msg", ErrorMessgage);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch(Exception ex2)
        {
            ErrorLog.WriteToEventLog(ex2, absolutepath, "");
        }
    }
}