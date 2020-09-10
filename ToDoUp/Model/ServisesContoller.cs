using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoUp.Model
{
    class ServisesContoller
    {
        private DB.DETLT2020Entities entities = new DB.DETLT2020Entities();

        private List<DB.Service> servicesDb = new List<DB.Service> { };

        /// <summary>
        /// Список  сервисов  вью
        /// </summary>
        public List<Servis>  Servis = new List<Servis>();

        /// <summary>
        /// Сервевис из  бд
        /// </summary>
        public DB.Service ServiceOne { get; set; }


        /// <summary>
        /// загрузка одного  сервиса
        /// </summary>
        /// <param name="servis"></param>
        public ServisesContoller( Model.Servis servis )
        {
            ServiceOne = entities.Service.FirstOrDefault(x => x.Title == servis.Name);
        }

        /// <summary>
        /// загрузка всех сервисов
        /// </summary>
        public ServisesContoller ()
        {
            servicesDb = entities.Service.ToList();
            
            foreach (var s in servicesDb )
            {
                Servis.Add(new Servis(s));
            }
        }

        /// <summary>
        /// Добавляет  в бд
        /// </summary>
        /// <param name="service"></param>
        public  ServisesContoller ( DB.Service service )
        {
            entities.Service.Add(service);
            Save();
        }

        /// <summary>
        /// Сохранияет  изменения 
        /// </summary>
        public  void Save ()
        {
            entities.SaveChanges();
        }
       

       
    }
}
