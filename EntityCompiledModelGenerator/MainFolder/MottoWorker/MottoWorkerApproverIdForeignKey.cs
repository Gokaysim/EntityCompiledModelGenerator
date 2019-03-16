using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.AdminClasses;

namespace test.MottoWorkerClasses
{
    public class MottoWorkerApproverIdForeignKey:IForeignKey
    {
        private static MottoWorkerApproverIdForeignKey _instance;
        
        public static MottoWorkerApproverIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new MottoWorkerApproverIdForeignKey();
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
						ApproverIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => AdminEntityType.GetInstance();
        public IKey PrincipalKey => AdminAdminIdKey.GetInstance();
        public INavigation DependentToPrincipal => ApproverNavigation.GetInstance();
        public INavigation PrincipalToDependent => ApprovedMottoWorkersNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}