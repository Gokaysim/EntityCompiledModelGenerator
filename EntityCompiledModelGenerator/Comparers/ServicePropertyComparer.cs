using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModelGenerator.Comparers
{
    public class ServicePropertyComparer:IComparer<IServiceProperty>
    {
        public int Compare(IServiceProperty baseServiceProperty, IServiceProperty testServiceProperty)
        {
            var errorCount = 0;

            if (baseServiceProperty.DeclaringEntityType.Name != testServiceProperty.DeclaringEntityType.Name)
            {
                
                Console.WriteLine("{0} service property: DeclaringEntityType is not equal",baseServiceProperty.ToString());
            }

            return errorCount;
        }
    }
}