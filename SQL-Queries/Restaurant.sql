Create Database Restaurant;

use Restaurant;

Create Table Dish (
  DishID int IDENTITY(1,1) Primary Key,
  DishName varchar(200) not null,
  Price int not null,
);

insert into Dish Values('Chapati', 10);
insert into Dish Values('Roti', 10);
insert into Dish Values('Gulab Jamun', 50);
insert into Dish Values('Rice Plate', 50);
insert into Dish Values('Chicken Biryani', 200);
insert into Dish Values('Mutton Biryani', 250);
insert into Dish Values('Veg Pulao', 180);
insert into Dish Values('Tea', 10);
insert into Dish Values('Special Tea', 20);
insert into Dish Values('Coffee', 10);
insert into Dish Values('Tandoori Roti', 30);
insert into Dish Values('Rumali Roti', 30);

select * from Dish;