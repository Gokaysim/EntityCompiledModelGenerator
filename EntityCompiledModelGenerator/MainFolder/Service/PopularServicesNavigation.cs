using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PopularServiceClasses;

namespace test.ServiceClasses
{
    public class PopularServicesNavigation:INavigation
    {
        private static PopularServicesNavigation _instance;
        
        public static PopularServicesNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PopularServicesNavigation();
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

        public string Name => "PopularServices";
        public ITypeBase DeclaringType => ServiceEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.ICollection`1[[Mottojoy.Infrastructure.Entity.ServiceDBO.PopularService, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
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
                    propertyInfo = ClrType.GetProperty("PopularServices");
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
                    fieldInfo = ClrType.GetField("<PopularServices>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>ServiceEntityType.GetInstance();
        public IForeignKey ForeignKey => PopularServiceServiceIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}