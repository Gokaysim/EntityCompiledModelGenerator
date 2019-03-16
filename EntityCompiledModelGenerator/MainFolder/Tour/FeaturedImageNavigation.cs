using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourImageClasses;

namespace test.TourClasses
{
    public class FeaturedImageNavigation:INavigation
    {
        private static FeaturedImageNavigation _instance;
        
        public static FeaturedImageNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new FeaturedImageNavigation();
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

        public string Name => "FeaturedImage";
        public ITypeBase DeclaringType => TourEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.TourDBO.TourImage");
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
                    propertyInfo = ClrType.GetProperty("FeaturedImage");
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
                    fieldInfo = ClrType.GetField("<FeaturedImage>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>TourEntityType.GetInstance();
        public IForeignKey ForeignKey => TourImageFeaturedImageTourIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}