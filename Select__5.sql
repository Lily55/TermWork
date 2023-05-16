select client_name, count(order_id) as orders_amount, round(sum(finish_cost)/count(order_id),2) as middle_finish_cost
from orders
	inner join client using(client_id)
group by client_name
having round(sum(finish_cost)/count(order_id),2) > (select round(avg(finish_cost),2) as middle_cost
													from orders)