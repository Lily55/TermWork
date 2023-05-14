update orders
set finish_cost = finish_cost + query_in.hall_cost
from (select order_id, hall_cost
	  from hall inner join orderedhall using(hall_id)) query_in
where orders.order_id = query_in.order_id;

update ordereddish
set dishes_amount = ceil(orders.guests_amount*0.7)
from orders
where orders.order_id = ordereddish.order_id;

select * from orders limit 5000;

update orders
set finish_cost = finish_cost + query_in.dishes_cost
from (select order_id, dish_cost*dishes_amount as dishes_cost
	  from dish inner join ordereddish using(dish_id)) query_in
where orders.order_id = query_in.order_id;