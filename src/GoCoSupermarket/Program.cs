using GoCoSupermarket.DependencyInjection;
using StructureMap;

namespace GoCoSupermarket.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialise the DI container and run the application
            var container = Container.For<ApplicationRegistry>();
            container.GetInstance<GoCoSupermarket>().Run(args);
        }
    }
}