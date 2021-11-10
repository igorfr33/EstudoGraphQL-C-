using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    //Classe de Contexto do Banco de Dados
    public class AppDbContext : DbContext 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
