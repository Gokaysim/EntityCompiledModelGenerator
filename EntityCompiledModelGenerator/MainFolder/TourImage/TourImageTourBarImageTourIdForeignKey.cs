using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourClasses;

namespace test.TourImageClasses
{
    public class TourImageTourBarImageTourIdForeignKey:IForeignKey
    {
        private static TourImageTourBarImageTourIdForeignKey _instance;
        
        public static TourImageTourBarImageTourIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourImageTourBarImageTourIdForeignKey();
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

        public IEntityType DeclaringEntityType => TourImageEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						TourBarImageTourIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => TourEntityType.GetInstance();
        public IKey PrincipalKey => TourTourIdKey.GetInstance();
        public INavigation DependentToPrincipal => TourBarImageTourNavigation.GetInstance();
        public INavigation PrincipalToDependent => TourBarImageNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}