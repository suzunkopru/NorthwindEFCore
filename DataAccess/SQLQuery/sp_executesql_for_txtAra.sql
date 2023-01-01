Exec sp_executesql 
N'Declare @__txt_Text_0 nvarchar(40)
Set @__txt_Text_0 = ''cha''
SELECT [p].[ProductID], [p].[CategoryID], 
[p].[Discontinued], [p].[ProductName], 
[p].[QuantityPerUnit], [p].[ReorderLevel], 
[p].[SupplierID], [p].[UnitPrice], 
[p].[UnitsInStock], [p].[UnitsOnOrder]
FROM [Products] AS [p]
WHERE CHARINDEX(@__txt_Text_0, [p].[ProductName]) > 0'