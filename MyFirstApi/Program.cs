using Repository;
using Service;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Entities;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<storeDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StoreConnection")));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var app = builder.Build();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
