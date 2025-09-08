use wiprojuly2025
create table customer(custid int,name varchar(50),salary int);
select * from customer;
create database customer;
use customer;
create table customer(custid int ,name varchar(20),salary int)

insert into customer (custid, name, salary ) values(100,'anu',2903),(101,'siva',2010),(102,'yash',1010)

insert into customer (custid,name,salary) values(100,'puji',2903)

select * from customer

select * from customer where custid=100

update customer set name = 'siva kumar' WHERE custid = 101

delete from customer where name = 'yash'

select * from customer order by salary 

select * from customer order by salary desc

truncate table customer

drop table customer

alter table customer add phonenumber int

begin transaction 

update customer set salary =  2900 where name = anu