using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.EarningClasses;

namespace test.EarningClasses
{
    public class PaymentNavigation:INavigation
    {
        private static PaymentNavigation _instance;
        
        public static PaymentNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PaymentNavigation();
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

        public string Name => "Payment";
        public ITypeBase DeclaringType => EarningEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.FinancialDBO.Payment");
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
                    propertyInfo = ClrType.GetProperty("Payment");
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
                    fieldInfo = ClrType.GetField("<Payment>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>EarningEntityType.GetInstance();
        public IForeignKey ForeignKey => EarningPaymentIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}