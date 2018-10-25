using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.PlaylistTracks
                              where x.Playlist.UserName.Equals(username) && x.Playlist.Name.Equals(playlistname)
                              orderby x.TrackNumber
                              select new UserPlaylistTrack
                              {
                                  TrackID = x.TrackId,
                                  TrackNumber = x.TrackNumber,
                                  TrackName = x.Track.Name,
                                  Milliseconds = x.Track.Milliseconds,
                                  UnitPrice = x.Track.UnitPrice
                              };

                return results.ToList();
            }
        }//eom

        //This method is an OLTP complex method
        //This method may alter multiple tracaks
        //This method requires the design to properly deisgn a solution BEFORE attempting to code
        public void Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            //The using sets up the transaction environment. If the logic does not reach a.SaveChanges method, all work is rolled back
            //a List<string> to be used to handle any erroes generated while doing the transaction.
            //All errors can then be returned to the MessageUserControl for display

            List<string> reasons = new List<string>();
            using (var context = new ChinookContext())
            {
                //code to go here
                //PART One 
                //Determine if a new playlist is needed
                //Determine the tracknumber dependent on if a playlist already exists
                Playlist exists = context.Playlists
                                   .Where(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Name.Equals(playlistname,StringComparison.OrdinalIgnoreCase))
                                   .Select(x => x).FirstOrDefault();

                //Create an instance for the PlaylistTrack
                PlaylistTrack newTrack = null;

                //Initialize a loacl tracknumber
                int tracknumber = 0;
                if(exists == null)
                {
                    //This is a new playlist being created
                    exists = new Playlist();
                    exists.Name = playlistname;
                    exists.UserName = username;
                    exists = context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    //This is an existing playlist

                    //Calculate the new proposed track number
                    tracknumber = exists.PlaylistTracks.Count() + 1;

                    //Business Rule - A track may only exist once on a playlist. It may exist on many different playlists
                    //.SingleOrDefault expects a single instance to be returned
                    newTrack = exists.PlaylistTracks.SingleOrDefault(x => x.TrackId == trackid);
                    if(newTrack != null)
                    {
                        reasons.Add("Track already exists on the playlist");
                    }
                    if(reasons.Count() > 0)
                    {
                        //Issue the BusinessRuleException(title, list of error strings)
                        throw new BusinessRuleException("Adding track to playlist", reasons);
                    }
                    else
                    {
                        //Part Two: Add to track
                        newTrack = new PlaylistTrack();
                        newTrack.TrackId = trackid;
                        newTrack.TrackNumber = tracknumber;

                        //What about the PlaylistID?
                        //Note: The PKey for PlaylistID may not yet exists. 
                        //Using navigation properties, one can let HashSet handle the expected PlaylistID pkey value
                        exists.PlaylistTracks.Add(newTrack);

                        //At this point, all records are in staged state. Physically, add all data for the to the database and commit
                        context.SaveChanges();
                    }

                }
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                //code to go here 

            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
               //code to go here


            }
        }//eom
    }
}
