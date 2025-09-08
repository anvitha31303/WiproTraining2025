--create a scalar function to find area of circle.
create function circleArea(@Radius float) returns float
as begin
return 3.14*@Radius*@Radius
end

select dbo.circleArea(5)

----joins----
use day2
select * from ordering
insert into ordering(order_id,order_name,mainId) values(23,'shiv',333)
select * from person p join ordering o on p.id=o.mainId

--inner join
select * from employee e join company c on e.empid=c.empid
--outer join
select * from employee e left outer join company c on e.empid=c.empid
select * from employee e left join company c on e.empid=c.empid
select * from employee e right outer join company c on e.empid=c.empid
select * from employee e right join company c on e.empid=c.empid
select * from employee e full outer join company c on e.empid=c.empid
select * from employee e full join company c on e.empid=c.empid

select * from employee e cross join company

--stored procedure----

create proc SimpleIOProc
	@input int output,
	@inout int 
as begin
	set @inout= @inout + @input 
End

declare @val int =5
exec SimpleIOProc @input=@val output, @inout=3 
print @val;

EXEC SimpleIOProc @input=3, @inOutParam = @val output