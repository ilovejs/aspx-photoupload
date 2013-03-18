<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections.Specialized;

public class Handler : IHttpHandler {

    public string GetConnectionString()
    {
        //sets the connection string from your web config file "ConnString" is the name of your Connection String
        return System.Configuration.ConfigurationManager.ConnectionStrings["tempdbConnectionString1"].ConnectionString;
    }
    
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request.QueryString["id"]; //get the querystring value that was pass on the ImageURL (see GridView MarkUp in Page1.aspx)

        if (id != null)
        {        
            MemoryStream memoryStream = new MemoryStream();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            string sql = "SELECT * FROM photoupload WHERE pid = @id";
       
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            //Get Image Data
            byte[] file = (byte[])reader["content"];

            reader.Close();
            connection.Close();
            memoryStream.Write(file, 0, file.Length);
            context.Response.Buffer = true;
            context.Response.BinaryWrite(file);
            memoryStream.Dispose();
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
}