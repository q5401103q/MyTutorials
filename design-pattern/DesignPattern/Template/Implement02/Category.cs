using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DesignPattern.Template.Implement02
{
    public class Category : DataAccessObject
    {
        public override void Select()
        {
            string sql = "SELECT * FROM CATEGORY";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Category");

        }

        public override void Display()
        {
            Console.WriteLine(connectionString);
            DataTable dataTable = dataSet.Tables["Category"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["CategoryName"].ToString());
            }
            Console.WriteLine();
        }
    }
}
