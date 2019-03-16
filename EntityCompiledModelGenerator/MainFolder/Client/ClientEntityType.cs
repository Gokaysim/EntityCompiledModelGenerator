using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using EntityCompiledModelGenerator;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mottojoy.Infrastructure.Entity.AdminDBO;
using Mottojoy.Infrastructure.Entity.ClientDBO;
using test.ClientPhotoClasses;using test.MottoWorkerClasses;

namespace test.ClientClasses
{
    public class ClientEntityType : IEntityType
    {
        private static ClientEntityType _instance;
        public static ClientEntityType GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ClientEntityType();
            }
            return _instance;
        }
        
        private IEnumerable<IKey> keys;
        private IEnumerable<IKey> Keys
        {
            get
            {
                if (keys==null)
                {
                    keys = new List<IKey>
					{
					ClientClientIdKey.GetInstance()
					};                    
                }
                return keys;
            }
        }
        
        private IEnumerable<IIndex> indexes;
        private IEnumerable<IIndex> Indexes
        {
            get
            {
                if (indexes==null)
                {
                    indexes = new List<IIndex>
					{					
	ClientPhotoIdIndex.GetInstance(),					
	CultureIndex.GetInstance(),					
	CurrencyIndex.GetInstance(),					
	DeletedIndex.GetInstance(),					
	InviterIdIndex.GetInstance(),
					};                    
                }
                return indexes;
            }
        }
                
        private IEnumerable<IForeignKey> foreignKeys;
        private IEnumerable<IForeignKey> ForeignKeys
        {
            get
            {
                if (foreignKeys==null)
                {
                    foreignKeys=new List<IForeignKey>
						{
						ClientClientPhotoIdForeignKey.GetInstance(),
						ClientInviterIdForeignKey.GetInstance(),
						};
                }
                return foreignKeys;
            }
        }
        
        private IEnumerable<IAnnotation> annotations;
        private IEnumerable<IAnnotation> Annotations
        {
            get
            {
                if (annotations==null)
                {
                    annotations = new List<IAnnotation>
					{
						new ConventionalAnnotation("ConstructorBinding",new DirectConstructorBinding(typeof(Mottojoy.Infrastructure.Entity.ClientDBO.Client).GetDeclaredConstructor(null),new List<ParameterBinding>()),ConfigurationSource.Convention),
						new ConventionalAnnotation("Relational:TableName","Client.Clients",ConfigurationSource.DataAnnotation),
					};              
                }
                return annotations;
            }
        }
        
        public IAnnotation FindAnnotation(string name)
        {
            return Annotations.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return Annotations;
        }

        public object this[string name]
        {
            get { return this.FindAnnotation(name)?.Value; }
        }

        public IModel Model => CompiledModel.GetInstance();

        public string Name=>"Mottojoy.Infrastructure.Entity.ClientDBO.Client";

        public Type ClrType=>typeof(Admin);

        public IKey FindPrimaryKey()
        {
            return Keys.FirstOrDefault(p => p.IsPrimaryKey());
        }

        //TODO it is a readOnlyList Indexes list can be changed to SortedDictionary<IReadOnlyList<IProperty>, Index> as EntityType
        public IKey FindKey(IReadOnlyList<IProperty> properties)
        {
            var declaredKey = this.Keys.FirstOrDefault(index=>PropertyListComparer.Instance.Equals(index.Properties,properties));
            if (declaredKey != null)
                return declaredKey;
            return this.BaseType?.FindKey(properties);
        }

        public IEnumerable<IKey> GetKeys()
        {
            return Keys;
        }

        public IForeignKey FindForeignKey(IReadOnlyList<IProperty> properties, IKey principalKey, IEntityType principalEntityType)
        {
            var declaredForeignKey = this.ForeignKeys.FirstOrDefault(fk =>
                PropertyListComparer.Instance.Equals(fk.Properties, properties)&&
                PropertyListComparer.Instance.Equals((IReadOnlyList<IProperty>) fk.PrincipalKey.Properties, principalKey.Properties)&&
                StringComparer.Ordinal.Equals(fk.PrincipalEntityType.Name, principalEntityType.Name));
            if (declaredForeignKey != null)
                return declaredForeignKey;
            return this.BaseType?.FindForeignKey(properties, principalKey, principalEntityType);    
        }

        public IEnumerable<IForeignKey> GetForeignKeys()
        {
            return ForeignKeys;
        }

        //TODO it is a readOnlyList Indexes list can be changed to SortedDictionary<IReadOnlyList<IProperty>, Index> as EntityType
        public IIndex FindIndex(IReadOnlyList<IProperty> properties)
        {
            return this.Indexes.FirstOrDefault(index=>PropertyListComparer.Instance.Equals(index.Properties,properties));
        }

        public IEnumerable<IIndex> GetIndexes()
        {
            return Indexes;
        }

        public IProperty FindProperty(string name)
        {
            return GetProperties().FirstOrDefault(p => p.Name == name);
        }
        private IEnumerable<IProperty> properties;
        public IEnumerable<IProperty> GetProperties()
        {
            if (properties==null)
            {
                properties = new List<IProperty>
					{
						ClientIdPropertyType.GetInstance(),
						ClientPhotoIdPropertyType.GetInstance(),
						CreateDatePropertyType.GetInstance(),
						CulturePropertyType.GetInstance(),
						CurrencyPropertyType.GetInstance(),
						DeletedPropertyType.GetInstance(),
						EmailPropertyType.GetInstance(),
						FirstNamePropertyType.GetInstance(),
						InviterIdPropertyType.GetInstance(),
						LastNamePropertyType.GetInstance(),
						PhoneNumberPropertyType.GetInstance(),
						UpdateDatePropertyType.GetInstance(),
					};
            }
            return properties;
        }
        private IEnumerable<IServiceProperty> serviceProperties;
        public IServiceProperty FindServiceProperty(string name)
        {
            return GetServiceProperties().FirstOrDefault(p=>p.Name == name);
        }

        public IEnumerable<IServiceProperty> GetServiceProperties()
        {
            if (serviceProperties==null)
            {
                serviceProperties=new List<IServiceProperty>
					{
					};
            }
            return serviceProperties;
        }

        public IEntityType BaseType => null;
        public string DefiningNavigationName => null;
        public IEntityType DefiningEntityType => null;
        
        private LambdaExpression queryFilter;
        public LambdaExpression QueryFilter
        {
            get { 
                if(queryFilter==null)
                {
                    var exp="b => Not(b.Deleted)";
					var p =new ParameterExpression[1];
					p.Append(Expression.Parameter(Type.GetType("Mottojoy.Infrastructure.Entity.ClientDBO.Client"),"b"));
					queryFilter = System.Linq.Dynamic.DynamicExpression.ParseLambda(p, Type.GetType("System.Boolean"), exp);
                }                
                return queryFilter; 
            }
        }
        
        private LambdaExpression definingQuery;
        public LambdaExpression DefiningQuery
        {
            get 
            { 
                if(definingQuery==null)
                {
                    var exp="b => Not(b.Deleted)";
					var p =new ParameterExpression[1];
					p.Append(Expression.Parameter(Type.GetType("Mottojoy.Infrastructure.Entity.ClientDBO.Client"),"b"));
					definingQuery = System.Linq.Dynamic.DynamicExpression.ParseLambda(p, Type.GetType("System.Boolean"), exp);                
                }
                return definingQuery; 
            }
        }
        public bool IsQueryType => false;
    }
}