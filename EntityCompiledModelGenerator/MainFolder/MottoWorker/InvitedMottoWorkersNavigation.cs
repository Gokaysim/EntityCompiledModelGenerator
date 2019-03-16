using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using test.MottoWorkerClasses;

namespace test.MottoWorkerClasses
{
    public class InvitedMottoWorkersNavigation:INavigation
    {
        private static InvitedMottoWorkersNavigation _instance;
        
        public static InvitedMottoWorkersNavigation GetInstance()
        {
            if(_instance==null)
            {
                _instance = new InvitedMottoWorkersNavigation();
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

        public string Name => "InvitedMottoWorkers";
        public ITypeBase DeclaringType => MottoWorkerEntityType.GetInstance();
        private Type clrType;
        public Type ClrType { 
            get
            {
                if(clrType==null)
                {
                    clrType = Type.GetType("System.Collections.Generic.ICollection`1[[Mottojoy.Infrastructure.Entity.MottoWorkDBO.MottoWorker, Mottojoy.Infrastructure.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");
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
                    propertyInfo = ClrType.GetProperty("InvitedMottoWorkers");
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
                    fieldInfo = ClrType.GetField("<InvitedMottoWorkers>k__BackingField");
                }
                return fieldInfo;
            }
        }
        public bool IsShadowProperty => false;
        public IEntityType DeclaringEntityType =>MottoWorkerEntityType.GetInstance();
        public IForeignKey ForeignKey => MottoWorkerInviterIdForeignKey.GetInstance();
        public bool IsEagerLoaded =>false;
    }
}