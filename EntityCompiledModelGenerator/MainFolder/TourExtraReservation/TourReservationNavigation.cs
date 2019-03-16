using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourExtraReservationClasses;

namespace test.TourExtraReservationClasses
{
    public class TourReservationNavigation:INavigation
    {
        private static TourReservationNavigation _instance;
        
        public static TourReservationNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourReservationNavigation();
            }
            return _instance;
        }
        private IEnumerable<IAnnotation> annotations;

        public IAnnotation FindAnnotation(string name)
        {
            return annotations.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return annotations;
        }

        public object this[string name] => FindAnnotation(name);

        public string Name => "TourReservation";
        public ITypeBase DeclaringType => TourExtraReservationEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.ReservationDBO.TourReservation");
                }
                return clrType;
            } 
        }
        private PropertyInfo propertyInfo;
        public PropertyInfo PropertyInfo { 
            get
            {
                if(propertyInfo==null)
                {
                    propertyInfo = ClrType.GetProperty("TourReservation");
                }
                return propertyInfo;
            } 
        }
        private FieldInfo fieldInfo;
        public FieldInfo FieldInfo { 
            get
            {
                if(fieldInfo==null)
                {
                    fieldInfo = ClrType.GetField("<TourReservation>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>TourExtraReservationEntityType.GetInstance();
        public IForeignKey ForeignKey => TourExtraReservationTourReservationIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}