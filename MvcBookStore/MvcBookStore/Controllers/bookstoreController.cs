using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcBookStore.Models;



namespace MvcBookStore.Controllers
{
    public class bookstoreController : Controller
    {
        // GET: bookstore
        dbQLBansach_dbmlDataContext data = new dbQLBansach_dbmlDataContext();

        private List<SACH> laysachmoi(int count)
        {
            return data.SACHes.OrderBy(a => a.Ngaycapnhat).Take(count).ToList();

        }
        public ActionResult Index()
        {
            var sachmoi = laysachmoi(5);
            return View(sachmoi);
        }
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult NhaXuatBan()
        {
            var nhaxb = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(nhaxb);
        }

        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }

        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }
    }
}