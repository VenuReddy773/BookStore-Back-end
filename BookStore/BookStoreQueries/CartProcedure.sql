create table CartTable(CartId int identity (1,1) primary key, user_id int foreign key (user_id) references UserRegister(user_id), Book_id int foreign key (Book_id) references BookTable(Book_id), OrderQuantity int default 1)

select * from CartTable

create procedure AddBookToCart
(
 @user_id int,
 @Book_id int,
 @OrderQuantity int
)
as
begin try
	if(Exists(select * from BookTable where Book_id=@Book_id))
	begin
		insert into CartTable (user_id,Book_id,OrderQuantity) values (@user_id,@Book_id,@OrderQuantity)
	end
	else
	begin
		select 2
	end
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure UpdateCart
(
 @CartId int,
 @OrderQuantity int
)
as
begin try
	if(Exists(select * from CartTable where CartId=@CartId))
	begin
		update CartTable set OrderQuantity=@OrderQuantity where CartId=@CartId
	end
	else
	begin
		select 2
	end
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure DeleteCart
(
 @CartId int
)
as
begin try
	if(Exists(select * from CartTable where CartId=@CartId))
	begin
		delete from CartTable where CartId=@CartId
	end
	else
	begin
		select 2
	end
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


create procedure GetCart
(
 @user_id int
)
as
begin try
	select CartTable.CartId,CartTable.Book_id,CartTable.user_id,CartTable.OrderQuantity,BookTable.BookTitle,BookTable.BookAuthor,BookTable.DiscountedPrice,BookTable.Price,BookTable.Description,BookTable.Rating,BookTable.BookImage,BookTable.ReviewCount,BookTable.Quantity from CartTable inner join BookTable on CartTable.Book_id = BookTable.Book_id where CartTable.user_id = @user_id
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch