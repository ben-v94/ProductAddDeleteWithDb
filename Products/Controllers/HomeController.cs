using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System.Diagnostics;
using Products;
using Microsoft.EntityFrameworkCore;

namespace Products.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository _repository;

        public HomeController(IProductRepository repository)
        {
            _repository = repository;
        }


        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Products()
        {
            var products = await _repository.GetAllAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(model);
                return RedirectToAction("Products");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            await _repository.DeleteAsync(id);
            return RedirectToAction("Products");
        }
    }
}
 