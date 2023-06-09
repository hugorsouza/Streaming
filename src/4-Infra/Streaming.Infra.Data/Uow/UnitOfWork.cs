using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streaming.Infra.Data.Interfaces;

namespace Streaming.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
