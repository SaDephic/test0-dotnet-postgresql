using Microsoft.EntityFrameworkCore;
using test0_dotnet_postgresql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//in memory
//builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("test0"));

//connect to database
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration["DB_STRING"],
        x => x.MigrationsHistoryTable("__test0_efmigrationshistory", "public")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
