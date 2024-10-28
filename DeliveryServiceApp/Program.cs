using DeliveryServiceApp.Data;
using DeliveryServiceApp.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderServiceApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("api", new OpenApiInfo{ Title = "DeliveryServiceApi", Version = "v1" });
});

builder.Services.AddAutoMapper(typeof(DeliveryProfile).Assembly);

builder.Services.AddDbContext<DSApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DeliveryServiceConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/api/swagger.json", "OrderServiceApi");
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(x=>x.MapControllers());



app.Run();

