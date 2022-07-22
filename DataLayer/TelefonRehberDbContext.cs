using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TelefonRehberDbContext : DbContext
    {
        public TelefonRehberDbContext(DbContextOptions<TelefonRehberDbContext> options)
         : base(options)
        {

        }
        public DbSet<Kisi> Kisiler { get; set; }
    }
}
