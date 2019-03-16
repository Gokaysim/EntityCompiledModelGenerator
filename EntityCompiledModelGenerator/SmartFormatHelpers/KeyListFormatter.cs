using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class KeyListFormatter:IFormatter
    {
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is IEnumerable<IKey>;
            
            if (!iCanHandleThisInput)
                return false;

            var appending = formattingInfo.Format.GetLiteralText();
            var keys =(IEnumerable<IKey>) formattingInfo.CurrentValue;
                        
            
            formattingInfo.Write(GetKeysString(keys,appending));

            return true;

        }

        private string[] names = new[] {"keylist"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetKeysString(IEnumerable<IKey> keys,string appending)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("new List<IKey>");
            sb.AppendFormat("\n{0}{{",appending);
            foreach (var key in keys)
            {
                sb.Append(GetKeyString(key, appending));
            }
            
            sb.AppendFormat("\n{0}}}",appending);

            return sb.ToString();
        }

        public static string GetKeyString(IKey key, string appending)
        {
            return string.Format("\n{1}{0}.GetInstance()",GetNameOfKey(key) ,appending);
        }

        public static string GetNameOfKey(IKey key)
        {
            var sb = new StringBuilder();
            
            sb.Append(EntityListFormatter.GetNakedNameOfIEntityType(key.DeclaringEntityType));

            foreach (var property in key.Properties)
            {
                string propertyName = PropertyListFormatter.GetNakedNameOfPropertyName(property);

                sb.Append(propertyName);
            }
            sb.Append("Key");

            return sb.ToString();
        }
    }
}