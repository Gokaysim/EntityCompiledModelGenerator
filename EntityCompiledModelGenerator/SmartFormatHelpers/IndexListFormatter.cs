using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class IndexListFormatter:IFormatter
    {      
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is IEnumerable<IIndex>;
            
            if (!iCanHandleThisInput)
                return false;

            var appending = formattingInfo.Format.GetLiteralText();
            var indexes =(IEnumerable<IIndex>) formattingInfo.CurrentValue;
                        
            
            formattingInfo.Write(GetIndexesString(indexes,appending));

            return true;

        }

        private string[] names = new[] {"indexlist"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetIndexesString(IEnumerable<IIndex> indexes,string appending)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("new List<IIndex>", appending);
            sb.AppendFormat("\n{0}{{",appending);

            foreach (var index in indexes)
            {
                sb.AppendFormat("{1}\n\t{0}.GetInstance(),",GetNameOfIndex(index),appending);
            }
            
            sb.AppendFormat("\n{0}}}",appending);

            return sb.ToString();
        }

        public static string GetNameOfIndex(IIndex index)
        {
            return $"{index.ToString().Split(".").Last().Split(" ").First()}Index";
        }
    }
}