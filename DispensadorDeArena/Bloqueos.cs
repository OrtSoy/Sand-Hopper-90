using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispensadorDeArena
{
    public class Bloqueos
    {
      
      
        
   

        public DateTime HoraDeServicio
        {
            get {
                
                var clock = Convert.ToString(PersonalData.Clock);
                var HopperDBDataContext = new HopperModel();
                var Hora = HopperDBDataContext
                    .Registroes
                    .Select(q => new { q.Clock, q.HoraYFecha})
                    .Where(c => c.Clock == clock)
                    .OrderByDescending(d => d.HoraYFecha)
                    .FirstOrDefault();

                if(Hora == null)
                {
                    return DateTime.Now.AddDays(1);
                }else
                    return Hora.HoraYFecha ;
            }
    

        }

        //public int SumaDeKilos
        //{
        //    get
        //    {
        //        var clock = Convert.ToString(PersonalData.Clock);
        //        var HopperDBDataContext = new HopperModel();
        //        var Hora = HopperDBDataContext
        //            .Registroes
        //            .Select(q => new { q.Clock, q.HoraYFecha, q.Kilos})
        //            .Where(c => c.Clock == clock)
        //            .OrderByDescending(d => d.HoraYFecha)
        //            .FirstOrDefault();

        //        return 10;
        //    }
        //}

        // Poner un array de clocks
        
        public bool SePuedeServir
        {

            
            get
            {
                var supervisores = new List<Supervisors>
                {
                   // new Supervisors() {Clock = 63882 },
                    new Supervisors() {Clock = 60018 },
                    new Supervisors() {Clock = 61156 },
                    new Supervisors() {Clock = 61372 },
                    new Supervisors() {Clock = 63808 },
                    new Supervisors() {Clock = 61708 },
                    new Supervisors() {Clock = 61020 }
                };
                var currentHour = DateTime.Now.Hour;
                var timeSpan =  DateTime.Now.Day - HoraDeServicio.Day;
                

                var resta =  currentHour - HoraDeServicio.Hour;

                if (supervisores.Exists(c => c.Clock == PersonalData.Clock))
                {
                    return true;

                }
                else
                {
                    if (timeSpan == 0)
                    {
                        if (resta >= 3)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                        return true;
                }  
                  
            }
        }

    }
}
