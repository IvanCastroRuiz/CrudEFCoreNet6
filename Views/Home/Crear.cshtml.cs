using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CrudEFCoreNet6.Views.Home
{
    public class Crear : PageModel
    {
        private readonly ILogger<Crear> _logger;

        public Crear(ILogger<Crear> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}