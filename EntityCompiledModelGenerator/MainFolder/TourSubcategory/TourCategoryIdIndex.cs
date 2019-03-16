using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace test.TourSubcategoryClasses
{
  public class TourCategoryIdIndex : IIndex
  {
  
    private static TourCategoryIdIndex _instance;
    
    public static TourCategoryIdIndex GetInstance()
    {
        if(_instance==null)
        {
            _instance = new TourCategoryIdIndex();
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
					TourCategoryIdPropertyType.GetInstance(),
				};
            }
            return properties;
        }
    }
    public bool IsUnique => false;
    public IEntityType DeclaringEntityType => TourSubcategoryEntityType.GetInstance();
  }
}