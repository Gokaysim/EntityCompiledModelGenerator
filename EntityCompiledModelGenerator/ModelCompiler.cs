using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using EntityCompiledModelGenerator.SmartFormatHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mottojoy.Infrastructure.Entity.AdminDBO;
using SmartFormat;

namespace EntityCompiledModelGenerator
{
    public class ModelCompiler
    {
        private readonly IModel model;
        private readonly string namespaceString;
        private readonly string filePathRoot;

        public ModelCompiler(IModel model, string namespaceString,string filePathRoot)
        {
            this.filePathRoot = filePathRoot;
            this.namespaceString = namespaceString;
            this.model = model;
        }
        
        public void createModel()
        {
            string file = null;
            using (StreamReader sr = new StreamReader("./CodeTemplates/ModelTemplate.txt"))
            {                
                file = sr.ReadToEnd();
            }
            
            var fileText = Smart.Format(file,
                new
                {
                    EntityTypes = model.GetEntityTypes(),
                    Namespace =namespaceString
                }
            );
            File.WriteAllText($"{filePathRoot}/CompiledModel.cs",fileText);
            
            foreach (var entity in model.GetEntityTypes())
            {
                EntityTypeCreator(entity);                    
            }
        }

        public void NavigationCreator(INavigation navigation,string filePath,string entityClassName)
        {
            string file = null;
            using (var sr = new StreamReader("./CodeTemplates/NavigationTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }

            var className = $"{navigation.Name}Navigation";

            var fileText = Smart.Format(file,
                new
                {
                    Namespace = namespaceString,
                    ClassName = className, 
                    EntityClassName = entityClassName,
                    Name = navigation.Name,
                    ClrType = navigation.ClrType.FullName,
                    PropertyInfo = navigation.PropertyInfo.Name,
                    FieldInfo = navigation.FieldInfo.Name,
                    DeclaringEntityType = $"{EntityListFormatter.GetNameOfIEntityType(navigation.DeclaringEntityType)}.GetInstance()",
                    IsShadowProperty = navigation.IsShadowProperty?"true":"false",
                    IsEagerLoaded = navigation.IsEagerLoaded?"true":"false",
                    DeclaringType = $"{EntityListFormatter.GetNameOfIEntityType(navigation.DeclaringType)}.GetInstance()",                    
                    ForeignKey = navigation.ForeignKey!=null? string.Format("{0}.GetInstance()",ForeignKeyListFormatter.GetNameOfForeignKey(navigation.ForeignKey)):"null",
                    ForeignKeyObject = navigation.ForeignKey,
                });
            
            File.WriteAllText($"{filePath}/{className}.cs",fileText);
        }
        private void EntityTypeCreator(IEntityType entityType)
        {
            
            string file = null;
            using (StreamReader sr = new StreamReader("./CodeTemplates/EntityTypeTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }

            var entityClassName = EntityListFormatter.GetNakedNameOfIEntityType(entityType);
            var filePath = $"{filePathRoot}/{entityClassName}";
            var className = EntityListFormatter.GetNameOfIEntityType(entityType);
            var classNameNameSpace = entityType.ClrType.Namespace;
            
            var primaryKey = entityType.FindPrimaryKey();

            Directory.CreateDirectory(filePath);
            
            foreach (var property in entityType.GetProperties())
            {
                PropertyCreator(property,filePath,className,classNameNameSpace,entityClassName);
            }

            foreach (var key in entityType.GetKeys())
            {
                KeyCreator(key, filePath,entityClassName);
            }
            foreach (var index in entityType.GetIndexes())
            {
                CreateIndex(index,filePath,entityClassName);
            }

            foreach (var serviceProperty in entityType.GetServiceProperties())
            {
                ServicePropertyCreator(serviceProperty,filePath,entityClassName);
            }

            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                ForeignKeyCreator(foreignKey,filePath,entityClassName);
            }

            foreach (var navigation in entityType.GetNavigations())
            {
                NavigationCreator(navigation,filePath,entityClassName);
            }

            var fileText = Smart.Format(file,
                new
                {
                    Namespace = namespaceString,
                    ClassName = className,
                    ClassNamespace = classNameNameSpace,
                    EntityName = entityType.Name,
                    Annotations = entityType.GetAnnotations(),
                    Keys = entityType.GetKeys(),
                    ServiceProperties = entityType.GetServiceProperties(),
                    ForeignKeys = entityType.GetForeignKeys(),
                    Properties = entityType.GetProperties(),
                    Indexes = entityType.GetIndexes(),
                    ConfigurationSource=((Key)primaryKey).GetConfigurationSource(),
                    PrimaryKeyProperties = primaryKey.Properties,
                    EntityClassName = entityClassName,
                    QueryFilter = entityType.QueryFilter,
                    DefiningQuery = entityType.DefiningQuery,
                    DefiningNavigationName = entityType.DefiningNavigationName ?? "null",
                    DefiningEntityType = entityType.DefiningEntityType == null ?"null":string.Format("{0}.GetInstance()",EntityListFormatter.GetNameOfIEntityType(entityType.DefiningEntityType)),
                    IsQueryType = entityType.IsQueryType?"true":"false",
                    BaseType = entityType.BaseType!=null? string.Format("{0}.GetInstance()",EntityListFormatter.GetNameOfIEntityType(entityType.BaseType)):"null"
                }
            );
            File.WriteAllText($"{filePath}/{className}.cs",fileText);
        }
        private void KeyCreator(IKey key, string filePath,string entityClassName)
        {
            string file = null;
            using (var sr = new StreamReader("./CodeTemplates/KeyTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }
             
            var className = KeyListFormatter.GetNameOfKey(key);

            var fileText = Smart.Format(file,
                new
                {
                    Namespace = namespaceString,
                    EntityClassName = entityClassName,
                    ClassName=className,
                    Annotations = key.GetAnnotations(),
                    DeclaringEntityType = EntityListFormatter.GetNameOfIEntityType(key.DeclaringEntityType),
                    Properties = key.Properties
                });
            
            File.WriteAllText($"{filePath}/{className}.cs",fileText);
        }
        private void ForeignKeyCreator(IForeignKey foreignKey,string filePath,string entityClassName)
        {
            string file = null;
            using (var sr = new StreamReader("./CodeTemplates/ForeignKeyTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }

            var className = ForeignKeyListFormatter.GetNameOfForeignKey(foreignKey);
            var fileText = Smart.Format(file,
                new
                {
                    Namespace = namespaceString,
                    EntityClassName = entityClassName,
                    ClassName = className,
                    IsUnique = foreignKey.IsUnique?"true":"false",
                    IsRequired = foreignKey.IsRequired?"true":"false",
                    IsOwnership = foreignKey.IsOwnership?"true":"false",
                    DeleteBehavior = foreignKey.DeleteBehavior,
                    Properties = foreignKey.Properties,
                    DependentToPrincipal = foreignKey.DependentToPrincipal != null ?string.Format("{0}.GetInstance()",NavigationFormatter.GetNameOfNavigation(foreignKey.DependentToPrincipal)):"null",
                    PrincipalToDependent = foreignKey.PrincipalToDependent != null ?string.Format("{0}.GetInstance()",NavigationFormatter.GetNameOfNavigation(foreignKey.PrincipalToDependent)):"null",
                    PrincipalKey = foreignKey.PrincipalKey!=null? string.Format("{0}.GetInstance()",KeyListFormatter.GetNameOfKey(foreignKey.PrincipalKey)):"null",
                    PrincipalEntityType = foreignKey.PrincipalEntityType!=null? string.Format("{0}.GetInstance()",EntityListFormatter.GetNameOfIEntityType(foreignKey.PrincipalEntityType)):"null",
                    Annotations = foreignKey.GetAnnotations(),
                    DeclaringEntityType = foreignKey.DeclaringEntityType!=null? string.Format("{0}.GetInstance()",EntityListFormatter.GetNameOfIEntityType(foreignKey.DeclaringEntityType)):"null"                    
                });
            
            File.WriteAllText($"{filePath}/{className}.cs",fileText);
        }
        private void ServicePropertyCreator(IServiceProperty serviceProperty, string filePath, string entityClassName)
        {
            string file = null;
            using (var sr = new StreamReader("./CodeTemplates/ServicePropertyTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }

             
            var className = $"{serviceProperty.Name}ServiceProperty";

            var fileText = Smart.Format(file,
                new
                {
                    Namespace = namespaceString,
                    EntityClassName = entityClassName,
                    ClassName = className
                });
            
            File.WriteAllText($"{filePath}/{className}.cs",fileText);
        }     
        private void CreateIndex(IIndex index,string filePath,string entityClassName)
        {
            string file = null;
            using (var sr = new StreamReader("./CodeTemplates/IndexTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }

            var className = $"{index.ToString().Split(".").Last().Split(" ").First()}Index";
            
            var fileText = Smart.Format(file,
                new
                {
                    Namespace = namespaceString,
                    EntityClassName = entityClassName,
                    Annotations = index.GetAnnotations(),
                    ClassName =  IndexListFormatter.GetNameOfIndex(index),
                    IsUnique = index.IsUnique?"true":"false",
                    DeclaringEntityType = EntityListFormatter.GetNameOfIEntityType(index.DeclaringEntityType),
                    Properties = index.Properties
                });
            
            File.WriteAllText($"{filePath}/{className}.cs",fileText);
        }
        private void PropertyCreator(IProperty propertyType,string filePath,string entityType,string classNameNameSpace,string entityClassName)
        {
            string file = null;
            using (StreamReader sr = new StreamReader("./CodeTemplates/PropertyTypeTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }

            var className = String.Format("{0}PropertyType",propertyType.Name);

            if (className == "TourSubcategoryIdPropertyType")
            {
                
            }
            
            string PropertyClrType1FullName ;
            if (propertyType.ClrType.IsEnum)
            {
                PropertyClrType1FullName = string.Format("typeof({0})",propertyType.ClrType.FullName);                
            }
            else
            {
                PropertyClrType1FullName = string.Format("Type.GetType(\"{0}\")",propertyType.ClrType.FullName);
            }

            string PropertyClrTypeFullName;
            if ( ((IPropertyBase) propertyType).ClrType.IsEnum)
            {
                PropertyClrTypeFullName = string.Format("typeof({0})", ((IPropertyBase) propertyType).ClrType.FullName);                
            }
            else
            {
                PropertyClrTypeFullName = string.Format("Type.GetType(\"{0}\")", ((IPropertyBase) propertyType).ClrType.FullName);
            }
            
            
            var fileText = Smart.Format(file,new
            {
                Name = propertyType.Name,
                IsNullable = propertyType.IsNullable,
                IsReadOnlyBeforeSave = propertyType.IsReadOnlyBeforeSave,
                IsReadOnlyAfterSave = propertyType.IsReadOnlyAfterSave,
                IsStoreGeneratedAlways = propertyType.IsStoreGeneratedAlways,
                IsConcurrencyToken = propertyType.IsConcurrencyToken,
                AfterSaveBehavior = propertyType.AfterSaveBehavior,
                BeforeSaveBehavior = propertyType.BeforeSaveBehavior,
                ValueGenerated = propertyType.ValueGenerated,
                Namespace = namespaceString,
                ClassName = className,
                ClassNamespace = classNameNameSpace,
                EntityType = entityType, 
                DeclaringType = propertyType.DeclaringType,
                DeclaringTypeAnnotations = propertyType.GetAnnotations(),
                PropertyClrType1FullName = PropertyClrType1FullName,
                IsShadowProperty1 = propertyType.IsShadowProperty,
                PropertyClrTypeFullName = PropertyClrTypeFullName,
                IsShadowProperty = ((IPropertyBase)propertyType).IsShadowProperty,
                EntityClassName = entityClassName,
            });
            
            
            File.WriteAllText($"{filePath}/{className}.cs",fileText);
        }
        
    }
}