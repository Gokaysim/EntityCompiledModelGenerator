using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class PropertyListFormatter:IFormatter
    {      
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is IEnumerable<IProperty>;
            
            if (!iCanHandleThisInput)
                return false;

            var appending = formattingInfo.Format.GetLiteralText();
            var properties =( IEnumerable<IProperty>) formattingInfo.CurrentValue;
                        
            
            formattingInfo.Write(GetPropertyListString(properties,appending));

            return true;

        }

        private string[] names = new[] {"propertylist"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetPropertyListString(IEnumerable<IProperty> properties,string appending)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("new List<IProperty>", appending);
            sb.AppendFormat("\n{0}{{",appending);

            foreach (var property in properties)
            {
                sb.AppendFormat("\n{1}\t{0}.GetInstance(),",GetNameOfPropertyName(property),appending);
            }
            
            sb.AppendFormat("\n{0}}}",appending);

            return sb.ToString();
        }

        public static string GetNameOfPropertyName(IProperty property)
        {
            return $"{GetNakedNameOfPropertyName(property)}PropertyType";
        }
        public static string GetNakedNameOfPropertyName(IProperty property)
        {
            return $"{property.Name}";
        }
    }
}