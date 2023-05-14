select order_id, finish_cost, dish_name, dish_cost
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
order by order_id


