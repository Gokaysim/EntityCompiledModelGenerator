using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace test.TourImageClasses
{
  public class TourBarImageTourIdIndex : IIndex
  {
  
    private static TourBarImageTourIdIndex _instance;
    
    public static TourBarImageTourIdIndex GetInstance()
    {
        if(_instance==null)
        {
            _instance = new TourBarImageTourIdIndex();
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
					TourBarImageTourIdPropertyType.GetInstance(),
				};
            }
            return properties;
        }
    }
    public bool IsUnique => true;
    public IEntityType DeclaringEntityType => TourImageEntityType.GetInstance();
  }
}