using BillPayment.Data.Logic;
using BillPayment.Domain.Data;
using BillPayment.Helpers;
using BillPayment.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IBillerRepository, BillerRepository>();
builder.Services.AddDbContext<BillerContext>(opt => opt.UseInMemoryDatabase(Settings.DbName)).AddEntityFrameworkInMemoryDatabase();

var serviceContext = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(builder.Services);
var context = serviceContext.GetRequiredService<BillerContext>();

InitData.Initialize(context);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Biller Assets API",
            Version = "v1",
            Description = "An API to perform billing operations",
            TermsOfService = new Uri("https://www.linkedin.com/in/alfred-nana-brown-a21b6a58/"),
            Contact = new OpenApiContact
            {
                Email = "nanabrown.agyir@gmail.com",
                Name = "Alfred Nana Brown",
                Url = new Uri("https://www.linkedin.com/in/alfred-nana-brown-a21b6a58/")
            },
            License = new OpenApiLicense
            {
                Name = "",
                Url = new Uri("https://www.example.com/license")
            }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biller - API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();