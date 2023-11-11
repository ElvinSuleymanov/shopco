using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace shopco_API.Application
{
   public static class MediatrInjection
    {
        public static IServiceCollection AddCustomMediator(this  IServiceCollection builder)
        {
            builder.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return builder;
        }
    }
}
