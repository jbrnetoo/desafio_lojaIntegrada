using System.Collections.Generic;
using System.Reflection;

namespace LI.Carrinho.CrossCutting.Assemblies
{
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("LI.Carrinho.API"),
                Assembly.Load("LI.Carrinho.Domain"),
                Assembly.Load("LI.Carrinho.Application"),
                Assembly.Load("LI.Carrinho.CrossCutting"),
                Assembly.Load("LI.Carrinho.Infrastructure")
            };
        }
    }
}
