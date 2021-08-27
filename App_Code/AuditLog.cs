using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for AuditLog
/// </summary>
public class AuditLog
{
    public static void WriteAuditLog(string Command, string SPName, string ScreenPath, string OldValue, string NewValue, string PerformBY)
    {
        string absolutepath = HttpContext.Current.Request.Url.AbsolutePath;

        try
        {
            string strCon2 = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;

            using (SqlConnection con2 = new SqlConnection(strCon2))
            {
                SqlCommand cmd2 = new SqlCommand("spAuditLog", con2);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@Command", SqlDbType.VarChar).Value = Command;
                cmd2.Parameters.AddWithValue("@SPName", SqlDbType.VarChar).Value = SPName;
                cmd2.Parameters.AddWithValue("@ScreenPath", SqlDbType.VarChar).Value = ScreenPath;
                cmd2.Parameters.AddWithValue("@OldValue", SqlDbType.VarChar).Value = OldValue;
                cmd2.Parameters.AddWithValue("@NewValue", SqlDbType.VarChar).Value = NewValue;
                cmd2.Parameters.AddWithValue("@PerformBY", SqlDbType.VarChar).Value = PerformBY;

                con2.Open();
                cmd2.ExecuteNonQuery();
                con2.Close();
            }
        }
        catch (Exception ex)
        {
            ErrorLog.WriteToEventLog(ex, absolutepath, "");
        }
    }
}