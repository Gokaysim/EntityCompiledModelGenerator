using Microsoft.EntityFrameworkCore.Metadata;
using SmartFormat.Core.Extensions;

namespace EntityCompiledModelGenerator.SmartFormatHelpers
{
    public class NavigationFormatter:IFormatter
    {
        public bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var iCanHandleThisInput = formattingInfo.CurrentValue is INavigation;
            
            if (!iCanHandleThisInput)
                return false;
            var navigation = (INavigation)formattingInfo.CurrentValue;
            var appending= formattingInfo.Format.GetLiteralText();
            
            formattingInfo.Write(string.Format("{0}",GetNameOfNavigation(navigation)));

            return true;
        }

        private string[] names = new[] {"navigation"};
        public string[] Names { get { return names; } set { this.names = value; } }

        public static string GetNameOfNavigation(INavigation navigation)
        {
            return $"{navigation.Name}Navigation";
        }
    }
}