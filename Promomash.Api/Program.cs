using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Promomash.Database;

var MyAllowSpecificOrigins = "MyPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PromomashContext>(options
     // => options.UseNpgsql("name=ConnectionStrings:SampleDbConnection"));
=> options.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection"), b => b.MigrationsAssembly("Promomash.Database")));

////=> options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
//builder.Services.AddMediatR(typeof(User));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
