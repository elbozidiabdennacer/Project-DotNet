using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Projet.Models
{
    public class Panier
    {
        List<Livre> livres; 

        public Panier()
        {
            livres = new List<Livre>();
        }

        public List<Livre> getLivres
        {
            get  {return livres; }
        }

        public void addLivre(Livre livre)
        {
            foreach(Livre l in livres)
            {
                if (l.IdBk == livre.IdBk)
                    return;
            }

            livres.Add(livre);

        }

        public void sousLivre(Livre livre)
        {
            foreach (Livre l in livres)
            {
                if (l.IdBk == livre.IdBk) 
                { 
                    livres.Remove(l);
                    return;
                }
            }
        }


    }
}