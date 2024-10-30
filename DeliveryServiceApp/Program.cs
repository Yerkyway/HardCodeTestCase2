using DeliveryServiceApp.Data;
using DeliveryServiceApp.EventHandler;
using DeliveryServiceApp.Profiles;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderServiceApp;
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



builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<DeliveryEventHandler>();
    
    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMQConfig = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(rabbitMQConfig["HostName"], Convert.ToUInt16(rabbitMQConfig["Port"]), rabbitMQConfig["VirtualHost"], h =>
        {
            h.Username(rabbitMQConfig["UserName"]);
            h.Password(rabbitMQConfig["Password"]);
        });
        
        cfg.ReceiveEndpoint("OrderServiceEventHandler", e =>
        {
            e.ConfigureConsumer<DeliveryEventHandler>(context);
        });
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/api/swagger.json", "DeliveryServiceApi");
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(x=>x.MapControllers());



app.Run();

