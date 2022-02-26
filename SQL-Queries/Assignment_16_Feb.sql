
--Second max salary from table
select max(salary) as Salary from Employee where Salary < (Select max(Salary) from Employee);

--Max Salary from table
select max(salary) as Salary from Employee;

select * from Employee;
select * from Department;

--Assignment on 16 Feb

--1)Select Second Max Salary Per DeptNo

select DeptNo, Max(Salary)
from (select e1.DeptNo, e1.Salary
from Employee e1,(select DeptNo , Max (Salary) as Salary
from Employee group by DeptNo)e2
where e1.DeptNo = e2.DeptNo
And e1.Salary < e2.Salary)e
group by DeptNo;
Go;

--2)Maximum Salary per desigation
select Designation, Max(Salary) as Salary from Employee Group by Designation;

--2)Second max salary per Designation

select Designation, Max(Salary)
from (select e1.Designation, e1.Salary
from Employee e1,(select Designation , Max (Salary) as Salary
from Employee group by Designation)e2
where e1.Designation = e2.Designation
And e1.Salary < e2.Salary)e
group by Designation;
Go;

--3)Create Strored Proc (SP) that will return Max Salary per DeptName
--Use Group By
Go
create proc sp_MaxSalaryByDeptName_1
as
Begin
    select DeptName, Max(Salary) as Salary
from Employee, Department -- Join
Where Employee.DeptNo = Department.DeptNo
Group by (Department.DeptName) -- Group By
Order By DeptName Desc -- Order by
end;

exec sp_MaxSalaryByDeptName_1;




select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Employee.DeptNo
From Department Right Join Employee 
on Department.DeptNo = Employee.DeptNo;

select Department.DeptNo, DeptName, EmpNo, EmpName, Salary, Designation, Employee.DeptNo
From Department Left Join Employee 
on Department.DeptNo = Employee.DeptNo;

select DeptName, Max(Salary) as Salary from Department Group by Deptname;
Go;

Create Proc sp_MaxSalaryPerDeptName
@DeptName int
As
-- Lets Declare a Local Variable for Store Procedure
Declare @MaxSalary int
Begin
	select DeptName 
    From Department Left Join Employee 
	on Department.DeptNo = Employee.DeptNo;
	
	--select DeptName, Max(Salary) as Salary from Department Group by Deptname;

	-- Return the result
	return @MaxSalary;
End;
Go;




--4)Create a SP that will insert row in Employee Table

Create proc sp_InsertEmployee
@EmpNo int, @EmpName varchar (200), @Salary int, @Designation varchar(100), @DeptNo int, @Email varchar(300)
As
Begin  	
  Insert into Employee (EmpNo, EmpName, Salary, Designation, DeptNo, Email)
  Values
	(@EmpNo,@EmpName, @Salary, @Designation, @DeptNo, @Email);
End;
Go

Exec sp_InsertEmployee @EmpNo=121, @EmpName='Kumar', @salary=15000,@Designation ='Intern' ,@DeptNo=12, @Email = 'kumar@gmail.com';
Go;
 
