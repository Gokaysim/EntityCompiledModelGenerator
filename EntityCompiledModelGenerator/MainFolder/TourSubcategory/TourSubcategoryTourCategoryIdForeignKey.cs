using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourCategoryClasses;

namespace test.TourSubcategoryClasses
{
    public class TourSubcategoryTourCategoryIdForeignKey:IForeignKey
    {
        private static TourSubcategoryTourCategoryIdForeignKey _instance;
        
        public static TourSubcategoryTourCategoryIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourSubcategoryTourCategoryIdForeignKey();
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

        public IEntityType DeclaringEntityType => TourSubcategoryEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						TourCategoryIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => TourCategoryEntityType.GetInstance();
        public IKey PrincipalKey => TourCategoryTourCategoryIdKey.GetInstance();
        public INavigation DependentToPrincipal => TourCategoryNavigation.GetInstance();
        public INavigation PrincipalToDependent => TourSubcategoriesNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}