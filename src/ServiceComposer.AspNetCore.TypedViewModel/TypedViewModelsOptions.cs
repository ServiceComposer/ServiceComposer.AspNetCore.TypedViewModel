using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceComposer.AspNetCore
{
    public class TypedViewModelsOptions
    {
        HashSet<Type> viewModelTypes = new();

        public IEnumerable<Type> ViewModelTypes { get { return viewModelTypes; } }

        public void RegisterTypedViewModel<TViewModel>()
        {
            RegisterTypedViewModels(new[] {typeof(TViewModel)});
        }

        public void RegisterTypedViewModels(Type[] viewModelTypes)
        {
            var invalidTypes = new List<Type>();
            invalidTypes.AddRange(viewModelTypes.Where(vmType => !vmType.IsInterface));
            if (invalidTypes.Any())
            {
                var typesListString = invalidTypes.Aggregate("", (current, vmType) => current + vmType.Name + ", ")
                    .TrimEnd(", ".ToCharArray());
                var message =
                    $"{typesListString} cannot be used as a typed {(invalidTypes.Count == 1 ? "model" : "models")}. Only interfaces are supported.";
                throw new ArgumentException(message);
            }

            foreach (var viewModelType in viewModelTypes)
            {
                this.viewModelTypes.Add(viewModelType);
            }
        }
    }
}