using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourImageClasses;

namespace test.TourImageClasses
{
    public class TourBarImageTourNavigation:INavigation
    {
        private static TourBarImageTourNavigation _instance;
        
        public static TourBarImageTourNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourBarImageTourNavigation();
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

        public string Name => "TourBarImageTour";
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
                    propertyInfo = ClrType.GetProperty("TourBarImageTour");
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
                    fieldInfo = ClrType.GetField("<TourBarImageTour>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>TourImageEntityType.GetInstance();
        public IForeignKey ForeignKey => TourImageTourBarImageTourIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}