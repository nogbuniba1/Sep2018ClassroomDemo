<Query Kind="Program">
  <Connection>
    <ID>94b300ef-a0e3-45c7-ae6f-0027f4bb745e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
//EXERCISE 1
//Create a list of Albums showing its title and artist. Show ablums with 25 or more tracks only
//For each album, show the songs on the album and their length

//-------USING IENUMERABLE------------------
//	var results = from x in Albums
//					where x.Tracks.Count() > 24
//					select new AnAlbum
//					{
//						artist = x.Artist.Name,
//						title = x.Title,
//						songs = from y in x.Tracks
//								select new Song
//								{
//									songname = y.Name,
//									length = y.Milliseconds/60000 + ":" + (y.Milliseconds%60000)/1000
//								}
//					};
//					results.Dump();


//-------------------------OR---------------------------------------------
//-------------USING TOLIST()----------------
	var results1 = from x in Albums
					where x.Tracks.Count() > 24
					select new AnAlbum
					{
						artist = x.Artist.Name,
						title = x.Title,
						songs = (from y in x.Tracks
								select new Song
								{
									songname = y.Name,
									length = y.Milliseconds/60000 + ":" + (y.Milliseconds%60000)/1000
								}).ToList()
					};
					results1.Dump();
}



// Define other methods and classes here

//Song is the POCO
public class Song
{
	public string songname {get; set;}
	public string length {get; set;}
}

//AnAlbum is the DTO. It has structure (a set of data on each instance of the class)
public class AnAlbum
{
	public string artist {get; set;}
	public string title {get; set;}
	public List<Song> songs {get; set;}
}
