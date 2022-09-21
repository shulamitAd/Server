using EFModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public interface IProjectContext : IDisposable
    {
        DbSet<Jobs> Jobs { get; }
        DbContext CreateContext();
    }
}
