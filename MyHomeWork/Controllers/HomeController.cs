using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomeWork.Controllers
{
    using MyHomeWork.Models.ViewModels;

    public class HomeController : Controller
    {
        List<AssetViewModel> _AssetModel = new List<AssetViewModel>();
        
        public HomeController()
        {
            _AssetModel.Add(new AssetViewModel()
            {
                Type = 1,
                Date = DateTime.Now.ToString(),
                Amt = 1000,
                Remark = "Hello1",
                IsEdit = false
            });
            _AssetModel.Add(new AssetViewModel()
            {
                Type = 2,
                Date = DateTime.Now.ToString(),
                Amt = 2000,
                Remark = "Hello2",
                IsEdit = false
            });
            _AssetModel.Add(new AssetViewModel()
            {
                Type = 1,
                Date = DateTime.Now.ToString(),
                Amt = 3000,
                Remark = "Hello3",
                IsEdit = false
            });
            _AssetModel.Add(new AssetViewModel()
            {
                Type = 1,
                Date = DateTime.Now.ToString(),
                Amt = 4000,
                Remark = "Hello4",
                IsEdit = false
            });
            _AssetModel.Add(new AssetViewModel()
            {
                Type = 1,
                Date = DateTime.Now.ToString(),
                Amt = 5000,
                Remark = "Hello5",
                IsEdit = false
            });
        }

       /// <summary>
       /// 帳本列表
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            //測試Commit
            if (TempData["Model"] != null)
            {
                var model = TempData["Model"] as AssetViewModel;
                _AssetModel.Add(model);
            }
            var i = 0;
            if (TempData["id"] != null)
            {
                var IdList = ((string)TempData["id"]).Split(',') ;
                foreach (var id in IdList)
                {                
                    var modelId = Convert.ToInt32(id);
                    if (i > 0) modelId -= i;
                    _AssetModel.RemoveAt(modelId-1);
                    i++;
                }
          }
            return View(_AssetModel as List<AssetViewModel>);
        }

        /// <summary>
        /// 單筆刪除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Del(string id)
        {
            TempData["id"] = id;
            return Content("<script>window.location='/Home/Index';</script>");
        }

        /// <summary>
        /// 編輯頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult MyForm()
        {
            ViewBag.ddlType = GetTypeSel().AsEnumerable();          
            return View();
        }

        /// <summary>
        /// 獲取帳本類別
        /// </summary>
        /// <returns>DropDownList</returns>
        public SelectList GetTypeSel()
        {
            List<SelectListItem> type = new List<SelectListItem>();
            type.Add(new SelectListItem()
            {
                Text = "支出",
                Value = "1"
            });
            type.Add(new SelectListItem()
            {
                Text = "收入",
                Value = "2"
            });
            SelectList list = new SelectList(type, "Value", "Text");
            return list;
        }

        /// <summary>
        /// 送出
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MyForm(AssetViewModel model, int rid)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ddlType = GetTypeSel().AsEnumerable();
                return View("MyForm");
            }
            if (model.IsEdit)
            {
                TempData["id"] = rid.ToString();
            }
            TempData["Model"] = model;         
           return Content("<script>window.location='/Home/Index'</script>");
        }

        /// <summary>
        /// 取得編輯資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditGet(string id)
        {
            int rid = int.Parse(id);
            var model = _AssetModel[rid-1];
            model.IsEdit = true;
            ViewBag.id = id;
            ViewBag.ddlType = GetTypeSel().AsEnumerable();
            return View("MyForm", model);
        }

        /// <summary>
        /// 刪除多筆
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DelList(string id)
        {
            TempData["id"] = id.TrimEnd(',');         
          return Redirect("/Home/Index");
            //return Content("<script>window.location='/Home/Index';</script>");
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
  

    }
}
