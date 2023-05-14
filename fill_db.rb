# frozen_string_literal: true

require 'pg'
require 'faker'
# Faker::Config.locale = :ru
conn = PG.connect(dbname: 'Ordering a banquet', user: 'postgres', password: 'CrazybirD')


# Заполнение таблицы Manager

def manager_name()
  return Faker::Name.last_name + ' ' + Faker::Name.initials(number: 1) + '.' + Faker::Name.initials(number: 1) + '.'
end

def employ_date()
  return Faker::Date.between(from: '2017-09-23', to: '2020-05-06')
end

def dismiss_date()
  return Faker::Date.between(from: '2020-09-23', to: '2023-05-06')
end

def phone_number()
  return Faker::PhoneNumber.cell_phone_in_e164
end

def manager_values()
  return %(('#{manager_name}', '#{employ_date}', '#{phone_number}'))
end

# conn.exec(%(Insert into Manager (manager_name, employ_date, phone_number)
#  Values #{100.times.collect{manager_values}.to_a.join(',')}))

# conn.exec(%(delete from Manager where manager_id > 101))

# Заполнение табицы Dish

def dish_name()
    return Faker::Food.dish
end

def dish_cost()
    return Faker::Number.decimal(l_digits: 3, r_digits: 2)
end

def dish_values()
    return %(('#{dish_name}', '#{dish_cost}'))
end

# conn.exec(%(Insert into Dish (dish_name, dish_cost)
#     Values #{100.times.collect{dish_values}.to_a.join(',')}))

# Заполнение таблицы Product

def product_name()
  return Faker::Food.ingredient
end

def delivery_date()
  return Faker::Date.between(from: '2023-05-01', to: '2023-05-06')
end

def number_in_stock()
  return Faker::Number.between(from: 50, to: 200)
end

def product_values()
  return %(('#{product_name}', '#{delivery_date}', #{number_in_stock}))
end

# conn.exec(%(Insert into Product (product_name, delivery_date, amount_in_stock) 
#   Values #{100.times.collect{product_values}.to_a.join(',')}))

# Заполнение таблицы DishProduct

def dish_id()
  return Faker::Number.between(from: 1, to: 101)
end

def product_id()
  return Faker::Number.between(from: 1, to: 100)
end

def products_amount()
  return Faker::Number.between(from: 1, to: 5)
end

def dish_product_values()
  return %((#{dish_id}, #{product_id}, #{products_amount}))
end

# conn.exec(%(Insert into DishProduct (dish_id, product_id, products_amount) 
#   Values #{100.times.collect{dish_product_values}.to_a.join(',')}))

# Заполянем таблицу Client

def client_email()
  return Faker::Internet.email(domain: 'yandex.ru')
end

def client_adress()
  return Faker::Address.street_address + ', Москва, Россия'
end

def client_values()
  return %(('#{manager_name}', '#{client_adress}', '#{phone_number}', '#{client_email}'))
end

# conn.exec(%(Insert into Client (client_name, client_adress, phone_number, email) 
#   Values #{100.times.collect{client_values}.to_a.join(',')}))

# заполняем таблицу Hall

def hall_name()
  return Faker::Restaurant.name
end

def seats_amount()
  return Faker::Number.between(from: 30, to: 250)
end

def hall_cost()
  return Faker::Number.between(from: 60000, to: 200000)
end

def hall_values()
  return %(('#{hall_name}', #{seats_amount}, #{hall_cost}))
end

# conn.exec(%(Insert into Hall (hall_name, seats_amount, hall_cost) 
#   Values #{100.times.collect{hall_values}.to_a.join(',')}))

# Заполнение таблицы Orders

def client_id()
  return Faker::Number.between(from: 101, to: 200)
end

def date_time()
  return Faker::Date.between(from: '2016-02-01', to: '2023-05-06')
end

def guests_amount()
  return Faker::Number.between(from: 20, to: 200)
end

def manager_id()
  return Faker::Number.between(from: 1, to: 101)
end

def start_cost()
  return Faker::Number.between(from: 80000, to: 300000)
end

def order_values()
  return %((#{client_id}, '#{date_time}', #{guests_amount}, #{manager_id}, #{start_cost}))
end

# conn.exec(%(Insert into orders (client_id, date_time, guests_amount, manager_id, start_cost) 
#   Values #{1000000.times.collect{order_values}.to_a.join(',')}))

# Заполняем таблицу OrderedDish

def order_id()
  return Faker::Number.between(from: 1, to: 10000100)
end

def ordered_dish_values()
  return %((#{order_id}, #{dish_id}))
end

# conn.exec(%(Insert into ordereddish (order_id, dish_id) 
#   Values #{100000.times.collect{ordered_dish_values}.to_a.join(',')}))

# Заполняем таблицу OrderedHall

def hall_id()
  return Faker::Number.between(from: 1, to: 100)
end

def ordered_hall_values()
  return  %((#{order_id}, #{hall_id}))
end

# conn.exec(%(Insert into orderedhall (order_id, hall_id) 
#   Values #{100000.times.collect{ordered_hall_values}.to_a.join(',')}))

# for i in 1..40 do
# conn.exec(%(Update Manager set dismiss_date = '#{dismiss_date}' where manager_id = #{manager_id} and dismiss_date is null))
# end

def banquet_type()
  return %((#{Faker::Number.between(from: 1, to: 6)}))
end

# conn.exec(%(Insert into orders (banquet_type_id) 
#   Values #{10000000.times.collect{banquet_type}.to_a.join(',')}))

# for i in 1..10000000 do
# conn.exec(%(Update orders set banquet_type_id = '#{Faker::Number.between(from: 1, to: 6)}' where order_id = #{i}))
# end