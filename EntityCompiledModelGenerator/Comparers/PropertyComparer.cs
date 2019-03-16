using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModelGenerator.Comparers
{
    public class PropertyComparer:IComparer<IProperty>
    {
        public int Compare(IProperty baseProperty, IProperty testProperty)
        {
            var errorCount = 0;

            if (baseProperty.IsNullable != testProperty.IsNullable)
            {
                Console.WriteLine("{0} key: IsNullable is not equal",baseProperty.ToString());
                errorCount++;
            }

            if (baseProperty.IsShadowProperty != testProperty.IsShadowProperty)
            {
                Console.WriteLine("{0} key: IsShadowProperty is not equal",baseProperty.ToString());
                errorCount++;                
            }

            if (baseProperty.IsConcurrencyToken != testProperty.IsConcurrencyToken)
            {
                Console.WriteLine("{0} key: IsConcurrencyToken is not equal",baseProperty.ToString());
                errorCount++;
            }

            if (baseProperty.DeclaringEntityType.Name != testProperty.DeclaringEntityType.Name)
            {                
                Console.WriteLine("{0} key: DeclaringEntityType is not equal",baseProperty.ToString());
                errorCount++;
            }

            if (baseProperty.BeforeSaveBehavior != testProperty.BeforeSaveBehavior)
            {                             
                Console.WriteLine("{0} key: BeforeSaveBehavior is not equal",baseProperty.ToString());
                errorCount++;
            }
            if (baseProperty.AfterSaveBehavior != testProperty.AfterSaveBehavior)
            {                             
                Console.WriteLine("{0} key: AfterSaveBehavior is not equal",baseProperty.ToString());
                errorCount++;
            }
            
            if (baseProperty.ValueGenerated != testProperty.ValueGenerated)
            {                             
                Console.WriteLine("{0} key: ValueGenerated is not equal",baseProperty.ToString());
                errorCount++;
            }

            if (baseProperty.ClrType.FullName != testProperty.ClrType.FullName)
            {                             
                Console.WriteLine("{0} key: ClrType is not equal",baseProperty.ToString());
                errorCount++;
            }
            

            return errorCount;
        }
    }
}