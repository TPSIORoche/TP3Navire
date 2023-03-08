using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Tanker:Navire
    {
        private string typeFluide;

        public Tanker(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT,string typeFluide) 
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            TypeFluide = typeFluide;
        }

        public string TypeFluide { get => typeFluide; private set => typeFluide = value; }

        public void Charger(int qte)
        {
            if (this.tonnageActuel + qte <= this.tonnageGT)
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
