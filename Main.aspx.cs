using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("Hello");

        //ContentSQL();

        //string vTest = Request.QueryString["ID"];

    }



    private void ContentSQL()
    {
        SqlConnection vCon = new SqlConnection("server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database=Test");

        vCon.Open();

        SqlCommand cmd = new SqlCommand("Select * from Student", vCon);
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            Response.Write("");
            Response.Write("學生姓名:" + dr["Name"].ToString() + "<br />");
            Response.Write("數學成績:" + dr["Math"].ToString() + "<br />");
            Response.Write("<br/>");
        }

        Response.Write(dr.FieldCount);
        //要釋放資源 重要!!
        cmd.Cancel();
        dr.Close();

        vCon.Close();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string vShopName = ShopList.SelectedValue;

        //string commandText = "Select * from " + vShopName;

        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandText, "server=DESKTOP-NIOHD0A\\SQLEXPRESS;uid=ricky;pwd=5438;database=Test");

        //DataSet vData = new DataSet();

        //sqlDataAdapter.Fill(vData);
        ////要先把datasourceID清空
        //Menu.DataSourceID = null;

        //Menu.DataSource = vData.Tables[0];

        //Menu.DataBind();
    }

    protected void Menu_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}