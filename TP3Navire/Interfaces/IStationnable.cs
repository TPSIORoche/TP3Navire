using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier

{
    interface IStationnable
    {
        void EnregistrerArriveePrevue(Object obj);
        void EnregistrerArrivee(Object obj);
        void EnregistrerDepart(Object obj);
        bool EstAttendu(String id);
        bool EstPresent(String id);
        bool EstParti(String id);
        bool EstEnAttente(String id);
        Object GetUnAttendu(String id);
        Object GetUnArrive(String id);
        Object GetUnParti(String id);

        
    }
}
