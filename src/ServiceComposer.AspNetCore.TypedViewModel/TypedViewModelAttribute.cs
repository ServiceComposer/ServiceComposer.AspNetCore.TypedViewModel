using System;

namespace ServiceComposer.AspNetCore.TypedViewModel
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class TypedViewModelAttribute : Attribute
    {
        public TypedViewModelAttribute(Type viewModelType)
        {
            if (!viewModelType.IsInterface)
            {
                var message =$"{viewModelType.Name} cannot be used as a typed model. Only interfaces are supported.";
                throw new ArgumentException(message);
            }

            Type = viewModelType;
        }

        public Type Type { get; }
    }
}