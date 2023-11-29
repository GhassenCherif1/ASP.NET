using System.ComponentModel.DataAnnotations.Schema;
using TP3.Models;
namespace TP3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }
        public virtual MembershipType? MembershipType { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
