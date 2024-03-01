using LastLastChance.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace LastLastChance.Models
{
    public class Book: LastLastChance.Data.Base.IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
