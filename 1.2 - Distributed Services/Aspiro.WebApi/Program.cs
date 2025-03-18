using Aspiro.Contracts.ServiceLibrary.ServiceContracts;
using Aspiro.DB.Infrastructure.BoundedContexts;
using Aspiro.DB.Infrastructure.Repositories;
using Aspiro.Impl.ServiceLibrary.Implementations;
using Aspiro.Library.InfrastructureContracts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Aspiro.Extensions.Mappings;

var builder = WebApplication.CreateBuilder(args);

//Configuracion manual del AutoMapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new UsersProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<AspiroDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IUsersApplicationService, UsersApplicationService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAngularApp");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
