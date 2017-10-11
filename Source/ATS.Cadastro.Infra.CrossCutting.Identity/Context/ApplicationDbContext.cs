using ATS.Cadastro.Infra.CrossCutting.Identity.Modelo;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace ATS.Cadastro.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
