using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ManangementEntitiesSingleton
    {
        private static readonly Lazy<Building_ManangementEntities>
        lazy =
        new Lazy<Building_ManangementEntities>
            (() => new Building_ManangementEntities());

        public static Building_ManangementEntities Instance { get { return lazy.Value; } }
        private ManangementEntitiesSingleton()
        {
        }
    }
}

