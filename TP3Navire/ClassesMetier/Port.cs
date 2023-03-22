using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    public class Port:IStationnable
    {
        private string nom;
        private string latitude;
        private string longitude;
        private int nbPortique;
        private int nbQuaisPassager;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private Dictionary<string, Navire> navireAttendus;
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
            NavireAttendus = new Dictionary<string,Navire>();
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
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus; set => navireAttendus = value; }

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

        public int GetNbSuperTankerArrives()
        {
            int i = 0;
            foreach (Navire navire in this.NavireArrives.Values)
            {
                i += ((navire is Tanker tanker) && (tanker.TonnageGT>130000))? 1 : 0;
            }
            return i;
        }

        
        public int GetNbCargoArrives()
        {
            int i = 0;
            foreach (Navire navire in this.NavireArrives.Values)
            {
                i += (navire is Cargo) ? 1 : 0;
            }
            return i;
        }

        public void EnregistrerArriveePrevue(Object obj)
        {
            if (obj is Navire)  
            {
                Navire navire = (Navire)obj;
                //if (this.NavireAttendus.ContainsKey(navire.Imo))
                if(EstAttendu(navire.Imo))
                {
                    throw new GestionPortException($"Le navire {navire.Imo} est déja attendu");
                }
                else
                {
                    this.NavireAttendus.Add(navire.Imo,navire);
                }
            }
            throw new NotImplementedException();
        }

        private void AjouterNavire(Cargo cargo)
        {
            if (this.NbPortique > GetNbCargoArrives())
            {
                if (EstAttendu(cargo.Imo))
                {
                    this.NavireAttendus.Remove(cargo.Imo);
                }
                //if (this.NavireEnAttente.ContainsKey(navire.Imo))
                else if (EstEnAttente(cargo.Imo))
                {
                    this.NavireEnAttente.Remove(cargo.Imo);
                }
                this.NavireArrives.Add(cargo.Imo, cargo);
            }
            else
            {
                if (EstAttendu(cargo.Imo))
                {
                    this.NavireAttendus.Remove(cargo.Imo);
                    this.NavireEnAttente.Add(cargo.Imo,cargo);
                }
                else
                {
                    throw new Exception("");
                }
            }
        }

        public void EnregistrerArrivee(Object obj)
        {
            if (obj is Navire)
            {
                Navire navire = (Navire)obj;
                if (this.NavireArrives.ContainsKey(navire.Imo))
                {
                    throw new GestionPortException($"Le navire {navire.Imo} est déja attendu");
                }
                else
                {   
                    if()
                    if (nbPortique>GetNbCargoArrives())
                    //if (this.NavireAttendus.ContainsKey(navire.Imo))
                    if(EstAttendu(navire.Imo))
                    {
                        this.NavireAttendus.Remove(navire.Imo);
                    }
                    //if (this.NavireEnAttente.ContainsKey(navire.Imo))
                    if(EstEnAttente(navire.Imo))
                    {
                        this.NavireEnAttente.Remove(navire.Imo);
                    }
                    this.NavireArrives.Add(navire.Imo, navire);
                }
            }
            throw new GestionPortException("Ce n'est pas un navire");
        }


        public void EnregistrerDepart(Object obj)
        {
            if (obj is Navire)
            {
                Navire navire = (Navire)obj;
                //if (this.NavireArrives.ContainsKey(navire.Imo))
                if(EstPresent(navire.Imo))
                {
                    throw new GestionPortException($"Le navire {navire.Imo} est déja attendu");
                }
                else
                {
                    this.NavireArrives.Remove(navire.Imo);
                    this.NavirePartis.Add(navire.Imo, navire);
                }
            }
            throw new GestionPortException("Ce n'est pas un navire");
        }

        public bool EstEnAttente(string id)
        {

            if (this.NavireEnAttente.ContainsKey(id))
            {
                foreach (Object navAt in this.NavireEnAttente)
                {
                    if (((Navire)navAt).Imo == id)
                    {
                        return true;
                    }
                    return false;
                }
            }
            throw new NotImplementedException();
        }

        public bool EstAttendu(string id)
        {
            if (this.NavireAttendus.ContainsKey(id))
                {
                    foreach(Object navAt in this.NavireAttendus)
                    {
                    if (((Navire)navAt).Imo==id)
                    {
                        return true;
                    }
                    return false;
                }
            }
            throw new NotImplementedException();
        }

        public bool EstPresent(string imo)
        {
            return this.NavireAttendus.ContainsKey(imo);
        }

        public bool EstParti(string id)
        {
            throw new NotImplementedException();
        }

        public void Chargement(String id , int qte)
        {

            Navire value;
            bool existe = this.NavireArrives.TryGetValue(id, out value);
            if (value.TonnageActuel + qte <= value.TonnageGT)
            {
                value.TonnageActuel += qte;
            }
            else
            {
                throw new GestionPortException("Impossible de charger, il n'y a pas assez de place pour charger");
            }
        }

        public void Dechargement(String id, int qte)
        {
            Navire value;
            bool existe = this.NavireArrives.TryGetValue(id, out value);
            if (value.TonnageActuel - qte >= 0)
            {
                value.TonnageActuel -= qte;
            }
            else
            {
                throw new GestionPortException("Impossible de décharger, il n'y a pas assez à décharger");
            }
        }

        public override string ToString()
        {

            string chaine= $"----------------------------------------------" +
                $"Port de {this.Nom}\n" +
                $"\tCoordonnées GPS : {this.Longitude} / {this.Latitude}" +
                $"\t Nb portiques : {this.NbPortique}" +
                $"\t Nb quais croisière : {this.NbQuaisTanker}" +
                $"\t Nb quais super tankers : {this.NbQuaisSuperTanker}" +
                $"\t Nb Navires à quai : {NavireArrives}" +
                $"\t Nb Navires attendus : {NavireAttendus}" +
                $"\t Nb Navires à partis : {NavirePartis}" +
                $"\t Nb Navires en attente : {NavireEnAttente}" +
                $"\n Nombre de cargos dans le port : {this.GetNbCargoArrives()}" +
                $"Nombre de tankers dans le port : {this.GetNbTankerArrives()}" +
                $"Nombre de super tankers dans le port : {this.GetNbSuperTankerArrives()}\n" +
                $"----------------------------------------------" +
                $"\n Liste des bateaux en attentes de leur arrivée : ";
            foreach (Object navire in this.navireEnAttente)
            {
                Navire nav=(Navire)navire;
                chaine += $"\n{nav.Imo}\t{nav.Nom} : {nav.GetType()}";
            }
            return chaine;
        }

    }
}
