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

insert into dbo.PresetToppingModel(PresetPizzaId, ToppingId)
values 
(1,1),(1,2),
(2,1),(2,2),(2,3),(2,4),
(3,1),(3,4),(3,5)*/

select *
from dbo.Users

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
from dbo.Orders

select *
from dbo.Stores

select *
from dbo.Pizzas

select *
from dbo.PizzaToppings