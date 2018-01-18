using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string vPath = "d:\\Pic\\";

        string zPath = Request.PhysicalApplicationPath;

        System.IO.Directory.CreateDirectory(zPath + "1234");

        foreach (string f in Request.Files.AllKeys)
        {
            HttpPostedFile file = Request.Files[f];
           
            file.SaveAs(vPath + "1234\\" + file.FileName);
        }
    }
}