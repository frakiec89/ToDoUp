using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoUp.Model
{
    class ServisesContoller
    {
        DB.DETLT2020Entities entities = new DB.DETLT2020Entities();

        List<DB.Service> servicesDb = new List<DB.Service> { };

        public List<Servis>  servis = new List<Servis>();

        public ServisesContoller ()
        {
            servicesDb = entities.Service.ToList();
            
            foreach (var s in servicesDb )
            {
                servis.Add(new Servis(s));
            }
        }

       

    }
}
