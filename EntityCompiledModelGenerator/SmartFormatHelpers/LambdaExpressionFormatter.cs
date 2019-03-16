using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class LambdaExpressionFormatter:IFormatter
    {
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is LambdaExpression;
            
            if (!iCanHandleThisInput)
                return false;
            
            var raw= formattingInfo.Format.GetLiteralText();
            var rawSplit =raw.Split("|");
            
            var entityClassName = rawSplit[0];
            var parameterName = rawSplit[1];
            var appending = rawSplit[2];
            
            var lambda =(LambdaExpression) formattingInfo.CurrentValue;
            
            var exp =lambda.ToString().Replace("\"","\\\"");               
            
            var sb = new StringBuilder();

            sb.AppendFormat("var exp=\"{0}\";",exp);

            sb.AppendFormat("\n{0}var p =new ParameterExpression[{1}];",appending,arg1: lambda.Parameters.Count);            
            foreach (var parameter in lambda.Parameters)
            {
                sb.AppendFormat("\n{0}p.Append(Expression.Parameter(Type.GetType(\"{1}\"),\"{2}\"));",appending,parameter.Type.FullName,parameter.Name);
            }
            sb.AppendFormat("\n{0}{1} = System.Linq.Dynamic.DynamicExpression.ParseLambda(p, Type.GetType(\"{2}\"), exp);",
                appending, parameterName,lambda.ReturnType.FullName);     

            formattingInfo.Write(sb.ToString());

            return true;
        }

        private string[] names = new[] {"lambdaexpression"};
        public string[] Names { get { return names; } set { this.names = value; } }
    }
}