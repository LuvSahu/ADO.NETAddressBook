CREATE PROCEDURE SpAddressBooks
@FirstName nvarchar(200),
@LastName  nvarchar(200),
@Address nvarchar(200),
@City nvarchar(200),
@State nvarchar(200),
@Zip bigint,
@Email nvarchar(200),
@PhoneNumber bigint
AS
insert into Addressbooks(FirstName,LastName,Address,City,State,Zip,Email,PhoneNumber) values(@FirstName,@LastName,@Address,@City,@State,@Zip,@Email,@PhoneNumber);

select * from AddressBooks;
