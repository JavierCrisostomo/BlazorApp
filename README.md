# BlazorApp

SELECT FirstName + ' ' + LastName AS 'Full Name'
	,Age
	,OrderId
	,DateCreated
	,MethodOfPurchase AS 'Purchase Method'
	,ProductNumber
	,ProductOrigin
FROM Customer c WITH (NOLOCK)
INNER JOIN Orders o WITH (NOLOCK) ON c.PersonID = o.PersonID
INNER JOIN OrdersDetails d WITH (NOLOCK) ON o.OrderID = d.OrderID
WHERE ProductID = '1112222333'
