create database bookStore

use bookStore

create table userRegister
(   user_id int not null identity(1,1) primary key,
	FullName varchar(100),
	EmailId varchar(100),
	Password varchar(100),
	MobileNumber varchar(20)	
)

select * from userRegister



