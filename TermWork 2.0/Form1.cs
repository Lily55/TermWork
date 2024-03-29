using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermWork_2._0
{
    public partial class Form1 : Form
    {
        public string connString = String.Format("Server={0}; Port = {1};" +
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
            sql = @"select * from orders order by 1  limit 500";
            Choose();
            comboBox1.Items.Insert(0, "������");
            comboBox1.Items.Insert(1, "���������");
            comboBox1.Items.Insert(2, "�������");
            comboBox1.Items.Insert(3, "���� ��������");
            comboBox1.Items.Insert(4, "����");
            comboBox1.Items.Insert(5, "�����");
            comboBox1.Items.Insert(6, "��������");
            comboBox1.Items.Insert(7, "������������ ����");
            comboBox1.Items.Insert(8, "���������� �����");
            comboBox1.Items.Insert(9, "�������� � ������");
        }

        private void Choose()
        {
            try
            {
                conn.Open();
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
            switch (tableChoice)
            {
                case "0":
                    {
                        sql = @"select * from orders where finish_cost is not null order by 1  limit 500";
                        break;
                    }
                case "1":
                    {
                        sql = @"select * from Manager";
                        break;
                    }
                case "2":
                    {
                        sql = @"select * from Client";
                        break;
                    }
                case "3":
                    {
                        sql = @"select * from BanquetType";
                        break;
                    }
                case "4":
                    {
                        sql = @"select * from Hall";
                        break;
                    }
                case "5":
                    {
                        sql = @"select * from Dish";
                        break;
                    }
                case "6":
                    {
                        sql = @"select * from Product";
                        break;
                    }
                case "7":
                    {
                        sql = @"select * from OrderedHall";
                        break;
                    }
                case "8":
                    {
                        sql = @"select * from OrderedDish";
                        break;
                    }
                case "9":
                    {
                        sql = @"select * from DishProduct";
                        break;
                    }
                default:
                    sql = @"select * from Orders";
                    break;
            }
            Choose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}