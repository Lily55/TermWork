select client_id, dish_id, count(dish_id) as max_count_dish
from (select client_id, dish_id, count(dish_id) as count_dish_id
													from ordereddish
														inner join (select order_id, client_id
																	from orders
																	where banquet_type_id = (select banquet_type_id
																							from banquettype
																							where banquet_type_name = 'New Year Party')) query_3 using (order_id)
																							group by client_id, dish_id) query_4
group by client_id, dish_id
having (client_id, count(dish_id)) = ANY(select client_id, max(count_dish_id)
										from (select client_id, dish_id, count(dish_id) as count_dish_id
													from ordereddish
														inner join (select order_id, client_id
																	from orders
																	where banquet_type_id = (select banquet_type_id
																							from banquettype
																							where banquet_type_name = 'New Year Party')) query_1 using (order_id)
													group by client_id, dish_id
													order by 1, 3 desc) query_2
										group by client_id
										order by 1, 2 desc)
										


