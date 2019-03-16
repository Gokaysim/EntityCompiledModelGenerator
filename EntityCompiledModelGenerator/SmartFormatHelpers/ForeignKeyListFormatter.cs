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
    public class ForeignKeyListFormatter:IFormatter
    {      
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is IEnumerable<IForeignKey>;
            
            if (!iCanHandleThisInput)
                return false;

            var appending = formattingInfo.Format.GetLiteralText();
            var foreignKeys =(IEnumerable<IForeignKey>) formattingInfo.CurrentValue;
                        
            
            formattingInfo.Write(GetForeignKeysString(foreignKeys,appending));

            return true;

        }

        private string[] names = new[] {"foreignkeylist"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetForeignKeysString(IEnumerable<IForeignKey> foreignKeys,string appending)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("new List<IForeignKey>");
            sb.AppendFormat("\n{0}{{",appending);
            foreach (var foreignKey in foreignKeys)
            {
                GetForeignKeyString(sb,foreignKey,appending);
            }
            
            sb.AppendFormat("\n{0}}}",appending);

            return sb.ToString();
        }

        public static void GetForeignKeyString(StringBuilder sb, IForeignKey foreignKey,string appending)
        {
//            sb.AppendFormat("\n{11}new SimpleForeignKey({12}{0},{12}{1},{12}{2},{12}{3},{12}{4},{12}{5},{12}{6}," +
//                            "{12}{7},{12}{8},{12}{9},{12}{10}),",
//                AnnotationListFormatter.GetAnnotationString(foreignKey.GetAnnotations(),appending+"\t\t"),
//                PropertyListFormatter.GetPropertyListString(foreignKey.Properties,appending+"\t\t"),
//                string.Format("{0}EntityType.GetInstance()",foreignKey.DeclaringEntityType.Name.Split(".").Last()),
//                string.Format("{0}EntityType.GetInstance()",foreignKey.PrincipalEntityType.Name.Split(".").Last()),
//                KeyListFormatter.GetKeyString(foreignKey.PrincipalKey,appending),
//                "",
//                "",
//                "",
//                "",
//                "",
//                "",
//                appending+"\t",
//                "\n"+appending+"\t\t"
//            );
            sb.AppendFormat("\n{1}{0}.GetInstance(),",GetNameOfForeignKey(foreignKey),appending);
        }

        public static string GetNameOfForeignKey(IForeignKey key)
        {
            var sb = new StringBuilder();
            
            sb.Append(EntityListFormatter.GetNakedNameOfIEntityType(key.DeclaringEntityType));

            foreach (var property in key.Properties)
            {
                sb.Append(PropertyListFormatter.GetNakedNameOfPropertyName(property));
            }
            sb.Append("ForeignKey");

            return sb.ToString();
        }
    }
}