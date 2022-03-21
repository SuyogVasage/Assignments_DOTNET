Select DeptName, EmpNo, EmpName
from Employee, Department 
Where Employee.DeptNo = Department.DeptNo 
Group by(Department.DeptName);
--Order By DeptName Desc;


Select EmpNo, EmpName from Employee;
Create database Industry;

Use Industry;

Create Table Department (
  DeptNo int Primary Key,
  DeptName varchar(100) not null,
  Location varchar(100),
  Capctay int not null
);

Alter Table Department alter column Location varchar (100) Not Null;

EXEC sp_rename 'Department.Capctay', 'Capacity', 'COLUMN';


insert into Department Values(10, 'IT', 'Pune', 200);
insert into Department Values(11, 'HR', 'Pune', 19);
insert into Department Values(12, 'SL', 'Pune', 24);
insert into Department Values(13, 'Admin', 'Pune', 15);
insert into Department Values(14, 'Acc', 'Pune', 20);

Select * from Department;

Update Department set Location = 'Mumbai' where DeptName ='Acc'; 

Update Department set Location = 'Mumbai' where DeptName ='HR'; 

Create Table Employee
(
EmpNo int Primary Key, EmpName varchar (100) not null,
Salary int not null, Designation varchar (100) not null,
DeptNo int not null References Department(DeptNo)
);

Alter Table Employee add Email varchar (300) not null;

alter table Employee alter column EmpName varchar (200) not null;

insert into Employee Values (101, 'Suyog', 100000, 'Manager', 11, 'suyog@gmail.com');
insert into Employee Values (102, 'Mayur', 50000, 'Engineer', 12, 'mayur@gmail.com');
insert into Employee Values (103, 'Yash', 20000, 'Intern', 13, 'Yash@gmail.com');
insert into Employee Values (104, 'Sasi', 15000, 'Clerk', 14, 'sasi@gmail.com');
insert into Employee Values (105, 'Onkar', 10000, 'Staff', 10, 'onkar@gmail.com');
insert into Employee Values (106, 'Jahnvi', 40000, 'Engineer', 12, 'jahanvi@gmail.com');
insert into Employee Values (107, 'Ankita', 120000, 'Manager', 13, 'ankita@gmail.com');
insert into Employee Values (108, 'Shreya', 10000, 'Intern', 14, 'shreya@gmail.com');
insert into Employee Values (109, 'Harsh', 19000, 'Staff', 11, 'harsh@gmail.com');
insert into Employee Values (110, 'Ayush', 170000, 'Manager', 10, 'ayush@gmail.com');
insert into Employee Values (111, 'Durvesh', 7000, 'Clerk', 12, 'durvesh@gmail.com');
insert into Employee Values (112, 'Uday', 10000, 'Intern', 14, 'uday@gmail.com');
insert into Employee Values (113, 'Shikhar', 110000, 'Manager', 10, 'shikhar@gmail.com');
insert into Employee Values (114, 'Jayesh', 60000, 'Engineer', 11, 'jyesh@gmail.com');
insert into Employee Values (115, 'Pranav', 9000, 'Staff', 13, 'pranav@gmail.com');
insert into Employee Values (116, 'Simran', 15000, 'Clerk', 14, 'simran@gmail.com');
insert into Employee Values (117, 'Abhishek', 180000, 'Manager', 11, 'abhi@gmail.com');
insert into Employee Values (118, 'Mrunal', 45000, 'Engineer', 12, 'mrunal@gmail.com');
insert into Employee Values (119, 'Prachi', 9900, 'Intern', 10, 'prachi@gmail.com');
insert into Employee Values (120, 'Nisha', 90000, 'Manager', 12, 'nisha@gmail.com');

Select * from Employee;

Drop table Employee;

Create Table Users (
  UserID int Primary Key,
  UserName varchar(100) not null,
  Password varchar(100),
);


Insert into Users values (101, 'Suyog', 'Gou764$');

Insert into Users values (102, 'Mayur', 'jdusk87@');

Insert into Users values (103, 'Yash', 'kuyuj87&*');

Insert into Users values (104, 'Jahanvi', 'kuygyug656$');

Insert into Users values (105, 'Shreya', 'IUTyu8687$');

select * from Users

alter table Employee add Tax float not null ;

alter table Employee drop Column Tax


use PersonInfo

drop database PersonInfo

select * from Persons

drop table Persons