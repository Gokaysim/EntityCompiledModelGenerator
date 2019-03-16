using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.MottoWorkerClasses;

namespace test.AppUserClasses
{
    public class AppUserMottoWorkerIdForeignKey:IForeignKey
    {
        private static AppUserMottoWorkerIdForeignKey _instance;
        
        public static AppUserMottoWorkerIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new AppUserMottoWorkerIdForeignKey();
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
						MottoWorkerIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => MottoWorkerEntityType.GetInstance();
        public IKey PrincipalKey => MottoWorkerMottoWorkerIdKey.GetInstance();
        public INavigation DependentToPrincipal => MottoWorkerNavigation.GetInstance();
        public INavigation PrincipalToDependent => null;
        public bool IsUnique =>false;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.ClientSetNull;
    }
}