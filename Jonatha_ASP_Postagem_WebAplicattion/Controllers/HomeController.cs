using Jonatha_ASP_Postagem_Repositories.Interface;
using Jonatha_ASP_Postagem_WebAplicattion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jonatha_ASP_Postagem_WebAplicattion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostagem interface_postagem;

        public HomeController(IPostagem _interface_postagem)
        {
            interface_postagem = _interface_postagem;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.view_postagem = await interface_postagem.Coletar_Dados_Postagem();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}