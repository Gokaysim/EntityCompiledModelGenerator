using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mottojoy.Infrastructure.Data;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class AnnotationListFormatter:IFormatter
    {      
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is IEnumerable<IAnnotation>;
            
            if (!iCanHandleThisInput)
                return false;

            var appending = formattingInfo.Format.GetLiteralText();
            var annotations =(IEnumerable<IAnnotation>) formattingInfo.CurrentValue;
                        
            
            formattingInfo.Write(GetAnnotationString(annotations,appending));

            return true;

        }

        private string[] names = new[] {"annotationlist"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetAnnotationString(IEnumerable<IAnnotation> annotations,string appending)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("new List<IAnnotation>", appending);
            sb.AppendFormat("\n{0}{{",appending);

            
            foreach (var annotation in annotations)
            {
                var type=annotation.GetType();
                if (type == typeof(ConventionalAnnotation))
                {
                    var castedValue = (ConventionalAnnotation)annotation; 
                    sb.AppendFormat("\n{1}\t{0},",GetStringOfConventionalAnnotation(castedValue),appending);                    
                }
                else
                {
                    throw new Exception("Unknown type of annotation value");
                }
            }
            
            sb.AppendFormat("\n{0}}}",appending);

            return sb.ToString();
        }

        public static string GetStringOfConventionalAnnotation(ConventionalAnnotation conventionalAnnotation)
        {
            StringBuilder sb = new StringBuilder();
            var valueType = conventionalAnnotation.Value.GetType();

            if (valueType == typeof(DirectConstructorBinding))
            {
                sb.AppendFormat("new ConventionalAnnotation(\"{0}\",{1},ConfigurationSource.{2})",
                    conventionalAnnotation.Name,
                    GetStringConstructorOfDirectConstructorBinding((DirectConstructorBinding)conventionalAnnotation.Value),
                    conventionalAnnotation.GetConfigurationSource());                
            }
            else if (valueType == typeof(string))
            {
                sb.AppendFormat("new ConventionalAnnotation(\"{0}\",\"{1}\",ConfigurationSource.{2})",
                    conventionalAnnotation.Name,
                    (string)conventionalAnnotation.Value,
                    conventionalAnnotation.GetConfigurationSource());
            }
            else
            {
                throw new Exception("Only string and DirectConstructorBinding are supported for now.");
            }

            return sb.ToString();
        }
        public static string GetStringConstructorOfDirectConstructorBinding(DirectConstructorBinding directConstructorBinding)
        {
            var sb = new StringBuilder();

            var v = directConstructorBinding.Constructor.GetType();

            if (directConstructorBinding.ParameterBindings.Count > 0)
            {
                throw new Exception("Parameterbinding not written");
            }
//            directConstructorBinding.Constructor.DeclaringType
            var splitFullName = directConstructorBinding.Constructor.DeclaringType.FullName.Split("`");
            string typeFullName = splitFullName.First();
            if (splitFullName.Length > 1)
            {
                typeFullName += "<string>";
            }
            
            sb.AppendFormat(
                "new DirectConstructorBinding(typeof({0}).GetDeclaredConstructor(null),new List<ParameterBinding>())",
                typeFullName);
            return sb.ToString();
        }
    }
}