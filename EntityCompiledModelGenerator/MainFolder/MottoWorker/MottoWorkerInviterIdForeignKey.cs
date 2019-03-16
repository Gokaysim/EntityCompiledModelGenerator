using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.MottoWorkerClasses;

namespace test.MottoWorkerClasses
{
    public class MottoWorkerInviterIdForeignKey:IForeignKey
    {
        private static MottoWorkerInviterIdForeignKey _instance;
        
        public static MottoWorkerInviterIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new MottoWorkerInviterIdForeignKey();
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

        public IEntityType DeclaringEntityType => MottoWorkerEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						InviterIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => MottoWorkerEntityType.GetInstance();
        public IKey PrincipalKey => MottoWorkerMottoWorkerIdKey.GetInstance();
        public INavigation DependentToPrincipal => InviterNavigation.GetInstance();
        public INavigation PrincipalToDependent => InvitedMottoWorkersNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}