using Microsoft.EntityFrameworkCore;
using VaibackEnd.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IssueDbContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
        )
    );
builder.Services.AddDbContext<UserDbContext>(
    u => u.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
        )
    );

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
