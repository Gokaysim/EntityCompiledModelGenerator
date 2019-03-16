using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.SubcategoryTourMatchClasses;

namespace test.SubcategoryTourMatchClasses
{
    public class TourSubcategoryNavigation:INavigation
    {
        private static TourSubcategoryNavigation _instance;
        
        public static TourSubcategoryNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourSubcategoryNavigation();
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

        public string Name => "TourSubcategory";
        public ITypeBase DeclaringType => SubcategoryTourMatchEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.TourDBO.TourSubcategory");
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
                    propertyInfo = ClrType.GetProperty("TourSubcategory");
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
                    fieldInfo = ClrType.GetField("<TourSubcategory>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>SubcategoryTourMatchEntityType.GetInstance();
        public IForeignKey ForeignKey => SubcategoryTourMatchTourSubcategoryIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}