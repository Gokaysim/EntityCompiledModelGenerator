using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModelGenerator.Comparers
{
    public class NavigationComparer:IComparer<INavigation>
    {
        public int Compare(INavigation baseNavigation, INavigation testNavigation)
        {
            var errorCount = 0;

            if (baseNavigation.IsEagerLoaded != testNavigation.IsEagerLoaded)
            {                
                Console.WriteLine("{0} navigation: IsEagerLoaded is not equal",baseNavigation.ToString());
                errorCount++;
            }
            
            if (baseNavigation.IsShadowProperty != testNavigation.IsShadowProperty)
            {                
                Console.WriteLine("{0} navigation: IsShadowProperty is not equal",baseNavigation.ToString());
                errorCount++;
            }
            
            if (baseNavigation.Name != testNavigation.Name)
            {                
                Console.WriteLine("{0} navigation: Name is not equal",baseNavigation.ToString());
                errorCount++;
            }
            
            if (baseNavigation.DeclaringEntityType.Name != testNavigation.DeclaringEntityType.Name)
            {                
                Console.WriteLine("{0} navigation: DeclaringEntityType is not equal",baseNavigation.ToString());
                errorCount++;
            }
            
            if (baseNavigation.ClrType.FullName != testNavigation.ClrType.FullName)
            {                
                Console.WriteLine("{0} navigation: ClrType is not equal",baseNavigation.ToString());
                errorCount++;
            }
            
            if ((baseNavigation.PropertyInfo.DeclaringType.FullName !=testNavigation.PropertyInfo.DeclaringType.FullName)
                ||(baseNavigation.PropertyInfo.Name != testNavigation.PropertyInfo.Name))
            {
                Console.WriteLine("{0} navigation: PropertyInfo is not equal",baseNavigation.ToString());
                errorCount++;
            }
            
            if ((baseNavigation.FieldInfo.DeclaringType.FullName !=testNavigation.FieldInfo.DeclaringType.FullName)
                ||(baseNavigation.FieldInfo.Name != testNavigation.FieldInfo.Name))
            {                
                Console.WriteLine("{0} navigation: FieldInfo is not equal",baseNavigation.ToString());
                errorCount++;
            }
            
            
            AnnotationComparer annotationComparer = new AnnotationComparer();
            foreach (var baseAnnotation in baseNavigation.GetAnnotations())
            {
                errorCount += annotationComparer.Compare(baseAnnotation,testNavigation.FindAnnotation(baseAnnotation.Name));
            }
            

            return errorCount;
        }
    }
}