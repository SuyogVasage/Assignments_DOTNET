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

Create Table Customer (
	CustID int IDENTITY(1,1) Primary Key,
	CustName varchar(100) not null,
	MobileNo varchar(50) not null,
);

Create Table LogEntry (
	LogID int IDENTITY(1,1) Primary Key,  
	CustID int not null References Customer(CustID),
	DishID int not null References Dish(DishID),
	Quantity int,
	DishName varchar(200) not null,
    Price int not null,
	Value float,
);

select * from LogEntry inner join Bill On LogEntry.CustID=Bill.CustID where Bill.CustID=1;
Go;


Create table Bill (
	BillNo int IDENTITY(101,1) Primary Key,
	CustID int not null References Customer(CustID),
	CustName varchar(100) not null, 
	MobileNo varchar(50) not null,
	TableNo int not null,
	Date smalldatetime not null,
	Subtotal float not null,
	Tax float not null,
	FinalTotal float not null,
	Payment varchar(100),
);


select * from Customer;

select * from LogEntry;

select * from Bill;




Delete from Customer where CustID = 12;

Delete from LogEntry where LogID = 15;
Delete from LogEntry where LogID = 16;
Delete from LogEntry where LogID = 17;
Delete from LogEntry where LogID = 18;


SET IDENTITY_INSERT LogEntry OFF

SET IDENTITY_INSERT Bill ON

Drop table Bill
Drop table Customer
Drop table LogEntry

insert into LogEntry values(1, 2, 1, 10) 
--PatientId int not null References Patient(PatientID),

create proc sp_GetBill
As
Begin
	select * from LogEntry inner join Bill On LogEntry.CustID=Bill.CustID where Bill.CustID=1;
End;

exec sp_GetBill

drop proc sp_GetBill