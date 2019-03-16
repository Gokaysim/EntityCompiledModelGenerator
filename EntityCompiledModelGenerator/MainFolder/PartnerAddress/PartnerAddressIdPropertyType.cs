using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using EntityCompiledModelGenerator;
using Mottojoy.Infrastructure.Entity.PartnerDBO;

namespace test.PartnerAddressClasses
{
    public class PartnerAddressIdPropertyType:IProperty
    {
        private static PartnerAddressIdPropertyType _instance;
        public static PartnerAddressIdPropertyType GetInstance()
        {
            if(_instance==null)
            {
                _instance =  new PartnerAddressIdPropertyType();
            }
            return _instance;
        }
        
        private bool _isShadowProperty = false;
        private bool _isShadowProperty1 = false;
        
        private IEnumerable<IAnnotation> _annotations;
        private IEnumerable<IAnnotation> Annotations
        {
            get
            {
                if (_annotations == null)
                {
                    _annotations = new List<IAnnotation>
                    {
                        
                    };
                }
                return _annotations;
            }
        }
        
        public PartnerAddressIdPropertyType ()
        {
        }
        public IAnnotation FindAnnotation(string name)
        {
            return Annotations.FirstOrDefault(p=>p.Name == name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return Annotations;
        }

        public object this[string name] => FindAnnotation(name);

        public string Name =>"PartnerAddressId";
        public ITypeBase DeclaringType => PartnerAddressEntityType.GetInstance();

        Type IProperty.ClrType  
        {
           get{
               if(_clrType1==null)
               {
                   _clrType1 = Type.GetType("System.Int32");
               }
               return _clrType1;
           }
       }

        bool IProperty.IsShadowProperty => _isShadowProperty1;

        public IEntityType DeclaringEntityType => PartnerAddressEntityType.GetInstance();
        public bool IsNullable => false;
        public PropertySaveBehavior BeforeSaveBehavior => PropertySaveBehavior.Save;
        public PropertySaveBehavior AfterSaveBehavior => PropertySaveBehavior.Throw;
        public bool IsReadOnlyBeforeSave =>false;
        public bool IsReadOnlyAfterSave =>true;
        public bool IsStoreGeneratedAlways =>false;
        public ValueGenerated ValueGenerated =>ValueGenerated.OnAdd;
        public bool IsConcurrencyToken =>false;


        private Type _clrType;
        private Type _clrType1;
        
        Type IPropertyBase.ClrType{
            get{
                if(_clrType==null)
                {
                    _clrType = Type.GetType("System.Int32");
                }
                return _clrType;
            }
        }
        
        private PropertyInfo _propertyInfo;
        public PropertyInfo PropertyInfo {
            get{
                if(_propertyInfo==null)
                {
                    _propertyInfo = _clrType.GetProperty(this.Name);
                }
                return _propertyInfo;
            }
        }
        private FieldInfo _fieldInfo;
        public FieldInfo FieldInfo {
            get{
                if(_fieldInfo==null)
                {
                    _fieldInfo = _clrType.GetField(this.Name);
                }
                return _fieldInfo;
            }
        }

        bool IPropertyBase.IsShadowProperty => _isShadowProperty;
    }
}

