using Evday.JaGo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evday.JaGo.EJDb.Repositories
{
    public class TestDbRepository : EFRepository
    {
        public TestDbRepository()
        {
           base._Context= new TestDbContext();
        }
    }
}
