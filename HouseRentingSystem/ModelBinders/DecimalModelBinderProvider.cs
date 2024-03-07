using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseRentingSystem.ModelBinders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {

        IModelBinder? IModelBinderProvider.GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }


}
