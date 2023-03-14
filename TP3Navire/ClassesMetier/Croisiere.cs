using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Croisiere:Navire
    {
        private char typeNavireCroisiere;
        private int nbPassagersMaxi;
        private Dictionary<string, Passager> passagers;

        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT, char typeNavireCroisiere, int nbPassagersMaxi, List<Object> listePassagers)
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            TypeNavireCroisiere = typeNavireCroisiere;
            NbPassagersMaxi = nbPassagersMaxi;
            Passagers = new Dictionary<string, Passager>();
            this.Embarquer(listePassagers);
        }

        public Croisiere(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT, char typeNavireCroisiere, int nbPassagersMaxi)
            : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            TypeNavireCroisiere = typeNavireCroisiere;
            NbPassagersMaxi = nbPassagersMaxi;
            Passagers = new Dictionary<string, Passager>();
        }

        public char TypeNavireCroisiere 
        { 
            get => typeNavireCroisiere;
            private set
            {
                //if ((value != 'V') && (value != 'M')) 
                //{
                //    typeNavireCroisiere = value;
                //}
                //else
                //{
                //    TypeNavireCroisiere=value ? value='V' : null
                //}
                if (value=='V')
                {
                    TypeNavireCroisiere = "Voilier";
                }
                else if (value == 'M')
                {
                    TypeNavireCroisiere = "Moteur";
                }
                else
                {
                    throw new GestionPortException("Type de navire de croisiere invalide");
                }
            }
                
        }
        public int NbPassagersMaxi { get => nbPassagersMaxi; private set => nbPassagersMaxi = value; }
        internal Dictionary<string, Passager> Passagers { get => passagers; private set => passagers = value; }

        public void Embarquer(List<Object> passagers)
        {
            if (this.passagers.Count + passagers.Count <= this.nbPassagersMaxi)
            {
                foreach (Object passager in passagers)
                {
                    if (passager is Passager)
                    {
                        if (!this.passagers.ContainsKey(passager.NumPasseport))
                        {
                            this.passagers.Add(passager.NumPasseport, passager);
                        }
                        else
                        {
                            throw new GestionPortException("Impossible d'ajouter la personne, elle est déjà dans le navire");
                        }
                    }
                    else
                    {
                        throw new GestionPortException("Impossible d'ajouter l'objet, il n'est pas de type Personne");
                    }
                        
                }
                
            }
            else
            {
                throw new GestionPortException("Impossible d'ajouter la liste, pas assez de place dans le navire");
            }
        }

        public void Debarquer(List<Object> passagers)
        {
            if (this.passagers.Count - passagers.Count >= 0)
            {
                foreach (Object passager in passagers)
                {
                    if (passager is Passager)
                    {
                        if (!this.passagers.ContainsKey(passager.NumPasseport))
                        {
                            this.passagers.Remove(passager.NumPasseport, passager);
                        }
                        else
                        {
                            throw new GestionPortException("Impossible de retirer la personne, elle n'est pas dans le navire");
                        }
                    }
                    else
                    {
                        throw new GestionPortException("Impossible de retirer l'objet, il n'est pas de type Personne");
                    }

                }

            }
            else
            {
                throw new GestionPortException("Impossible de retirer la liste, pas assez de place dans le navire");
            }
        }

    }


}
