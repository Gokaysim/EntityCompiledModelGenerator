using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.ReservationClasses;

namespace test.PaymentClasses
{
    public class PaymentReservationIdForeignKey:IForeignKey
    {
        private static PaymentReservationIdForeignKey _instance;
        
        public static PaymentReservationIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PaymentReservationIdForeignKey();
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

        public IEntityType DeclaringEntityType => PaymentEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						ReservationIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => ReservationEntityType.GetInstance();
        public IKey PrincipalKey => ReservationReservationIdKey.GetInstance();
        public INavigation DependentToPrincipal => ReservationNavigation.GetInstance();
        public INavigation PrincipalToDependent => PaymentNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}