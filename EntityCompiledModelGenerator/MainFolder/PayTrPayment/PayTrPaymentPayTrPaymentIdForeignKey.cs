using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PaymentClasses;

namespace test.PayTrPaymentClasses
{
    public class PayTrPaymentPayTrPaymentIdForeignKey:IForeignKey
    {
        private static PayTrPaymentPayTrPaymentIdForeignKey _instance;
        
        public static PayTrPaymentPayTrPaymentIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PayTrPaymentPayTrPaymentIdForeignKey();
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

        public IEntityType DeclaringEntityType => PayTrPaymentEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						PayTrPaymentIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => PaymentEntityType.GetInstance();
        public IKey PrincipalKey => PaymentPaymentIdKey.GetInstance();
        public INavigation DependentToPrincipal => PaymentNavigation.GetInstance();
        public INavigation PrincipalToDependent => PayTrPaymentNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}