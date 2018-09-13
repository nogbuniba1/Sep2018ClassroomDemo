using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;    //For ODS

#endregion


namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Artist> Artist_List()                       //To show the list of artists
        {
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Artist Artist_Find(int artistid)                     //To find a particular artist
        {
            using (var context = new ChinookContext())
            {
                return context.Artists.Find(artistid);
            }
        }
    }
}
