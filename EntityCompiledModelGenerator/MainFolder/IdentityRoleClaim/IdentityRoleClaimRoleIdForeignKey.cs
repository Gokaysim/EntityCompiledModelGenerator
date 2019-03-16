using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.AppRoleClasses;

namespace test.IdentityRoleClaimClasses
{
    public class IdentityRoleClaimRoleIdForeignKey:IForeignKey
    {
        private static IdentityRoleClaimRoleIdForeignKey _instance;
        
        public static IdentityRoleClaimRoleIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new IdentityRoleClaimRoleIdForeignKey();
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

        public IEntityType DeclaringEntityType => IdentityRoleClaimEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						RoleIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => AppRoleEntityType.GetInstance();
        public IKey PrincipalKey => AppRoleIdKey.GetInstance();
        public INavigation DependentToPrincipal => null;
        public INavigation PrincipalToDependent => null;
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Cascade;
    }
}