using System;
using System.Collections.Generic;
using System.Text;

namespace Teste
{
    public class Program
    {
        private readonly IDependencyResolver _resolver;
        private readonly ITransactionManager _transaction;

        public Program(IDependencyResolver resolver, ITransactionManager transaction)
        {
            _resolver = resolver;
            _transaction = transaction;
        }

        public void MapTypes()
        {
            using (_transaction.Begin())
            {
                foreach (var name in Enum.GetNames(typeof(Types)))
                {
                    var mapper = _resolver.ResolveNamed<IMapper>($"{name}Mapper");
                    var repository = _resolver.ResolveNamed<IRepository>(name);
                    var item = mapper.Map(name);

                    repository.Create(item);
                }

                _transaction.Commit();
            }
        }
    }
}