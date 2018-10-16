<Query Kind="Program">
  <Connection>
    <ID>b7724731-12ce-4ece-8977-5ef3ead68b90</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>OMST_2018</Database>
  </Connection>
</Query>

void Main()
{
	var locationlist = from x in Locations
						select new
						{	
							desc = x.Description,
							phone = x.Phone,
							theatrelist = (from y in x.Theatres
											select new
											{	
												theatrenumber = y.TheatreNumber,
												seatingsize = y.SeatingSize
											}).ToList()
							
						};
						locationlist.Dump();
}

// Define other methods and classes here
