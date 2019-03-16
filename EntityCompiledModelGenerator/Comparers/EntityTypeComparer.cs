using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityCompiledModelGenerator.Comparers
{
    public class EntityTypeComparer:IComparer<IEntityType>
    {


        public int Compare(IEntityType baseEntity, IEntityType testEntity)
        {
            int errorCount = 0;
            if (baseEntity == null && testEntity == null)
            {
                return errorCount;
            }

            if (baseEntity != null && testEntity == null)
            {
 
                Console.WriteLine("{0} base entity: basetype is not equal",baseEntity.Name);              
                errorCount++;
                return errorCount;
            }
            if (baseEntity == null )
            {
 
                Console.WriteLine("{0} base entity: basetype is not equal",baseEntity.Name);              
                errorCount++;
                return errorCount;
            }
            
            
            if (baseEntity.IsQueryType != testEntity.IsQueryType)
            {
                Console.WriteLine("{0} base entity: IsQueryType is not equal",baseEntity.Name);
                errorCount++;
            }

            errorCount += Compare(baseEntity.BaseType, testEntity.BaseType);
            
            
            //TODO lamba check            

            if (baseEntity.Name != testEntity.Name)
            {
                Console.WriteLine("{0} base entity: Name is not equal",baseEntity.Name);
                errorCount++;                
            }
            
            if (baseEntity.DefiningNavigationName != testEntity.DefiningNavigationName)
            {
                Console.WriteLine("{0} base entity: DefiningNavigationName is not equal",baseEntity.Name);
                errorCount++;                
            }

            var baseIndexes = baseEntity.GetIndexes();
            var testIndexes = testEntity.GetIndexes();
            if (baseIndexes.Count() != testIndexes.Count())
            {
                Console.WriteLine("{0} base entity: index list count is not equal",baseEntity.Name);
                errorCount++;   
            }
            else
            {
                var indexComparer = new IndexComparer();
                for (var i=0;i<baseIndexes.Count();i++)
                {
                    errorCount+=indexComparer.Compare(baseIndexes.ElementAt(i),testIndexes.ElementAt(i));
                }
            }

            var baseProperties = baseEntity.GetProperties();
            var testProperties = testEntity.GetProperties();
            if (baseProperties.Count() != testProperties.Count())
            {
                Console.WriteLine("{0} base entity: properties list count is not equal",baseEntity.Name);
                errorCount++;   
            }
            else
            {
                var propertyComparer = new PropertyComparer();
                for (var i=0;i<baseProperties.Count();i++)
                {
                    errorCount+=propertyComparer.Compare(baseProperties.ElementAt(i),testProperties.ElementAt(i));
                }
            }

            var baseServiceProperties = baseEntity.GetServiceProperties();
            var testServiceProperties = testEntity.GetServiceProperties();
            if (baseServiceProperties.Count() != testServiceProperties.Count())
            {
                Console.WriteLine("{0} base entity: serviceProperty list count is not equal",baseEntity.Name);
                errorCount++;   
            }
            else
            {
                var servicePropertyComparer = new ServicePropertyComparer();
                for (var i=0;i<baseServiceProperties.Count();i++)
                {
                    errorCount+=servicePropertyComparer.Compare(baseServiceProperties.ElementAt(i),testServiceProperties.ElementAt(i));
                }
            }
            
            var baseKeys = baseEntity.GetKeys();
            var testKeys = testEntity.GetKeys();
            if (baseKeys.Count() != testKeys.Count())
            {
                Console.WriteLine("{0} base entity: serviceProperty list count is not equal",baseEntity.Name);
                errorCount++;   
            }
            else
            {
                var keyComparer = new KeyComparer();
                for (var i=0;i<baseKeys.Count();i++)
                {
                    errorCount+=keyComparer.Compare(baseKeys.ElementAt(i),testKeys.ElementAt(i));
                }
            }
            
            var baseForeignKeys = baseEntity.GetForeignKeys();
            var testForeignKeys = testEntity.GetForeignKeys();
            if (baseForeignKeys.Count() != testForeignKeys.Count())
            {
                Console.WriteLine("{0} base entity: foreignkey list count is not equal",baseEntity.Name);
                errorCount++;   
            }
            else
            {
                var keyComparer = new ForeignKeyComparer();
                for (var i=0;i<baseForeignKeys.Count();i++)
                {
                    errorCount+=keyComparer.Compare(baseForeignKeys.ElementAt(i),testForeignKeys.ElementAt(i));
                }
            }
            
            var baseAnnotations = baseEntity.GetAnnotations();
            var testAnnotations = testEntity.GetAnnotations();
            if (baseAnnotations.Count() != testAnnotations.Count())
            {
                Console.WriteLine("{0} base entity: annotation list count is not equal",baseEntity.Name);
                errorCount++;   
            }
            else
            {
                var keyComparer = new AnnotationComparer();
                for (var i=0;i<baseAnnotations.Count();i++)
                {
                    errorCount+=keyComparer.Compare(baseAnnotations.ElementAt(i),testAnnotations.ElementAt(i));
                }
            }
            return errorCount;
        }
    }
}