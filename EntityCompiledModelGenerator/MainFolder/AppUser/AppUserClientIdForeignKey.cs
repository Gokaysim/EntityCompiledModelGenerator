using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.ClientClasses;

namespace test.AppUserClasses
{
    public class AppUserClientIdForeignKey:IForeignKey
    {
        private static AppUserClientIdForeignKey _instance;
        
        public static AppUserClientIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new AppUserClientIdForeignKey();
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

        public IEntityType DeclaringEntityType => AppUserEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						ClientIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => ClientEntityType.GetInstance();
        public IKey PrincipalKey => ClientClientIdKey.GetInstance();
        public INavigation DependentToPrincipal => ClientNavigation.GetInstance();
        public INavigation PrincipalToDependent => AppUserNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}