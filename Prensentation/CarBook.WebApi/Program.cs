using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Ýnterfaces;
using CarBook.Application.Ýnterfaces.CarInterfaces;
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
builder.Services.AddHttpClient();  //AddHttpClient(): Bu metot, HttpClient sýnýfýnýn kullanýmýný saðlar ve HTTP istekleri yapmak için gereklidir. HTTP istekleri yapýlacak herhangi bir harici servis veya API'ye baðlanmak için gerekli olan bir bileþendir.
// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IReporsitory<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));//Car repository 'den alýnan verileri swagger tarafýndan eriþilmesini saðlar 
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
//Yukarýdaki yapý bloglar arasýndaki ayrýmýný saðlar ve baðýmlýlýklarý soyutlamak için Ýnterface kullanýlmýþtý. Bu sayede, uygulamanýn farklý katmanlarý arasýndaki baðýmlýlýklar azaltýlarak, kodun daha okunabilir, bakýmý daha kolay ve test edilebilir hale gelir. Ayrýca, DI konteyneri aracýlýðýyla baðýmlýlýklarýn yönetimi saðlanýr ve gerektiðinde deðiþtirilebilir.

builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));


builder.Services.AddScoped<GetAboutQueryHandler>();//Api controller yaptýktan sonra program.cs yazacaðýmýz servis iþlemleri
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();//Api controller yaptýktan sonra program.cs yazacaðýmýz servis iþlemleri
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();


builder.Services.AddScoped<GetBrandQueryHandler>(); //Api controller yaptýktan sonra program.cs yazacaðýmýz servis iþlemleri
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();


builder.Services.AddScoped<GetCarQueryHandler>();//Api controller yaptýktan sonra program.cs yazacaðýmýz servis iþlemleri
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();


builder.Services.AddScoped<GetCategoryQueryHandler>();//Api controller yaptýktan sonra program.cs yazacaðýmýz servis iþlemleri
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();


builder.Services.AddScoped<GetContactQueryHandler>();//Api controller yaptýktan sonra program.cs yazacaðýmýz servis iþlemleri
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
