create database ReactAPI

use ReactAPI

Create table Marks
(
	RowID int identity(1,1) primary key,
	UserID varchar(100) not null,
	Mathematics float not null,
	Science float not null,
	Geography float not null,
	History float not null,
	Date date not null,	
)
