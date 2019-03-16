using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.ClientPhotoClasses;

namespace test.ClientClasses
{
    public class ClientClientPhotoIdForeignKey:IForeignKey
    {
        private static ClientClientPhotoIdForeignKey _instance;
        
        public static ClientClientPhotoIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ClientClientPhotoIdForeignKey();
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

        public IEntityType DeclaringEntityType => ClientEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						ClientPhotoIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => ClientPhotoEntityType.GetInstance();
        public IKey PrincipalKey => ClientPhotoClientPhotoIdKey.GetInstance();
        public INavigation DependentToPrincipal => ClientPhotoNavigation.GetInstance();
        public INavigation PrincipalToDependent => ClientNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}