using Project.Models;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Client admin = (Client)Session["user"];

            if (admin != null)
            {
                if (ConnexionBD.estAdmin(admin.Email, admin.password))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Accueil", "Gestion/");
                }
            }
            else
            {
                return RedirectToAction("login","Gestion");
            }
        } 
        

        // GET: Admin/Details/5
        public ActionResult getClients()
        {
            Client admin = (Client)Session["user"];
            if (admin != null)
            {
                if (ConnexionBD.estAdmin(admin.Email, admin.password))
                {
                    List<Client> clients = ConnexionBD.getClients();
                    return View(clients);
                }
                else
                {
                    return RedirectToAction("Accueil", "Gestion/");
                }
            }
            else
            {
                return RedirectToAction("login", "Gestion/"); 
            }

        }

        // GET: Admin/Create
        public ActionResult getCommandes()
        {
            Client admin = (Client)Session["user"];
            if (admin != null)
            {
                if (ConnexionBD.estAdmin(admin.Email, admin.password))
                {
                    List<getCommande> commandes = ConnexionBD.getCommandes();
                    return View(commandes);
                }
                else
                {
                    return RedirectToAction("Accueil", "Gestion/");
                }
            }
            else
            {
                return RedirectToAction("login", "Gestion/");
            }
        }

       
        public ActionResult setArticle(string op)
        {
            Client admin = (Client)Session["user"];
            if (admin != null)
            {
                if (ConnexionBD.estAdmin(admin.Email, admin.password))
                {

                    if (op.Equals("lvr"))
                    {
                        string Nom = Request["nombk"];
                        string Auteur = Request["Auteur"];
                        string date_edition = Request["date_edition"];
                        double prix = double.Parse(Request["prix"]);
                        int IdB = int.Parse(Request["beblio"]);
                        string path = Request["path"];

                        Livre livre = new Livre(Nom, Auteur, date_edition, prix, path, IdB);
                        ConnexionBD.setLivre(livre);
                    }
                    else if (op.Equals("cat"))
                    {
                        string Nom = Request["nombb"];
                        int IdB = int.Parse(Request["idbb"]);

                        Categorie categorie = new Categorie(Nom, IdB);
                        ConnexionBD.setCategorie(categorie);
                    }
                    return View();
                }
                else
                { 
                    return RedirectToAction("Accueil", "Gestion/");
                }

            }
            else
            {
                return RedirectToAction("login", "Gestion/");
            }

        }
    }
}

        
