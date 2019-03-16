using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class EntityListFormatter:IFormatter
    {      
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is IEnumerable<IEntityType>;
            
            if (!iCanHandleThisInput)
                return false;

            var appending = formattingInfo.Format.GetLiteralText();
            var foreignKeys =(IEnumerable<IEntityType>) formattingInfo.CurrentValue;
                        
            
            formattingInfo.Write(GetEntityTypeString(foreignKeys,appending));

            return true;

        }

        private string[] names = new[] {"entitytypelist"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetEntityTypeString(IEnumerable<IEntityType> foreignKeys,string appending)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("new List<IEntityType>");
            sb.AppendFormat("\n{0}{{",appending);
            foreach (var entityType in foreignKeys)
            {
                sb.AppendFormat("\n\t{1}{0}.GetInstance(),",GetNameOfIEntityType(entityType),appending);
            }
            
            sb.AppendFormat("\n{0}}}",appending);

            return sb.ToString();
        }

        public static string GetNameOfIEntityType(IEntityType entityType)
        {
            return $"{GetNakedNameOfIEntityType(entityType)}EntityType";
        }
        public static string GetNameOfIEntityType(ITypeBase entityType)
        {
            return $"{GetNakedNameOfIEntityType(entityType)}EntityType";
        }
        public static string GetNakedNameOfIEntityType(IEntityType entityType)
        {
            return entityType.Name.Split(".").Last().Split("<").First();
        }
        public static string GetNakedNameOfIEntityType(ITypeBase entityType)
        {
            return entityType.Name.Split(".").Last().Split("<").First();
        }
    }
}