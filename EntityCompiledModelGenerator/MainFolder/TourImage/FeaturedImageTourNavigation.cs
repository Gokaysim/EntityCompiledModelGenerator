using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourImageClasses;

namespace test.TourImageClasses
{
    public class FeaturedImageTourNavigation:INavigation
    {
        private static FeaturedImageTourNavigation _instance;
        
        public static FeaturedImageTourNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new FeaturedImageTourNavigation();
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

        public string Name => "FeaturedImageTour";
        public ITypeBase DeclaringType => TourImageEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.TourDBO.Tour");
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
                    propertyInfo = ClrType.GetProperty("FeaturedImageTour");
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
                    fieldInfo = ClrType.GetField("<FeaturedImageTour>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>TourImageEntityType.GetInstance();
        public IForeignKey ForeignKey => TourImageFeaturedImageTourIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}