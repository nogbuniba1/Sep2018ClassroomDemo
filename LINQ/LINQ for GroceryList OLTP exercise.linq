<Query Kind="Statements">
  <Connection>
    <ID>daa6e31e-10df-4613-8c1e-9a318269f43e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

var results = from x in OrderLists
				where x.QtyPicked == 0 && x.OrderID == 347
				 select new
				 {
				 	Product = x.Product.Description,
					Ordered = x.QtyOrdered,
					Picked = x.QtyPicked,
					Comment = x.CustomerComment,
					PickIssue = x.PickIssue
				 };
				
				
results.Dump();		

var results2 = from x in OrderLists
               where x.Order.CustomerID == 50
			   select new
				{
					Name = x.Order.Customer.FirstName + " " + x.Order.Customer.LastName,
					Contact = x.Order.Customer.Phone
				};
				
results2.Dump();


var results3 = from x in Orders
				where x.PickerID == 
				select x;
				
results3.Dump();
			   
			  
				

var results2 = (from x in Orders
               where x.OrderID == 1
                select x.CustomerID).SingleOrDefault();

var resCustomer = from x in Customers
					where x.CustomerID == (int) results2
					select x;
results2.Dump();
resCustomer.Dump();
							

var results3 = (from x in Orders
                                where x.OrderID == 1
                                select x.Customer).SingleOrDefault();
                 results3.Dump();