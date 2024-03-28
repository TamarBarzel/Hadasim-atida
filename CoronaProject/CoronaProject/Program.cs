using CoronaProjectDTO;
using Microsoft.OpenApi.Models;
using AutoMapper;
using CoronaProjectBL.Interfaces;
using CoronaProjectBL;
using CoronaProjectDL.Interfaces;
using CoronaProjectDL;
using CoronaProjectDL.Models;
using CoronaProjectDTO.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});
builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddScoped<IPatientBL, PatientBL>();
builder.Services.AddScoped<IPatientDL, PatientDL>();
builder.Services.AddScoped<IManufacterBL, ManufacterBL>();
builder.Services.AddScoped<IManufacterDL, ManufacterDL>();
builder.Services.AddScoped<IVaccinationBL, VaccinationBL>();
builder.Services.AddScoped<IVaccinationDL, VaccinationDL>();


var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
