using DbLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;

namespace IdentityApiTest
{
    public class BaseTest
    {
        protected IConfigurationRoot _configBuilder { get; set; }
        protected ApplicationDbContext _appDbCtx;
        protected IServiceCollection _serviceCollection;
        protected IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public BaseTest()
        {
            _configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
            _serviceCollection = new ServiceCollection();
            BuildServiceCollection();
        }

        private void BuildServiceCollection()
        {
            var connString = new NpgsqlConnection(_configBuilder.GetValue<string>("PostgresConnString"));
            _serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connString));

            var identityDbContext = _serviceCollection.BuildServiceProvider().GetService<ApplicationDbContext>();
            identityDbContext.Database.OpenConnection();
            identityDbContext.Database.EnsureCreated();

            _serviceCollection.AddLogging();
            _serviceCollection.AddIdentity<ApplicationUser, IdentityRole>()
                                .AddUserManager<UserManager<ApplicationUser>>()
                                .AddSignInManager<SignInManager<ApplicationUser>>()
                                .AddEntityFrameworkStores<ApplicationDbContext>()
                                .AddDefaultTokenProviders();



            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        //private void SetDbContext()
        //{
        //    DbContextOptionsBuilder<ApplicationDbContext>? opt =
        //        NpgsqlDbContextOptionsBuilderExtensions
        //        .UseNpgsql(new DbContextOptionsBuilder<ApplicationDbContext>(),
        //                        _configBuilder.GetValue<string>("PostgresConnString"));

        //    _appDbCtx = new ApplicationDbContext(opt.Options);
        //}
    }
}
