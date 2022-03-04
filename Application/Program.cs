using Infrastructure.Repositories.NoteRepository;
using Infrastructure.SatelliteInfoProvider;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient("Satellite", client =>
{

})
.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
{
    TimeSpan.FromSeconds(1),
    TimeSpan.FromSeconds(5),
    TimeSpan.FromSeconds(10)
}));

builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<INoteRepository, NoteRepository>();

builder.Services.AddSingleton<ISatelliteInfoProviderService, SatelliteInfoProviderService>();

builder.Services.AddHttpContextAccessor(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); 
}
else
{
    // http://localhost:5213/swagger/index.html
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
