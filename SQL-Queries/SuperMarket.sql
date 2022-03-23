Create Database SuperMarket

Use SuperMarket

Create table Category
(
  CategoryId int Primary Key,
  CategoryName varchar(50) not null 
)

insert into Category values(101,'Food')
insert into Category values(102,'IT')
insert into Category values(103,'Household')


create table Product
(
  ProductId int Primary key,
  ProductName varchar(50) not null,
  UnitPrice int not null,
  CategoryId int not null References Category (CategoryId)
)


insert into Product values(10001, 'Must Oil',100,101)
insert into Product values(10002, 'Soya Oil',120,101)
insert into Product values(10003, 'Sunf Oil',110,101)
insert into Product values(10004, 'Router',3000,102)
insert into Product values(10005, 'Ext. HDD',12000,102)
insert into Product values(10006, 'USB Store',600,102)
insert into Product values(10007, 'TV',30000,103)
insert into Product values(10008, 'Mixer',3000,103)
insert into Product values(10009, 'Iron',800,103)

create table BillMaster(
  BillNo int identity primary key,
  BillAmount int not null
)

create table BillDetails
(
  BillItemId int identity primary key,
  ProductId int not null references Product(ProductId),
  ProductName varchar(50) not null,
  Quantity int not null,
  RowPrice int not null,
  BillNo int not null references BillMaster(BIllNo) 
)


select * from Product

select * from Category

select * from BillDetails

select * from BillMaster