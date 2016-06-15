// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicTests.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   Defines the BasicTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Tests
{
    using System;

    using Extenstions;

    using Models;

    using NUnit.Framework;

    /// <summary>
    /// The basic tests.
    /// </summary>
    [TestFixture]
    public sealed class BasicTests
    {
        /// <summary>
        /// Tests a single property for failure.
        /// </summary>
        [Test]
        public void SingleProperty_AssertFail()
        {
            var reportHeader = new ReportHeader();

            var ex = Assert.Throws<AssertionException>(() =>
                  reportHeader.ShouldNotifyFor(x => x.Report)
                  .When(
                      () =>
                          {
                              /* Do nothing so we expect an assert */
                          }));

            Assert.That(
                ex.Message,
                Is.EqualTo("Expected PropertyChanged to fire for Report"));
        }

        /// <summary>
        /// Tests a single property pass
        /// </summary>
        [Test]
        public void SingleProperty_AssertPass()
        {
            var reportHeader = new ReportHeader();

            reportHeader.ShouldNotifyFor(x => x.Report)
            .When(() => reportHeader.Report = "Setup Sheet");
        }

        /// <summary> Non property expression exception. 
        /// We cant extract a property name from a literal string when
        /// a property event fires and compare it.          
        /// </summary>
        [Test]
        public void NonPropertyExpression_Exception()
        {
            var reportHeader = new ReportHeader();

            var ex = Assert.Throws<ArgumentException>(() =>
            reportHeader.ShouldNotifyFor(x => "not a property expression"));

            Assert.That(
                ex.Message,
                Is.EqualTo("Expression must be a simple property access of the form \"x => x.PropertyName\"."));
        }

        /// <summary> Multiple properties single notification assert fail. </summary>
        [Test]
        public void MultipleProperties_SingleNotification_AssertFail()
        {
            var reportHeader = new ReportHeader();

            var ex = Assert.Throws<AssertionException>(() =>
                reportHeader.ShouldNotifyFor(x => x.Customer)
                    .And(x => x.Xml)
                    .When(() => reportHeader.Customer = "Mick"));

            const string ExpectedMessage = "Expected PropertyChanged to fire for Xml Expectation met for Customer";

            Assert.That(
                ex.Message,
                Is.EqualTo(ExpectedMessage));
        }

        /// <summary>
        /// The multiple properties assert pass.
        /// </summary>
        [Test]
        public void MultipleProperties_AssertPass()
        {
            var reportHeader = new ReportHeader();

            reportHeader.ShouldNotifyFor(x => x.Customer)
                     .And(x => x.Xml)
                     .When(() => reportHeader.Customer = "Mick");
        }

        /// <summary>
        /// The multiple properties no notification assert fail.
        /// </summary>
        [Test]
        public void MultipleProperties_NoNotification_AssertFail()
        {
            var reportHeader = new ReportHeader();

            var ex = Assert.Throws<AssertionException>(() =>
                reportHeader.ShouldNotifyFor(x => x.Customer)
                    .And(x => x.Xml)
                    .When(() =>
                            {
                                /* do nothing */
                            }));

            const string ExpectedMessage = "Expected PropertyChanged to fire for Customer, Xml";

            Assert.That(
                ex.Message,
                Is.EqualTo(ExpectedMessage));
        }
    }
}
