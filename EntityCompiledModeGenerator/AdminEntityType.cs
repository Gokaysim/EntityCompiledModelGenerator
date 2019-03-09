using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mottojoy.Infrastructure.Entity.AdminDBO;

namespace test.text
{
    public class AdminEntityType : IEntityType
    {
        public AdminEntityType(IModel model){
            this._model = model;
        }
        public IAnnotation FindAnnotation(string name)
        {
            return Annotations.FirstOrDefault(p=>p.Name == name);
        }

        private IEnumerable<IAnnotation> _annotations;
        public IEnumerable<IAnnotation> GetAnnotations()
        {
            return Annotations;
        }
        private IEnumerable<IAnnotation> Annotations
        {
            get
            {
                if (_annotations == null)
                {
                    _annotations = new List<IAnnotation>
                    {
                        new Annotation("Relational:TableName","Admin.Admins"),
						 new Annotation("RelationshipDiscoveryConvention:NavigationCandidates","System.Collections.Immutable.ImmutableSortedDictionary`2[System.Reflection.PropertyInfo,System.Type]")
                    };
                }
                return _annotations;
            }
        }

        public object this[string name] => throw new NotImplementedException();
        private IModel _model;
        public IModel Model => _model;
        public string Name => "Mottojoy.Infrastructure.Entity.AdminDBO.Admin";
        public Type ClrType => typeof(Admin);
        
        private IKey _primaryKey;
        public IKey FindPrimaryKey()
        {
            if (_primaryKey == null)
            {                
                _primaryKey = new Key(
                    new List<Property>()
                    {
                        new Annotation("AdminId","")
                          
                    },
                    ConfigurationSource.Convention);
            }
            return _primaryKey;
        }

        public IKey FindKey(IReadOnlyList<IProperty> properties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IKey> GetKeys()
        {
            throw new NotImplementedException();
        }

        public IForeignKey FindForeignKey(IReadOnlyList<IProperty> properties, IKey principalKey, IEntityType principalEntityType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IForeignKey> GetForeignKeys()
        {
            throw new NotImplementedException();
        }

        public IIndex FindIndex(IReadOnlyList<IProperty> properties)
        {
            if(_indexes==null)
            {
            
            }
        }
        private IEnumerable<IIndex> _indexes;
        public IEnumerable<IIndex> GetIndexes()
        {
            if(_indexes==null)
            {
            
            }
            return _indexes;
        }

        public IProperty FindProperty(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProperty> GetProperties()
        {
            throw new NotImplementedException();
        }

        public IServiceProperty FindServiceProperty(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IServiceProperty> GetServiceProperties()
        {
            throw new NotImplementedException();
        }

        public IEntityType BaseType { get; }
        public string DefiningNavigationName { get; }
        public IEntityType DefiningEntityType { get; }
        public LambdaExpression QueryFilter { get; }
        public LambdaExpression DefiningQuery { get; }
        public bool IsQueryType { get; }

    }
}