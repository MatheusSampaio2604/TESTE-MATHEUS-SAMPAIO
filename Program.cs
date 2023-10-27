

using Microsoft.EntityFrameworkCore;
using TESTE_MATHEUS_SAMPAIO.Context;
using TESTE_MATHEUS_SAMPAIO.Models.Repository;
using TESTE_MATHEUS_SAMPAIO.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IDepartamentosRepository, DepartamentosRepository>();
builder.Services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();
builder.Services.AddScoped<IServicosRepository, ServicosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddScoped<IDepartamentosService, DepartamentosService>();
builder.Services.AddScoped<IFornecedoresService, FornecedoresService>();
builder.Services.AddScoped<IProdutosService, ProdutosService>();
builder.Services.AddScoped<IServicosService, ServicosService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();



var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
