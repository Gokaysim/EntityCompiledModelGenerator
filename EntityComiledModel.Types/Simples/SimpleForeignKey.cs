using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityCompiledModel.Types.Simples
{
    public class SimpleForeignKey:IForeignKey
    {
        private readonly IEnumerable<IAnnotation> annotations;
        public SimpleForeignKey(
            IEnumerable<IAnnotation> annotations,
            IReadOnlyList<IProperty> properties, 
            IEntityType declaringEntityType, 
            IEntityType principalEntityType, 
            IKey principalKey, 
            INavigation dependentToPrincipal, 
            INavigation principalToDependent, 
            bool isUnique, 
            bool isRequired, 
            bool isOwnership, 
            DeleteBehavior deleteBehavior)
        {
            this.annotations = annotations;
            DeclaringEntityType = declaringEntityType;
            Properties = properties;
            PrincipalEntityType = principalEntityType;
            PrincipalKey = principalKey;
            DependentToPrincipal = dependentToPrincipal;
            PrincipalToDependent = principalToDependent;
            IsUnique = isUnique;
            IsRequired = isRequired;
            IsOwnership = isOwnership;
            DeleteBehavior = deleteBehavior;
        }

        public IAnnotation FindAnnotation(string name)
        {
            return GetAnnotations().FirstOrDefault(p => p.Name == name );
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return annotations;
        }

        public object this[string name] => FindAnnotation(name);

        public IEntityType DeclaringEntityType { get; }
        public IReadOnlyList<IProperty> Properties { get; }
        public IEntityType PrincipalEntityType { get; }
        public IKey PrincipalKey { get; }
        public INavigation DependentToPrincipal { get; }
        public INavigation PrincipalToDependent { get; }
        public bool IsUnique { get; }
        public bool IsRequired { get; }
        public bool IsOwnership { get; }
        public DeleteBehavior DeleteBehavior { get; }
    }
}