using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ServiceComposer.AspNetCore.TypedViewModel
{
    class CastleDynamicProxyViewModelFactory : IViewModelFactory
    {
        private readonly TypedViewModelsOptions _typedViewModelsOptions;
        private static ProxyGenerator generator = new();

        public CastleDynamicProxyViewModelFactory(TypedViewModelsOptions typedViewModelsOptions)
        {
            _typedViewModelsOptions = typedViewModelsOptions;
        }
        
        public DynamicViewModel CreateViewModel(HttpContext httpContext, CompositionContext compositionContext)
        {
            var logger = httpContext.RequestServices.GetRequiredService<ILogger<DynamicViewModel>>();
            var typedViewModel = (TypedViewModel) generator.CreateClassProxy(
                typeof(TypedViewModel),
                _typedViewModelsOptions.ViewModelTypes.ToArray(),
                ProxyGenerationOptions.Default,
                new object[0],
                new TypedViewModelInterceptor());

            var vm = new TypedDynamicViewModel(logger, compositionContext, typedViewModel);

            return vm;
        }
    }
}