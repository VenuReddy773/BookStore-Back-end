create table BookTable
(   Book_id int not null identity(1,1) primary key,
	BookTitle varchar(100),
	BookAuthor varchar(100),
	Description varchar(500),
	Price int not null,
	DiscountedPrice int not null,
	Rating float not null,
	BookImage varchar(100),
	Quantity int not null,
	ReviewCount int	
)

select * from BookTable