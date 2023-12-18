using BlogTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbs;
using System.Data.SqlClient;

namespace BlogTracker.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult SaveEmployee()
        {
            return View();
        }

        public ActionResult ListOfBlogs() 
        {
            return View();
        
        }

        public ActionResult List_Of_Blogs()
        {
            dbs.blogEntities dbs = new dbs.blogEntities();
            List<blogInfo> listTo = dbs.blogInfoes.ToList(); 
            List<BlogInfoModel> bmodel = new List<BlogInfoModel>();
            foreach (var item in listTo)
            {
                BlogInfoModel model = new BlogInfoModel();
                model.Title = item.title;
                model.BlogId = (int)item.blogId;
                model.Subject = item.subject;
                model.DateOfCreation = (DateTime)item.dateOfCreation;
                model.EmpEmailId = item.empEmailId;
                model.BlogUrl = item.blogUrl;
                bmodel.Add(model);
            }
            return View(bmodel);
        }

        public ActionResult EmployeeList()
        {

            dbs.blogEntities db = new dbs.blogEntities();
            List<emp> listTo = db.emps.ToList();
            List<EmployeeModel> emodel = new List<EmployeeModel>();
            foreach (var item in listTo)
            {
                EmployeeModel model = new EmployeeModel();
                model.EmailId = item.emailId;
                model.Name = item.name;
                model.DateOfJoining = (DateTime)item.dateOfJoin;
                model.Passcode = (int)item.passcode;
                emodel.Add(model);
            }
            return View(emodel);

        }

        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(FormCollection collection)
        {
            dbs.blogEntities dbs = new dbs.blogEntities();

            EmployeeModel m = new EmployeeModel();
            m.EmailId = collection["EmailId"];
            m.Name = collection["Name"].ToString();
            m.DateOfJoining = Convert.ToDateTime(collection["DateOfJoining"]);
            m.Passcode = Convert.ToInt32(collection["PassCode"]);

            emp s = new emp();
            s.emailId = m.EmailId;
            s.name = m.Name;
            s.dateOfJoin = Convert.ToDateTime(m.DateOfJoining);
            s.passcode = (Convert.ToInt32(m.Passcode));
            dbs.emps.Add(s);
            dbs.SaveChanges();
            return RedirectToAction("EmployeeList");
        }

        public ActionResult Edit(int id)
        {
            dbs.blogEntities dbs = new dbs.blogEntities();
            emp s = dbs.emps.Find(id);          
            EmployeeModel m = new EmployeeModel();
            m.EmailId = s.emailId;
            m.Name = s.name;
            m.DateOfJoining = Convert.ToDateTime(s.dateOfJoin);
            m.Passcode = Convert.ToInt32(s.passcode);
            return View(m);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                dbs.blogEntities dbs = new dbs.blogEntities();
                emp m = dbs.emps.Find(id);
                m.emailId = collection["EmailId"];
                m.name = collection["Name"].ToString();
                m.dateOfJoin = Convert.ToDateTime(collection["DateOfJoining"]);
                m.passcode = Convert.ToInt32(collection["PassCode"]);


                dbs.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            dbs.blogEntities dbs = new dbs.blogEntities();
            emp s = dbs.emps.Find(id);
            EmployeeModel m = new EmployeeModel();
            m.EmailId = s.emailId;
            m.Name = s.name;
            m.DateOfJoining = Convert.ToDateTime(s.dateOfJoin);
            m.Passcode = Convert.ToInt32(s.passcode);
            return View(m);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dbs.blogEntities dbs = new dbs.blogEntities();
                emp s = dbs.emps.Find(id);
                dbs.emps.Remove(s);

                dbs.SaveChanges();

                return RedirectToAction("EmployeeList");
            }
            catch
            {
                return View();
            }
        }
    }
 }
