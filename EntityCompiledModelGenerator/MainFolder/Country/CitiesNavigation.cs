using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.CityClasses;

namespace test.CountryClasses
{
    public class CitiesNavigation:INavigation
    {
        private static CitiesNavigation _instance;
        
        public static CitiesNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new CitiesNavigation();
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

        public string Name => "Cities";
        public ITypeBase DeclaringType => CountryEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.ICollection`1[[Mottojoy.Infrastructure.Entity.CommonDBO.City, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
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
                    propertyInfo = ClrType.GetProperty("Cities");
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
                    fieldInfo = ClrType.GetField("<Cities>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>CountryEntityType.GetInstance();
        public IForeignKey ForeignKey => CityCountryIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}