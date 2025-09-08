create database day2
use day2
create table sample(rollno int,name varchar(50),college varchar(100))
insert into sample(rollno,name,college) values(31303,'anu','klu')
select * from sample
create table person(id int primary key,lastname varchar(50),firstname varchar(50),age int)

insert into person(id,lastname,firstname,age) values(34,'kumar','siva',22)
select * from person
insert into person(id,lastname,firstname,age) values(3333,'siva','anu',22)

1.default constraint:
create table person1(id int primary key,lastname varchar(50),firstname varchar(50),age int default 25)
insert into person1(id,lastname,firstname) values(1,'a','anvitha')
insert into person1(id,lastname,firstname) values(4,'k','yash')
insert into person1(id,lastname,firstname) values(5,'a',null)

select * from person1

2.unique+not null
create table test(Id int not null unique,fullname varchar(50) not null,sec int)
insert into test(Id,fullname,sec) values(5,'anvitha guduru',2)
select * from test

3.foreign key
create table ordering
(order_id int primary key,
order_name varchar(30),
mainId int foreign key references test(Id)
)

4.built-in functions
 string functions
 select ascii('a') ---97 a 65 A
 select replace('india is a big country','big','biggest')
 select replicate('india',10)
 select rtrim('india country            ')
 select ltrim('           india country')

select datepart(day,'2025-08-1')
select datepart(month,'2025-08-1')
select datepart(year,'2025-08-1')



select datename(dw,'1/8/2025')
select getdate()
 select dateadd(day,2,getdate())
 select dateadd(month,2,getdate())
 select dateadd(year,2,getdate())

