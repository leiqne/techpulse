using API.Configuration;
using API.Repositories.Orders;
using API.Repositories.Orders.Interfaces;
using API.Repositories.Products;
using API.Repositories.Products.Interfaces;
using API.Repositories.Providers;
using API.Repositories.Providers.Interfaces;
using API.Repositories.Reviews;
using API.Repositories.Reviews.Interfaces;
using API.Repositories.Users;
using API.Repositories.Users.Interfaces;
using API.Services.Auth;
using API.Services.Auth.Interfaces;
using API.Services.Hashing;
using API.Services.Hashing.Interfaces;
using API.Services.Orders;
using API.Services.Orders.Interfaces;
using API.Services.Products;
using API.Services.Products.Interfaces;
using API.Services.Providers;
using API.Services.Providers.Interfaces;
using API.Services.Reviews;
using API.Services.Reviews.Interfaces;
using API.Services.Tokens;
using API.Services.Tokens.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IAccountAuthService, AccountAuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();