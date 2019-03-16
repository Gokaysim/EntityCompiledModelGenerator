using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class ServicePropertiesFormatter:IFormatter
    {
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is IEnumerable<IServiceProperty>;
            
            if (!iCanHandleThisInput)
                return false;
            var appending = formattingInfo.Format.GetLiteralText();
            var serviceProperties =(IEnumerable<IServiceProperty>) formattingInfo.CurrentValue;
            StringBuilder sb = new StringBuilder();
            sb.Append("new List<IServiceProperty>");
            sb.AppendFormat("\n{0}{{",appending);

            foreach (var serviceProperty in serviceProperties)
            {
                Type.GetType(serviceProperty.PropertyInfo.DeclaringType.Namespace);

                sb.AppendFormat("{7}\tnew SimpleServiceProperty({0},\n{7}{1},\n{7}{2},\n{7}{3},\n{7}{4},\n{7}{5},\n{7}{6}),",
                    serviceProperty.ClrType.FullName,
                    serviceProperty.PropertyInfo.Name,
                    serviceProperty.FieldInfo.Name,
                    "this",
                    serviceProperty.IsShadowProperty?"true":"false",
                    $"new SimpleTypeBase({serviceProperty.DeclaringType.Name},_model,{AnnotationListFormatter.GetAnnotationString(serviceProperty.DeclaringType.GetAnnotations(),"")})",                    
                    serviceProperty.Name
                    );
            }

            sb.AppendFormat("\n{0}}}",appending);
            
            
            formattingInfo.Write(sb.ToString());

            return true;

        }

        private string[] names = new[] {"serviceproperties"};
        public string[] Names { get { return names; } set { this.names = value; } }
    }
}