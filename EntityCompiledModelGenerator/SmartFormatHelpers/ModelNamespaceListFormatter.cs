using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class ModelNamespaceListFormatter:IFormatter
    {
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {

            var obj = formattingInfo.CurrentValue;
            
            System.Type type = obj.GetType(); 
            var foreignKeys = (IEnumerable<IEntityType>)type.GetProperty("EntityTypes").GetValue(obj, null);
            var namespaceString = (string)type.GetProperty("Namespace").GetValue(obj, null);

            formattingInfo.Write(GetNamespacesForForeignKeyList(foreignKeys,namespaceString));
            
            return true;

            
        }

        public static string GetNamespacesForForeignKeyList(IEnumerable<IEntityType> list,string nameSpaceString)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendFormat("using {0}.{1}Classes;\n",nameSpaceString,EntityListFormatter.GetNakedNameOfIEntityType(item));
            }

            return sb.ToString();
        }

        private string[] names = new[] {"modelnamespacelist"};
        public string[] Names
        {
            get { return names; }
            set { names = value; }
        }
    }
}