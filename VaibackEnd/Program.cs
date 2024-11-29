using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(
    u => u.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
    )
);
builder.Services.AddDbContext<PostDbContext>(
    p => p.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
    )
);

builder.Services.AddScoped<PostService>();

var app = builder.Build();

// Apply migrations automatically for all DbContexts
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContexts = new DbContext[]
    {
        services.GetRequiredService<UserDbContext>(),
        services.GetRequiredService<PostDbContext>()
    };

    foreach (var context in dbContexts)
    {
        context.Database.Migrate();
    }
}

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
