using BookClubApp.Server.Data;
using BookClubApp.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookClubService, BookClubService>();
builder.Services.AddScoped<IBookClubMemberService, BookClubMemberService>();

builder.Services.AddDbContext<BookClubAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:Main")));



var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapFallbackToFile("/index.html");

app.Run();
