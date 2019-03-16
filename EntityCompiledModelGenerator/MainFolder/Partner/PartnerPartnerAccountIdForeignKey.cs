using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PartnerAccountClasses;

namespace test.PartnerClasses
{
    public class PartnerPartnerAccountIdForeignKey:IForeignKey
    {
        private static PartnerPartnerAccountIdForeignKey _instance;
        
        public static PartnerPartnerAccountIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PartnerPartnerAccountIdForeignKey();
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

        public IEntityType DeclaringEntityType => PartnerEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						PartnerAccountIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => PartnerAccountEntityType.GetInstance();
        public IKey PrincipalKey => PartnerAccountPartnerAccountIdKey.GetInstance();
        public INavigation DependentToPrincipal => PartnerAccountNavigation.GetInstance();
        public INavigation PrincipalToDependent => PartnerNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}