using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PaymentClasses;

namespace test.EarningClasses
{
    public class EarningPaymentIdForeignKey:IForeignKey
    {
        private static EarningPaymentIdForeignKey _instance;
        
        public static EarningPaymentIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new EarningPaymentIdForeignKey();
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

        public IEntityType DeclaringEntityType => EarningEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						PaymentIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => PaymentEntityType.GetInstance();
        public IKey PrincipalKey => PaymentPaymentIdKey.GetInstance();
        public INavigation DependentToPrincipal => PaymentNavigation.GetInstance();
        public INavigation PrincipalToDependent => EarningsNavigation.GetInstance();
        public bool IsUnique =>false;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}