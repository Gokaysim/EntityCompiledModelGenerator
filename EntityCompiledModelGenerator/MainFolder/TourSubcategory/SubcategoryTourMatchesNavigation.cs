using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.SubcategoryTourMatchClasses;

namespace test.TourSubcategoryClasses
{
    public class SubcategoryTourMatchesNavigation:INavigation
    {
        private static SubcategoryTourMatchesNavigation _instance;
        
        public static SubcategoryTourMatchesNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new SubcategoryTourMatchesNavigation();
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

        public string Name => "SubcategoryTourMatches";
        public ITypeBase DeclaringType => TourSubcategoryEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.IEnumerable`1[[Mottojoy.Infrastructure.Entity.TourDBO.SubcategoryTourMatch, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
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
                    propertyInfo = ClrType.GetProperty("SubcategoryTourMatches");
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
                    fieldInfo = ClrType.GetField("<SubcategoryTourMatches>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>TourSubcategoryEntityType.GetInstance();
        public IForeignKey ForeignKey => SubcategoryTourMatchTourSubcategoryIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}