using System;
using StructureMap;

namespace ConductOfCode
{
    public static class IoC
    {
        private static readonly Lazy<Container> Lazy = new Lazy<Container>(CreateContainer);

        public static IContainer Container => Lazy.Value;

        private static Container CreateContainer()
        {
            return new Container(_ =>
                _.Scan(x =>
                {
                    x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    x.LookForRegistries();
                })
            );
        }
    }
}