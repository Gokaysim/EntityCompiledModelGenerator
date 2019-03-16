using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModel.Types.Simples
{
    public class SimpleNavigation:INavigation
    {
        private IEnumerable<IAnnotation> annotations;

        public SimpleNavigation(ITypeBase declaringType, Type clrType, PropertyInfo propertyInfo, FieldInfo fieldInfo, bool isShadowProperty, IEntityType declaringEntityType, IForeignKey foreignKey, bool isEagerLoaded)
        {
            DeclaringType = declaringType;
            ClrType = clrType;
            PropertyInfo = propertyInfo;
            FieldInfo = fieldInfo;
            IsShadowProperty = isShadowProperty;
            DeclaringEntityType = declaringEntityType;
            ForeignKey = foreignKey;
            IsEagerLoaded = isEagerLoaded;
        }

        public IAnnotation FindAnnotation(string name)
        {
            return annotations.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return annotations;
        }

        public object this[string name] => FindAnnotation(name);

        public string Name { get; }
        public ITypeBase DeclaringType { get; }
        public Type ClrType { get; }
        public PropertyInfo PropertyInfo { get; }
        public FieldInfo FieldInfo { get; }
        public bool IsShadowProperty { get; }
        public IEntityType DeclaringEntityType { get; }
        public IForeignKey ForeignKey { get; }
        public bool IsEagerLoaded { get; }
    }
}