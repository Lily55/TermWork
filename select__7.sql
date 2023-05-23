select client_name, Чаще_заказываемое_блюдо, Чаще_заказываемый_зал, count(order_id)
from orders
	inner join client using(client_id)
	inner join (select client_id, (array_agg(dish_name))[1] as Чаще_заказываемое_блюдо
				from
				(select client_id, dish_name, count(ordereddish.dish_id)
				from orders
					inner join ordereddish using(order_id)
					inner join dish using(dish_id)
				 where date_time between '2017-08-01' and '2018-09-30'
				group by client_id, dish_name
				order by 1, 3 desc) query_1
				group by client_id) query_3 using(client_id)
	inner join (select client_id, (array_agg(hall_name))[1] as Чаще_заказываемый_зал
				from
				(select client_id, hall_name, count(orderedhall.hall_id)
				from orders
					inner join orderedhall using(order_id)
					inner join hall using(hall_id)
				 where date_time between '2017-08-01' and '2018-09-30'
				group by client_id, hall_name
				order by 1, 3 desc) query_2
				group by client_id) query_4 using(client_id)
where date_time between '2017-08-01' and '2018-09-30'
		and client_id = 101
group by client_name, Чаще_заказываемое_блюдо, Чаще_заказываемый_зал


select client_name, dish_name, hall_name
from orders
	inner join client using(client_id)
	inner join ordereddish using(order_id)
	inner join dish using(dish_id)
	inner join orderedhall using(order_id)
	inner join hall using(hall_id)
where date_time between '2016-08-01' and '2018-09-30'
		and client_id = 101
		and dish_id = (select dish_id
					  from ordereddish
					  where order_id in (select order_id
										from orders
										where client_id = 101)
					  group by dish_id
					  having count(dish_id))
order by 3 desc, 5 desc

