using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityCompiledModelGenerator.Comparers
{
    public class AnnotationComparer:IComparer<IAnnotation>
    {
        public int Compare(IAnnotation baseAnnotation, IAnnotation testAnnotation)
        {
            var errorCount = 0;

            if (baseAnnotation.Name != testAnnotation.Name)
            {
                Console.WriteLine("{0} annotation: Name is not equal",baseAnnotation.ToString());
                errorCount++;
            }

            Type valueType = baseAnnotation.Value.GetType();

            if (valueType == typeof(string))
            {
                if((string)baseAnnotation.Value!= (string)testAnnotation.Value)
                {
                    Console.WriteLine("{0} annotation: Value is not equal",baseAnnotation.ToString());
                    errorCount++;                    
                }                
            }
            else if (typeof(DirectConstructorBinding) == valueType)
            {
            }

            return errorCount;
        }
    }
}