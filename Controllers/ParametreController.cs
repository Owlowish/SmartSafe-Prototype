using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartsafe.Models;
using Microsoft.AspNetCore.Authorization;


namespace Smartsafe.Controllers
{
    public class ParametreController : Controller
    {

      // INITIALISATION DES CONTEXT DB
        private readonly UserContext _context;
        private readonly VariableContext _context2;
        
        public ParametreController(UserContext context1, VariableContext context2)
        {
            _context = context1;
            _context2 = context2;
        }        
        

        // DEVEROUILLAGE : VERRIFICATION MDP ET IDENTIFIANT

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(User user)
        {
             // recherche dans la base de donnée l'élément correspondant aux critères
            try
            {
           // initialisation de userdb, issus de User.db, correspondant à l'identifiant entré par l'utilisateur
                var userdb = (from m in _context.User
                            where (m.UserNumber == user.UserNumber )
                            select m).Single();

            // vérification du mot de passe correspondant
            if (userdb.Password == user.Password)
            {                
                // on donne l'accès en validant le token de connexion
                 var signedin = (from m in _context2.Variable
                            select m).Single();
                signedin.SignedIn= 1;
                _context2.SaveChanges();

                return RedirectToAction("Index","Parametre");
            }

              if (userdb.Password != user.Password)
            {                
                return RedirectToAction("Erreur","Lock");
            }
                
            }
            catch (System.Exception)
            {      
                 return RedirectToAction("Erreur","Lock");
            }
            return View();
        }
  

        public IActionResult Index()
        {
            // On regarde si l'utilisateur est connecté
            var signedin = (from m in _context2.Variable
                        select m).Single();

            if (signedin.SignedIn == 1) 
            return View();           
           
            return RedirectToAction("Login","Parametre");
        }


           public IActionResult Login()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
