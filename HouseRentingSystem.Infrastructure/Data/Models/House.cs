using HouseRentingSystem.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HouseRentingSystem.Infrastructure.Data.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.TitleMinLength)]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(DataConstants.AddressMinLength)]
        [MaxLength(DataConstants.AddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MinLength(DataConstants.DescriptionMinLength)]
        [MaxLength(DataConstants.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;


        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), DataConstants.PricePerMonthMinLength, DataConstants.PricePerMonthMaxLength, ConvertValueInInvariantCulture = true)]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

       
        public Category Category { get; set; } = null!;

        [Required]
        public int AgentId { get; set; }

       
        public Agent Agent { get; set; } = null!;

        public string RenterId { get; set; } = string.Empty;

    }
}
