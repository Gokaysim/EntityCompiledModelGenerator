using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class ForeignKeyNamespaceListFormatter:IFormatter
    {
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {

            var obj = formattingInfo.CurrentValue;
            
            System.Type type = obj.GetType(); 
            var foreignKeys = (string)type.GetProperty("PrincipalEntityType").GetValue(obj, null);
            var namespaceString = (string)type.GetProperty("Namespace").GetValue(obj, null);

            formattingInfo.Write(string.Format("using {0}.{1}Classes",namespaceString,foreignKeys.Split("EntityType")[0]));
            
            return true;

            
        }
        private string[] names = new[] {"foreignkeynamespacelist"};
        public string[] Names
        {
            get { return names; }
            set { names = value; }
        }
    }
}