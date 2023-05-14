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
    public partial class Form2 : Form
    {
        private NpgsqlConnection conn;
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;

        public Form2()
        {
            InitializeComponent();
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

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            conn = new NpgsqlConnection(form1.connString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Вывести номер и конечную стоимость заказов, включающих самое популярноое блюдо. Название блюда и его цену указать в двух последних колонках.";
            sql = @"select order_id, finish_cost, dish_name, dish_cost
                    from orders
	                    inner join ordereddish using (order_id)
	                    inner join Dish on dish.dish_id = ordereddish.dish_id
                    where dish.dish_id in (select dish_id
						                    from ordereddish
						                    group by dish_id
						                    having sum(dishes_amount) = (select max(sum_dishes_amount)
													                    from (select dish_id, sum(dishes_amount) as sum_dishes_amount
															                    from ordereddish
															                    group by dish_id
															                    order by sum_dishes_amount desc) query_1))
                    order by order_id";
            Choose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "В каких залах чаще всего празднуют Дни рождения? Вывести название зала и количество проводимых Дней рождения для 10 верхних записей";
            sql = @"select hall_name, count(order_id) as Количество_праздников
                    from orderedhall
		                    inner join hall using(hall_id)
                    where order_id in (select order_id
					                    from orders
					                    where banquet_type_id = (select banquet_type_id
											                    from banquettype
											                    where banquet_type_name like 'Birthday'))
                    group by hall_name
                    order by Количество_праздников desc
                    limit 10";
            Choose();
        }
    }
}
