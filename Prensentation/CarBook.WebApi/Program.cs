using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.�nterfaces;
using CarBook.Application.�nterfaces.CarInterfaces;
using System.Reflection;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Application.Services;
using CarBook.Application.Features.Mediator.Handlers.BlogHandlers;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Repositories.CarPricingRepositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();  //AddHttpClient(): Bu metot, HttpClient s�n�f�n�n kullan�m�n� sa�lar ve HTTP istekleri yapmak i�in gereklidir. HTTP istekleri yap�lacak herhangi bir harici servis veya API'ye ba�lanmak i�in gerekli olan bir bile�endir.
// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IReporsitory<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));//Car repository 'den al�nan verileri swagger taraf�ndan eri�ilmesini sa�lar 
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
//Yukar�daki yap� bloglar aras�ndaki ayr�m�n� sa�lar ve ba��ml�l�klar� soyutlamak i�in �nterface kullan�lm��t�. Bu sayede, uygulaman�n farkl� katmanlar� aras�ndaki ba��ml�l�klar azalt�larak, kodun daha okunabilir, bak�m� daha kolay ve test edilebilir hale gelir. Ayr�ca, DI konteyneri arac�l���yla ba��ml�l�klar�n y�netimi sa�lan�r ve gerekti�inde de�i�tirilebilir.

builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));


builder.Services.AddScoped<GetAboutQueryHandler>();//Api controller yapt�ktan sonra program.cs yazaca��m�z servis i�lemleri
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();//Api controller yapt�ktan sonra program.cs yazaca��m�z servis i�lemleri
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();


builder.Services.AddScoped<GetBrandQueryHandler>(); //Api controller yapt�ktan sonra program.cs yazaca��m�z servis i�lemleri
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();


builder.Services.AddScoped<GetCarQueryHandler>();//Api controller yapt�ktan sonra program.cs yazaca��m�z servis i�lemleri
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();


builder.Services.AddScoped<GetCategoryQueryHandler>();//Api controller yapt�ktan sonra program.cs yazaca��m�z servis i�lemleri
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();


builder.Services.AddScoped<GetContactQueryHandler>();//Api controller yapt�ktan sonra program.cs yazaca��m�z servis i�lemleri
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddScoped<GetBlogQueryHandler>();
builder.Services.AddScoped<GetBlogByIdQueryHandler>();
builder.Services.AddScoped<CreateBlogCommandHandler>();
builder.Services.AddScoped<UpdateBlogCommandHandler>();
builder.Services.AddScoped<RemoveBlogCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
