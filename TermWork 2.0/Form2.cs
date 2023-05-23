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

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Какие заказы включают блюда, использующие самые редкие продукты? Вывести номер заказа, название блюда, название продукта";
            sql = @"select order_id, dish_name, product_name
                    from ordereddish
		                    inner join dish using(dish_id)
		                    inner join dishproduct using(dish_id)
		                    inner join product using(product_id)
                    group by order_id, dish_name, product_name
                    having sum(products_amount) = (select min(Количество_штук)
								                    from (select product_id, sum(products_amount) as Количество_штук
										                    from dishproduct
										                    group by product_id
										                    order by Количество_штук) query_1)";
            Choose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Какие клиенты какие залы чаще всего заказывают?";
            sql = @"select client_name as Имя_клиента, (array_agg(hall_name))[1] as Чаще_заказываемый_зал, (array_agg(replics_amount))[1] as Количество_праздников
					from (select client_name, hall_name, count(hall_name) as replics_amount
							from orders
								inner join orderedhall using(order_id)
								inner join client using(client_id)
								inner join hall using(hall_id)
														  
							group by client_name, hall_name
							order by 1, 3 desc) query_1
													
					group by client_name";
            Choose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Для клиентов у которых средняя конечная стоимость заказов выше средней конечной стоимости по суммам заказов клиентов (общей стоимости всех заказов клиентов), вывести имя, общую конечную стоимость всех заказов, количество заказов.";
            sql = @"select client_name, count(order_id) as orders_amount, round(sum(finish_cost)/count(order_id),2) as middle_finish_cost
                    from orders
	                    inner join client using(client_id)
                    group by client_name
                    having round(sum(finish_cost)/count(order_id),2) > (select round(avg(finish_cost),2) as middle_cost
													                    from orders)";
            Choose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Какие клиенты, какие блюда чаще всего заказывают на Новый год?";
            sql = @"select client_name as Имя_клиента, (array_agg(dish_name))[1] as Чаще_заказываемое_блюдо, (array_agg(replics_amount))[1] as Количество_заказов
					from (select client_name, dish_name, count(dish_name) as replics_amount
							from orders
								inner join ordereddish using(order_id)
								inner join client using(client_id)
								inner join dish using(dish_id)
							where banquet_type_id = (select banquet_type_id
													from banquettype
													where banquet_type_name like 'New Year%')							  
							group by client_name, dish_name
							order by 1, 3 desc) query_1
													
					group by client_name";
            Choose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Вывести статистику по клиенту за определённый период (какие блюда для каких праздников чаще всего заказывались)";
            sql = @"select client_name, banquet_type_name, (array_agg(dish_name))[1] as Самое_заказываемое_блюдо, (array_agg(dish_count))[1] as Количество_заказов_блюда
                    from(select client_name, banquet_type_name, dish_name, count(dish_id) as dish_count
                    from orders
	                    join client using(client_id)
	                    join BanquetType using(banquet_type_id)
	                    join ordereddish using(order_id)
	                    join dish using(dish_id)
                    where client_id = 101
		                    and date_time between '2017-08-05' and '2021-09-30'
                    group by client_name, banquet_type_name, dish_name
                    order by 2, 4 desc) query_1
                    group by client_name, banquet_type_name";
            Choose() ;
        }
    }
}
