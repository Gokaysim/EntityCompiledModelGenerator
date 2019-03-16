using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourClasses;

namespace test.SubcategoryTourMatchClasses
{
    public class SubcategoryTourMatchTourIdForeignKey:IForeignKey
    {
        private static SubcategoryTourMatchTourIdForeignKey _instance;
        
        public static SubcategoryTourMatchTourIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new SubcategoryTourMatchTourIdForeignKey();
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
						TourIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => TourEntityType.GetInstance();
        public IKey PrincipalKey => TourTourIdKey.GetInstance();
        public INavigation DependentToPrincipal => TourNavigation.GetInstance();
        public INavigation PrincipalToDependent => SubcategoryTourMatchesNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}