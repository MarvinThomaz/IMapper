using System;
using System.Collections.Generic;
using System.Text;

namespace Teste
{
    interface ITransactionManager : IDisposable
    {
        IDisposable Begin();
        void Commit();
        void Rollback();
    }
}
