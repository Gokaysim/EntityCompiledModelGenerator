using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace test.AppRoleClasses
{
  public class NormalizedNameIndex : IIndex
  {
  
    private static NormalizedNameIndex _instance;
    
    public static NormalizedNameIndex GetInstance()
    {
        if(_instance==null)
        {
            _instance = new NormalizedNameIndex();
        }
        return _instance;
    }
    
    private IEnumerable<IAnnotation> annotations; 

    
    public IAnnotation FindAnnotation(string name)
    {
      return GetAnnotations().FirstOrDefault(p => p.Name == name);
    }

    public IEnumerable<IAnnotation> GetAnnotations()
    {
        if(annotations==null)
        {
            annotations=new List<IAnnotation>
				{
					new ConventionalAnnotation("Relational:Name","RoleNameIndex",ConfigurationSource.Explicit),
				};            
        }
        return annotations;
    }

    public object this[string name] => this.FindAnnotation(name)?.Value;

    private IReadOnlyList<IProperty> properties;
    public IReadOnlyList<IProperty> Properties
    {
        get{
            if(properties==null)
            {    
                properties = new List<IProperty>
				{
					NormalizedNamePropertyType.GetInstance(),
				};
            }
            return properties;
        }
    }
    public bool IsUnique => true;
    public IEntityType DeclaringEntityType => AppRoleEntityType.GetInstance();
  }
}