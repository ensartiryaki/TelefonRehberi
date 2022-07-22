using DataLayer.Entities;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelefonRehberi.Controllers
{
    public class KisiController : Controller
    {
        KisiRepository _kisiRepository;
        public KisiController(KisiRepository kisiRepository)
        {
            _kisiRepository = kisiRepository;
        }
        public ActionResult Index()
        {
            List<Kisi> model = _kisiRepository.KisiListesi();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            Kisi kisi = _kisiRepository.KisileriGetir(id);
            return View(kisi);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kisi kisi)
        {
            ModelState.Clear();
            if (_kisiRepository.KisiListesi().FirstOrDefault(c=>c.TCKimlik==kisi.TCKimlik)!=null)
            {
                ModelState.AddModelError("TCKimlik", "Daha önce kullanılmış");
            }
            if (_kisiRepository.KisiListesi().FirstOrDefault(c=>c.Telefon==kisi.Telefon)!=null)
            {
                ModelState.AddModelError("Telefon", "Daha önce kullanılmış");
            }
            if (_kisiRepository.KisiListesi().FirstOrDefault(c => c.EMail == kisi.EMail) != null)
            {
                ModelState.AddModelError("EMail", "Daha önce kullanılmış");
            }
            if (ModelState.IsValid)
            {
                _kisiRepository.AddOrUpdateKisi(kisi);
                return RedirectToAction("Index");
            }
            return View(kisi);
        }
        public ActionResult Edit(int id)
        {
            Kisi kisi = _kisiRepository.KisileriGetir(id);
            return View(kisi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kisi kisi)
        {
            _kisiRepository.AddOrUpdateKisi(kisi);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _kisiRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
