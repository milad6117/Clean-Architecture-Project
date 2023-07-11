using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Entities;
using Trial.Core.Extension;

namespace Trial.Data.Extension
{
    public static class Extension
    {
        public static void CreateON(this ModelBuilder modelBuilder)
        {
            var ListIDateEntities = typeof(IDateEntity).GetAllClassName();

            var ListEntitiesMap = modelBuilder.Model.GetEntityTypes().Where(p => ListIDateEntities.Contains(p.ClrType.FullName));

            foreach (var EntityMap in ListEntitiesMap)
            {

                var props = EntityMap.FindProperty("CreateON");
                if (props != null)
                {
                    props.ValueGenerated = ValueGenerated.OnAdd;
                    props.SetDefaultValue("GETDATE()");
                }
            }
        }
    }
}
