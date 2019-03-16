using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModelGenerator.Comparers
{
    public class ForeignKeyComparer:IComparer<IForeignKey>
    {
        public int Compare(IForeignKey baseForeignKey, IForeignKey testForeignKey)
        {
            var errorCount = 0;

            if (baseForeignKey.IsUnique != testForeignKey.IsUnique)
            {
                Console.WriteLine("{0} foreignkey: IsUnique is not equal",baseForeignKey.ToString());
                errorCount++;
            }
            
            if (baseForeignKey.IsRequired != testForeignKey.IsRequired)
            {
                Console.WriteLine("{0} foreignkey: IsRequired is not equal",baseForeignKey.ToString());
                errorCount++;
            }
            
            if (baseForeignKey.IsOwnership != testForeignKey.IsOwnership)
            {
                Console.WriteLine("{0} foreignkey: IsOwnership is not equal",baseForeignKey.ToString());
                errorCount++;
            }            
            
            if (baseForeignKey.DeclaringEntityType.Name != testForeignKey.DeclaringEntityType.Name)
            {
                Console.WriteLine("{0} foreignkey: DeclaringEntityType is not equal",baseForeignKey.ToString());
                errorCount++;
            }            
            
            if (baseForeignKey.DeleteBehavior != testForeignKey.DeleteBehavior)
            {
                Console.WriteLine("{0} foreignkey: DeleteBehavior is not equal",baseForeignKey.ToString());
                errorCount++;
            }                     
            
            if (baseForeignKey.DependentToPrincipal!=null && (baseForeignKey.DependentToPrincipal.Name != testForeignKey.DependentToPrincipal.Name))
            {
                Console.WriteLine("{0} foreignkey: DependentToPrincipal is not equal",baseForeignKey.ToString());
                errorCount++;
            }

            if (baseForeignKey.PrincipalToDependent != null && baseForeignKey.PrincipalToDependent.Name !=
                testForeignKey.PrincipalToDependent.Name)
            {
                Console.WriteLine("{0} foreignkey: PrincipalToDependent is not equal", baseForeignKey.ToString());
                errorCount++;
            }

            return errorCount;
        }
    }
}