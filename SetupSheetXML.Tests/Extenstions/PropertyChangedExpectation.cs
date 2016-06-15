// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyChangedExpectation.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   The property changed expectation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Tests.Extenstions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;

    using NUnit.Framework;

    /// <summary>
    /// The property changed expectation.
    /// </summary> 
    /// <typeparam name="T"> The type
    /// </typeparam>
    public class PropertyChangedExpectation<T>
        where T : INotifyPropertyChanged
    {
        /// <summary>
        /// Holds the prop name passed in.
        /// </summary>
        private readonly string thePropertyName;

        private readonly IEnumerable<string> thePropertyNames;

        private readonly T theSubject;

        ///  <summary> Initializes a new instance of the PropertyChangedExpectation class. </summary>
        /// <param name="subject">The subject payload</param>
        /// <param name="propertyNames">The list of property names</param>
        public PropertyChangedExpectation(T subject, params string[] propertyNames)
        {
            // Store the property name for our assert 
            this.thePropertyName = propertyNames.First();
            this.thePropertyNames = propertyNames;
            this.theSubject = subject;
        }

        /// <summary>
        /// The when method.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        public void When(Action action)
        {
            // Store a list of property names for this subject
            var notifications = new List<string>();
            this.theSubject.PropertyChanged += (s, e) => notifications.Add(e.PropertyName);

            // Excercise the action that was passed in
            action();

            // Cache a list of property name non matches
            var unmetExpectations = this.thePropertyNames.Where(x => !notifications.Contains(x));
            var names = unmetExpectations as string[] ?? unmetExpectations.ToArray();
            if (!names.Any())
            {
                return;
            }

            // Format message
            var msg = $"Expected PropertyChanged to fire for {this.FormatNames(names)}";

            // Cache a list of property name matches
            var metExpectations = this.thePropertyNames.Intersect(notifications).ToArray();

            if (metExpectations.Any())
            {
                msg += $" Expectation met for {this.FormatNames(metExpectations)}";
            }

            Assert.Fail(msg);
        }

        /// <summary> Ands the given propertry expression. </summary>
        ///
        /// <typeparam name="TProp"> Type of the property. </typeparam>
        /// <param name="propertryExpression"> The propertry expression. </param>
        ///
        /// <returns> A PropertyChangedExpectation&lt;T&gt; </returns>
        public PropertyChangedExpectation<T> And<TProp>(Expression<Func<T, TProp>> propertryExpression)
        {
            var newPropertyNames =
                this.thePropertyNames.Concat(new[]
                {
                    ExpressionUtlilities.GetPropertyName(propertryExpression)
                }).ToArray();


            return new PropertyChangedExpectation<T>(
                this.theSubject,
                newPropertyNames);
        }

        /// <summary>
        /// The format names.
        /// </summary>
        /// <param name="propertyNames">
        /// The property names.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string FormatNames(IEnumerable<string> propertyNames)
        {
            return string.Join(", ", propertyNames.Select(x => $"{x}"));
        }
    }
}
