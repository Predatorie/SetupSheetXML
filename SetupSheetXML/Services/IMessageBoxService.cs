// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageBoxService.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   Abstraction of the Mastercam.IO.DialogManager class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Services
{
    using Mastercam.App.Exceptions;
    using Mastercam.IO.Types;

    /// <summary>The MessageBoxService interface.</summary>
    public interface IMessageBoxService
    {
        /// <summary>The ok.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        void Ok(string message, string title);

        /// <summary>The mastercam error.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        void MastercamError(string message, string title);

        /// <summary>The mastercam exception.</summary>
        /// <param name="ex">The ex.</param>
        void MastercamException(MastercamException ex);

        /// <summary>The ask for angle.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        DialogReturnType AskForAngle(string prompt, ref double value);

        /// <summary>The ask for double.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        DialogReturnType AskForDouble(string prompt, double lower, double upper, ref double value);

        /// <summary>The ask for integer.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        DialogReturnType AskForInteger(string prompt, short lower, short upper, ref short value);

        /// <summary>The ask for string.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        DialogReturnType AskForString(string prompt, ref string value);

        /// <summary>The yes no.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        DialogReturnType YesNo(string message, string title);

        /// <summary>The yes no cancel.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        DialogReturnType YesNoCancel(string message, string title);
    }
}