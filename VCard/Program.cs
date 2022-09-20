using VCard.Repositories.Abstract;
using VCard.Repositories.Concrete;
using VCard.Services.Abstract;
using VCard.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddSingleton<IQrService, QrService>();
builder.Services.AddSingleton<IVCardService, VCardService>();
builder.Services.AddSingleton<IVCardRepository, EFVCardRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
