using JQueryAndAjaxCRUD2.Data;
using JQueryAndAjaxCRUD2.Models;
using Microsoft.AspNetCore.Mvc;

namespace JQueryAndAjaxCRUD2.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly EmpData _reviews;

        public ReviewsController(EmpData reviews)
        {
            _reviews = reviews;
        }

        [HttpGet]
        public IActionResult RIndex()
        {
          var data =  _reviews.reviewData.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult RCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RCreate(ReviewModel reviewModel)
        {
            _reviews.reviewData.Add(reviewModel);
            _reviews.SaveChanges();
            return RedirectToAction("RIndex");
        }

        [HttpGet]
        public IActionResult REdit(int id)
        {
            var finddata = _reviews.reviewData.Find(id);
            if(finddata == null)
            {
                return (NotFound());
            }
            return View(finddata);
        }

        [HttpPost]
        public IActionResult REdit(ReviewModel reviewdata)
        {
            _reviews.reviewData.Update(reviewdata);
            _reviews.SaveChanges();
            return RedirectToAction("RIndex");
        }

        [HttpGet]
        public IActionResult RDelete(int id)
        {
            var findata = _reviews.reviewData.Find(id);
            _reviews.reviewData.Remove(findata);
            _reviews.SaveChanges();
            return RedirectToAction("RIndex");
        }
    }
}
