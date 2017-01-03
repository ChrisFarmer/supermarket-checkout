using GoCoSupermarket.BusinessLogic;
using GoCoSupermarket.BusinessLogicInterfaces;
using StructureMap;

namespace GoCoSupermarket.DependencyInjection
{
    public class ApplicationRegistry : Registry
    {
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
