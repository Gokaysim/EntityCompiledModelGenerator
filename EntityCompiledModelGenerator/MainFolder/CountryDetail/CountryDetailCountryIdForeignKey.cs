using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.CountryClasses;

namespace test.CountryDetailClasses
{
    public class CountryDetailCountryIdForeignKey:IForeignKey
    {
        private static CountryDetailCountryIdForeignKey _instance;
        
        public static CountryDetailCountryIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new CountryDetailCountryIdForeignKey();
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

        public IEntityType DeclaringEntityType => CountryDetailEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						CountryIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => CountryEntityType.GetInstance();
        public IKey PrincipalKey => CountryCountryIdKey.GetInstance();
        public INavigation DependentToPrincipal => CountryNavigation.GetInstance();
        public INavigation PrincipalToDependent => CountryDetailsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}