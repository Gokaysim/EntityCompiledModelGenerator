using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PartnerClasses;

namespace test.EarningClasses
{
    public class EarningPartnerIdForeignKey:IForeignKey
    {
        private static EarningPartnerIdForeignKey _instance;
        
        public static EarningPartnerIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new EarningPartnerIdForeignKey();
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

        public IEntityType DeclaringEntityType => EarningEntityType.GetInstance();
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
        public INavigation PrincipalToDependent => EarningsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}