using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModelGenerator.Comparers
{
    public class ModelComparer:IComparer<IModel>
    {
        public int Compare(IModel baseModel, IModel testModel)
        {
            var baseModelEntityTypes= baseModel.GetEntityTypes();
            var testModelEntityTypes= testModel.GetEntityTypes();

            EntityTypeComparer entityTypeComparer = new EntityTypeComparer();
            var errorCount = 0;
            foreach (var entityType in baseModelEntityTypes)
            {
                errorCount += entityTypeComparer.Compare(entityType,testModelEntityTypes.FirstOrDefault(p=>p.Name == entityType.Name));
            }

            if (errorCount == 0)
            {
                Console.WriteLine("No error found");
            }
            else
            {
                Console.WriteLine("Error count {0}",errorCount);
            }
            return errorCount;
        }
    }
}