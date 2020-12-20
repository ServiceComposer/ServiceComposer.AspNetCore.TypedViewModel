using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ServiceComposer.AspNetCore.TypedViewModel;

namespace ServiceComposer.AspNetCore
{
    public static class ViewModelCompositionOptionsExtensions
    {
        public static void EnableTypedViewModelSupport(this ViewModelCompositionOptions options)
        {
            options.Services.TryAddSingleton(typeof(IViewModelFactory), typeof(CastleDynamicProxyViewModelFactory));
        }
    }
}