using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourSubcategoryClasses;

namespace test.TourCategoryClasses
{
    public class TourSubcategoriesNavigation:INavigation
    {
        private static TourSubcategoriesNavigation _instance;
        
        public static TourSubcategoriesNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourSubcategoriesNavigation();
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

        public string Name => "TourSubcategories";
        public ITypeBase DeclaringType => TourCategoryEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.IEnumerable`1[[Mottojoy.Infrastructure.Entity.TourDBO.TourSubcategory, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
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
                    propertyInfo = ClrType.GetProperty("TourSubcategories");
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
                    fieldInfo = ClrType.GetField("<TourSubcategories>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>TourCategoryEntityType.GetInstance();
        public IForeignKey ForeignKey => TourSubcategoryTourCategoryIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}