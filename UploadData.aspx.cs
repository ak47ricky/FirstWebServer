using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        try
        {
            string vPlayerID = Request.QueryString["PlayerID"].ToString();
            HttpPostedFile myData = null;
            myData = Request.Files["Pic"];
            myData.SaveAs(Server.MapPath("~/Pic/" + vPlayerID.ToString() + "/Pic/" + myData.FileName));
            Response.Write("0");
        }
        catch
        {
            Response.Write("1");
            return;
        }

    }
}