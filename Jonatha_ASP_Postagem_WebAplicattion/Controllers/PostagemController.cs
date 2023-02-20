using Jonatha_ASP_Postagem_Domain;
using Jonatha_ASP_Postagem_Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Jonatha_ASP_Postagem_WebAplicattion.Controllers
{
    public class PostagemController : Controller
    {
        private readonly IPostagem interface_postagem;

        public PostagemController(IPostagem _interface_postagem)
        {
            interface_postagem = _interface_postagem;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.view_postagem = await interface_postagem.Coletar_Dados_Postagem();
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Postagem modelo_postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    modelo_postagem.USUARIO = "SISTEMA";
                    modelo_postagem.CURTIDA = 0;
                    await interface_postagem.Registro(modelo_postagem);

                    TempData["sucesso_mensagem"] = "O seu Post foi registrado com sucesso!!!";
                    return RedirectToAction("Registrar", "Postagem");
                }
            }
            catch (Exception ex)
            {
                TempData["erro_mensagem"] = "Por favor Preencha os Campos Corretamente!!!";
                ModelState.AddModelError("", $"Error: {ex.Message}");
            }

            return View(modelo_postagem);
        }

        public async Task<IActionResult> Alterar(int Id)
        {
            if (Id == 0)
            {
                BadRequest("");
            }

            var result = await interface_postagem.Coletar_Dados_Postagem_ID(Id);
            ViewBag.Id = Id;

            if (result != null)
            {
                return View(result);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(Postagem modelo_postagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await interface_postagem.Alterar(modelo_postagem);

                    TempData["sucesso_mensagem"] = "O seu Post foi alterado com sucesso!!!";
                    return RedirectToAction("Index", "Postagem");
                }
            }
            catch (Exception ex)
            {
                TempData["erro_mensagem"] = "Por favor Preencha os Campos Corretamente!!!";
                ModelState.AddModelError("", $"Error: {ex.Message}");
            }

            return View(modelo_postagem);
        }

        public void Excluir(int Id)
        {
            interface_postagem.Deletar(Id);
        }
    }
}
