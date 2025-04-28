using BusinessLogicLayer.Container;
using BusinessLogicLayer.ValidationRules.ReservationValidator;
using DataAccessLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
//CORS yapýlandýrmasý
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()//herhangi bir baþlýða izin ver
        .AllowAnyMethod()//herhangi bir metoda izin ver
        .AllowCredentials()//Dýþardan herhangi bir kimliðe izin ver
        .SetIsOriginAllowed((Host) => true)//dýþardan gelen herhangi bir saðlayýcýya izin ver
        .AllowCredentials();//dýþardan herhangi bir kimliðe izin ver
    });//app tarafýnda kullanmam gerek
});
//DbContext tanýmlamak
builder.Services.AddDbContext<SignalRContext>();
//newlemelerden kurtarmak
builder.Services.ContainerDependencies();
//auto mapperý tanýmlamak      //usin reflection       
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//SignalR kullanýmý
builder.Services.AddSignalR();
//(fluent validatio)DataAnnotations disabled
//yapacaðýzki hatalarýmýz türkçe gelsin
builder.Services.AddFluentValidationAutoValidation(opt =>
{
    opt.DisableDataAnnotationsValidation = true;
});
//Fluent Validation yapýlandýrmasý
builder.Services.AddValidatorsFromAssemblyContaining<CreateReservationValidator>();
//Include metodunda cycle was detected hatasý çözümü
builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//app---------------------------------------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//cors yapýlandýrmasý 
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//SignalR için gerekli
app.MapHub<SignalRHub>("/signalrhub");//bunu kullanmamýn sebebi
//normalde biz locale istekte bulunurken localhost:1234/swagger/category/Index
//bunda signalr iþlemleri için sýnýfýmýzýn ismini localhost:1234/signalrhub
//olarak server mantýðýnda kullanýyor

app.Run();
