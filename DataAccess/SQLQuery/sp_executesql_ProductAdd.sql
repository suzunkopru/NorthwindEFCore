exec sp_executesql 
'SET IMPLICIT_TRANSACTIONS OFF;
SET NOCOUNT ON;
Declare @p0 int, @p1 bit, @p2 nvarchar(40), @p3 nvarchar(20),
@p4 smallint, @p5 int, @p6 money, @p7 smallint, @p8 smallint
Select @p0=2, @p1=0, @p2=N''5Yeni Ürün'',
@p3=N''5Koli içinde 12 adet'',
@p4=10, @p5=4, @p6=$150.0000, @p7=2, @p8=10
INSERT INTO 
[Products] ([CategoryID], [Discontinued], 
[ProductName], [QuantityPerUnit], 
[ReorderLevel], [SupplierID], 
[UnitPrice], [UnitsInStock], [UnitsOnOrder])
OUTPUT INSERTED.[ProductID]
VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8);'