using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Movie added")]
        public DateTime? Date { get; set; }
        public string Photo { get; set; }
        [ForeignKey("Genre")]
        public int genre_Id { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Customer>? Customers { get; set;}
        

    }
}
