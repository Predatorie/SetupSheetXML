// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedExtenstions.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   Defines the NotifyPropertyChangedExtenstions extention type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Tests.Extenstions
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    /// <summary>
    /// The notify property changed extenstions.
    /// </summary>
    public static class NotifyPropertyChangedExtenstions
    {
        /// <summary> A T extension method that should notify for. </summary>
        ///
        /// <typeparam name="T">     Generic type parameter. </typeparam>
        /// <typeparam name="TProp"> Type of the property. </typeparam>
        /// <param name="subject">            The subject to act on. </param>
        /// <param name="propertyExpression"> The property expression. </param>
        ///
        /// <returns> A PropertyChangedExpectation&lt;T&gt; </returns>
        public static
            PropertyChangedExpectation<T>
            ShouldNotifyFor<T, TProp>(this T subject, Expression<Func<T, TProp>> propertyExpression)
            where T : INotifyPropertyChanged
        {
            return new PropertyChangedExpectation<T>(subject, ExpressionUtlilities.GetPropertyName(propertyExpression));
        }      
    }
}
