using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace test.ClientClasses
{
  public class ClientPhotoIdIndex : IIndex
  {
  
    private static ClientPhotoIdIndex _instance;
    
    public static ClientPhotoIdIndex GetInstance()
    {
        if(_instance==null)
        {
            _instance = new ClientPhotoIdIndex();
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
					ClientPhotoIdPropertyType.GetInstance(),
				};
            }
            return properties;
        }
    }
    public bool IsUnique => true;
    public IEntityType DeclaringEntityType => ClientEntityType.GetInstance();
  }
}