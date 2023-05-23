select client_name, dish_name as Чаще_заказываемое_блюдо, hall_name as Чаще_заказываемый_зал, count(order_id)
from orders
	inner join client using(client_id)
	inner join (select client_id, (array_agg(dish_id))[1] as often_dish from
				(select client_id, dish_id, count(ordereddish.dish_id)
				from orders
					inner join ordereddish using(order_id)	
				 where date_time between '2017-08-01' and '2018-09-30' and client_id = 101
				group by client_id, dish_id
				order by 1, 3 desc) query_1
				group by client_id) query_3 using(client_id)
	inner join (select client_id, (array_agg(hall_id))[1] as often_hall
				from
				(select client_id, hall_id, count(orderedhall.hall_id)
				from orders
					inner join orderedhall using(order_id)
				 where date_time between '2017-08-01' and '2018-09-30' and client_id = 101
				group by client_id, hall_id
				order by 1, 3 desc) query_2
				group by client_id) query_4 using(client_id)
	inner join dish on dish.dish_id = query_3.often_dish
	inner join hall on hall.hall_id = query_4.often_hall
where date_time between '2017-08-01' and '2018-09-30'
		and client_id = 101
group by client_name, Чаще_заказываемое_блюдо, Чаще_заказываемый_зал



select client_id, dish_id, count(dish_id) as dish_count
from ordereddish
	join orders using(order_id)
where client_id = 101 and date_time between '2017-08-01' and '2018-09-30'
group by client_id, dish_id
order by 3 desc
limit 1

select client_id, hall_id, count(hall_id) as hall_count
from orderedhall
	join orders using(order_id)
where client_id = 101 and date_time between '2017-08-01' and '2018-09-30'
group by client_id, hall_id
order by 3 desc
limit 1


select client_name, dish_name, hall_name
from client
	join (select client_id, hall_id, count(hall_id) as hall_count
			from orderedhall
				join orders using(order_id)
			where client_id = 101 and date_time between '2017-08-01' and '2018-09-30'
			group by client_id, hall_id
			order by 3 desc
			limit 1) query_1 using(client_id)
	join (select client_id, dish_id, count(dish_id) as dish_count
			from ordereddish
				join orders using(order_id)
			where client_id = 101 and date_time between '2017-08-01' and '2018-09-30'
			group by client_id, dish_id
			order by 3 desc
			limit 1) query_2 using(client_id)
	join dish on query_2.dish_id = dish.dish_id
	join hall on query_1.hall_id = hall.hall_id
group by client_name, dish_name, hall_name


	

