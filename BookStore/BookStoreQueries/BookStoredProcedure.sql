create procedure AddBook
(
	@BookTitle varchar(100),
	@BookAuthor varchar(100),
	@Description varchar(500),
	@Price int,
	@DiscountedPrice int,
	@Rating float,
	@BookImage varchar(100),
	@Quantity int,
	@ReviewCount int	

)
as 
begin try
insert into BookTable values(@BookTitle,@BookAuthor,@Description,@Price,@DiscountedPrice,@Rating,@BookImage,@Quantity,@ReviewCount)
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch

create procedure GetAllBooks
as 
begin try
select * from BookTable  
end try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrorMessage;
end catch