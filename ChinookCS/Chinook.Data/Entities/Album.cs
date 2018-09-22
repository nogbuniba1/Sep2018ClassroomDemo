using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Chinook.Data.Entities
{
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(160, ErrorMessage = "Title is limited to 160 characters")]
        public string Title { get; set; }

        public int ArtistId { get; set; }       //The default value of an "int" is 0, so we don't need to put the required error message

        public int ReleaseYear { get; set; }

        [StringLength(50, ErrorMessage = "Release label is limited to 50 characters")]
        public string ReleaseLabel { get; set; }

        //Navigation Properties 
        public virtual Artist Artist { get; set; }

        //Navigation Properties 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
