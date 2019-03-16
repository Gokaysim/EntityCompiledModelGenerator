using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.ClientClasses;

namespace test.ReservationClasses
{
    public class ReservationClientIdForeignKey:IForeignKey
    {
        private static ReservationClientIdForeignKey _instance;
        
        public static ReservationClientIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ReservationClientIdForeignKey();
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

        public IEntityType DeclaringEntityType => ReservationEntityType.GetInstance();
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
        public INavigation PrincipalToDependent => ReservationsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}