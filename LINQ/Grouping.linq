<Query Kind="Expression">
  <Connection>
    <ID>94b300ef-a0e3-45c7-ae6f-0027f4bb745e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Grouping of Data within itself 
//** a) by column
//** b) by multiple columns
//** c) by an entity

//Grouping can be saved temporarily into a dataset and that dataset can be report on
//The grouping attribute is referred to as the .Key
//Multiple attributes or entity use .Key.Attribute

//EXAMPLE 1: Report albums in Release year
from x in Albums
group x by x.ReleaseYear into gYear
select gYear

from x in Albums
group x by x.ReleaseYear into gYear
select new
	{
		year = gYear.Key,
		numberofalbumsforyear = gYear.Count(),
		albumandartist = from y in gYear
							select new
							{
								title = y.Title,
								artist = y.Artist.Name,
								albumsongcount = y.Tracks.Count()
							}
	}
	

//EXAMPLE 2: Grouping of Tracks by Genre namefrom 2010
//Actions against your data BEFORE grouping is done again the natural entity attribute
//Actions done after grouping MUST refer to the temporary dataset group

//In this example, grouping can be done against a complete Entity. This type of groupin produces a KEY set of ALL Entity Attributes
from t in Tracks
where t.Album.ReleaseYear > 2010
group t by t.Genre into gTemp
orderby gTemp.Count() descending
select new
	{
		genre = gTemp.Key.Name,
		numberof = gTemp.Count()
	}
	
	
	
	

//EXAMPLE 3: create a list of employees showing the customers that each employee supports

//What is the datapiletogroup? Customers
//What is the grouping attribute criteria? by Employee

from x in Customers
group x by x.SupportRepIdEmployee into gEmployeeCustomerList
select new
		{
			FirstName = gEmployeeCustomerList.Key.FirstName,
			LastName = gEmployeeCustomerList.Key.LastName,
			Phone = gEmployeeCustomerList.Key.Phone,
			Email = gEmployeeCustomerList.Key.Email,
			NumberOfCustomers = gEmployeeCustomerList.Count(),
			CustomerList = from y in gEmployeeCustomerList
							select new
			{
				Name = y.LastName + ", " + y.FirstName,
				Phone = y.Phone,
				Email = y.Email
			}
			
		}
