<Query Kind="Statements">
  <Connection>
    <ID>94b300ef-a0e3-45c7-ae6f-0027f4bb745e</ID>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Using the statement language environment, we code complete C# statements, which include the LINQ Query and a receiving variable .
//The statements will end with the semi-colon(;)
//To see the contents of the receiving variable, you will use the LINQPad command .Dump()
//.Dump() is NOT a C# method. It is a LINQPad method

//**EXERCISE 1**
//List the albums for U2 showing title and release year. Order by release year
var results = from x in Albums
				where x.Artist.Name.Equals("U2")
				orderby x.ReleaseYear
				select new
				{
					Title = x.Title, 
					Year = x.ReleaseYear
				};
results.Dump();


//**EXERCISE 2**
//Ternary Operator - condition(s) ? trueValue : falseValue
var results2 = from x in Albums
				orderby x.ReleaseLabel
				select new
				{
					title = x.Title,
					label = x.ReleaseLabel == null ? "unknown": x.ReleaseLabel
				};
results2.Dump();


//**EXERCISE 3**
//A list of albums showing the title and decade of release. Albums from 1970 to 1979 are 70s; 1980 to 1989 are 80s; 1990 to 1999 are 90s; 2000+ are modern
var results3 = from x in Albums
				orderby x.ReleaseYear
				select new
				{
					title = x.Title,
					decade = x.ReleaseYear >= 1970 && x.ReleaseYear <= 1979 ? "70s" : 
								(x.ReleaseYear >= 1980 && x.ReleaseYear <= 1989 ? "80s" :
								(x.ReleaseYear >= 1990 && x.ReleaseYear <= 1999 ? "90s" : 
								"Modern"))
				};
results3.Dump();


//**EXERCISE 4**
//Situation: I need a value from a query that will be used in a future query
//Create a list of Tracks showing the track name and whether the track is longer than the track average length or shorter or of the average

//This first query is obtaining a value tha will be used in a future step
var resultaverage = (from x in Tracks
					select x.Milliseconds).Average();

//This query is using a value created by a previous query
var results4 = from x in Tracks
			select new
				{
					Song = x.Name,
					Time = x.Milliseconds,
					Length = x.Milliseconds > resultaverage ? "Long" :
								(x.Milliseconds < resultaverage ? "Short" :
									"Average")
				};
resultaverage.Dump();
results4.Dump();




//Aggregates
//These are : .Average(), .Sum(), .Count(), .Min(), .Max()
//Aggregates MUST be done against a collection(0, 1 or more rows)

//**EXERCISE 5**
//List all albums with title artist name and the number of tracks on that album

var results5 = from x in Albums
				select new
				{
					title = x.Title,
					artist = x.Artist.Name,
					trackcount = x.Tracks.Count()
				};
results5.Dump();
	

//**EXERCISE 6**
//Create a list of artists with their albums counts order by descending album count
var results6 =  from x in Artists
				orderby x.Albums.Count() descending
				select new
				{
					artist = x.Name,
					albumcount = x.Albums.Count()
				};
results6.Dump();

//**EXERCISE 7**
//Find the maximum number of albums for all artists i.e. what is the most albums
var results7 = (from x in Artists
 				select x.Albums.Count()).Max();		

//who is that artist
var results7b = from x in Artists
 				where x.Albums.Count() == results7
				select x;
results7.Dump();
results7b.Dump();

//results7c is the combination of results7 and results7b
var results7c = from x in Artists
 				where x.Albums.Count() == (from y in Artists 
											select y.Albums.Count()).Max()								
				select x;		
results7c.Dump();


//**EXERCISE 8**
//Produce a list of Albums which have tracks showing their title, artist, number of tracks on album, total price of all tracks, longest, shortest and average track
var results8 = from x in Albums
				where x.Tracks.Count() > 0
				select new
				{
					title = x.Title,
					artist = x.Artist.Name,
//					numberoftracks = (from y in x.Tracks 
//										select y).Count(),
					methodnumberoftracks = x.Tracks.Count(),
					
					cost = x.Tracks.Sum(y => y.UnitPrice),
					longest = x.Tracks.Max(y => y.Milliseconds),
					shortest = x.Tracks.Min(y => y.Milliseconds),
					average = x.Tracks.Average(y => y.Milliseconds),
				};

results8.Dump();

//**EXERCISE 9**
//List all the Playlists which have at least one track. Show the playlist name, no of playlist tracks, the cost of the playlist and the total storage size of the playlist

var results9 = from x in Playlists
				where x.PlaylistTracks.Count() > 0
				select new
				{
					name = x.Name,
					trackcount = x.PlaylistTracks.Count(),
					cost = x.PlaylistTracks.Sum(plt => plt.Track.UnitPrice),
					storage = x.PlaylistTracks.Sum(plt => plt.Track.Bytes/1000),
				};

results9.Dump();