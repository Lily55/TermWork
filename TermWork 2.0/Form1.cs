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
            comboBox1.Items.Insert(2, "Залы");
            comboBox1.Items.Insert(3, "Блюда");
            comboBox1.Items.Insert(4, "Продукты");
            comboBox1.Items.Insert(5, "Арендованные залы");
            comboBox1.Items.Insert(6, "Заказанные блюда");
            comboBox1.Items.Insert(7, "Продукты в блюдах");
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
                            sql = @"select * from Orders";
                            break;
                        }
                    case "1":
                        {
                            sql = @"select * from Manager";
                            break;
                        }
                    case "2":
                        {
                            sql = @"select * from Hall";
                            break;
                        }
                    case "3":
                        {
                            sql = @"select * from Dish";
                            break;
                        }
                    case "4":
                        {
                            sql = @"select * from Product";
                            break;
                        }
                    case "5":
                        {
                            sql = @"select * from OrderedHall";
                            break;
                        }
                    case "6":
                        {
                            sql = @"select * from OrderedDish";
                            break;
                        }
                    case "7":
                        {
                            sql = @"select * from DishProduct";
                            break;
                        }
                    default:
                        sql = @"select * from Orders";
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