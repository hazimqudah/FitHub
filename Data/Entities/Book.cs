using System.ComponentModel.DataAnnotations;

namespace FitHub.Data.Entities
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Comment { get; set; }
    }
}
