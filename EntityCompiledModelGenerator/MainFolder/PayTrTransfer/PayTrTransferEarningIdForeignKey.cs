using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.EarningClasses;

namespace test.PayTrTransferClasses
{
    public class PayTrTransferEarningIdForeignKey:IForeignKey
    {
        private static PayTrTransferEarningIdForeignKey _instance;
        
        public static PayTrTransferEarningIdForeignKey GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PayTrTransferEarningIdForeignKey();
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

        public IEntityType DeclaringEntityType => PayTrTransferEntityType.GetInstance();
        private IReadOnlyList<IProperty> properties;
        public IReadOnlyList<IProperty> Properties { 
            get
            {
                if(properties==null)
                {
                    properties = new List<IProperty>
					{
						EarningIdPropertyType.GetInstance(),
					};
                }
                return properties;
            } 
        }
        public IEntityType PrincipalEntityType => EarningEntityType.GetInstance();
        public IKey PrincipalKey => EarningEarningIdKey.GetInstance();
        public INavigation DependentToPrincipal => EarningNavigation.GetInstance();
        public INavigation PrincipalToDependent => PayTrTransferNavigation.GetInstance();
        public bool IsUnique =>true;
        public bool IsRequired =>true;
        public bool IsOwnership =>false;
        public DeleteBehavior DeleteBehavior => DeleteBehavior.Restrict;
    }
}