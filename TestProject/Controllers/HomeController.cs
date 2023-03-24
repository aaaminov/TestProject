using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestProject.Models;

namespace TestProject.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private TestProjectDBContext _dbContext;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
            _dbContext = TestProjectDBContext.Instance;
        }

        public IActionResult Index() {
            ViewBag.brands = _dbContext.brand_car.ToList();
            ViewBag.models = _dbContext.model_car.ToList();
            return View();
        }

        public IActionResult Brand(int id) {
			if (id == 0) {
                ViewBag.title = "Создание бренда";
            } else {
                Brand_Car brandCar = _dbContext.brand_car.Find(id);
                ViewBag.current_brand = brandCar;
                ViewBag.title = brandCar.name;
			}
            return View();
        }
        
        public IActionResult Model(int id) {
            ViewBag.brands = _dbContext.brand_car.ToList();
            if (id == 0) {
                ViewBag.title = "Создание модели";
            } else {
                Model_Car modelCar = _dbContext.model_car.Find(id);
                ViewBag.current_model = modelCar;
                ViewBag.title = modelCar.brand.name + " " + modelCar.name;
			}
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SaveBrand(Brand_Car brand) {
            Console.WriteLine(brand.ToString());
            if (brand == null) {
                return View("Error");
            }

            if (brand.id == 0) {
                int new_id = _dbContext.brand_car.ToList().OrderBy(i => i.id).Last().id + 1;
                brand.id = new_id;
                _dbContext.brand_car.Add(brand);
            } else {
                Brand_Car dbBrand = _dbContext.brand_car.Find(brand.id);
                if (dbBrand != null) {
                    dbBrand.name = brand.name;
                    dbBrand.active = brand.active;
                }
            }
            Console.WriteLine(brand.ToString());
            await _dbContext.SaveChangesAsync();
            Console.WriteLine(_dbContext.brand_car.ToList().ToString());
            return RedirectToAction("Index");
		}


        [HttpPost]
        public async Task<IActionResult> SaveModel(Model_Car model) {
            if (model == null) {
                return View("Error");
            }
            if (model.id == 0) {
                int new_id = _dbContext.model_car.ToList().OrderBy(i => i.id).Last().id + 1;
                model.id = new_id;
                _dbContext.model_car.Add(model);
            } else {
                Model_Car dbModel = _dbContext.model_car.Find(model.id);
                if (dbModel != null) { 
                    dbModel.brand_id = model.brand_id;
                    dbModel.name = model.name;
                    dbModel.active = model.active;
                }
			}

			await _dbContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}