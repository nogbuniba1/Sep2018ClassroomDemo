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
	//**EXERCISE 9**
	//List all the Playlists which have at least one track. Show the playlist name, no of playlist tracks, the cost of the playlist and the total storage size of the playlist
	
	var results9 = from x in Playlists
					where x.PlaylistTracks.Count() > 0
					select new PlaylistSummary
					{
						name = x.Name,
						trackcount = x.PlaylistTracks.Count(),
						cost = x.PlaylistTracks.Sum(plt => plt.Track.UnitPrice),
						storage = x.PlaylistTracks.Sum(plt => plt.Track.Bytes/1000),
					};
	
	results9.Dump();
}

// Define other methods and classes here
public class PlaylistSummary
{
	public string name {get; set;}
	public int trackcount {get; set;}
	public decimal cost {get; set;}
	public double? storage {get; set;}
}