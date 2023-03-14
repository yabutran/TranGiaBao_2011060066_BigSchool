using _34_TranGiaBao_2011060066.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _34_TranGiaBao_2011060066.Controllers
{
    public class RubikController : Controller
    {
        dbRubikDataContext data = new dbRubikDataContext();
        // GET: Rubik
        public ActionResult Index()
        {
            var all_rubik = from r in data.Rubiks select r;

            return View(all_rubik);
        }
        public ActionResult Detail(int id)
        {
            var d_rubik = data.Rubiks.Where(m => m.id == id).First();
            return View(d_rubik);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, Rubik s)
        {
            var E_ten = collection["ten"];
            var E_mota = collection["mota"];
            var E_hang = collection["hang"];
            var E_gia = Convert.ToDecimal(collection["giaban"]);
            var E_hinh = collection["hinh"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don 't empty!";
            }
            else
            {

                s.ten = E_ten.ToString();
                s.mota = E_mota.ToString();
                s.hang = E_hang.ToString();
                s.gia = E_gia;
                s.hinh = E_hinh.ToString();
                s.ngaycapnhat = E_ngaycapnhat;
                s.soluongton = E_soluongton;
                data.Rubiks.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        public ActionResult Edit(int id)
        {
            var E_sach = data.Rubiks.First(m => m.id == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_rubik = data.Rubiks.First(m => m.id == id);
            var E_ten = collection["ten"];
            var E_mota = collection["mota"];
            var E_hang = collection["hang"];
            var E_gia = Convert.ToDecimal(collection["gia"]);
            var E_hinh = collection["hinh"];
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_rubik.id = id;
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                E_rubik.ten = E_ten.ToString();
                E_rubik.mota = E_mota.ToString();
                E_rubik.hang = E_ten.ToString();
                E_rubik.gia = E_gia;
                E_rubik.hinh = E_hinh.ToString();
                E_rubik.ngaycapnhat = E_ngaycapnhat;
                E_rubik.soluongton = E_soluongton;
                UpdateModel(E_rubik);
                data.SubmitChanges();
                return RedirectToAction("Index");

            }
            return this.Edit(id);


        }
        public ActionResult Delete(int id)
        {
            var D_sach = data.Rubiks.First(m=>m.id==id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete (int id, FormCollection collection)
        {
            var D_Sach=data.Rubiks.Where(m=>m.id==id).First();
            data.Rubiks.DeleteOnSubmit(D_Sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}