--Вывести статистику по клиенту за определённый период (какие блюда для каких праздников чаще всего заказывались)

select client_name, banquet_type_name, (array_agg(dish_name))[1] as Самое_заказываемое_блюдо, (array_agg(dish_count))[1] as Количество_заказов_блюда
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
group by client_name, banquet_type_name

