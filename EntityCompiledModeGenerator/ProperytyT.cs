using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModeGenerator
{
    public class ProperytyT:IProperty
    {
        private Type _clrType;
        private bool _isShadowProperty;
        private Type _clrType1;
        private bool _isShadowProperty1;

        public IAnnotation FindAnnotation(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            throw new NotImplementedException();
        }

        public object this[string name] => throw new NotImplementedException();

        public string Name { get; }
        public ITypeBase DeclaringType { get; }

        Type IProperty.ClrType => _clrType1;

        bool IProperty.IsShadowProperty => _isShadowProperty1;

        public IEntityType DeclaringEntityType { get; }
        public bool IsNullable { get; }
        public PropertySaveBehavior BeforeSaveBehavior { get; }
        public PropertySaveBehavior AfterSaveBehavior { get; }
        public bool IsReadOnlyBeforeSave { get; }
        public bool IsReadOnlyAfterSave { get; }
        public bool IsStoreGeneratedAlways { get; }
        public ValueGenerated ValueGenerated { get; }
        public bool IsConcurrencyToken { get; }

        Type IPropertyBase.ClrType => _clrType;

        public PropertyInfo PropertyInfo { get; }
        public FieldInfo FieldInfo { get; }

        bool IPropertyBase.IsShadowProperty => _isShadowProperty;
    }
}