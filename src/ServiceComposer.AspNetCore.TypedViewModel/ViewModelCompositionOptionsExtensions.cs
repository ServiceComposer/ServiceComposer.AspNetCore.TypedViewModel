using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ServiceComposer.AspNetCore.TypedViewModel;

namespace ServiceComposer.AspNetCore
{
    public static class ViewModelCompositionOptionsExtensions
    {
        private static readonly TypedViewModelsOptions typedViewModelsOptions = new(); 
        public static void TypedViewModelsOptions(this ViewModelCompositionOptions options, Action<TypedViewModelsOptions> configure)
        {
            options.Services.TryAddSingleton(typedViewModelsOptions);
            options.Services.TryAddSingleton(typeof(IViewModelFactory), typeof(CastleDynamicProxyViewModelFactory));
            
            configure(typedViewModelsOptions);
        }
    }
}