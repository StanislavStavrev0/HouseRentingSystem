using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Core.ViewModels.Agent
{
    public class BecomeAgentFormModel
    {
        //[Required(ErrorMessage = RequiredMessage)]
        //[StringLength(PhoneNumberMaxLength,
        //    MinimumLength = PhoneNumberMinLength,
        //    ErrorMessage = LengthMessage)]
        [Display(Name = "Phone Number")]
        [Phone()]
        public string PhoneNumber { get; set; } = null!;
    }
}
