using Ferreteria.Application.Interfaces;
using Ferreteria.Application.Services;
using Ferreteria.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//  1. Configuración de la conexión a PostgreSQL (Supabase)

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//  2. Inyección de dependencias (Application layer)

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();


//  3. Configuración de Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();


//  4. Configuración del pipeline HTTP

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


//  5. Rutas

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     try
//     {
//         //  IdentityUser
//         var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//         var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//
//         // Crear el rol "Admin" si no existe
//         if (!await roleManager.RoleExistsAsync("Admin"))
//         {
//             await roleManager.CreateAsync(new IdentityRole("Admin"));
//         }
//
//         // Crear el usuario admin si no existe
//         string adminEmail = "admin@firmeza.com";
//         string adminPassword = "diciembre";
//
//         var existingUser = await userManager.FindByEmailAsync(adminEmail);
//         if (existingUser == null)
//         {
//             var adminUser = new ApplicationUser
//             {
//                 UserName = adminEmail,
//                 Email = adminEmail,
//                 EmailConfirmed = true
//             };
//
//             var result = await userManager.CreateAsync(adminUser, adminPassword);
//             if (result.Succeeded)
//             {
//                 await userManager.AddToRoleAsync(adminUser, "Admin");
//                 Console.WriteLine(" Usuario admin creado exitosamente");
//             }
//             else
//             {
//                 Console.WriteLine(" Error al crear el usuario admin:");
//                 foreach (var error in result.Errors)
//                     Console.WriteLine($" - {error.Description}");
//             }
//         }
//         else
//         {
//             Console.WriteLine(" El usuario admin ya existe");
//         }
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"⚠️ Error al crear usuario admin: {ex.Message}");
//     }
// }

app.Run();
