create table Orders
(
         OrderId int not null identity (1,1) primary key,
		 user_id INT NOT NULL,
		 FOREIGN KEY (user_id) REFERENCES userRegister(user_id),
		 AddressId int
		 FOREIGN KEY (AddressId) REFERENCES Address(AddressId),
	     Book_id INT NOT NULL
		 FOREIGN KEY (Book_id) REFERENCES BookTable(Book_id),
		 TotalPrice int,
		 BookQuantity int,
		 OrderDate DateTime
)

select * from Orders



create procedure AddingOrders
	@user_id int,
	@AddressId int,
	@Book_id INT ,
	@BookQuantity int
AS
	Declare @Total int
BEGIN
	Select @Total=DiscountedPrice from BookTable where Book_id = @Book_id;
	IF (EXISTS(SELECT * from BookTable WHERE Book_id = @Book_id))
	begin
		IF (EXISTS(SELECT * from userRegister WHERE user_id = @user_id))
		Begin
		Begin try
			Begin transaction			
				INSERT INTO Orders(user_id,AddressId,Book_id,TotalPrice,BookQuantity,OrderDate)
				VALUES ( @user_id,@AddressId,@Book_id,@BookQuantity*@Total,@BookQuantity,GETDATE())
				Update BookTable set Quantity=Quantity-@BookQuantity
				Delete from CartTable where Book_id = @Book_id and user_id = @user_id
			commit Transaction
		End try
		Begin catch
			Rollback transaction
		End catch
		end
		Else
		begin
			Select 1
		end
	end 
	Else
	begin
			Select 2
	end	
END


create procedure GetAllOrders
	@user_id int
AS
BEGIN
	select 
		BookTable.Book_id,BookTable.BookTitle,BookTable.BookAuthor,BookTable.DiscountedPrice,BookTable.Price,BookTable.BookImage,Orders.OrderId,Orders.OrderDate
		FROM BookTable
		inner join Orders
		on Orders.Book_id=BookTable.Book_id where Orders.user_id=@user_id
END
