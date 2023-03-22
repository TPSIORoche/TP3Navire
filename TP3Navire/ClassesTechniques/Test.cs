using NavireHeritage.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NavireHeritage.ClassesTechniques
{
    public abstract class Test
    {

        public static void ChargementInitial(Port port)
        {
            try
            {
                port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CGM A. LINCOLN", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9502910", "MAERSK EMERALD", "54.72202 N", "170.54304 W", 141754, 141189, 137000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9204506", "HOLANDIA", "41.74844 N", "6.87008 E", 8737, 9113, 7500, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9204506", "HOLANDIA", "41.74844 N", "6.87008 E", 8737, 9113, 7500, "marchandises diverses"));


            }
            catch
            {
                throw new Exception("Erreur, chargement initial");
            }
        }

        public static void TestEnregistrerArriveePrevue(Port port, Navire navire)
        {
            try
            {
                port.EnregistrerArriveePrevue(navire);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
