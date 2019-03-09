using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModeGenerator
{
    public class CompiledTypeBase:ITypeBase
    {
        public CompiledTypeBase(string name,IModel model,IEnumerable<IAnnotation> annotations,Type clrType)
        {
            this.Model = model;
            this.Name = name;
            this._annotations = annotations;
            this.ClrType = clrType;
        }

        private IEnumerable<IAnnotation> _annotations;
        
        public IAnnotation FindAnnotation(string name)
        {
            return _annotations.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return _annotations;
        }

        public object this[string name] => throw new NotImplementedException();

        public IModel Model { get; }
        public string Name { get; }
        public Type ClrType { get; }
    }
}