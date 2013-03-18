using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //add method
    protected void submitbtn_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null)
        {
            HttpPostedFile File = FileUpload1.PostedFile;
            byte[] Data = new Byte[File.ContentLength];
            //TODO
            File.InputStream.Read(Data, 0, File.ContentLength);
            
            string connectionString = ConfigurationManager.ConnectionStrings["tempdbConnectionString1"].ToString();

            string sqlquery = "INSERT INTO photoupload(pid,description,content) values (@a,@b,@c)";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlquery, conn);
            command.Parameters.Add("@a", SqlDbType.Int).Value = idtextbox.Text.ToString();
            command.Parameters.Add("@b", SqlDbType.NVarChar, 50).Value = desctextbox.Text.ToString();
            command.Parameters.Add("@c", SqlDbType.Image, Data.Length).Value = Data;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }

    //public static byte[] GetPhoto(string filePath)
    //{
    //    FileStream stream = new FileStream(
    //        filePath, FileMode.Open, FileAccess.Read);
    //    BinaryReader reader = new BinaryReader(stream);

    //    byte[] photo = reader.ReadBytes((int)stream.Length);

    //    reader.Close();
    //    stream.Close();

    //    return photo;
    //}

    //show picture
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string connectionString = ConfigurationManager.ConnectionStrings["tempdbConnectionString1"].ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        
        try
        {
            connection.Open();
            string sqlStatement = "SELECT * FROM photoupload where pid=@id";
            SqlCommand cmd = new SqlCommand(sqlStatement, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(TextBox1.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            //Get Image Information
            TextBox2.Text = reader["Description"].ToString();
            reader.Close();

            Image1.ImageUrl = "Handler.ashx?id=" + TextBox1.Text.ToString();
            
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            connection.Close();
        }
    }
}