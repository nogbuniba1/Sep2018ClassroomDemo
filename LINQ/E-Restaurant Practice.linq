<Query Kind="Statements">
  <Connection>
    <ID>35e7aa34-0d60-4bff-a8b0-808ab723edcd</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var ex1 = from x in Reservations
			where x.ReservationDate.Year == 2014 && x.ReservationDate.Month == 05 && x.ReservationDate.Day == 29
			group x by x.ReservationDate.Hour into gReserv
			select gReserv;

var ex2 = from x in Bills
			where x.PaidStatus.Equals("False")
			select new
			{
				BillID = x.BillID,
				Name = x.Waiter.FirstName + " " + x.Waiter.LastName,
				Placed = x.OrderPlaced,
				Ready = x.OrderReady,
				Served = x.OrderServed
			};
ex2.Dump();

var ex3 = from x in BillItems
//			where x.Bill.OrderReady.HasValue && !x.Bill.OrderServed.HasValue
			group x by x.Bill into gItem
			select new
			{
				table = gItem.Key.TableID,
				Description = gItem,
//				Quantity = gItem.Key.Quantity
			};
			
			
ex3.Dump();

from customer in Bills
where !customer.OrderPlaced.HasValue
select new
{
    BillId = customer.BillID,
    Name = customer.Waiter.FirstName + " " + customer.Waiter.LastName,
    TableId = customer.TableID,
    NumberInParth = customer.NumberInParty
}

var ex5 = from x in BillItems
			where x.Bill.OrderPlaced.HasValue && !x.Bill.OrderReady.HasValue
			select new
			{
				Table = x.Bill.TableID,
				BillID = x.BillID,
				Type = x.Item.MenuCategory.Description
				

			};

ex5.Dump();







var ex5 = from x in Bills
			where x.OrderPlaced.HasValue && !x.OrderReady.HasValue
			select new
			{
				tableID = x.TableID,
				description = x.BillItems.ItemID
			};
			
			ex5.Dump();
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			
			