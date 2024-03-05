using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)] //this will put unique constraints in the DB table generation
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.DataConstants.PhoneNumberMinLength)]
        [MaxLength(Constants.DataConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<House> Houses { get; set; } = new List<House>();
    }
}
