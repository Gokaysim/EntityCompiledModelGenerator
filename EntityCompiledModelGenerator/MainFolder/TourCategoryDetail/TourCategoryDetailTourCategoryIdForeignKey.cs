using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourCategoryClasses;

namespace test.TourCategoryDetailClasses
{
    public class TourCategoryDetailTourCategoryIdForeignKey:IForeignKey
    {
        private static TourCategoryDetailTourCategoryIdForeignKey _instance;
        
        public static TourCategoryDetailTourCategoryIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourCategoryDetailTourCategoryIdForeignKey();
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

        public IEntityType DeclaringEntityType => TourCategoryDetailEntityType.GetInstance();
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
        public INavigation PrincipalToDependent => TourCategoryDetailsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Cascade;
    }
}