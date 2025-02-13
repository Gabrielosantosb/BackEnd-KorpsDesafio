using BackEnd_KorpsDesafio.Application.Product;
using BackEnd_KorpsDesafio.ORM.Context;
using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Mappings.Product;
using BackEnd_KorpsDesafio.ORM.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



#region Mapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion Mapper

#region dependencyInjection
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<BaseRepository<ProductModel>>();

builder.Services.AddScoped<IProductService, ProductService>();
#endregion dependencyInjection

#region mysqlconfig
builder.Services.AddDbContext<KorpsDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});
#endregion mysqlconfig


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
