using AutoMapper;
using BackendFinalGrupo10.Context;
using BackendFinalGrupo10.Profiles;
using BackendFinalGrupo10.Repository;
using BackendFinalGrupo10.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AgendaContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:Grupo10APIDBConnectionString"]));


//Aca va token

var config = new MapperConfiguration(cfg => 
    {
        cfg.AddProfile(new ContactProfile()); 
        cfg.AddProfile(new UserProfile()); 
    });

//var mapper = config.CreateMapper();
IMapper mapper = config.CreateMapper();
//builder.Services.AddSingleton(mapper);
//builder.Services.AddMvc();

//Inyeccion de dependencia
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();







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
