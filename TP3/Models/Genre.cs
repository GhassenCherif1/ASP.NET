using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter the Name")]
        public string GenreName { get; set; }
        public virtual ICollection<Movie> Movies { get;}
    }
}
