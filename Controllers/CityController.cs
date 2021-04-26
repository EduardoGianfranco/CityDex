using System.Collections.Generic;
using System.Linq;
using CityDex.Data;
using CityDex.Models;
using Microsoft.AspNetCore.Mvc;

namespace Citydex.Controllers{
    public class CityController : Controller{
        private CityDexContext _context;
        public CityController(CityDexContext context)
        {
            _context = context;
        }
        public IActionResult Nuevo(){
            return View();
        }

        [HttpPost]
        public IActionResult Nuevo(City c){
            if(ModelState.IsValid){     //Si es valido,
                    _context.Add(c);     // guardar el objeto (c)
                    _context.SaveChanges(); //en la base de datos
                    return RedirectToAction("Lista");
            }
            return View(c);
        }

        public IActionResult Lista(){
                    //Seleccionar la lista de ciudades desde la BD y enviar a la Vista
            var ciudades = _context.Ciudades.OrderBy(x => x.Nombre).ToList();
            return View(ciudades);
        }
    }
}