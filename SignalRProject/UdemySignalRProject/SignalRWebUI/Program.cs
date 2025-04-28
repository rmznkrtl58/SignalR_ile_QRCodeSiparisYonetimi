using DataAccessLayer.Concrete;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

//Authentice olmu� kullan�c�y� zorunlu k�lmak (yani kullan�c� giri� yapmak zorunda)
var requiredAuthorizePolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
//UI-da apileri consume etmek i�in
builder.Services.AddHttpClient();
// t�m controller�ma eri�im sa�lamas� i�in authentice olmu�
// kullan�c� gerekli!
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requiredAuthorizePolicy));
});
//Identity Kullan�m�
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
//veri taban� Contextini tan�mlama
builder.Services.AddDbContext<SignalRContext>();
//Authentice olmayan kullan�c�y� y�nlendir
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index/";
});
//------------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//404-405 G�B� vb. hata kodlar�nda ne gibi sayfalar�n gelece�ini g�sterir
app.UseStatusCodePages(async statusCode =>
{
  
    if (statusCode.HttpContext.Response.StatusCode == 404)
    {
        //404(Not Found) Bulunamad�
        statusCode.HttpContext.Response.Redirect("/Showcase/ErrorPage/NotFound404Page/");
    }
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//authentice ve authorize kullan
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
