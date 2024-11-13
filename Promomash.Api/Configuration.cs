using Microsoft.EntityFrameworkCore;
using Promomash.Core.Commands.CreateUser;
using Promomash.Core.Queries.GetUsers;
using Promomash.Database;

namespace Promomash
{
    public static class Configuration
    {
        public static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PromomashContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection"),
                                  b => b.MigrationsAssembly(typeof(PromomashContext).Assembly.FullName)));


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetUsersQueryHandler).Assembly);
            });
        }

        public static void ConfigureMiddleware(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigins");
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
