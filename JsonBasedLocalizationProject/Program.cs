using JsonBasedLocalizationProject;
using JsonBasedLocalizationProject.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddSingleton<IJsonErrorMessageProvider, JsonErrorMessageProvider>();
builder.Services.AddSingleton<LocalizationMiddleware>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

var cultures = new CultureInfo[]
{
    new("tr-Tr"),
    new("en-US"),
};

var localizeOptions = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(cultures[0]),
    SupportedCultures = cultures,
};

app.UseRequestLocalization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRequestLocalization(localizeOptions);
app.UseMiddleware<LocalizationMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
