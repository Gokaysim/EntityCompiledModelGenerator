using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.MottoWorkerClasses;

namespace test.MottoWorkerClasses
{
    public class ApproverNavigation:INavigation
    {
        private static ApproverNavigation _instance;
        
        public static ApproverNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ApproverNavigation();
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

        public string Name => "Approver";
        public ITypeBase DeclaringType => MottoWorkerEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("Mottojoy.Infrastructure.Entity.AdminDBO.Admin");
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
                    propertyInfo = ClrType.GetProperty("Approver");
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
                    fieldInfo = ClrType.GetField("<Approver>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>MottoWorkerEntityType.GetInstance();
        public IForeignKey ForeignKey => MottoWorkerApproverIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}