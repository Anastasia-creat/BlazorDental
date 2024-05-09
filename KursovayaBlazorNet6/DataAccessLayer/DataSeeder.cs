using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using KursovayaBlazorNet6.UsersRoles;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Numerics;
using System.Security.Claims;

namespace KursovayaBlazorNet6.DataAccessLayer
{
    public static class DataSeeder
    {
        public static void SeedServices(IServiceProvider provider)
        {

            var serviceRepository = provider
               .GetRequiredService<IRepository<Service>>();

            var categoryRepository = provider
                .GetRequiredService<IRepository<Category>>();


            var doctorRepository = provider
                .GetRequiredService<IRepository<Doctor>>();


            //отдельные 2 категории на блейзор
            var categoryUslugiRepository = provider
                .GetRequiredService<IRepository<CategoryUslugi>>();

            var categoryMedicRepository = provider
               .GetRequiredService<IRepository<CategoryMedic>>();


            if (serviceRepository.GetList().Count() > 0)
                return;



            var filesService = new DirectoryInfo("ClinicJson")
                .GetFiles("*.json");

            if (doctorRepository.GetList().Count() > 0)
                return;

            var filesDoctor = new DirectoryInfo("DoctorsJson")
                .GetFiles("*.json");

            foreach (var fi in filesService)
            {
                string categoryName = Path.GetFileName(fi.FullName);
                categoryName = Path.GetFileNameWithoutExtension(categoryName);

                var category = new Category { Name = categoryName };
                categoryRepository.Create(category);

                ////new uslugi blazor
                var categoryUslugi = new CategoryUslugi { Name = categoryName };
                categoryUslugiRepository.Create(categoryUslugi);
                //------------------------------------------------

                string jsonText = File.ReadAllText(fi.FullName);

                var services = JsonConvert
                    .DeserializeObject<List<ServicesModel>>(jsonText);

                //var doctors = JsonConvert
                // .DeserializeObject<List<DoctorModel>>(jsonText);

                foreach (var model in services)
                {
                    var product = new Service
                    {
                        //  Description = model.Description,
                        Name = model.Name,
                        //  ImageUrl = model.ImageUrl,
                        Price = model.Price,
                        ServiceCategory = category,

                        UslugiCategory = categoryUslugi
                      
                    };

                    serviceRepository.Create(product);
                }

                //foreach (var model in doctors)
                //{
                //    var product = new Doctor
                //    {
                //        Name = model.Name,
                //        Description = model.Description,
                //        DoctorCategory = category,
                //        ImageUrl = model.ImageUrl
                //    };
                //}
            }

            foreach (var fi in filesDoctor)
            {
                string categoryNameDoctor = Path.GetFileName(fi.FullName);
                categoryNameDoctor = Path.GetFileNameWithoutExtension(categoryNameDoctor);

                var category = new Category { Name = categoryNameDoctor };
                categoryRepository.Create(category);

                //new medic blazor
                var categoryMedic = new CategoryMedic { Name = categoryNameDoctor };
                categoryMedicRepository.Create(categoryMedic);


                string jsonText = File.ReadAllText(fi.FullName);
                var doctors = JsonConvert
                    .DeserializeObject<List<DoctorModel>>(jsonText);

                foreach (var model in doctors)
                {
                    var doctor = new Doctor
                    {

                        Description = model.Description,
                        Name = model.Name,
                        ImageUrl = model.ImageUrl,
                        DoctorCategory = category,

                        MedicCategory = categoryMedic


                    };

                    doctorRepository.Create(doctor);
                }
            }

            //foreach (var fi in filesDoctor)
            //{
            //    string categoryNameDoctor = Path.GetFileName(fi.FullName);
            //    categoryNameDoctor = Path.GetFileNameWithoutExtension(categoryNameDoctor);

            //    //var category = new Category { Name = categoryNameDoctor };
            //    //categoryRepository.Create(category);

            //    //new medic blazor
            //    var categoryMedic = new CategoryMedic { Name = categoryNameDoctor };
            //    categoryMedicRepository.Create(categoryMedic);


            //    string jsonText = File.ReadAllText(fi.FullName);
            //    var doctors = JsonConvert
            //        .DeserializeObject<List<DoctorModel>>(jsonText);

            //    foreach (var model in doctors)
            //    {
            //        var doctor = new Doctor
            //        {

            //            Description = model.Description,
            //            Name = model.Name,
            //            ImageUrl = model.ImageUrl,
            //           // DoctorCategory = category,

            //            MedicCategory = categoryMedic


            //        };

            //        doctorRepository.Create(doctor);
            //    }
            //}
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Count() > 0) return;

            var user1 = new ApplicationUser
            {
                UserName = "admin@ya.ru",
                LastName = "Админов",
                FirstName = "Админ",
                Email = "admin@ya.ru",
                EmailConfirmed = true
            };
            IdentityResult userResult = userManager.CreateAsync(user1, "1Qwerty!").Result;
            if (userResult.Succeeded)
            {
                userResult = userManager.AddToRoleAsync(user1, AppRoles.Administrator).Result;
            }


            var user2 = new ApplicationUser
            {
                UserName = "content@ya.ru",
                LastName = "Манагер контента",
                FirstName = "Коля",
                Email = "content@ya.ru",
                EmailConfirmed = true
            };
            userResult = userManager.CreateAsync(user2, "1Qwerty!").Result;
            if (userResult.Succeeded)
            {
                userResult = userManager.AddToRoleAsync(user2, AppRoles.ContentManager).Result;
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = new string[]
            {
                AppRoles.Administrator,
                AppRoles.ContentManager,
                AppRoles.Order,
                AppRoles.Guest
            };
            if (roleManager.Roles.Count() > 0) return;

            foreach (var roleName in roleNames)
            {
                var role = new IdentityRole { Name = roleName };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static async Task AddPermissionClaim(
           this RoleManager<IdentityRole> roleManager,
           IdentityRole role,
           string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }

    }
}

