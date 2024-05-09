using KursovayaBlazorNet6.Abstract;
using KursovayaBlazorNet6.BusinessLogic;

using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Helpers;
using KursovayaBlazorNet6.Models;
using Mapster;

namespace KursovayaBlazorNet6.BlazorServices
{
    public class BlazorCart
    {

        private readonly IHttpContextAccessor _contextAccesor;
        private readonly IRepository<Service> _repositoryService;
        private readonly IRepository<Doctor> _repositoryDoctor;

        public BlazorCart(
            IHttpContextAccessor httpContextAccessor,
            IRepository<Service> repositoryService,
            IRepository<Doctor> repositoryDoctor

            )
        {
            _contextAccesor = httpContextAccessor;
            _repositoryService = repositoryService;
            _repositoryDoctor = repositoryDoctor;
        }

        public void AddDoctor(long doctorId)
        {
            var model = _repositoryDoctor
            .Read(doctorId)
                .Adapt<DoctorModel>();

            var cart = _contextAccesor.HttpContext.LoadFromSession<Cart>();
            cart.AddCoupons(model);
            _contextAccesor.HttpContext.SaveToSession(cart);
        }

        public void RemoveDoctor(long doctorId)
        {
            var model = _repositoryDoctor
                .Read(doctorId)
                .Adapt<DoctorModel>();

            var cart = _contextAccesor.HttpContext.LoadFromSession<Cart>();
            cart.RemoveCoupons(model);
            _contextAccesor.HttpContext.SaveToSession(cart);
        }


        //ServiceCart
        public void AddService(long serviceId)
        {
            var model = _repositoryService
            .Read(serviceId)
                .Adapt<ServicesModel>();

            var cart = _contextAccesor.HttpContext.LoadFromSession<CartService>();
            cart.AddService(model);
            _contextAccesor.HttpContext.SaveToSession(cart);
        }

        public void RemoveService(long serviceId)
        {
            var model = _repositoryService
                .Read(serviceId)
                .Adapt<ServicesModel>();

            var cart = _contextAccesor.HttpContext.LoadFromSession<CartService>();
            cart.RemoveService(model);
            _contextAccesor.HttpContext.SaveToSession(cart);
        }

        public Cart GetCart()
        {
            return _contextAccesor.HttpContext.LoadFromSession<Cart>();
        }

        public CartService GetCartService()
        {
            return _contextAccesor.HttpContext.LoadFromSession<CartService>();
        }
    }
}
