using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.CommentClasses;

namespace test.CommentClasses
{
    public class ChildrenCommentsNavigation:INavigation
    {
        private static ChildrenCommentsNavigation _instance;
        
        public static ChildrenCommentsNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ChildrenCommentsNavigation();
            }
            return _instance;
        }
        private IEnumerable<IAnnotation> annotations;

        public IAnnotation FindAnnotation(string name)
        {
            return annotations.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return annotations;
        }

        public object this[string name] => FindAnnotation(name);

        public string Name => "ChildrenComments";
        public ITypeBase DeclaringType => CommentEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.IList`1[[Mottojoy.Infrastructure.Entity.EvaluationDBO.Comment, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
                }
                return clrType;
            } 
        }
        private PropertyInfo propertyInfo;
        public PropertyInfo PropertyInfo { 
            get
            {
                if(propertyInfo==null)
                {
                    propertyInfo = ClrType.GetProperty("ChildrenComments");
                }
                return propertyInfo;
            } 
        }
        private FieldInfo fieldInfo;
        public FieldInfo FieldInfo { 
            get
            {
                if(fieldInfo==null)
                {
                    fieldInfo = ClrType.GetField("<ChildrenComments>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>CommentEntityType.GetInstance();
        public IForeignKey ForeignKey => CommentParentCommentIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}