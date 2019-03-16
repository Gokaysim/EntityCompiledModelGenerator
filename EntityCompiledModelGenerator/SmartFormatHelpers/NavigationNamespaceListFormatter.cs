using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class NavigationNamespaceListFormatter:IFormatter
    {
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {

            var obj = formattingInfo.CurrentValue;
            
            var type = obj.GetType(); 
            var foreignKey = (IForeignKey)type.GetProperty("ForeignKeyObject").GetValue(obj, null);
            var namespaceString = (string)type.GetProperty("Namespace").GetValue(obj, null);

            var nakedEntityName = EntityListFormatter.GetNakedNameOfIEntityType(foreignKey.DeclaringEntityType);
            formattingInfo.Write(string.Format("using {0}.{1}Classes",namespaceString,nakedEntityName));
            
            return true;

            
        }
        private string[] names = new[] {"navigationnamespacelist"};
        public string[] Names
        {
            get { return names; }
            set { names = value; }
        }
    }
}