using System.Collections;
using ContactBookWeb.Data;
using ContactBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookWeb.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Member> objCategoryList = _context.Members;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member obj)
        {
            if (obj.FirstName == obj.LastName && obj.LastName == obj.PhoneNumber.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _context.Members.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Member created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _context.Members.FirstOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Member obj)
        {
            if (obj.FirstName == obj.LastName && obj.LastName == obj.PhoneNumber.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _context.Members.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Member updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var memberFromDb = _context.Members.FirstOrDefault(c => c.Id == id);

            if (memberFromDb == null)
            {
                return NotFound();
            }

            return View(memberFromDb);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Members.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Members.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Member deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
