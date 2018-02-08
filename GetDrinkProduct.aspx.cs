using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;

public partial class GetDrinkProduct : System.Web.UI.Page
{
    public class rDrinkProduct
    {
        public string Name;
        public string PicName;
        public string Introduction;
        public int Price;

        public rDrinkProduct()
        {
            Name = string.Empty;
            PicName = string.Empty;
            Introduction = string.Empty;
            Price = 0;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        List<rDrinkProduct> mDataList = new List<rDrinkProduct>();
        mDataList.Clear();

        using (SqlConnection vCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileDaddy;PASSWORD=Aa54380438!;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            vCon.Open();

            string vSqlStr = "Select * from DrinkProduct";

            using (SqlCommand vCmd = new SqlCommand(vSqlStr,vCon))
            {
                SqlDataReader vRd = vCmd.ExecuteReader();

                while (vRd.Read())
                {
                    rDrinkProduct vData = new rDrinkProduct();
                    vData.Name = vRd["Name"].ToString();
                    vData.PicName = vRd["PicName"].ToString();
                    vData.Introduction = vRd["Introduction"].ToString();
                    vData.Price = int.Parse(vRd["Price"].ToString());

                    mDataList.Add(vData);
                }

                rDrinkProduct[] vResult;
                vResult = mDataList.ToArray();

                string vJsonData = JsonConvert.SerializeObject(vResult, Formatting.Indented);

                Response.Write(vJsonData);
            }

        }

    }
}