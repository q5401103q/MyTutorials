using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MappingGenerator
{
    public partial class Form1 : Form
    {
        private List<string> list = new List<string>();

        /// <summary>
        /// 连接字符串
        /// </summary>
        private string ConnectionString { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            list.Clear();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    //使用信息架构视图 
                    SqlCommand sqlcmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME", conn);
                    //打开数据库连接
                    conn.Open();
                    //读取数据
                    SqlDataReader dr = sqlcmd.ExecuteReader();
                    //填充列表
                    while (dr.Read())
                    {
                        list.Add(dr.GetString(0));
                    }
                    //关闭连接
                    conn.Close();
                }
                cobTable.DataSource = list;
                btnConnect.Enabled = false;
            }
            catch
            {
                MessageBox.Show("连接数据库失败，请检查连接字符串");
            }
        }

        private void btnGenEntity_Click(object sender, EventArgs e)
        {
            try
            {
                string tablename = cobTable.SelectedValue.ToString();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT a.name , b.name as ctype, a.max_length ");
                sb.AppendLine("FROM  sys.columns a ");
                sb.AppendLine("INNER JOIN sys.types b ON a.system_type_id = b.system_type_id ");
                sb.AppendFormat("WHERE a.object_id = OBJECT_ID('{0}')", tablename);

                StringBuilder result = new StringBuilder();

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    //使用信息架构视图 
                    SqlCommand sqlcmd = new SqlCommand(sb.ToString(), conn);
                    //打开数据库连接
                    conn.Open();
                    //填充器
                    SqlDataAdapter adp = new SqlDataAdapter(sqlcmd);
                    //接收容器
                    DataTable dt = new DataTable();
                    //填充
                    adp.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //result.AppendLine("using System;");
                        //result.AppendLine("using System.Collections.Generic;");
                        //result.AppendLine("using System.Linq;");
                        //result.AppendLine("using System.Text;");
                        //result.AppendLine("using System.Threading.Tasks;");
                        //result.AppendLine();
                        //result.AppendLine("namespace YourFuckingNameSpace");
                        //result.AppendLine("{");
                        result.AppendLine("    public class " + tablename);
                        result.AppendLine("    {");
                        foreach (DataRow row in dt.Rows)
                        {
                            string type = TypeConvertor.ConvertDbTypeToCLRType(row["ctype"].ToString());
                            result.AppendLine("        public "+ type + " " + row["name"].ToString() + " { get; set; }");                            
                        }
                        result.AppendLine("    }");
                        //result.AppendLine("}");

                        Clipboard.SetText(result.ToString());
                        MessageBox.Show("已添加到剪切板，请CTRL+V粘贴即可");
                    }

                    //关闭
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("生成实体失败！" + ex.Message);
            }            
        }

        private void btnGenMapping_Click(object sender, EventArgs e)
        {
            try
            {
                string tablename = cobTable.SelectedValue.ToString();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT a.name , b.name as ctype, a.max_length ");
                sb.AppendLine("FROM  sys.columns a ");
                sb.AppendLine("INNER JOIN sys.types b ON a.system_type_id = b.system_type_id ");
                sb.AppendFormat("WHERE a.object_id = OBJECT_ID('{0}')", tablename);

                StringBuilder result = new StringBuilder();

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    //使用信息架构视图 
                    SqlCommand sqlcmd = new SqlCommand(sb.ToString(), conn);
                    //打开数据库连接
                    conn.Open();
                    //填充器
                    SqlDataAdapter adp = new SqlDataAdapter(sqlcmd);
                    //接收容器
                    DataTable dt = new DataTable();
                    //填充
                    adp.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //result.AppendLine("using System;");
                        //result.AppendLine("using System.Collections.Generic;");
                        //result.AppendLine("using System.Data.Entity.ModelConfiguration;"); 
                        //result.AppendLine("using System.Linq;");
                        //result.AppendLine("using System.Text;");
                        //result.AppendLine("using System.Threading.Tasks;");
                        //result.AppendLine();
                        //result.AppendLine("namespace YourFuckingNameSpace");
                        //result.AppendLine("{");
                        result.AppendLine("    public class " + tablename + "_Mapping : EntityTypeConfiguration<"+ tablename +">");
                        result.AppendLine("    {");
                        result.AppendLine("        public " + tablename + "_Mapping()");
                        result.AppendLine("        {");
                        result.AppendLine("            this.HasKey(t => t.YourFuckingKey);");
                        result.AppendLine("            this.ToTable(\"" + tablename + "\");");
                        foreach (DataRow row in dt.Rows)
                        {
                            result.AppendLine("            this.Property(t => t."+ row["name"].ToString() +").HasColumnName(\"" + row["name"].ToString() + "\").HasColumnType(\""+ row["ctype"].ToString() + "\");");

                        }
                        result.AppendLine("        }");
                        result.AppendLine("    }");
                        //result.AppendLine("}");

                        Clipboard.SetText(result.ToString());
                        MessageBox.Show("已添加到剪切板，请CTRL+V粘贴即可");
                    }

                    //关闭
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成映射失败！" + ex.Message);
            }
        }

        private string GetConnectionString()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = $"Data Source={txtDataSource.Text};Integrated Security=False;Initial Catalog={txtInitialCategory.Text};User Id={txtUserId.Text};Password={txtPassword.Text};Pooling=True;";
            }
            return ConnectionString;
        }
    }
}
