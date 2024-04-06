//using HotelRate2.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

internal class CustomFormCollectionModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(FormCollection))
        {
            return new CustomFormCollectionModelBinder();
        }

        return null;
    }
}

public class CustomFormCollectionModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var formCollection = bindingContext.HttpContext.Request.Form;
        bindingContext.Result = ModelBindingResult.Success(formCollection);
        return Task.CompletedTask;
    }
}
