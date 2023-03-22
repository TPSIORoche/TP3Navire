using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Passager
    {
        private string numPasseport;
        private string nom;
        private string prenom;
        private string nationalite;

        public Passager(string numPasseport, string nom, string prenom, string nationalite)
        {
            this.numPasseport = numPasseport;
            this.nom = nom;
            this.prenom = prenom;
            this.nationalite = nationalite;
        }

        public string NumPasseport { get => numPasseport; private set => numPasseport = value; }
        public string Nom { get => nom; private set => nom = value; }
        public string Prenom { get => prenom; private set => prenom = value; }
        public string Nationalite { get => nationalite; private set => nationalite = value; }
    }
}
