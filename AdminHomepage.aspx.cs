using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;



namespace MangAtongsPrototype.ASPX
{
    public partial class AdminHompage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT (CustomerID) FROM customer_tbl), (SELECT COUNT (OrderID) FROM testOrders2_tbl WHERE OrderStatus='Pending'), (SELECT COUNT(OrderID) FROM testOrders2_tbl), (SELECT SUM(OrderTotalprice) FROM testOrders2_tbl WHERE OrderStatus = 'Completed'); ", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UserCount.Text = dr.GetValue(0).ToString();
                        OrderCount.Text = dr.GetValue(2).ToString();
                        POrderCount.Text = dr.GetValue(1).ToString();
                        SalesCount.Text = "P" + dr.GetValue(3).ToString();
                    }

                    GenerateChart();
                    GenerateChart2();
                    con.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void GenerateChart()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("SELECT OrderProductID AS ProductID, COUNT(*) AS Orders FROM testOrderedItems_tbl GROUP BY OrderProductID;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            ProdSalesChartInfo.Series[0].Points.DataBindXY(x, y);
            ProdSalesChartInfo.Series[0].ChartType = SeriesChartType.Bar;
            ProdSalesChartInfo.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            ProdSalesChartInfo.Legends[0].Enabled = true;
        }

        private void GenerateChart2()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("SELECT * FROM testOrders2_tbl WHERE OrderStatus='Completed' ORDER BY OrderID ;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][1].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][2]);
            }

            Sales.Series[0].Points.DataBindXY(x, y);
            Sales.Series[0].ChartType = SeriesChartType.Line;
            Sales.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            Sales.Legends[0].Enabled = true;
        }
    }
}