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
    public class TypeBaseFormatter:IFormatter
    {      
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is ITypeBase;
            
            if (!iCanHandleThisInput)
                return false;

            var appending = formattingInfo.Format.GetLiteralText();
            var typeBase =(ITypeBase) formattingInfo.CurrentValue;
                        
            
            formattingInfo.Write(GetEntityTypeString(typeBase,appending));

            return true;

        }

        private string[] names = new[] {"entitylist"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetEntityTypeString(ITypeBase typeBase,string appending)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("{0}.GetInstance(),",GetNameOfITypeBase(typeBase));

            return sb.ToString();
        }

        public static string GetNameOfITypeBase(ITypeBase entityType)
        {
            return $"{entityType.Name.Split(".").Last().Split("<").First()}TypeBase";
        }
    }
}