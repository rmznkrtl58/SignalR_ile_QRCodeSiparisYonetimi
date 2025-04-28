using BusinessLogicLayer.Container;
using BusinessLogicLayer.ValidationRules.ReservationValidator;
using DataAccessLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
//CORS yap�land�rmas�
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()//herhangi bir ba�l��a izin ver
        .AllowAnyMethod()//herhangi bir metoda izin ver
        .AllowCredentials()//D��ardan herhangi bir kimli�e izin ver
        .SetIsOriginAllowed((Host) => true)//d��ardan gelen herhangi bir sa�lay�c�ya izin ver
        .AllowCredentials();//d��ardan herhangi bir kimli�e izin ver
    });//app taraf�nda kullanmam gerek
});
//DbContext tan�mlamak
builder.Services.AddDbContext<SignalRContext>();
//newlemelerden kurtarmak
builder.Services.ContainerDependencies();
//auto mapper� tan�mlamak      //usin reflection       
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//SignalR kullan�m�
builder.Services.AddSignalR();
//(fluent validatio)DataAnnotations disabled
//yapaca��zki hatalar�m�z t�rk�e gelsin
builder.Services.AddFluentValidationAutoValidation(opt =>
{
    opt.DisableDataAnnotationsValidation = true;
});
//Fluent Validation yap�land�rmas�
builder.Services.AddValidatorsFromAssemblyContaining<CreateReservationValidator>();
//Include metodunda cycle was detected hatas� ��z�m�
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
//cors yap�land�rmas� 
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//SignalR i�in gerekli
app.MapHub<SignalRHub>("/signalrhub");//bunu kullanmam�n sebebi
//normalde biz locale istekte bulunurken localhost:1234/swagger/category/Index
//bunda signalr i�lemleri i�in s�n�f�m�z�n ismini localhost:1234/signalrhub
//olarak server mant���nda kullan�yor

app.Run();
