using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement02
{
    public class Product : DataAccessObject
    {
        public override void Select()
        {
            string sql = "select top 10 * from Product";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Product");
        }

        public override void Display()
        {
            Console.WriteLine(connectionString);
            DataTable dataTable = dataSet.Tables["Product"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["ProductName"].ToString());
            }
            Console.WriteLine();
        }

        public override void Connect()
        {
            connectionString = "Server=Rj-121;User Id=sa;Password=sa;Database=Northwind";
        }
    }
}
