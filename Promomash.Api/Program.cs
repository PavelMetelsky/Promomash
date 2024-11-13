using Promomash;

var builder = WebApplication.CreateBuilder(args);

// Define CORS policy name and configuration.
const string AllowSpecificOriginsPolicy = "AllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOriginsPolicy,
                      policyBuilder =>
                      {
                          policyBuilder.WithOrigins("http://localhost:4200")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
                      });
});

Configuration.AddServices(builder);

var app = builder.Build();

Configuration.ConfigureMiddleware(app);

app.Run();
