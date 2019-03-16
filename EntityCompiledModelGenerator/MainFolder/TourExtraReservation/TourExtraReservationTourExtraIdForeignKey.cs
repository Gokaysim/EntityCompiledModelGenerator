using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.TourExtraClasses;

namespace test.TourExtraReservationClasses
{
    public class TourExtraReservationTourExtraIdForeignKey:IForeignKey
    {
        private static TourExtraReservationTourExtraIdForeignKey _instance;
        
        public static TourExtraReservationTourExtraIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new TourExtraReservationTourExtraIdForeignKey();
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
						TourExtraIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => TourExtraEntityType.GetInstance();
        public IKey PrincipalKey => TourExtraTourExtraIdKey.GetInstance();
        public INavigation DependentToPrincipal => TourExtraNavigation.GetInstance();
        public INavigation PrincipalToDependent => TourExtraReservationsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}