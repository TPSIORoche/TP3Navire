using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Port:IStationnable
    {
        private string nom;
        private string latitude;
        private string longitude;
        private int nbPortique;
        private int nbQuaisPassager;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private Dictionary<string, Navire> navireArrives;
        private Dictionary<string, Navire> navirePartis;
        private Dictionary<string, Navire> navireEnAttente;

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisPassager, int nbQuaisTanker, int nbQuaisSuperTanker)
        {
            Nom = nom;
            Latitude = latitude;
            Longitude = longitude;
            NbPortique = nbPortique;
            NbQuaisPassager = nbQuaisPassager;
            NbQuaisTanker = nbQuaisTanker;
            NbQuaisSuperTanker = nbQuaisSuperTanker;
            NavireArrives = new Dictionary<string, Navire>();
            NavirePartis = new Dictionary<string, Navire>();
            NavireEnAttente = new Dictionary<string, Navire>();
            
        }

        public string Nom 
        { 
            get => nom;
            private set => nom = value; 
        }
        public string Latitude
        { 
            get => latitude;
            private set => latitude = value;
        }
        public string Longitude
        { 
            get => longitude;
            private set => longitude = value;
        }
        public int NbPortique {
            get => nbPortique;
            set => nbPortique = value;
        }
        public int NbQuaisPassager
        { 
            get => nbQuaisPassager;
            set => nbQuaisPassager = value;
        }
        public int NbQuaisTanker
        { 
            get => nbQuaisTanker;
            set => nbQuaisTanker = value;
        }
        public int NbQuaisSuperTanker
        { 
            get => nbQuaisSuperTanker;
            set => nbQuaisSuperTanker = value;
        }
        internal Dictionary<string, Navire> NavireArrives
        {
            get => navireArrives;
            private set => navireArrives = value;
        }
        internal Dictionary<string, Navire> NavirePartis
        { 
            get => navirePartis;
            private set => navirePartis = value;
        }
        internal Dictionary<string, Navire> NavireEnAttente
        {
            get => navireEnAttente;
            private set => navireEnAttente = value;
        }

        public Object GetUnAttendu(string id)
        {
            Navire value;
            bool exists = this.NavireEnAttente.TryGetValue(id, out value);
            if (exists)
            {
                return value;
            }
            else
            {
                throw new Exception("");
            }
        }

        public Object GetUnArrive(string id)
        {
            Navire value;
            bool exists = this.NavireArrives.TryGetValue(id, out value);
            if (exists)
            {
                return value;
            }
            else
            {
                throw new Exception("");
            }
        }

        public Object GetUnParti(string id)
        {
            Navire value;
            bool exists = this.NavirePartis.TryGetValue(id, out value);
            if (exists)
            {
                return value;
            }
            else
            {
                throw new Exception("");
            }
        }

        public int GetNbTankerArrives()
        {
            int i = 0;
            foreach(Object navire in this.NavireArrives)
            {
                i += (navire is Tanker) ? 1 : 0;
            }
            return i;
        }

        public int GetSuperTankerArrives()
        {
            int i = 0;
            foreach (Object navire in this.NavireArrives)
            {
                i += ((navire is Tanker tanker) && (tanker.TonnageGT>130000))? 1 : 0;
            }
            return i;
        }

        public int GetNbCargoArrives()
        {
            int i = 0;
            foreach (Object navire in this.NavireArrives)
            {
                i += (navire is Cargo) ? 1 : 0;
            }
            return i;
        }

        public void EnregistrerArriveePrevue(object obj)
        {
            throw new NotImplementedException();
        }

        public void EnregistrerArrivee(string o)
        {
            throw new NotImplementedException();
        }

        public void EnregistrerDepart(string o)
        {
            throw new NotImplementedException();
        }

        public bool EstEnAttente(string id)
        {
            throw new NotImplementedException();
        }

        public bool EstAttendu(string id)
        {
            if (this.NavireEnAttente.ContainsKey(id))
                {
                    foreach(Object navAt in this.NavireEnAttente)
                    {
                    if (navAt.)
                    {
                        return True;
                    }
                }
            }
            throw new NotImplementedException();
        }

        public bool EstPresent(string id)
        {
            throw new NotImplementedException();
        }

        public bool EstParti(string id)
        {
            throw new NotImplementedException();
        }

        public 
    }
}
