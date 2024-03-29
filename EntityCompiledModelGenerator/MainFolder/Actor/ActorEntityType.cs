using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using EntityCompiledModelGenerator;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SampleContext.Entities;


namespace test.ActorClasses
{
    public class ActorEntityType : IEntityType
    {
        private static ActorEntityType _instance;
        public static ActorEntityType GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ActorEntityType();
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
					ActorActorIdKey.GetInstance()
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
						new ConventionalAnnotation("ConstructorBinding",new DirectConstructorBinding(typeof(SampleContext.Entities.Actor).GetDeclaredConstructor(null),new List<ParameterBinding>()),ConfigurationSource.Convention),
						new ConventionalAnnotation("Relational:TableName","Actors",ConfigurationSource.Convention),
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

        public string Name=>"SampleContext.Entities.Actor";

        public Type ClrType=>typeof(Actor);

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
						ActorIdPropertyType.GetInstance(),
						BirthDatePropertyType.GetInstance(),
						LastNamePropertyType.GetInstance(),
						NamePropertyType.GetInstance(),
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
                                    
                }
                return definingQuery; 
            }
        }
        public bool IsQueryType => false;
    }
}