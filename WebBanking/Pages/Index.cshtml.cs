using BankingLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string operation { get; set; }

        [BindProperty]
        public double amount { get; set; }

        public void OnGet()
        {

        }

        public void OnPostOpenAccount()
        {
            Operaciones.AperturaCuenta();
        }

        public void OnPostExecuteOperation()
        {
            switch (operation)
            {
                case "D":
                    Operaciones.Deposito(amount);
                    break;
                case "R":
                    Operaciones.Retiro(amount);
                    break;
            }

            amount = 0;
        }
    }
}
