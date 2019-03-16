using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModel.Types.Simples
{
    public class Class1:IPropertyBase
    {
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
        public Type ClrType { get; }
        public PropertyInfo PropertyInfo { get; }
        public FieldInfo FieldInfo { get; }
        public bool IsShadowProperty { get; }
    }
}