using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;

/// <summary>
/// Summary description for CurrentField
/// </summary>
public class CurrentField
{
    private static readonly string _connectionString;
    private string _colName;
    private string _colValue;

    public string CurrColName
    {
        get { return _colName; }
        set { _colName = value; }
    }

    public string CurrColValue
    {
        get { return _colValue; }
        set { _colValue = value; }
    }

    #region UserRole
    public List<CurrentField> GetCurrentFieldUserRole(string StaffNo)
    {
        string strConn = ConfigurationManager.ConnectionStrings["PECConn"].ConnectionString;

        List<CurrentField> results = new List<CurrentField>();

        DataTable dt = null;

        string absolutepath = HttpContext.Current.Request.Url.AbsolutePath;

        try
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand("spCurrentFieldUserRole", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@StaffNo", SqlDbType.NVarChar).Value = StaffNo;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        CurrentField currFlds = new CurrentField();
                        currFlds.CurrColName = column.ColumnName;
                        currFlds.CurrColValue = row[column].ToString();
                        results.Add(currFlds);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLog.WriteToEventLog(ex, absolutepath, "");
        }
        return results;
    }
    #endregion
}