using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using MVC_Core_SocialMediaProject.Models;
using MVC_Core_SocialMediaProject.Services.Implementation;
using MVC_Core_SocialMediaProject.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<CiitcoderDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
});
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<ITopicsServices, TopicServices>();
builder.Services.AddTransient<ITopicContentServices, TopicContentServices>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IExtraservice, ExtraService>();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(Options =>
{
    Options.IOTimeout = TimeSpan.FromMinutes(10);
});
//allow to long size videos
builder.Services.Configure<FormOptions>(Options =>
{
    Options.ValueLengthLimit = int.MaxValue;
    Options.MultipartBodyLengthLimit = int.MaxValue;
    Options.MultipartHeadersLengthLimit = int.MaxValue;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
