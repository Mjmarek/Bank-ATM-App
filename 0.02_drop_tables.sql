Begin Transaction

Drop Table Account
Drop Table Customer

Create Table Customer(
	CustomerID int Not Null,
	FirstName nvarchar(50) Not Null,
	LastName nvarchar(50) Not Null,
	Primary Key (CustomerID)
);

Create Table Account(
	AccountID int Not Null,
	AccountNumber int Not Null,
	AccountType nvarchar(25) Not Null,
	Balance money Not Null,
	PIN int Not Null,	
	CustomerID int Not Null,
	Primary Key (AccountID),
	Foreign Key (CustomerID) References Customer (CustomerID)
);

Commit
