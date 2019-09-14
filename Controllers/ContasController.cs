using Microsoft.AspNetCore.Mvc;

using ContadeLuz.Models;

namespace ContadeLuz.Controllers
{
    public class ContasController: Controller
    {

        ContaRepository _repository = 
        new ContaRepository();

        public IActionResult Index()
        {
            var contas = _repository.GetAll();
            ViewBag.Maximo = _repository.Maior();
            ViewBag.Minimo = _repository.Menor();
            return View(contas);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Maior()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Conta conta)
        {
            _repository.Create(conta);
            return View();
        }


       [HttpGet]
        public IActionResult Edit( int id)
        {
            var cont = _repository.GetById(id);
            return View(cont);
        }

        [HttpPost]
        public IActionResult Edit(Conta contaAlterado)
        {
            _repository.Update(contaAlterado);

            return RedirectToAction("index");
        }


        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}