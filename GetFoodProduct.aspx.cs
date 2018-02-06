using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class GetFoodProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<FoodProductData> vListData = new List<FoodProductData>();
        vListData.Clear();


        using (SqlConnection vCon = new SqlConnection("Data Source=184.168.47.10;Integrated Security=False;User ID=MobileDaddy;PASSWORD=Aa54380438!;Connect Timeout=15;Encrypt=False;Packet Size=4096"))
        {
            vCon.Open();

            string vCmdStr = "select * from FoodProduct";

            using (SqlCommand vCmd = new SqlCommand(vCmdStr, vCon))
            {
                try
                {
                    SqlDataReader vRd = vCmd.ExecuteReader();

                    while (vRd.Read())
                    {
                        FoodProductData zData = new FoodProductData();
                        zData.Name = vRd["Name"].ToString();
                        zData.PicName = vRd["PicName"].ToString();
                        zData.Introduction = vRd["Introduction"].ToString();
                        zData.Price = int.Parse(vRd["Price"].ToString());
                        vListData.Add(zData);
                    }

                    FoodProductData[] zResult;

                    zResult = vListData.ToArray();

                    string zJsonData = JsonConvert.SerializeObject(zResult,Formatting.Indented);
                    
                    Response.Write(zJsonData);

                }
                catch
                {
                    //Response.Write("99");
                }
            }
        }
    }

    public class FoodProductData
    {
        public string Name;
        public string PicName;
        public string Introduction;
        public int Price;

        public FoodProductData()
        {
            Name = string.Empty;
            PicName = string.Empty;
            Introduction = string.Empty;
            Price = 0;
        }
    };
}