using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST.Models;
using log4net.Config;
using log4net;
namespace TEST.Controllers

{
    public class pController : Controller
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: p
        /// <summary>
        /// this Index() is for to show the description of table.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            using (dbmodel obj = new dbmodel())
            {
                return View(obj.politics.ToList());
            }               
        }
        /// <summary>
        /// this method is for showing details of table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: p/Details/5
        public ActionResult Details(int id)
        {
            using (dbmodel obj = new dbmodel())
            {
                return View(obj.politics.Where(x => x.id == id).FirstOrDefault());
            }
        }
        /// <summary>
        /// this create() is for Creating a table
        /// </summary>
        /// <returns></returns>
        // GET: p/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p/Create
        [HttpPost]
        public ActionResult Create(politic collection)
        {
            try
            {
                using (dbmodel obj = new dbmodel())
                {
                   obj.politics.Add(collection);
                    obj.SaveChanges();
                    
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// this method is for edit the exsting data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: p/Edit/5
        public ActionResult Edit(int id)
        {
            using (dbmodel obj = new dbmodel())
            {
                return View(obj.politics.Where(x => x.id == id).FirstOrDefault());
            }
            return View();
        }

        // POST: p/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, politic collection)
        {
            try
            {
                using (dbmodel obj = new dbmodel())
                {
                    obj.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    obj.SaveChanges();
                }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: p/Delete/5
        public ActionResult Delete(int id)
        {
            using (dbmodel obj = new dbmodel())
            {
                return View(obj.politics.Where(x => x.id == id).FirstOrDefault());
            }
            return View();
        }
        /// <summary>
        /// this method is for deleting the exsting the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>

        // POST: p/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (dbmodel obj = new dbmodel())
                {
                    politic p = obj.politics.Where(x => x.id == id).FirstOrDefault();
                    obj.politics.Remove(p);
                    obj.SaveChanges();
                }
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
