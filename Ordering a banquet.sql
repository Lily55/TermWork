create table if not exists Hall (
	hall_id serial primary key,
	hall_name text NOT NULL,
	seats_amount int NOT NULL CONSTRAINT positive_seats_amount CHECK (seats_amount > 0)
);

create table if not exists Manager (
	manager_id serial primary key,
	manage_name text NOT NULL,
	employ_date date NOT NULL,
	dismiss_date date
);

create table if not exists Dish (
	dish_id serial primary key,
	dish_name text NOT NULL,
	dish_cost decimal(10,2) NOT NULL CONSTRAINT positive_dish_cost CHECK(dish_cost > 0)
);

create table if not exists Orders (
	order_id serial primary key,
	client_id int NOT NULL,
	date_time date NOT NULL,
	guests_amount int NOT NULL CONSTRAINT positive_guests_amount CHECK (guests_amount > 0),
	manager_ID int,
	banquet_type_id int,
	start_cost decimal(10,2) NOT NULL CONSTRAINT positive_start_cost CHECK (start_cost > 0),
	prepayment decimal(10,2) NOT NULL CONSTRAINT positive_prepayment CHECK (prepayment > 0),
	finish_cost decimal(10,2) NOT NULL CONSTRAINT positive_finish_cost CHECK (finish_cost > 0),
	CHECK (finish_cost >= start_cost),
	FOREIGN KEY (manager_ID) references Manager (manager_id) on delete SET NULL,
	FOREIGN KEY (client_ID) references Client (client_id) on delete cascade,
	FOREIGN KEY (banquet_type_id) references BanquetType (banquet_type_id) on delete SET NULL
);

create table if not exists OrderedDish (
	order_ID int NOT NULL,
	dish_ID int NOT NULL,
	dishes_amount int NOT NULL CONSTRAINT positive_dishes_amount CHECK (dishes_amount > 0),
	foreign key (dish_ID) references Dish (dish_id) on delete cascade,
	foreign key (order_ID) references Orders (order_id) on delete cascade
);

CREATE TABLE IF NOT EXISTS Product (
	product_id serial primary key,
	product_name text NOT NULL,
	delivery_date date NOT NULL,
	amount_in_stock int NOT NULL CONSTRAINT positive_amount_in_stock CHECK (amount_in_stock > 0)
);

CREATE TABLE IF NOT EXISTS DishProduct (
	dish_ID int NOT NULL,
	product_ID int NOT NULL,
	products_amount int NOT NULL CONSTRAINT positive_products_amount CHECK (products_amount > 0),
	FOREIGN KEY (dish_ID) references Dish (dish_id) on delete cascade,
	Foreign key (product_ID) references Product (product_id) on delete cascade
);

create table if not exists OrderedHall (
	order_id int not NULL,
	hall_id int not null,
	tables_amount int not null constraint positive_tables_amount check(tables_amount > 0),
	foreign key (order_id) references Orders(order_id) on delete cascade,
	foreign key (hall_id) references Hall(hall_id) on delete cascade
);

create table if not exists Client (
	client_id serial primary key,
	client_name text NOT NULL,
	client_adress text NOT NULL,
	phone_number varchar(14) NOT NULL,
	email text NOT NULL
);

create table if not exists BanquetType (
	banquet_type_id serial primary key,
	banquet_type_name text NOT NULL,
	start_cost decimal(10,2) NOT null,
	description text
);






