using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Pages
{
    public class Objeto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
    }

    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
             Objeto _obj = new Objeto();
            _obj.nombre = "Manuel";
            _obj.edad =  42;
            _obj.apellido = "Valdés";
            ViewData["objeto"] = _obj;
        }
    }
}
