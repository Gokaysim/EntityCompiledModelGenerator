using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModelGenerator.Comparers
{
    public class KeyComparer:IComparer<IKey>
    {
        public int Compare(IKey baseKey, IKey testKey)
        {
            var errorCount = 0;

            if (baseKey.DeclaringEntityType.Name != testKey.DeclaringEntityType.Name)
            {
                Console.WriteLine("{0} key: DeclaringEntityType is not equal",baseKey.ToString());
                errorCount++;
            }

            if (baseKey.Properties.Count != testKey.Properties.Count)
            {
                Console.WriteLine("{0} key: Properties count is not equal",baseKey.ToString());
                errorCount++;
            }

            foreach (var property in baseKey.Properties)
            {
                var count = testKey.Properties.Count(p => property.Name == p.Name);
                if (count ==0)
                {
                    Console.WriteLine("{0} key: {1} property: Properties not found ",baseKey.ToString(),property.Name);
                    errorCount++;
                }
                if (count >1)
                {
                    Console.WriteLine("{0} key: {1} property: Properties found more than once",baseKey.ToString(),property.Name);
                    errorCount++;
                }
            }

            return errorCount;
        }
    }
}