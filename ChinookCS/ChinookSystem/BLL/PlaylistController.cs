using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
using Chinook.Data.DTOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<PlaylistSummary> Playlist_GetPlaylistSummary()
        {
            //In Visual studio, we are using Linq to Entities whereas in LinQPad, we are using Linq to SQL
            //Access to our entities is via the COntext classs which contain the need DbSet<>s
            using (var context = new ChinookContext())
            {
                //Enter the LINQ Query
                var results9 = from x in context.Playlists
                               where x.PlaylistTracks.Count() > 0
                               select new PlaylistSummary
                               {
                                   name = x.Name,
                                   trackcount = x.PlaylistTracks.Count(),
                                   cost = x.PlaylistTracks.Sum(plt => plt.Track.UnitPrice),
                                   storage = x.PlaylistTracks.Sum(plt => plt.Track.Bytes / 1000),
                               };
                //Remember!! .Dump() is strinctly for LINQPad
                //results9.Dump();
                return results9.ToList();
            }
        }
    }
}
