using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore.Models;

namespace MvcBookStore.Controllers
{
    public class NguoidungController : Controller
    {
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dangky()
        {
            return View();
        }

        dbQLBansach_dbmlDataContext db = new dbQLBansach_dbmlDataContext();

        [HttpPost]

        public ActionResult Dangky(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["matkhaunhaplai"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = string.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if(string.IsNullOrEmpty(hoten))
            {
                ViewData["lop1"] = "ho ten khach hang khong duoc de trong";
            }
            else if (string.IsNullOrEmpty(tendn))
            {
                ViewData["loi2"] = "phai nhap ten dang nhap";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi3"] = "phai nhap mat khau";
            }
            else if(string.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["loi4"] = "phai nhap lai mat khau";
            }
            if (string.IsNullOrEmpty(email))
            {
                ViewData["loi5"] = "email khong duoc bo trong";
            }
            if (string.IsNullOrEmpty(dienthoai))
            {
                ViewData["loi6"] = "phai nhap so dien thoai";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]

        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if(string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phai nhap ten dang nhap";
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "chuc mung dang nhap thanh cong";
                    Session["Taikhoan"] = kh;
                }
                else
                    ViewBag.Thongbao = "ten dang nhap hoac mat khau khong dung";
            }
            return View();
        }
    }
}