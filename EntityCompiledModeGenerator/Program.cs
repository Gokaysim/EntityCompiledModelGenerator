using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mottojoy.Infrastructure.Data;
using Mottojoy.Infrastructure.Entity.AdminDBO;
using SmartFormat;

namespace EntityCompiledModeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new MottojoyContextFactory();

            var m = factory.GetModel();

            var entityList = m.GetEntityTypes();


            EntityTypeCreator(entityList.First(),"test.text");

        }
        static void EntityTypeCreator(IEntityType entityType,string nameSpace)
        {
            string file = null;
            using (StreamReader sr = new StreamReader("./CodeTemplates/EntityTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }
            var entityTypeSplit= entityType.Name.Split(".");
            string className = String.Format("{0}EntityType",entityTypeSplit[entityTypeSplit.Length-1]);
            string classNameNameSpace = entityType.ClrType.Namespace;
            
            var primaryKey = entityType.FindPrimaryKey();

            var ty = entityType.GetIndexes();
            IIndex index = ty.First();

            foreach (var property in entityType.GetProperties())
            {
                PropertyCreator(property, nameSpace, entityTypeSplit[entityTypeSplit.Length-1],className,classNameNameSpace);
            }
            
            var fileText = Smart.Format(file,
                new
                {
                    Namespace = nameSpace,
                    ClassName = className,
                    ClassNamespace = classNameNameSpace,
                    EntityName = entityType.Name,
                    Annotations = entityType.GetAnnotations(),
                    ConfigurationSource=((Key)primaryKey).GetConfigurationSource(),
                    PrimaryKeyProperties = primaryKey.Properties
                }
            );
            
            File.WriteAllText($"./{className}.cs",fileText);
        }

        static void PropertyCreator(IProperty propertyType,string nameSpace,string entityType,string entityClassName,string classNameNameSpace)
        {
            string file = null;
            using (StreamReader sr = new StreamReader("./CodeTemplates/PropertyTemplate.txt"))
            {
                file = sr.ReadToEnd();
            }

            var className = String.Format("{0}PropertyType",propertyType.Name);
            var Annotations = propertyType.GetAnnotations();
            var p = propertyType.PropertyInfo;

            var yas= typeof(Admin);
            var adminIdInfo =yas.GetProperty("AdminId");
            var v = yas.GetField("AdminId");

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
                Namespace = nameSpace,
                ClassName = className,
                ClassNamespace = classNameNameSpace,
                EntityClassName = entityClassName,
                EntityType = entityType, 
                DeclaringType = propertyType.DeclaringType,
                DeclaringTypeAnnotations = Annotations,
            });
            
            File.WriteAllText($"./{entityClassName}/{className}.cs",fileText);
        }
    }
    
}