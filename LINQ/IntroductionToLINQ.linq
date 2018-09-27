<Query Kind="Expression">
  <Connection>
    <ID>94b300ef-a0e3-45c7-ae6f-0027f4bb745e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Query syntax
//Find all albums released btw 2007 and 2010 inclusive
from x in Albums
where x.ReleaseYear >= 2007 && x.ReleaseYear <= 2010
select x


//Find all customers who are from the US, order by lastname then firstname
from x in Customers
where x.Country.Equals("USA")
orderby x.LastName, x.FirstName
select x


//Find all USA cutomers who have an email having yahoo. Show only the customer full name and email
from x in Customers
where x.Country.Equals("USA") && x.Email.Contains("yahoo")
select new
{
	FullName = x.LastName + "," + x.FirstName,
	Email = x.Email
}


//Create an alpahbetic list of albums showing album title and release year. Include the artistname
from x in Albums
orderby x.Title
select new
{
	Title = x.Title, 
	Year = x.ReleaseYear,
	ArtistName = x.Artist.Name
}

//List the albums for U2 showing title and release year. Order by release year

from x in Albums
where x.Artist.Name.Equals("U2")
orderby x.ReleaseYear
select new
{
	Title = x.Title, 
	Year = x.ReleaseYear
}


//Method Syntax
//Albums
   //.Where (rowPlaceholder => rowPlaceholder.ArtistId.Equals (22))
   //.OrderBy (rowPlaceholder => rowPlaceholder.ReleaseYear)