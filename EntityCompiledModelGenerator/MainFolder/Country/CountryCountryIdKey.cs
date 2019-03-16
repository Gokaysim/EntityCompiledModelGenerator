using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace test.CountryClasses
{
    public class CountryCountryIdKey:IKey
    {    
        private static CountryCountryIdKey _instance;            
        public static CountryCountryIdKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new CountryCountryIdKey();
            }
            return _instance;
        }
        
        private IEnumerable<IAnnotation> _annotations;

        public IAnnotation FindAnnotation(string name)
        {
            return GetAnnotations().FirstOrDefault(p=>p.Name==name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            if(_annotations==null)
            {
                _annotations = new List<IAnnotation>
				{
				};    
            }
            return _annotations;
        }

        public object this[string name] => FindAnnotation(name);

        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties 
        { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						CountryIdPropertyType.GetInstance(),
					};
                };
                return properties;
            }
        }
        public IEntityType DeclaringEntityType => CountryEntityType.GetInstance();
    }
}