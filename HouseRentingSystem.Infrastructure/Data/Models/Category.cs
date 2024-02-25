using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Infrastructure.Constants;
namespace HouseRentingSystem.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.HouseNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public List<House> Houses { get; set; } = new List<House>();
    }
}
