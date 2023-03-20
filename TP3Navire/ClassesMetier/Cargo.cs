using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Cargo:Navire, INavCommerciable
    {
        private string typeFret;

        public Cargo(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT,string typeFret) 
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            TypeFret = typeFret;
        }

        public string TypeFret { get => typeFret; private set => typeFret = value; }

        public void Charger(int qte)
        {
            if (this.tonnageActuel+qte <= this.tonnageGT)
            {
                this.tonnageActuel += qte;
            }
            else
            {
                throw new GestionPortException("Impossible de charger, il n'y a pas assez de place pour charger");
            }
        }

        public void Decharger(int qte)
        {
            if (this.tonnageActuel - qte >= 0)
            {
                this.tonnageActuel -= qte;
            }
            else
            {
                throw new GestionPortException("Impossible de décharger, il n'y a pas assez à décharger");
            }
        }
    }
}
