using Microsoft.EntityFrameworkCore;
using WebAPIK8s;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<DbContextClass>(o => o.UseInMemoryDatabase("WebAPIK8s"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DbContextClass>();
    SeedData.Initialize(services);
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
