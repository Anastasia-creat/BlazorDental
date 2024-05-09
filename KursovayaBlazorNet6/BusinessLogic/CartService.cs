using KursovayaBlazorNet6.Models;

namespace KursovayaBlazorNet6.BusinessLogic
{
    public class CartService
    {

        public CartService()
        {
            Records = new List<CartRecordService>();
        }

        public int ServiceCount => Records.Sum(r => r.Quantity);

        public int TotalCost => Records.Sum(r => r.Cost);



        //ServiceCart
        public void AddService(ServicesModel model)
        {
            var record = Records.
                FirstOrDefault(r => r.Service.ServiceId == model.ServiceId);

            if (record == null)
            {
                Records.Add(new CartRecordService { Service = model, Quantity = 1 });
            }
            else
            {
                record.Quantity++;
            }
        }

        public void RemoveService(ServicesModel model)
        {
            var record = Records
                .FirstOrDefault(r => r.Service.ServiceId == model.ServiceId);

            if (record != null)
            {
                record.Quantity--;
                if (record.Quantity == 0)
                {
                    Records.Remove(record);
                }
            }
        }

       

        public List<CartRecordService> Records { get; set; }
    }

    public class CartRecordService
    {
        public int Cost => Service.Price * Quantity;

        public ServicesModel Service { get; set; }

        public int Quantity { get; set; }
    }
}

