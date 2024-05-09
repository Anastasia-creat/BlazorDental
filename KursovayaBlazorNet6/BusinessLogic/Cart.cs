using KursovayaBlazorNet6.BlazorComponents;
using KursovayaBlazorNet6.Domains;
using KursovayaBlazorNet6.Models;
using System.Collections.Generic;
using System.Linq;

namespace KursovayaBlazorNet6.BusinessLogic
{
    public class Cart
    {
        
        //Doctors
        public List<CartRecord> Records { get; set; }

       
        public List<Doctor> doctor { get; set; }
    
        public Cart()
        {
            Records = new List<CartRecord>();
        }

       
        public int DoctorCount  => Records.Sum(r => r.Quantity);

        public object Day { get; private set; }

        public void AddCoupons(DoctorModel model)
        {
            var record = Records.
                FirstOrDefault(r => r.Doctor.DoctorId == model.DoctorId);

            if(record == null)
            {
                Records.Add(new CartRecord
                
                { Doctor = model, 
                  
                    Quantity = 1});
              
            }
            else
            {
                record.Quantity++;
            }
        }

        public void RemoveCoupons(DoctorModel model)
        {
            var record = Records
                .FirstOrDefault(r => r.Doctor.DoctorId == model.DoctorId);

            if(record != null)
            {
                record.Quantity--;
                if(record.Quantity == 0)
                {
                    Records.Remove(record);
                }
            }
        }


        

    }

    //Doctors
    public class CartRecord
    {
       

        public DateTime DateValue { get; set; }
        public DoctorModel  Doctor{ get; set; }
     

        public int Quantity { get; set; }
    }

   
}
