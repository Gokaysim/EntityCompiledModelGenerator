using System;
using System.Linq;
using System.Reflection;

namespace EntityCompiledModelGenerator
{
    public static class Extensions
    {
        public static ConstructorInfo GetDeclaredConstructor(this Type type, Type[] types)
        {
            types = types ?? Array.Empty<Type>();

            return type.GetTypeInfo().DeclaredConstructors
                .SingleOrDefault(
                    c => !c.IsStatic
                         && c.GetParameters().Select(p => p.ParameterType).SequenceEqual(types));
        }
        
    }
}