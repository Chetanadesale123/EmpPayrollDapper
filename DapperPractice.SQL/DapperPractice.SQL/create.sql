use Payroll_service

Create Table tbl_Employees
(
id int primary key identity(1,1),
FirstName Nvarchar(50) not null,
LastName Nvarchar(50) not null,
Address Nvarchar(50) not null,
Mobile Nvarchar(50) not null
)
exec sp_columns tbl_Employees --to describe table

insert into tbl_Employees(FirstName,LastName,Address,Mobile) values('Chetana','Desale','Hinjevadi,pune.','6543218778')
insert into tbl_Employees(FirstName,LastName,Address,Mobile) values('vidya','Patil','Bellandur,Banglore.','9199112358')
select * from tbl_Employees