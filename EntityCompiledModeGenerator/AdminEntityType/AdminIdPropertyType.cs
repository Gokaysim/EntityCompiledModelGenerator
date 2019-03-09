using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using EntityCompiledModeGenerator;
using Mottojoy.Infrastructure.Entity.AdminDBO;

namespace test.text
{
    public class AdminIdPropertyType:IProperty
    {
        private Type _clrType;
        private bool _isShadowProperty;
        private Type _clrType1;
        private bool _isShadowProperty1;
        
        private IModel _model;
        public AdminIdPropertyType(IModel model,Type clrType,
        bool isShadowProperty,Type clrType1,bool isShadowProperty1)
        {
            this._model = model;
            this._clrType = clrType;
            this._isShadowProperty = isShadowProperty;
            this._clrType1 = clrType1;
            this._isShadowProperty1 = isShadowProperty1;
            
        }
        
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
        public IAnnotation FindAnnotation(string name)
        {
            return Annotations.FirstOrDefault(p=>p.Name == name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return Annotations;
        }

        public object this[string name] => throw new NotImplementedException();

        public string Name =>"AdminId";
        public ITypeBase _declaringType;
        public ITypeBase DeclaringType 
        {
            get{ 
                if(_declaringType==null)
                {
                    _declaringType = new CompiledTypeBase("Mottojoy.Infrastructure.Entity.AdminDBO.Admin",_model,new List<Annotation>{
                        
                    },typeof(Admin));
                }
                return _declaringType;
            }
        }

        Type IProperty.ClrType => _clrType1;

        bool IProperty.IsShadowProperty => _isShadowProperty1;

        public IEntityType DeclaringEntityType { get; }
        public bool IsNullable => false;
        public PropertySaveBehavior BeforeSaveBehavior => PropertySaveBehavior.Save;
        public PropertySaveBehavior AfterSaveBehavior => PropertySaveBehavior.Throw;
        public bool IsReadOnlyBeforeSave =>false;
        public bool IsReadOnlyAfterSave =>true;
        public bool IsStoreGeneratedAlways =>false;
        public ValueGenerated ValueGenerated =>ValueGenerated.OnAdd;
        public bool IsConcurrencyToken =>false;

        Type IPropertyBase.ClrType => _clrType;
        
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