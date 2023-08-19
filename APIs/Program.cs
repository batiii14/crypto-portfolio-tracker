using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.concretes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBuyingTransactionService, BuyingTransactionManager>();
builder.Services.AddScoped<IBuyingTransactionDal, BuyingTransactionDal>();
builder.Services.AddScoped<ICoinService, CoinManager>();
builder.Services.AddScoped<ICoinDal, CoinDal>();
builder.Services.AddScoped<ISellingTransactionService, SellingTransactionManager>();
builder.Services.AddScoped<ISellingTransactionDal, SellingTransactionDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IWalletService, WalletManager>();
builder.Services.AddScoped<IWalletDal, WalletDal>();
builder.Services.AddScoped<ICoinUpdaterService, CoinUpdaterManager>();
builder.Services.AddScoped<ICoinUpdaterDal, CoinUpdaterDal>();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();
app.UseCors(opt =>
{
    opt.WithOrigins("http://localhost:4200")
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowCredentials();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIs");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
