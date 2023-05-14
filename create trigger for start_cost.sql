CREATE OR REPLACE FUNCTION set_start_cost() returns
trigger as
$$
begin
UPDATE orders
	set start_cost = banquettype.start_cost
	from banquettype
	where order_id = new.order_id and orders.banquet_type_id = banquettype.banquet_type_id;
Update orders
	set prepayment = round(start_cost/2,2)
	where order_id = new.order_id;
update orders
	set finish_cost = start_cost
	where order_id = new.order_id;
return new;
end;
$$
language 'plpgsql';

create or replace trigger add_start_cost
after insert on orders for each row
EXECUTE PROCEDURE set_start_cost();
