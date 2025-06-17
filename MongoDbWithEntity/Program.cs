
using Microsoft.EntityFrameworkCore;
using MongoDbWithEntity.MongoDataBase;
using MongoDbWithEntity.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoDBSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSetting>();
builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddDbContext<developDbContext>(options =>
options.UseMongoDB(mongoDBSettings.ConnectionString ?? "", mongoDBSettings.DatabaseName ?? ""));

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
