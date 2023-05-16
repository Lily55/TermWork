select client_name as Имя_клиента, (array_agg(dish_name))[1] as Чаще_заказываемое_блюдо, (array_agg(replics_amount))[1] as Количество_заказов
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
													
					group by client_name
				
				
				
