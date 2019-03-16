using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.ServiceClasses;

namespace test.CommentClasses
{
    public class CommentServiceIdForeignKey:IForeignKey
    {
        private static CommentServiceIdForeignKey _instance;
        
        public static CommentServiceIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new CommentServiceIdForeignKey();
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

        public IEntityType DeclaringEntityType => CommentEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						ServiceIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => ServiceEntityType.GetInstance();
        public IKey PrincipalKey => ServiceServiceIdKey.GetInstance();
        public INavigation DependentToPrincipal => ServiceNavigation.GetInstance();
        public INavigation PrincipalToDependent => null;
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Cascade;
    }
}