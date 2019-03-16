using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourSubcategoryClasses;

namespace test.SubcategoryTourMatchClasses
{
    public class SubcategoryTourMatchTourSubcategoryIdForeignKey:IForeignKey
    {
        private static SubcategoryTourMatchTourSubcategoryIdForeignKey _instance;
        
        public static SubcategoryTourMatchTourSubcategoryIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new SubcategoryTourMatchTourSubcategoryIdForeignKey();
            }
            return _instance;
        }
        private IEnumerable<IAnnotation> annotations;
        

        public IAnnotation FindAnnotation(string name)
        {
            return GetAnnotations().FirstOrDefault(p => p.Name == name );
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            if(annotations==null)
            {
                annotations =new List<IAnnotation>
				{
				};
            }
            return annotations;
        }

        public object this[string name] => FindAnnotation(name);

        public IEntityType DeclaringEntityType => SubcategoryTourMatchEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						TourSubcategoryIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => TourSubcategoryEntityType.GetInstance();
        public IKey PrincipalKey => TourSubcategoryTourSubcategoryIdKey.GetInstance();
        public INavigation DependentToPrincipal => TourSubcategoryNavigation.GetInstance();
        public INavigation PrincipalToDependent => SubcategoryTourMatchesNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}