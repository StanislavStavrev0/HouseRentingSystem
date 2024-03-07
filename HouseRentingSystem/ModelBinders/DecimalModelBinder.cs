using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace HouseRentingSystem.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal result = 0M;
                bool success = false;

                try
                {
                    string strValue = valueResult.FirstValue.Trim();
                    strValue = strValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    strValue = strValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    result = Convert.ToDecimal(strValue, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (Exception)
                {
                    // Optionally log the error or handle it as needed
                    success = false;
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                }
                else
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Decimal value is invalid.");
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }
            return Task.CompletedTask;
        }

          
        
        
    }
}
