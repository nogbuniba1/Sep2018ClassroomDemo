using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Chinook.Data.Entities
{
    [Table("Artists")]
    public class Artist
    {
        //This is the default for Primary key - [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //For a compound Key - [Key, Column (Order = 1)] for the first key, [Key, Column (Order = 2)] for the 2nd key etc.

        [Key]                  
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(120, ErrorMessage = "Name is limited to 120 Characters")]
        public string Name { get; set; }
    }
}
