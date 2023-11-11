using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shopco_API.Application.CQRS.Account.Commands;
using shopco_API.Application.CQRS.Account.Queries;
using shopco_API.Application.CQRS.Products.Commands;
using shopco_API.Application.CQRS.Products.Queries;
using shopco_API.Application.CQRS.Seller.Commands;
using shopco_API.Application.Interfaces;
using shopco_API.Domain.Models.AccountModels;
using shopco_API.Domain.Models.ProductModels;
using shopco_API.Domain.Models.SellerModels;
using shopco_API.Infrastructure.DataBase;
using shopco_API.Infrastructure.Services;

namespace shopco_API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection collection)
        {
            collection.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return collection;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection builder)
        {
            builder.AddTransient<IMediator, Mediator>();
            //builder.AddTransient<IRequestHandler<AccountRegisterCommand, RegisterResponse>, AccountRegisterCommandHandler>();
            //builder.AddTransient<IRequestHandler<AccountLoginCommand, LoginResponse>, AccountLoginCommandHandler>();
            //builder.AddTransient<IRequestHandler<GetAccountQuery, GetAccountResponse>, GetAccountQueryHandler>();
            //builder.AddTransient<IRequestHandler<RegisterSellerCommand, RegisterSellerResponse>, RegisterSellerCommandHandler>();
            //builder.AddTransient<IRequestHandler<LoginSellerCommand, LoginSellerResponse>, LoginSellerCommandHandler>();
            //builder.AddTransient<IRequestHandler<AddProductCommand, AddProductResponse>, AddProductCommandHandler>();
            //builder.AddTransient<IRequestHandler<GetProductQuery, GetProductResponse>, GetProductQueryHandler>();
            builder.AddTransient<ISellerService, SellerService>();
            builder.AddTransient<IAccountService, AccountService>();
            builder.AddTransient<IAuthenticationService, AuthenticationService>();
            builder.AddDbContext<ApplicationDbContext>(options => options.UseMySql("Server=localhost;Uid=root;Pwd=elvin2003;Database=ShopcoDb;", ServerVersion.AutoDetect("Server=localhost;Uid=root;Pwd=elvin2003;Database=ShopcoDb;")));
            return builder;
        }
    }
}
