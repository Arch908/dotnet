using System.ComponentModel.DataAnnotations;

namespace FoodMenu.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
