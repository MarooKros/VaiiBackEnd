using Microsoft.EntityFrameworkCore;
using VaibackEnd.Data;

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
builder.Services.AddDbContext<IssueDbContext>(
    p => p.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
    )
);
builder.Services.AddDbContext<LogginDbContext>(
    l => l.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
    )
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<LogginService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContexts = new DbContext[]
    {
        services.GetRequiredService<UserDbContext>(),
        services.GetRequiredService<PostDbContext>(),
        services.GetRequiredService<IssueDbContext>(),
        services.GetRequiredService<LogginDbContext>()
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

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();
