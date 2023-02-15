using DebetCredit.Database;
using DebetCredit.Models;
using DebetCredit.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DebetCredit.Controllers
{
    public class BalanceController : Controller
    {
        private BalanceService balanceService = new BalanceService();
        private CategoryService categoryService = new CategoryService();
        private StatisticService statisticService = new StatisticService();
        
        [HttpGet] // Balance
        public ActionResult Index()
        {
            var model = new GlobalModel<BalanceModel>
            {
                Rows = balanceService.GetAll(),
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpGet] // Balance/Create
        public ActionResult Create()
        {
            var model = new GlobalModel<BalanceModel>
            {
                Row = new BalanceModel(),
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost] // Balance/Create
        public ActionResult Create(BalanceDB _)
        {
            var balance = new BalanceDB
            {
                Date = DateTime.ParseExact(Request.Form["Row.Date"], "yyyy-MM-dd", default, DateTimeStyles.None),
                TypeID = int.Parse(Request.Form["Row.TypeID"]),
                CategoryID = int.Parse(Request.Form["Row.CategoryID"]),
                Amount = int.Parse(Request.Form["Row.Amount"]),
                Comment = Request.Form["Row.Comment"]
            };

            balanceService.Add(balance);

            return RedirectToAction("Index");
        }

        [HttpGet] // Balance/Edit
        public ActionResult Edit(int id)
        {
            var balance = balanceService.GetById(id);

            if (balance is null)
            {
                return RedirectToAction("Index");
            }

            var model = new GlobalModel<BalanceModel>
            {
                Row = balance,
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost] // Balance/Edit
        public ActionResult Edit()
        {
            var model = new BalanceDB
            {
                ID = int.Parse(Request.Form["Row.ID"]),
                Date = DateTime.Parse(Request.Form["Row.Date"]),
                Amount = int.Parse(Request.Form["Row.Amount"]),
                Comment = Request.Form["Row.Comment"],
                CategoryID = int.Parse(Request.Form["Row.CategoryID"])
            };

            balanceService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpGet] // Balance/Delete/5
        public ActionResult Delete(int id)
        {
            balanceService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet] // Balance/Incoming
        public ActionResult Incoming()
        {
            var model = new GlobalModel<BalanceModel>
            {
                Rows = balanceService.GetIncoming(),
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpGet] // Balance/Outcoming
        public ActionResult Outcoming()
        {
            var model = new GlobalModel<BalanceModel>
            {
                Rows = balanceService.GetOutcoming(),
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost] // Balance/DataRange
        public ActionResult DateRange(string begin, string end)
        {
            if (!DateTime.TryParseExact(begin, "yyyy-MM-dd", default, DateTimeStyles.None, out var beginDate))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!DateTime.TryParseExact(end, "yyyy-MM-dd", default, DateTimeStyles.None, out var endDate))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (beginDate > endDate)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new GlobalModel<BalanceModel>
            {
                Rows = balanceService.GetRange(beginDate, endDate),
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpGet] // Balance/Category
        public ActionResult Category()
        {
            foreach (string item in Request.Headers.Keys)
            {
                if (item == "Content-Type" && Request.Headers[item] == "application/json")
                {
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = categoryService.GetAll().Select(category => new
                        {
                            ID = category.ID,
                            Name = category.CategoryName,
                            Type = category.TypeID
                        })
                        .ToArray()
                    };
                }
            }

            var model = new GlobalModel<CategoryModel>
            {
                Rows = categoryService.GetAll(),
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };
            
            return View(model);
        }

        [HttpGet] // Balance/CreateCategory
        public ActionResult CreateCategory()
        {
            var model = new GlobalModel<CategoryModel>
            {
                Row = new CategoryModel { CategoryName = string.Empty },
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost] // Balance/CreateCategory
        public ActionResult CreateCategory(CategoryDB _)
        {
            var category = new CategoryDB
            {
                TypeID = int.Parse(Request.Form["Row.TypeID"]),
                Name = Request.Form["Row.CategoryName"]
            };

            categoryService.Add(category);

            return RedirectToAction("Category", "Balance");
        }

        [HttpPost] // Balance/EditCategory
        public ActionResult EditCategory(CategoryDB _)
        {
            var model = new CategoryDB
            { 
                ID = int.Parse(Request.Form["Row.ID"]),
                TypeID = int.Parse(Request.Form["Row.TypeID"]),
                Name = Request.Form["Row.CategoryName"]
            };

            categoryService.Update(model);

            return RedirectToAction("Category", "Balance");
        }

        [HttpGet] // Balance/EditCategory/1
        public ActionResult EditCategory(int id)
        {
            var category = categoryService.GetById(id);

            if (category is null)
            {
                return RedirectToAction("Category", "Balance");
            }

            var model = new GlobalModel<CategoryModel>
            {
                Row = category,
                BalanceTypes = balanceService.GetTypes(),
                CategoryTypes = categoryService.GetAll()
            };

            return View(model);
        }

        [HttpGet] // Balance/DeleteCategory/1
        public ActionResult DeleteCategory(int id)
        {
            categoryService.Delete(id);

            return RedirectToAction("Category", "Balance");
        }

        [HttpGet] // Balance/Stat?year=2022
        public ActionResult Stat(int year = 2022)
        {
            return View(new Statistic
            {
                Table = statisticService.Get(year),
                Year = year
            });
        }
    }
}
