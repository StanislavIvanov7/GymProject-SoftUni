using Gym.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Gym.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.ConfigureApplicationCookie(cnf =>
{
    cnf.LoginPath = "/User/Login";
});

builder.Services.AddControllersWithViews(opt =>
{
    opt.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    opt.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    //app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    //app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.CreateAdminRoleAsync();
await app.RunAsync();
