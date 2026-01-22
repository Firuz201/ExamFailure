using System.Threading.Tasks;
using ExamFailure.Contexts;
using ExamFailure.Models;
using ExamFailure.ViewModels.ChefViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ExamFailure.Areas.Admin.Controllers
{
    public class ChefController(AppDbContext _context) : Controller
    {
        public async Task <IActionResult> Index()
        {

            var chefs = await _context.Chefs.Select(x => new ChefGetVM()
            {
                FullName=x.FullName,
                Description=x.Description,
                PositionID=x.PositionId,
                ImagePath=x.ImagePath,

            }).ToListAsync();
            return View(chefs);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ChefCreateVM vm)
        {
            Chef chef = new()
            {
                FullName = vm.FullName,
                Description = vm.Description,
                PositionId = vm.PositionID,
                ImagePath = "defauly"

            };

            await _context.Chefs.AddAsync(chef);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);

            if (chef is null)
                return NotFound();


            _context.Remove(chef);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);

            if (chef is null)
                return NotFound();


            ChefUpdateVM vm = new() {
            
            Id=chef.Id,
            FullName = chef.FullName,
            Description = chef.Description,
            PositionID = chef.PositionId,
            };

            return View(vm);


        }


        [HttpPost]
        public async Task<IActionResult> Update(ChefUpdateVM vm)
        {
            if (!ModelState.IsValid)
                return View();


            var existChef = await _context.Chefs.FindAsync(vm.Id);

            if (existChef is null)
                return BadRequest();


            existChef.FullName = vm.FullName;
            existChef.Description = vm.Description;



            _context.Update(existChef);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
