create database Students
go
use Students

create table Student(
	GrNumber int identity(1,1) primary key,
	SName varchar(100),
	SGender varchar(100),
	SAge int,
	SStd int
)

insert into Student values ('Arzu','Male',15,10), ('jay','Male',16,11), ('Sonu','Male',16,11)

select * from Student