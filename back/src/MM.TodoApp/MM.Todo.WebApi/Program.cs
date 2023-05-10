using Microsoft.EntityFrameworkCore;
using MM.ToDo.Data.Context.Data;
using MM.ToDo.Data.Repositories;
using MM.ToDo.Domain.Interfaces.Repositories;
using MM.ToDo.Domain.Interfaces.Services;
using MM.ToDo.Domain.Services;
using MM.ToDoData.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<IAtividadeRepo, AtividadeRepo>();
builder.Services.AddScoped<IGeralRepo, GeralRepo>();
builder.Services.AddScoped<IAtividadeService, AtividadeService>();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}
    ) ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.MapControllers();

app.Run();
