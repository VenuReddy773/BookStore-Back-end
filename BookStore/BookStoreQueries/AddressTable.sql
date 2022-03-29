create table AddressType
(
	TypeId int NOT NULL IDENTITY(1,1) primary key,
	Type varchar(20)
)
insert into AddressType (Type) values ('Home')
insert into AddressType (Type) values ('Work')
insert into AddressType (Type) values ('Others')

select * from AddressType


create table Address
(
    AddressId int NOT NULL IDENTITY(1,1) primary key,
	user_id INT NOT NULL
	FOREIGN KEY (user_id) REFERENCES userRegister(user_id),
	Address varchar(max) not null,
	City varchar(100),
	State varchar(100),
	TypeId int
	FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId)
)

select * from Address



create procedure AddAddress
(
		@user_id int,
        @Address varchar(600),
		@City varchar(50),
		@State varchar(50),
		@TypeId int	
)		
As 
Begin try
	IF (EXISTS(SELECT * FROM userRegister WHERE @user_id = @user_id))
	Begin
	Insert into Address (user_id,Address,City,State,TypeId )
		values (@user_id,@Address,@City,@State,@TypeId);
	End
	Else
	Begin
		Select 1
	End
End try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure UpdateAddress
(
		@AddressId int,
		@Address varchar(600),
		@City varchar(50),
		@State varchar(50),
		@TypeId int	
)
As 
Begin try
	IF (EXISTS(SELECT * FROM Address WHERE AddressId = @AddressId))
	Begin
	update Address set Address=@Address,City=@City,State=@State,TypeId=@TypeId where AddressId = @AddressId
	End
	Else
	Begin
		Select 1
	End
End try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create PROCEDURE GetAllAddresses
AS
BEGIN try
	 begin
	   SELECT * FROM Address
   	 end
End try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch



create PROCEDURE GetAddressbyUserid
  @user_id int
AS
BEGIN try

     IF(EXISTS(SELECT * FROM Address WHERE user_id=@user_id))
	 begin
	   SELECT * FROM Address WHERE user_id=@user_id;
   	 end
	 else
	 begin
		select 1
	end
End try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch
