using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.AutoMapping;
using KursovayaBlazorNet6.BlazorServices;
using KursovayaBlazorNet6.Data;
using KursovayaBlazorNet6.DataAccessLayer;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.UsersRoles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Syncfusion.Blazor;
using Smart.Blazor;
using KursovayaBlazorNet6.BlazorComponents;
using KursovayaBlazorNet6.ServerHub;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.ResponseCompression;
using KursovayaBlazorNet6;


namespace KursovayaBlazorNet6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


//var builder = WebApplication.CreateBuilder(args);
//static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();



////подключаем blazor
//builder.Services.AddServerSideBlazor();

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(20);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

//builder.Services
//    .AddIdentity<ApplicationUser, IdentityRole>(options =>
//    {
//        options.SignIn.RequireConfirmedAccount = false;
//        options.Password.RequireDigit = true;
//        options.Password.RequireLowercase = true;
//        options.Password.RequireUppercase = true;
//        options.Password.RequireNonAlphanumeric = true;
//        options.Password.RequiredLength = 7;

//        // User settings
//        options.User.RequireUniqueEmail = true;
//    })
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultUI()
//    .AddDefaultTokenProviders();

//builder.Services.AddControllersWithViews();


//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Identity/Account/Login";
//    options.SlidingExpiration = true;
//});

////---------------------------------------------
///*

//builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
//builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
//*/

//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
//builder.Services.AddRazorPages();
////builder.Services.MapSignalR;

//builder.Services.AddSyncfusionBlazor();

//builder.Services.AddTransient<IRepository<Service>, ServiceSqlRepository>();
//builder.Services.AddTransient<IRepository<Category>, CategorySqlRepository>();
//builder.Services.AddTransient<IRepository<Doctor>, DoctorSqlRepository>();
//builder.Services.AddTransient<IRepository<Reviews>, ReviewsSqlRepository>();
//builder.Services.AddTransient<IRepository<CategoryUslugi>, CategoryUslugiSqlRepository>();
//builder.Services.AddTransient<IRepository<CategoryMedic>, CategoryMedicSqlRepository>();

////builder.Services.AddTransient<IRepository<OrderRecord>, OrderRecordSqlRepository>();
////builder.Services.AddTransient<IRepository<Order>, OrderSqlRepository>();

////папка BlazorServices
//builder.Services.AddTransient<BlazorService>();
//builder.Services.AddTransient<BlazorDoctors>();
//builder.Services.AddTransient<BlazorDialogDocComponent>();

//builder.Services.AddSmart(); 

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<HttpContextAccessor>();
//builder.Services.AddTransient<BlazorCart>();

//builder.Services.AddSignalR();

////builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Blazor/Pages");
////Services.ConfigureServices(IServiceCollection services);




//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}
//app.UseSession();
//app.UseMvc();

//// app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.Use(async delegate (HttpContext Context, Func<Task> Next)
//{
////    //this throwaway session variable will "prime" the SetString() method
////    //to allow it to be called after the response has started
//    var TempKey = Guid.NewGuid().ToString(); //create a random key
//    Context.Session.Set(TempKey, System.Array.Empty<byte>()); //set the throwaway session variable
//    Context.Session.Remove(TempKey); //remove the throwaway session variable
//    await Next(); //continue on with the request
//});




//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//// 1) классич маршруты APS NET MVC
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Blazor}/{action=Index}/{id?}");

//// 2) маршруты для RazorPages (использ в Identity)
//app.MapRazorPages();

//// 3) маршрутизация Blazor
//app.MapBlazorHub();



//using (var scope = app.Services.CreateScope())
//{
//    DataSeeder.SeedServices(scope.ServiceProvider);

//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    DataSeeder.SeedRoles(roleManager);
//    DataSeeder.SeedUsers(userManager);
//}




//ModelsMapping.InitializeMappingService();
//ModelsMapping.InitializeMappingDoctor();

//app.Run();


