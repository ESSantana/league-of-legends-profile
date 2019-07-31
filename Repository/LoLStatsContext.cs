using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoLStats.Models;
using System.Data.SqlClient;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LoLStats.Controllers.model;

namespace LoLStats.Repository
{
    public class LoLStatsContext : DbContext
    {
        public DbSet<Perfil> Perfil { get; set; }

        public LoLStatsContext(DbContextOptions<LoLStatsContext> options) : base(options)
        {

        }
    }
}
