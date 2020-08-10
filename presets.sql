/*Commands used in the manual insertion/update of preset data and clearance of test data are saved here.*/

/*insert into dbo.Stores(Name)
values ('PizzaHut'), ('Dominos')

insert into dbo.ToppingModel(Name)
values ('Cheese'), ('Pepperoni'), ('Sausage'), ('Ham'), ('Pineapple')

insert into dbo.SizeModel(Name)
values ('Small'), ('Large')

insert into dbo.CrustModel(Name)
values ('Thin'), ('Stuffed')

insert into dbo.PresetPizzas(CrustId, SizeId, Name)
values (2, 2, 'Classic'), (2, 2, 'MeatLovers'), (2, 2, 'Hawaiian')

insert into dbo.PresetToppings(PresetPizzaId, ToppingId)
values 
(1,1),(1,2),
(2,1),(2,2),(2,3),(2,4),
(3,1),(3,4),(3,5)

update dbo.Toppings
set Price = 2.00
where Name = 'Cheese'

update dbo.Toppings
set Price = 3.00
where Price = 0.00

update dbo.Sizes
set Price = 7.00
where id = 1

update dbo.Sizes
set Price = 10.00
where id = 2

update dbo.Crusts
set Price = 3.00
where id = 1

update dbo.Crusts
set Price = 5.00
where id = 2

select *
from dbo.Toppings

select *
from dbo.PresetPizzas

select *
from dbo.PresetToppings

select *
from dbo.Sizes

select *
from dbo.Crusts

select *
from dbo.Stores

select *
from dbo.Users

select *
from dbo.Orders

select *
from dbo.Pizzas

select *
from dbo.PizzaToppings

delete from dbo.PizzaToppings

delete from dbo.Pizzas

delete from dbo.Orders

delete from dbo.Users
*/