using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.RateClasses;

namespace test.CommentClasses
{
    public class CommentRateIdForeignKey:IForeignKey
    {
        private static CommentRateIdForeignKey _instance;
        
        public static CommentRateIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new CommentRateIdForeignKey();
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
						RateIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => RateEntityType.GetInstance();
        public IKey PrincipalKey => RateRateIdKey.GetInstance();
        public INavigation DependentToPrincipal => RateNavigation.GetInstance();
        public INavigation PrincipalToDependent => CommentNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.ClientSetNull;
    }
}