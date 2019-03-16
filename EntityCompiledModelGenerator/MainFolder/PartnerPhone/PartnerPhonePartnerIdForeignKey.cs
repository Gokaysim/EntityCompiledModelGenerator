using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PartnerClasses;

namespace test.PartnerPhoneClasses
{
    public class PartnerPhonePartnerIdForeignKey:IForeignKey
    {
        private static PartnerPhonePartnerIdForeignKey _instance;
        
        public static PartnerPhonePartnerIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PartnerPhonePartnerIdForeignKey();
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

        public IEntityType DeclaringEntityType => PartnerPhoneEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						PartnerIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => PartnerEntityType.GetInstance();
        public IKey PrincipalKey => PartnerPartnerIdKey.GetInstance();
        public INavigation DependentToPrincipal => PartnerNavigation.GetInstance();
        public INavigation PrincipalToDependent => PartnerPhonesNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}