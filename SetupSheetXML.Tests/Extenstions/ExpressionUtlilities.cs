// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionUtlilities.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   The expression utlilities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Tests.Extenstions
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// The expression utlilities.
    /// </summary>
    internal static class ExpressionUtlilities
    {
        /// <summary> Gets property name. </summary>
        ///
        /// <typeparam name="T">     Generic type parameter. </typeparam>
        /// <typeparam name="TProp"> Type of the property. </typeparam>
        /// <param name="propertyExpression"> The property expression. </param>
        ///
        /// <returns> The property name. </returns>
        public static string GetPropertyName<T, TProp>(Expression<Func<T, TProp>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Expression must be a simple property access of the form \"x => x.PropertyName\".");
            }

            return body.Member.Name;
        }
    }
}
