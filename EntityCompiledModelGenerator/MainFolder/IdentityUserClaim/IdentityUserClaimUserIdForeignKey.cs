using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.AppUserClasses;

namespace test.IdentityUserClaimClasses
{
    public class IdentityUserClaimUserIdForeignKey:IForeignKey
    {
        private static IdentityUserClaimUserIdForeignKey _instance;
        
        public static IdentityUserClaimUserIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new IdentityUserClaimUserIdForeignKey();
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

        public IEntityType DeclaringEntityType => IdentityUserClaimEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						UserIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => AppUserEntityType.GetInstance();
        public IKey PrincipalKey => AppUserIdKey.GetInstance();
        public INavigation DependentToPrincipal => null;
        public INavigation PrincipalToDependent => null;
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Cascade;
    }
}