using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourSubcategoryClasses;

namespace test.TourSubcategoryClasses
{
    public class TourCategoryNavigation:INavigation
    {
        private static TourCategoryNavigation _instance;
        
        public static TourCategoryNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourCategoryNavigation();
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

        public string Name => "TourCategory";
        public ITypeBase DeclaringType => TourSubcategoryEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.TourDBO.TourCategory");
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
                    propertyInfo = ClrType.GetProperty("TourCategory");
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
                    fieldInfo = ClrType.GetField("<TourCategory>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>TourSubcategoryEntityType.GetInstance();
        public IForeignKey ForeignKey => TourSubcategoryTourCategoryIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}