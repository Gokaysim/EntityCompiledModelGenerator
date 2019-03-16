using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.ServiceClasses;

namespace test.PartnerClasses
{
    public class ServicesNavigation:INavigation
    {
        private static ServicesNavigation _instance;
        
        public static ServicesNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ServicesNavigation();
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

        public string Name => "Services";
        public ITypeBase DeclaringType => PartnerEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.ICollection`1[[Mottojoy.Infrastructure.Entity.ServiceDBO.Service, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
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
                    propertyInfo = ClrType.GetProperty("Services");
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
                    fieldInfo = ClrType.GetField("<Services>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>PartnerEntityType.GetInstance();
        public IForeignKey ForeignKey => ServicePartnerIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}