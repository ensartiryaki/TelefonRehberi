using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
   public class KisiRepository
    {
        TelefonRehberDbContext _ctx;
        public KisiRepository(TelefonRehberDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Kisi> KisiListesi()
        {
            return _ctx.Kisiler.ToList();
        }
        public void AddOrUpdateKisi(Kisi kisi)
        {
            if (kisi.KisiId<=0)
            {
                _ctx.Kisiler.Add(kisi);
            }
            else
            {
                _ctx.Attach(kisi);
                _ctx.Entry(kisi).State = EntityState.Modified;
            }
            _ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            var silinecek = _ctx.Kisiler.FirstOrDefault(c => c.KisiId == id);
            _ctx.Kisiler.Remove(silinecek);
            _ctx.SaveChanges();
        }
        public Kisi KisileriGetir(int id)
        {
            return _ctx.Kisiler.FirstOrDefault(c => c.KisiId == id);
        }
    }
}
