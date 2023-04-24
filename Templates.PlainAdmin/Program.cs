using Templates.PlainAdmin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5227/")
});

builder.Services.AddScoped<AppService>();
builder.Services.AddScoped<PersonalInfoServices>();
builder.Services.AddScoped<AboutsServices>();
builder.Services.AddScoped<ProgressBarServices>();
builder.Services.AddScoped<TimeLineServices>();
builder.Services.AddScoped<PortifolioServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
