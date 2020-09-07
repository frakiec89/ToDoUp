using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoUp.Model
{
    class Servis
    {
            public string Name { get; set; }
            public string PriceEndTime { get; set; }
            public string RealPrice { get; set; }
            public string Discont { get; set; }
            public string FilePath { get; set; }
            public string ButtonChange { get; set; }
            public string buttinRemove { get; set; }
       

        public Servis ( DB.Service service)
        {
            Name = service.Title;

            if (service.Discount > 0)
                RealPrice = Convert.ToDouble(service.Cost).ToString();
            else
                RealPrice = null;

            PriceEndTime = GetRealPrice(service.Discount.Value, service.Cost, service.DurationInSeconds);
            Discont = GetDisconte(service.Discount);
            FilePath = service.MainImagePath ;

            buttinRemove = "Visible";
            ButtonChange = "Visible";
        }

        

        private string GetRealPrice(double discount, decimal cost, int durationInSeconds)
        {
            if (discount == 0)
                return cost + " Рублей" + " за " + durationInSeconds / 60 + " мин.";

            return GetDisconteRub(discount,cost) + " Рублей" + " за " + durationInSeconds / 60 + " мин.";

        }

        private string GetDisconteRub(double discount, decimal cost)
        {
            double co =  Convert.ToDouble(cost);
            double c = co - ( co* discount);
            return c.ToString();
        }

        private string GetDisconte(double? discount)
        {
            if (discount > 0)
                return "Скидка " + discount * 100 + "%";

            return null;
        }
    }
}
