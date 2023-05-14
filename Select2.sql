select hall_name, count(order_id) as Количество_праздников
from orderedhall
		inner join hall using(hall_id)
where order_id in (select order_id
					from orders
					where banquet_type_id = (select banquet_type_id
											from banquettype
											where banquet_type_name like 'Birthday'))
group by hall_name
order by Количество_праздников desc

select hall_name, count(order_id) as Количество_праздников
from orderedhall
		inner join hall using(hall_id)
where order_id in (select order_id
					from orders
				   		inner join banquettype using(banquet_type_id)
					where banquet_type_name like 'Birthday')
group by hall_name
order by Количество_праздников desc
