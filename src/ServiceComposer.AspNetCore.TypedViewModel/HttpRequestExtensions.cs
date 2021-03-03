using System;
using ImpromptuInterface;
using Microsoft.AspNetCore.Http;
using ServiceComposer.AspNetCore.TypedViewModel;

namespace ServiceComposer.AspNetCore
{
    public static class HttpRequestExtensions
    {
        public static T GetTypedViewModel<T>(this HttpRequest request) where T : class
        {
            var vm = request.GetComposedResponseModel();
            T myInterface = Impromptu.ActLike(vm);

            return myInterface;

            // var message = $"Cannot convert view model to {typeof(T).Name}. Make sure " +
            //               $"{typeof(T).Name} was registered as typed view model at configuration " +
            //               $"time by calling options.RegisterTypedViewModel<{typeof(T).Name}>().";
            // throw new InvalidCastException(message);
        }
    }
}