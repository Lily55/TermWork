using Npgsql;
using System.Data;

namespace TermWork_2._0
{
    public partial class Form1 : Form
    {
        private string connString = String.Format("Server={0}; Port = {1};" +
        "User ID = {2}; Password = {3}; Database = {4}", "localhost", 5432, "postgres", "CrazybirD", "Ordering a banquet");

        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private string tableChoice;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connString);
            comboBox1.Items.Insert(0, "Заказы");
            comboBox1.Items.Insert(1, "Менеджеры");
        }

        private void Select()
        {
            try
            {
                conn.Open();
                switch (tableChoice)
                {
                    case "0":
                        {
                            sql = @"select * from order_select()";
                            break;
                        }
                    case "1":
                        {
                            sql = @"select * from manager_select()";
                            break;
                        }
                    default:
                        sql = @"select * from order_select()";
                        break;
                }


                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableChoice = comboBox1.SelectedIndex.ToString();
            Select();
        }
    }
}