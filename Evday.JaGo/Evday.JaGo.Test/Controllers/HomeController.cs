using Evday.JaGo.Core.Repositories;
using Evday.JaGo.EJDb.Entities;
using Evday.JaGo.EJDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Evday.JaGo.Test.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            //var _rep = new TestDbRepository();
            //var list = _rep.GetModel<Teacher>(item => item.tId < 4).ToList();

            //list.ForEach(item => item.Name = "aldjflajsdflajsdflajfd");

            ////_rep.BulkUpdate<Teacher>(list);
            //_rep.BulkInsert<Teacher>(list);
            TestXElement();
            return View();
        }


        public void TestUow()
        {
            var _uow = new UnitOfWork<Teacher>();
            var _rep = new TestDbRepository();
            _uow.RegisterChangeded(new Teacher() { }, SqlType.Insert, _rep);
        }

        public void TestXElement()
        {
            var souces = new List<Teacher>() {
                new Teacher(){ Name="zhangsan", tId= 1 },
                new Teacher(){ Name="lisi", tId= 2 }
            };

            var node = from a in souces
                       select new XElement("teacher",
                       new XAttribute("id", a.tId),
                       new XAttribute("name", a.Name)
                       );

            XElement xmlTree1 = new XElement("Teachers",node);

            

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}