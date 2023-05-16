select client_name, hall_name, Количество_повторений
from client
	inner join (select client_id, hall_id, count(*) as Количество_повторений
				from orders
						inner join orderedhall using(order_id)
				group by client_id, hall_id
				having (client_id, count(*)) = ANY(select client_id, max(replics_amount) as max_replics_amount
													from (select client_id, hall_id, count(*) as replics_amount
															from orders
																inner join orderedhall using(order_id)
															group by client_id, hall_id
															order by 1, 3 desc) query_1
													group by client_id)) query_2
			using (client_id)
			inner join hall using (hall_id)

order by 1, 3 desc


select client_name as Имя_клиента, (array_agg(hall_name))[1] as Чаще_заказываемый_зал, (array_agg(replics_amount))[1] as Количество_праздников
													from (select client_name, hall_name, count(hall_name) as replics_amount
															from orders
																inner join orderedhall using(order_id)
														  		inner join client using(client_id)
														  		inner join hall using(hall_id)
														  
															group by client_name, hall_name
															order by 1, 3 desc) query_1
													
													group by client_name











	
