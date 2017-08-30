using System;
using System.Collections.Generic;
using System.Text;

namespace Teste
{
    interface IDependencyResolver
    {
        T ResolveNamed<T>(string name);
    }
}
