using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PayTrPaymentClasses;

namespace test.PaymentClasses
{
    public class PayTrPaymentNavigation:INavigation
    {
        private static PayTrPaymentNavigation _instance;
        
        public static PayTrPaymentNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PayTrPaymentNavigation();
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

        public string Name => "PayTrPayment";
        public ITypeBase DeclaringType => PaymentEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.FinancialDBO.PayTrPayment");
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
                    propertyInfo = ClrType.GetProperty("PayTrPayment");
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
                    fieldInfo = ClrType.GetField("<PayTrPayment>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>PaymentEntityType.GetInstance();
        public IForeignKey ForeignKey => PayTrPaymentPayTrPaymentIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}