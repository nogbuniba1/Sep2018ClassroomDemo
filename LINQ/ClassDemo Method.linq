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
	string tracksby = "Genre";
	int argid = 1;
	var res = from x in Tracks
				where (tracksby.Equals ("Artist") && x.Album.ArtistId.Equals(argid)) 
				|| (tracksby.Equals ("Genre") && x.GenreId.Equals(argid)) 
				|| (tracksby.Equals ("MediaType") && x.MediaTypeId.Equals(argid)) 
				||(tracksby.Equals ("Album") && x.AlbumId.Equals(argid))
				
				select new TrackList
					{
						TrackID = x.TrackId,
						Name = x.Name,
						Title = x.Album.Title,
						MediaName = x.MediaType.Name,
						GenreName = x.Genre.Name,
						Composer = x.Composer,
						Milliseconds = x.Milliseconds,
						Bytes = x.Bytes,
						UnitPrice = x.UnitPrice
					};
		res.Dump();
}

// Define other methods and classes here

	
	public class TrackList
    {
        public int TrackID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string MediaName { get; set; }
        public string GenreName { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }
    }