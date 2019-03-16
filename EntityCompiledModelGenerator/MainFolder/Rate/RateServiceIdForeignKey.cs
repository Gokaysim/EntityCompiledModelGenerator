using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.ServiceClasses;

namespace test.RateClasses
{
    public class RateServiceIdForeignKey:IForeignKey
    {
        private static RateServiceIdForeignKey _instance;
        
        public static RateServiceIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new RateServiceIdForeignKey();
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

        public IEntityType DeclaringEntityType => RateEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						ServiceIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => ServiceEntityType.GetInstance();
        public IKey PrincipalKey => ServiceServiceIdKey.GetInstance();
        public INavigation DependentToPrincipal => ServiceNavigation.GetInstance();
        public INavigation PrincipalToDependent => RatesNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}