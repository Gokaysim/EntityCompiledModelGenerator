using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.AdminClasses;

namespace test.AppUserClasses
{
    public class AppUserAdminIdForeignKey:IForeignKey
    {
        private static AppUserAdminIdForeignKey _instance;
        
        public static AppUserAdminIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new AppUserAdminIdForeignKey();
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
						AdminIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => AdminEntityType.GetInstance();
        public IKey PrincipalKey => AdminAdminIdKey.GetInstance();
        public INavigation DependentToPrincipal => AdminNavigation.GetInstance();
        public INavigation PrincipalToDependent => AppUserNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}