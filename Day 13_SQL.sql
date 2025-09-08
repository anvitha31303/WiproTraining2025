Declare @val4 int;
Declare @val5 int;

BEGIN TRY
   Set @val4=8;

BEGIN TRY
    Set @val4=8;
    Set @val5=@val4/0; /* Error Occur Here */
END TRY

BEGIN CATCH
    Print 'Error Occur that is:'
    Print Error_Message()
END CATCH

Set @val5=@val4/0; /* Error Occur Here */
END TRY

BEGIN CATCH
    Print 'Error Occur that is:'
    Print Error_Message()
END CATCH

--------------------
CREATE PROCEDURE UpdateSalaryByEmpID
    @EmpID INT,
    @NewSalary DECIMAL(10, 2)
AS
BEGIN
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmpID = @EmpID;
END;


EXEC UpdateSalaryByEmpID 
    @EmpID = 101, 
    @NewSalary = 72000.00;


create proc insertemp
 (@eid int, @ename varchar(50), @city varchar(50), @salary int)
 as
 begin
     insert into employee(empid, empname, city, salary)
     values(@eid, @ename, @city, @salary)
 end

 exec insertemp 1006, 'Pratyush', 'Mumbai', 5000;


create proc SimpleIOProc
  @input int output,
  @inout int 
as begin
  set @inout= @inout + @input 
End

declare @val int =5
exec SimpleIOProc @input=@val output, @inout=3 
print @val;


---create a stored procedure to display empid in employee table--in ascending order
---create a stored procedure to display empid in employee table in descending order
-----------------------
CREATE TABLE new_employees (
    employee_id int primary key,
    first_name varchar(50) not null,
    last_name varchar(50) not null,
    department_id INT,
    FOREIGN KEY(department_id) REFERENCES departments(department_id)
);
INSERT INTO new_employees(employee_id, first_name, last_name, department_id) values(1, 'John', 'Doe', 2),
    (2, 'Jane', 'Smith', 1),
    (3, 'Bob', 'Johnson', 3),
    (4, 'Alice', 'Williams', 1);

DROP TABLE employees;
ALTER TABLE new_employees RENAME TO employees;