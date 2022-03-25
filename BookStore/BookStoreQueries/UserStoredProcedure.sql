create procedure AddUser
(
	@FullName varchar(100),
	@EmailId varchar(100),
	@Password varchar(100),
	@MobileNumber varchar(20)
)
as 
begin try
insert into userRegister values(@FullName,@EmailId,@Password,@MobileNumber)
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch


alter procedure UserLogin
(
 @EmailId varchar(100),
 @Password varchar(100)
)
as
begin try     
		select * from userRegister where (EmailId=@EmailId and Password=@Password)
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

alter procedure ForgotPassword
(
 @EmailId varchar(100)
)
as
begin try     
		update userRegister set Password=NULL where (EmailId=@EmailId)
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch

create procedure ResetPassword
(
 @EmailId varchar(100),
 @Password varchar(100)
)
as
begin try     
		update userRegister set Password=@Password where (EmailId=@EmailId)
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch