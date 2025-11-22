create database DapperExampleQuery
use DapperExampleQuery

create table dbo.person(
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	surname nvarchar(50),
	Age int
)

insert into dbo.person values ('rakesh', 'shah', 21), ('nilesh', 'desai', 22), ('mahendara', 'dhoni', 21)

select * from dbo.person



--Parameters: @Name, @Surname, @Age
create procedure sp_GetAll
as
begin
	set nocount on; --આ સ્ટેટમેન્ટ ડેટાબેઝ ક્લાયંટને 'X rows affected' સંદેશ મોકલવાથી અટકાવે છે, જે ખાસ કરીને Dapper જેવી એપ્લિકેશન્સમાં પ્રદર્શન 
					--સુધારે છે.
	select * from dbo.person
end
go

create procedure sp_GetPersonById
	@PersonId int
as begin
	set nocount on;
	select * from person
	where
	Id = @PersonId;
end
go
create Procedure sp_AddPerson
	@Name nvarchar(50), -- we can give here any name instead of @Name
	@surname nvarchar(50),
	@Age int
As
Begin
	Insert into person(Name,surname,Age) values (@Name,@surname,@Age);
End
Go
create procedure sp_EditPerson
	@Id int,
	@Name nvarchar(30),
	@Surname nvarchar(50),
	@Age int
as
begin
	update dbo.person 
	set
		Name = @Name,
		surname = @Surname,
		Age = @Age 
	where 
		Id = @Id
end
Go
create procedure sp_DeletePerson
	@Id int
as
begin
	delete from person
	where
	Id = @Id
end 
go
	