using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserService,UserService>();
//Where is the IUserRepository interface? UserRepository has no interface yet, so this line doesn't compile
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var app = builder.Build();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
