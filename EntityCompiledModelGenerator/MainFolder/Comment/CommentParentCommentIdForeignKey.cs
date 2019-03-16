using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.CommentClasses;

namespace test.CommentClasses
{
    public class CommentParentCommentIdForeignKey:IForeignKey
    {
        private static CommentParentCommentIdForeignKey _instance;
        
        public static CommentParentCommentIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new CommentParentCommentIdForeignKey();
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
						ParentCommentIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => CommentEntityType.GetInstance();
        public IKey PrincipalKey => CommentCommentIdKey.GetInstance();
        public INavigation DependentToPrincipal => ParentCommentNavigation.GetInstance();
        public INavigation PrincipalToDependent => ChildrenCommentsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>false;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.ClientSetNull;
    }
}