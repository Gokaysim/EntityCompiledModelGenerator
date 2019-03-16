using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityCompiledModel.Types.Simples
{
    public class SimpleKey:IKey
    {
        private readonly IEnumerable<IAnnotation> _annotations;

        public SimpleKey(IEnumerable<IAnnotation> annotations, IReadOnlyList<IProperty> properties, IEntityType declaringEntityType)
        {
            _annotations = annotations;
            Properties = properties;
            DeclaringEntityType = declaringEntityType;
        }

        public IAnnotation FindAnnotation(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            throw new System.NotImplementedException();
        }

        public object this[string name] => throw new System.NotImplementedException();

        public IReadOnlyList<IProperty> Properties { get; }
        public IEntityType DeclaringEntityType { get; }
    }
}