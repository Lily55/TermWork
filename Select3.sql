select order_id, dish_name, product_name
from ordereddish
		inner join dish using(dish_id)
		inner join dishproduct using(dish_id)
		inner join product using(product_id)
group by order_id, dish_name, product_name
having sum(products_amount) = (select min(Количество_штук)
								from (select product_id, sum(products_amount) as Количество_штук
										from dishproduct
										group by product_id
										order by Количество_штук) query_1)








	
