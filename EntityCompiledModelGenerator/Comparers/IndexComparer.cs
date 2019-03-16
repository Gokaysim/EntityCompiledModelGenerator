using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModelGenerator.Comparers
{
    public class IndexComparer:IComparer<IIndex>
    {
        public int Compare(IIndex baseIndex, IIndex testIndex)
        {
            var returnVal = 0;

            if (baseIndex.IsUnique != testIndex.IsUnique)
            {
                Console.WriteLine("{0} base entity: IsUnique is not equal",baseIndex.ToString());
                --returnVal;
            }
            
            if (baseIndex.DeclaringEntityType.Name != testIndex.DeclaringEntityType.Name)
            {
                Console.WriteLine("{0} base entity: DeclaringEntityType is not equal",baseIndex.ToString());
                --returnVal;
            }
            

            return returnVal;
        }
    }
}