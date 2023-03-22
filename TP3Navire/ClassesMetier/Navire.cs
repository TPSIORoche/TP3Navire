using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    public abstract class Navire
    {
        protected string imo;
        protected string nom;
        protected string latitude;
        protected string longitude;
        protected int tonnageActuel;
        protected int tonnageGT;
        protected int tonnageDWT;

        protected Navire(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT)
        {
            Imo = imo;
            this.nom = nom;
            Latitude = latitude;
            Longitude = longitude;
            TonnageActuel = tonnageActuel;
            TonnageGT = tonnageGT;
            TonnageDWT = tonnageDWT;
        }

        public string Imo
        {
            get => imo;
            private set
            {
                if (Regex.IsMatch(value, @"^IMO[0-9]{7}$"))
                {
                    this.imo = value;
                }
                else
                {
                    throw new GestionPortException("erreur : numéro IMO non valide");
                }
            }
        }

        public string Nom { get => nom; private set => nom = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
        public int TonnageGT { get => tonnageGT; private set => tonnageGT = value; }
        public int TonnageDWT { get => tonnageDWT; private set => tonnageDWT = value; }
    }


}
