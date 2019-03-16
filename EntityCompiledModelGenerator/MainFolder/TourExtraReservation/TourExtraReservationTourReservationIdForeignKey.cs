using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourReservationClasses;

namespace test.TourExtraReservationClasses
{
    public class TourExtraReservationTourReservationIdForeignKey:IForeignKey
    {
        private static TourExtraReservationTourReservationIdForeignKey _instance;
        
        public static TourExtraReservationTourReservationIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourExtraReservationTourReservationIdForeignKey();
            }
            return _instance;
        }
        private IEnumerable<IAnnotation> annotations;
        

        public IAnnotation FindAnnotation(string name)
        {
            return GetAnnotations().FirstOrDefault(p => p.Name == name );
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            if(annotations==null)
            {
                annotations =new List<IAnnotation>
				{
				};
            }
            return annotations;
        }

        public object this[string name] => FindAnnotation(name);

        public IEntityType DeclaringEntityType => TourExtraReservationEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						TourReservationIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => TourReservationEntityType.GetInstance();
        public IKey PrincipalKey => TourReservationTourReservationIdKey.GetInstance();
        public INavigation DependentToPrincipal => TourReservationNavigation.GetInstance();
        public INavigation PrincipalToDependent => TourExtraReservationsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}