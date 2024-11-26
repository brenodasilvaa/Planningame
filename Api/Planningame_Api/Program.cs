using Microsoft.EntityFrameworkCore;
using Planningame_Insfrastructure;
using Planningame_Insfrastructure.Inicialization;
using Planningame_Application;
using Planningame_Api.Mapeadores;
using Planningame_Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureInfra(builder.Configuration);
builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("AllowAll", policy =>
{
    policy.AllowAnyOrigin() 
          .AllowAnyMethod() 
          .AllowAnyHeader();
}));

PartidaMap.Add();
RodadasMap.Add();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PlanningameDbContext>();
    dbContext.Database.Migrate();   
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
