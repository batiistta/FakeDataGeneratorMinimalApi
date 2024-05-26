using Carter;
using FakeDataGeneratorMinimalApi.Data;
using FakeDataGeneratorMinimalApi.RateLimit;
using Microsoft.EntityFrameworkCore;

namespace FakeDataGeneratorMinimalApi.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddEndpointsApiExplorer()
                .AddCarter()
                .AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("PessoaJuridica");
                    options.UseInMemoryDatabase("PessoaFisica");
                })
                .AddSwaggerGen()
                .AddDistributedMemoryCache();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                    .UseSwaggerUI();
            }
            app.UseMiddleware<RateLimitMiddleware>();
            app.MapCarter();
        }
    }
}
