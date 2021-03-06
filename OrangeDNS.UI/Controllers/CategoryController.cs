﻿#region copyright
// Copyright (c) 2017 All Rights Reserved
// Author: İsmail Kundakcı
// Author Website: www.ismailkundakci.com
// Author Email: ism.kundakci@hotmail.com
// Date: 19/03/2017 13:15:00
// Description: OrangeDNS is a powerfull dns firewall solution written by C# used ARSoft.Tools.Net library
// ARSoft.Tools.Net Page: arsofttoolsnet.codeplex.com
#endregion
using OrangeDNS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeDNS.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            if (Session["UserId"] == null) return RedirectToAction("login", "home");
            List<Category> categories = null;
            using (OrangeDNSDataContext dc = new OrangeDNSDataContext())
            {
                categories = dc.Categories.ToList();
            }
            return View(categories);
        }
        public ActionResult Delete(int categoryId)
        {
            if (Session["UserId"] == null) return RedirectToAction("login", "home");
            List<Category> categories = null;
            using (OrangeDNSDataContext dc = new OrangeDNSDataContext())
            {
                Category category = dc.Categories.SingleOrDefault(c => c.Id == categoryId);
                dc.Categories.Remove(category);
                dc.SaveChanges();
                categories = dc.Categories.ToList();
            }
            ViewData["ResultMsg"] = "Kategori başarıyla silindi!";
            return View("index", categories);
        }
        public ActionResult Add()
        {
            if (Session["UserId"] == null) return RedirectToAction("login", "home");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category Model)
        {
            if (Session["UserId"] == null) return RedirectToAction("login", "home");
            using (OrangeDNSDataContext dc = new OrangeDNSDataContext())
            {
                if (!ModelState.IsValid)
                { ViewData["ResultMsg"] = "Hata kategori eklenemedi!"; return View(); }

                dc.Categories.Add(Model);
                dc.SaveChanges();
                ModelState.Clear();
                ViewData["ResultMsg"] = "Kategori başarıyla eklendi!";
            }
            return View();
        }
    }
}