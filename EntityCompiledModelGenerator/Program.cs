using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using EntityCompiledModelGenerator.Comparers;
using EntityCompiledModelGenerator.SmartFormatHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SampleContext;
using SmartFormat;
using ModelExtensions = Microsoft.EntityFrameworkCore.ModelExtensions;


namespace EntityCompiledModelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
           
//            Test();
            Create();
//            CheckDb();
        }

        static void CheckDb()
        {
//            var contextFactory = new MottojoyContextFactory(CompiledModel.GetInstance());

//            using (var context = contextFactory.CreateDbContext(null))
//            {
//                var admin = context.Set<Admin>().First();
//            }
        }
        static void Test()
        {
//            var factory = new MottojoyContextFactory();
//
//            var context= factory.CreateDbContext(null);
//            
//            ModelComparer modelComparer = new ModelComparer();
//
//            modelComparer.Compare(context.Model,CompiledModel.GetInstance());
        }

        static void Create()
        {
            var factory = new SampleContextFactory();            
            Smart.Default.AddExtensions(
                new AnnotationListFormatter(),
                new ServicePropertiesFormatter(),
                new PropertyListFormatter(),
                new ForeignKeyListFormatter(),
                new KeyListFormatter(),
                new EntityNamespaceListFormatter(),
                new EntityListFormatter(),
                new IndexListFormatter(),
                new LambdaExpressionFormatter(),
                new ModelNamespaceListFormatter(),
                new ForeignKeyNamespaceListFormatter(),
                new NavigationFormatter(),
                new NavigationNamespaceListFormatter());
            
            Directory.CreateDirectory("./MainFolder");
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var context = factory.CreateDbContext(null))
            {
                IModel model = context.Model;
                sw.Stop();
                Console.WriteLine("{0} milliseconds has been elapsed for creating Model",sw.Elapsed.TotalMilliseconds);
                
                sw.Restart();

                var v =new ModelCompiler(model, "test", "./MainFolder");
                v.createModel();
                
                sw.Stop();
                Console.WriteLine("{0} milliseconds has been elapsed for creating Compiled Model",sw.Elapsed.TotalMilliseconds);
            } 
        }

        
    }
    
}