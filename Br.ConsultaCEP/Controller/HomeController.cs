using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Br.ConsultaCEP.Models;
using Br.ConsultaCEP.Services;
using Br.ConsultaCEP.Context;

namespace Br.ConsultaCEP.Controllers
{
    public class HomeController : Controller
    {
        private readonly CepContext _context;
        private readonly CepService _service;

        public HomeController(CepContext context)
        {
            _context = context;
            _service = new CepService(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscarCEP(string cep)
        {
            var cepObject = Cep.Busca(cep);

            if (!ValidarCEP(cepObject))
                TempData["result"] = "ERROR";
            else
                TempData["result"] = "OK";

            return View("Index", cepObject);
        }

        private bool ValidarCEP(object cep)
        {
            foreach (var item in cep.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    string value = (string)item.GetValue(cep);
                    if (!string.IsNullOrEmpty(value))
                        return true;
                }

            }
            return false;
        }

        [HttpPost]
        public async Task<IActionResult> Salvar_Endereco(string cep, string logradouro, string bairro, string localidade, string complemento, string uf, string siafi, string gia, string ibge)
        {
            TempData["result"] = "SAVE";

            Cep obj = new Cep()
            {
                CEP = cep,
                Logradouro = logradouro,
                Bairro = bairro,
                Localidade = localidade,
                Complemento = complemento == null ? "" : complemento,
                UF = uf,
                GIA = gia,
                SIAFI = siafi,
                IBGE = ibge
            };


            var result = _service.Save(obj);

            if(result.Result.CEP == null)
            {
                TempData["result"] = "REPEAT";
                return View("Index", obj);
            }
        


            return View("Index");
        }


        public async Task<IActionResult> ListEnderecos()
        {
            var enderecos = await _service.List();

            return View(enderecos);
        }


    }
}