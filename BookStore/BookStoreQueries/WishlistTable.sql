create table Wishlist
(
	WishlistId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT NOT NULL
	FOREIGN KEY (user_id) REFERENCES userRegister(user_id),
	Book_id INT NOT NULL
	FOREIGN KEY (Book_id) REFERENCES BookTable(Book_id)	
)


select * from Wishlist

alter PROCEDURE CreateWishlist
	@user_id INT,
	@Book_id INT
AS
BEGIN TRY
	IF EXISTS(SELECT * FROM Wishlist WHERE Book_id = @Book_id AND user_id = @user_id)
		SELECT 1;
	ELSE
	BEGIN
		IF EXISTS(SELECT * FROM BookTable WHERE Book_id = @Book_id)
		BEGIN
			INSERT INTO Wishlist(user_id,Book_id)
			VALUES ( @user_id,@Book_id)
		END
		ELSE
			SELECT 2;
	END
END TRY
BEGIN CATCH
SELECT
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
END CATCH


CREATE PROCEDURE DeleteWishlist
	@WishlistId INT
AS
BEGIN TRY
		DELETE FROM Wishlist WHERE WishlistId = @WishlistId
END TRY
BEGIN CATCH
SELECT
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
END CATCH


alter PROCEDURE ShowWishlistbyUserId
  @user_id int
AS
BEGIN TRY
	   select 
		BookTable.Book_id,BookTable.BookTitle,BookTable.BookAuthor,BookTable.DiscountedPrice,BookTable.Price,BookTable.BookImage,BookTable.Description,BookTable.Quantity,BookTable.ReviewCount,BookTable.Rating,Wishlist.WishlistId,Wishlist.user_id,Wishlist.Book_id
		FROM BookTable
		inner join Wishlist
		on Wishlist.Book_id=BookTable.Book_id where Wishlist.user_id=@user_id
END TRY
BEGIN CATCH
SELECT
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
END CATCH