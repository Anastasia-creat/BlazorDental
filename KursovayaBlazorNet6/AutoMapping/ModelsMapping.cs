using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using Mapster;


namespace KursovayaBlazorNet6.AutoMapping
{
    public static class ModelsMapping
    {
        public static void InitializeMappingService()
        {
            TypeAdapterConfig<Service, ServicesModel>
                  .NewConfig()
                  .Map(dest => dest.ServiceId, source => source.ServiceId)
                  .Map(dest => dest.Name, source => source.Name)
                  .Map(dest => dest.Category, source => source.ServiceCategory)
                  .Map(dest => dest.CategoryUslugi, source => source.UslugiCategory)
                  .Map(dest => dest.Price, source => source.Price);


            TypeAdapterConfig<Service, ServicesBriefModel>
                .NewConfig()
                .Map(dest => dest.ServiceId, source => source.ServiceId)
                .Map(dest => dest.Name, source => source.Name)
                .Map(dest => dest.Price, source => source.Price);


            TypeAdapterConfig<Service, EditServicesModel>
                .NewConfig()
                .Map(dest => dest.ServiceId, source => source.ServiceId)
                .Map(dest => dest.Name, source => source.Name)
                .Map(dest => dest.Price, source => source.Price)
                .Map(dest => dest.Category, source => source.ServiceCategory);

                
        } 

        
        public static void InitializeMappingDoctor()
        {
            TypeAdapterConfig<Doctor, DoctorModel>
                .NewConfig()
                .Map(dest => dest.DoctorId, source => source.DoctorId)
                .Map(dest => dest.Name, source => source.Name)
                .Map(dest => dest.Description, source => source.Description)
                .Map(dest => dest.Category, source => source.DoctorCategory)
                .Map(dest => dest.CategoryMedic, source => source.MedicCategory)
                .Map(dest => dest.ImageUrl, source => source.ImageUrl);

            TypeAdapterConfig<Doctor, DoctorBriefModel>
                .NewConfig()
                .Map(dest => dest.DoctorId, source => source.DoctorId)
                .Map(dest => dest.Name, source => source.Name)
                .Map(dest => dest.Category, source => source.DoctorCategory)
                .Map(dest => dest.CategoryMedic, source => source.MedicCategory);


            TypeAdapterConfig<Doctor, EditDoctorsModel>
                .NewConfig()
                .Map(dest => dest.DoctorId, source => source.DoctorId)
                .Map(dest => dest.Name, source => source.Name)
                .Map(dest => dest.Description, source => source.Description)
                .Map(dest => dest.Category, source => source.DoctorCategory)
                .Map(dest => dest.ImageUrl, source => source.ImageUrl);

        }
    }
}
