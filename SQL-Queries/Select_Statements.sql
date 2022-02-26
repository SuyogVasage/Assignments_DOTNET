Select EmpNo, EmpName, Designation from Employee;

Select EmpNo, EmpName, Designation from Employee where Designation = 'manager';

select * from Employee where EmpName Like 'S%';

select * from Employee where EmpName Like '%a';

select Count(*) from Employee;

select * from Employee Order by Salary desc;

select * from Employee;

select Distinct Designation from Employee;


select Designation, Max(Salary) as Salary from Employee Group by Designation;
