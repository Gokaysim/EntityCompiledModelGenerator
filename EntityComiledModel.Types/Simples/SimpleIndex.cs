using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityCompiledModel.Types.Simples
{
  public class SimpleIndex : IIndex
  {
    private readonly IReadOnlyList<IProperty> _properties;
    private readonly bool _isUnique;
    private readonly IEntityType _declaringEntityType;
    
    private readonly IEnumerable<IAnnotation> _annotations;

    public SimpleIndex(
      IReadOnlyList<IProperty> properties,
      IEnumerable<IAnnotation> annotations,
      bool isUnique,
      IEntityType declaringEntityType
      )
    {
      _properties = properties;
      _annotations = annotations;
      _isUnique = isUnique;
      _declaringEntityType = declaringEntityType;
    }
    public IAnnotation FindAnnotation(string name)
    {
      return _annotations.FirstOrDefault(p => p.Name == name);
    }

    public IEnumerable<IAnnotation> GetAnnotations()
    {
      return _annotations;
    }

    public object this[string name] => this.FindAnnotation(name)?.Value;

    public IReadOnlyList<IProperty> Properties => _properties;
    public bool IsUnique => _isUnique;
    public IEntityType DeclaringEntityType => _declaringEntityType;
  }
}