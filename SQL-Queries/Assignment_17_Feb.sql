
--Create a Stored Provcedure that will perform an Insert Operation on Employee Table.
--But before Performing the insert operation, this SP Must call the ValidateData() function which will accept the Employee Row parameters and vbalidate it based on following conditions
--EmpNo Must be +ve integer
--EmpName Must containing Characters
--Salary Must be +Ve integer
--DeptNo Muset be present into Department table (Optional) 
--The alidateData() function will return 0 is any of the record-value is invalid else will return 1. The SP will perform insert operation accordingly

create function ValidateData(@EmpNo int, @EmpName varchar(200), @Salary int)
returns int
As
Begin
	declare @returnInt int
	If @EmpNo <=0 OR @Salary <= 0  --EmpName not like %[^A-Z]%
		set @returnInt = 0;
	Else
		set @returnInt = 1;	

		return @returnInt;
End;
Go;


Create proc sp_InsertEmployeeCheck
@EmpNo int, @EmpName varchar (200), @Salary int, @Designation varchar(100), @DeptNo int, @Email varchar(300)
As
Begin
	if dbo.ValidateData(@EmpNo, @EmpName,@Salary) = 0
		select 'Entered data is not in Correct Format';
	else
		Insert into Employee (EmpNo, EmpName, Salary, Designation, DeptNo, Email)
		Values
			(@EmpNo,@EmpName, @Salary, @Designation, @DeptNo, @Email);
End;

Exec sp_InsertEmployeeCheck @EmpNo=125, @EmpName='Praveen', @salary=55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';


Exec sp_InsertEmployeeCheck @EmpNo=126, @EmpName='Pr6aveen', @salary=55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';
Exec sp_InsertEmployeeCheck @EmpNo=123, @EmpName='Praveen', @salary=-55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';
Exec sp_InsertEmployeeCheck @EmpNo=-123, @EmpName='Praveen', @salary=55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';

Exec sp_InsertEmployeeCheck @EmpNo=123, @EmpName='Praveen', @salary=55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';


Exec sp_InsertEmployeeCheck @EmpNo=124, @EmpName='44Praveen', @salary=55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';
Exec sp_InsertEmployeeCheck @EmpNo=-124, @EmpName='Praveen', @salary=55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';
Exec sp_InsertEmployeeCheck @EmpNo=123, @EmpName='Praveen', @salary=-55000, @Designation ='Engineer' ,@DeptNo=14, @Email = 'praveen@gmail.com';




Select * from Employee;

Select * from Department;

drop proc sp_InsertEmployeeCheck;

Drop function ValidateData;

Delete from Employee where EmpNo = 123;
Delete from Employee where EmpNo = 124;
Delete from Employee where EmpNo = 125;
Delete from Employee where EmpNo = 128;

drop proc sp_InsertEmployeeCheck;
Delete from Employee where EmpNo = 123;
Drop function ValidateData;
Go;

--Create a stored procedure that will try to list all emloyees based upon
--deptName but if deptName is passed as NULL or deptName is not present 
--in dept table it shuld return error

Create proc sp_ListEmployeeByDeptName
@DeptNameCheck1 varchar(100)
As
Begin
--declare @DeptNameCheck1 varchar(100)
--set @DeptNameCheck1 = 'IT'
Declare @string varchar(100);
set @string = (select DeptName from Department where DeptName = @DeptNameCheck1);
	If  @string = null
		select 'Entered DeptName is not Correct';
		
	else
		select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Location ,Email 
		From Department Left Join Employee 
		on Department.DeptNo = Employee.DeptNo
		where Department.DeptName = @DeptNameCheck1;
End;

exec sp_ListEmployeeByDeptName @DeptNameCheck1 = null;

--Declare @DeptNameCheck1 varchar(100);
--set @DeptNameCheck1 ='IT';

select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Capacity , Location ,Email 
From Department Left Join Employee 
on Department.DeptNo = Employee.DeptNo;


select * from Department;