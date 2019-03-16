

using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.EntityFrameworkCore.Internal
{
    /// <summary>
    ///     Extension methods for <see cref="T:Microsoft.EntityFrameworkCore.Metadata.IModel" />.
    /// </summary>
    public static class ModelExtensions
    {
        /// <summary>
        ///     Gets the entity that maps the given entity class. Returns null if no entity type with the given CLR type is found
        ///     or the entity type has a defining navigation.
        /// </summary>
        /// <param name="model"> The model to find the entity type in. </param>
        /// <param name="type"> The type to find the corresponding entity type for. </param>
        /// <returns> The entity type, or null if none if found. </returns>
        public static IEntityType FindEntityType(this IModel model, Type type)
        {
            return null;
        }
    }
}