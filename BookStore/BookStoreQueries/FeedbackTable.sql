create table Feedback
(
         FeedbackId int not null identity (1,1) primary key,
		 user_id INT NOT NULL
		 FOREIGN KEY (user_id) REFERENCES userRegister(user_id),
	     Book_id INT NULL
		 FOREIGN KEY (Book_id) REFERENCES BookTable(Book_id),
		 Comments Varchar(max),
		 Ratings int		 
)

select * from Feedback


create procedure AddFeedback(
	@user_id int,
	@Book_id int,
	@Comments Varchar(max),
	@Ratings int
)		
As 
Declare @AverageRating int;
Begin
	IF (EXISTS(SELECT * FROM Feedback WHERE Book_id = @Book_id and user_id=@user_id))
		select 1; --already given feedback--
	Else
	Begin
		IF (EXISTS(SELECT * FROM BookTable WHERE Book_id = @Book_id))
		Begin
			Begin try
				Begin transaction
					Insert into Feedback (user_id,Book_id,Comments,Ratings )
						values (@user_id,@Book_id,@Comments,@Ratings);		
					select @AverageRating=AVG(Ratings) from Feedback where Book_id = @Book_id;
					Update BookTable set Rating=@AverageRating, ReviewCount=ReviewCount+1 where Book_id = @Book_id;
				Commit Transaction
			End Try
			Begin catch
				Rollback transaction
			End catch
		End
		Else
		Begin
			Select 2; 
		End
	End
End

-------------------------Get feedback---------------------------
alter procedure GetFeedback
(
	@Book_id int
)
AS
BEGIN
	select 
		Feedback.user_id,Feedback.Comments,Feedback.Ratings,userRegister.FullName,Feedback.FeedbackId
		FROM userRegister
		inner join Feedback
		on Feedback.user_id=userRegister.user_id
		where Book_id=@Book_id
END