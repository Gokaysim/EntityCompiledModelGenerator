using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.PayTrTransferClasses;

namespace test.EarningClasses
{
    public class PayTrTransferNavigation:INavigation
    {
        private static PayTrTransferNavigation _instance;
        
        public static PayTrTransferNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new PayTrTransferNavigation();
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

        public string Name => "PayTrTransfer";
        public ITypeBase DeclaringType => EarningEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.FinancialDBO.PayTrTransfer");
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
                    propertyInfo = ClrType.GetProperty("PayTrTransfer");
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
                    fieldInfo = ClrType.GetField("<PayTrTransfer>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>EarningEntityType.GetInstance();
        public IForeignKey ForeignKey => PayTrTransferEarningIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}