using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Data;
using WebApplication.Manager;
using Microsoft.Extensions.Hosting;
using WebApplication.Manager.NotificationEngin;
using WebApplication.Domain.Reminders;
using WebApplication.Data.SeedData;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

 builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.ConfigureDataModule(configuration);

builder.Services.ConfigureManagerModule(configuration);

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddTransient<IDataSeeder, ReminderSeeder>();
builder.Services.AddTransient<IDataSeeder, DepartmentsSeeder>();

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<EmailRequestHandler>());
var app = builder.Build();

// Create a scope to resolve services
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeederExecutor seederExecutor = new SeederExecutor(context);
    seederExecutor.ExecuteSeeders();
}

// Continue with the rest of your application logic
Console.WriteLine("All seeding done.");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
