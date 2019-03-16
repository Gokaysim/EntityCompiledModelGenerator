using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourClasses;

namespace test.ServiceClasses
{
    public class ToursNavigation:INavigation
    {
        private static ToursNavigation _instance;
        
        public static ToursNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ToursNavigation();
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

        public string Name => "Tours";
        public ITypeBase DeclaringType => ServiceEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.ICollection`1[[Mottojoy.Infrastructure.Entity.TourDBO.Tour, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
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
                    propertyInfo = ClrType.GetProperty("Tours");
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
                    fieldInfo = ClrType.GetField("<Tours>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>ServiceEntityType.GetInstance();
        public IForeignKey ForeignKey => TourServiceIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}