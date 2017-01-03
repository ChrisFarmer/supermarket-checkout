using GoCoSupermarket.BusinessLogic;
using GoCoSupermarket.BusinessLogicInterfaces;
using StructureMap;

namespace GoCoSupermarket.DependencyInjection
{
    /// <summary>
    /// Used by StructureMap to initialise certain assemblies for dependency injection.
    /// </summary>
    public class ApplicationRegistry : Registry
    {
        /// <summary>
        /// Used to initialise the classes that StructureMap will instantiate and inject through constructors.
        /// </summary>
        public ApplicationRegistry()
        {
            this.Scan(x =>
            {
                x.Assembly("GoCoSupermarket.BusinessLogicInterfaces");
                x.Assembly("GoCoSupermarket.BusinessLogic");
                x.Assembly("GoCoSupermarket.Data");
                x.Assembly("GoCoSupermarket.DataInterfaces");
                x.WithDefaultConventions();
            });
        }
    }
}
