
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Service;
using T_Repository;
using FirstProject.Middleware;

var builder = WebApplication.CreateBuilder(args);
//var school = builder.Configuration.GetConnectionString("school");
var Home = builder.Configuration.GetConnectionString("Home");
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrder_service, Order_service>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddDbContext<ProductsContext>(option => option.UseSqlServer(Home));
//builder.Services.AddDbContext<ProductsContext>(option => option.UseSqlServer("Server=DESKTOP-LLM33R2;Database=Products;Trusted_Connection=True;"));
builder.Host.UseNLog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.UseMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
