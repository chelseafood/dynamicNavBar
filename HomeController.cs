using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnePASFrontEndPrototypeOne.Controllers
{
    public class samplecollection
    {
        public int id = 0;
        public string title = string.Empty;
        public int parentid = 0;
        public string role = string.Empty;
        //List<string> role = new List<string> { };
    }

    public class HomeController : Controller
    {

        //public async System.Threading.Tasks.Task<ActionResult> IndexAsync()
        //{
        //    var tblMenuActionss = from m in testdb.tblMenuActions
        //                          where m.Deleted == false
        //                          select m;

        //    return View(await tblMenuActionss.ToListAsync());

        //}
        List<samplecollection> ActionCollection = null;
        public List<string> ActionMenus = new List<string>();
        public ActionResult Index()
        {
            ActionCollection = new List<samplecollection>();

            samplecollection item = new samplecollection();
            item.id = 1;
            item.parentid = 0;
            item.title = "A";
            item.role = "AH";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 2;
            item.parentid = 0;
            item.title = "B";
            item.role = "RV";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 3;
            item.parentid = 0;
            item.title = "C";
            item.role = "MG";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 4;
            item.parentid = 1;
            item.title = "A1";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 5;
            item.parentid = 1;
            item.title = "A2";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 6;
            item.parentid = 5;
            item.title = "A21";
            item.role = "RV";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 7;
            item.parentid = 5;
            item.title = "A22";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 8;
            item.parentid = 7;
            item.title = "A221";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 9;
            item.parentid = 7;
            item.title = "A222";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 10;
            item.parentid = 9;
            item.title = "A2221";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 11;
            item.parentid = 9;
            item.title = "A2222";
            ActionCollection.Add(item);



            List<samplecollection>  aaa = (List<samplecollection>) (ActionCollection.Where(p => p.parentid == 0 && p.role=="AH").ToList()); 
            foreach (samplecollection sampleitem in aaa)
            {
                ActionMenu(sampleitem, ActionMenus);
            }
            ViewBag.ActionMenus = this.ActionMenus;
            return View();
        }

        public void ActionMenu(samplecollection sampleitem, List<string> ActionMenus)
        {
            List<samplecollection> aaa = (List<samplecollection>)(ActionCollection.Where(p => p.parentid == sampleitem.id).ToList());
            if(aaa.Count > 0)
            {
                if (sampleitem.parentid == 0)
                {
                    ActionMenus.Add(@"<li role = ""presentation"" class=""dropdown"">");
                    ActionMenus.Add(@"<a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"" role=""button"" aria-haspopup=""true"" aria-expanded=""false"">" + sampleitem.title + @"<span class=""caret""></span></a>");

                }
                else
                {
                    ActionMenus.Add(@"<li  class=""dropdown-submenu"">");
                    ActionMenus.Add(@"<a class=""test"" href=""#"">" + sampleitem.title);
                    
                }
                ActionMenus.Add(@"<ul class=""dropdown-menu"">");
            }
            else
            {
               
                    ActionMenus.Add(@"<li><a href=""www.google.com.sg"">" + sampleitem.title + @"</a></li>");
               
            }

            foreach (samplecollection Item in aaa)
            {
                ActionMenu(Item, ActionMenus);
            }

            if (aaa.Count > 0)
            {
                ActionMenus.Add(@"</ul>");
                ActionMenus.Add(@"</li>");
            }
        }

        public ActionResult About()
        {
            ActionCollection = new List<samplecollection>();

            samplecollection item = new samplecollection();
            item.id = 1;
            item.parentid = 0;
            item.title = "A";
            item.role = "AH";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 2;
            item.parentid = 0;
            item.title = "B";
            item.role = "RV";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 3;
            item.parentid = 0;
            item.title = "C";
            item.role = "MG";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 4;
            item.parentid = 1;
            item.title = "A1";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 5;
            item.parentid = 1;
            item.title = "A2";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 6;
            item.parentid = 5;
            item.title = "A21";
            item.role = "RV";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 7;
            item.parentid = 5;
            item.title = "A22";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 8;
            item.parentid = 7;
            item.title = "A221";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 9;
            item.parentid = 7;
            item.title = "A222";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 10;
            item.parentid = 9;
            item.title = "A2221";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 11;
            item.parentid = 9;
            item.title = "A2222";
            ActionCollection.Add(item);



            List<samplecollection> aaa = (List<samplecollection>)(ActionCollection.Where(p => p.parentid == 0 && p.role == "AH").ToList());
            foreach (samplecollection sampleitem in aaa)
            {
                ActionMenu(sampleitem, ActionMenus);
            }
            ViewBag.ActionMenus = this.ActionMenus;

            return View();
        }

        public ActionResult Contact()
        {
            ActionCollection = new List<samplecollection>();

            samplecollection item = new samplecollection();
            item.id = 1;
            item.parentid = 0;
            item.title = "A";
            item.role = "AH";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 2;
            item.parentid = 0;
            item.title = "B";
            item.role = "RV";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 3;
            item.parentid = 0;
            item.title = "C";
            item.role = "MG";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 4;
            item.parentid = 1;
            item.title = "A1";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 5;
            item.parentid = 1;
            item.title = "A2";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 6;
            item.parentid = 5;
            item.title = "A21";
            item.role = "RV";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 7;
            item.parentid = 5;
            item.title = "A22";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 8;
            item.parentid = 7;
            item.title = "A221";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 9;
            item.parentid = 7;
            item.title = "A222";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 10;
            item.parentid = 9;
            item.title = "A2221";
            ActionCollection.Add(item);

            item = new samplecollection();
            item.id = 11;
            item.parentid = 9;
            item.title = "A2222";
            ActionCollection.Add(item);



            List<samplecollection> aaa = (List<samplecollection>)(ActionCollection.Where(p => p.parentid == 0 && p.role == "AH").ToList());
            foreach (samplecollection sampleitem in aaa)
            {
                ActionMenu(sampleitem, ActionMenus);
            }
            ViewBag.ActionMenus = this.ActionMenus;
            return View();
        }
    }

}
