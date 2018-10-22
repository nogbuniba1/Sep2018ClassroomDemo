<Query Kind="Expression">
  <Connection>
    <ID>bda6452f-404d-474e-9916-cf050d5aa1f8</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Rules:
// 1. if you have a navigational property between the tables
//    this should be your first choice of attack
// 2. if you do not have a navigational property then you can
//    do a join of your tables

//assume for this example that there is no navigational property
//between Artists and Albums

//the first table to be referenced should be the main processing data pile
//the other table(s) are the support tables to the first table

from x in Albums
join y in Artists on x.ArtistId equals y.ArtistId
select new
{
	Title = x.Title,
	Year = x.ReleaseYear,
	Label = x.ReleaseLabel == null ? "unknown" : x.ReleaseLabel,
	Artist = y.Name,
	trackcount = x.Tracks.Count()
}