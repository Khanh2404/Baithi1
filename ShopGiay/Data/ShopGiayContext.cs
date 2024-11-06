using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGiay.Models;

namespace ShopGiay.Data
{
    public class ShopGiayContext : DbContext
    {
        public ShopGiayContext (DbContextOptions<ShopGiayContext> options)
            : base(options)
        {
        }

        public DbSet<ShopGiay.Models.LoaiGiay> LoaiGiay { get; set; } = default!;
        public DbSet<ShopGiay.Models.ChiTietGiay> ChiTietGiay { get; set; } = default!;
    }
}
