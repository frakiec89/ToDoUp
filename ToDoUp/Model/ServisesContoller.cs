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

        /// <summary>
        /// Список  сервисов  вью
        /// </summary>
        public List<Servis>  Servis = new List<Servis>();

        /// <summary>
        /// Сервевис из  бд
        /// </summary>
        public DB.Service ServiceOne { get; set; }

        public ServisesContoller( Model.Servis servis )
        {
            ServiceOne = entities.Service.FirstOrDefault(x => x.Title == servis.Name);
        }

        public ServisesContoller ()
        {
            servicesDb = entities.Service.ToList();
            
            foreach (var s in servicesDb )
            {
                Servis.Add(new Servis(s));
            }
        }

        public  void Save ()
        {
            entities.SaveChanges();
        }
       

        public  int Add ()
        {
            entities.Service.Add(new DB.Service());
            entities.SaveChanges();
            return entities.Service.Last().ID;
        }
    }
}
