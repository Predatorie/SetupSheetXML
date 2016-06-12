// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxService.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   Defines the MessageBoxService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Services
{
    using Mastercam.App.Exceptions;
    using Mastercam.IO;
    using Mastercam.IO.Types;

    /// <summary>The message box service.</summary>
    public class MessageBoxService : IMessageBoxService
    {
        /// <summary>The ok.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        public void Ok(string message, string title)
        {
            DialogManager.OK(message, title);
        }

        /// <summary>The mastercam error.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        public void MastercamError(string message, string title)
        {
            DialogManager.Error(message, title);
        }

        /// <summary>The mastercam exception.</summary>
        /// <param name="ex">The ex.</param>
        public void MastercamException(MastercamException ex)
        {
            DialogManager.Exception(ex);
        }

        /// <summary>The ask for angle.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        public DialogReturnType AskForAngle(string prompt, ref double value)
        {
            return DialogManager.AskForAngle(prompt, ref value);
        }

        /// <summary>The ask for double.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        public DialogReturnType AskForDouble(string prompt, double lower, double upper, ref double value)
        {
            return DialogManager.AskForNumber(prompt, lower, upper, ref value);
        }

        /// <summary>The ask for integer.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        public DialogReturnType AskForInteger(string prompt, short lower, short upper, ref short value)
        {
            return DialogManager.AskForNumber(prompt, lower, upper, ref value);
        }

        /// <summary>The ask for string.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        public DialogReturnType AskForString(string prompt, ref string value)
        {
            return DialogManager.AskForString(prompt, ref value);
        }

        /// <summary>The yes no.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        public DialogReturnType YesNo(string message, string title)
        {
            return DialogManager.YesNo(message, title);
        }

        /// <summary>The yes no cancel.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <returns>The <see cref="DialogReturnType"/>.</returns>
        public DialogReturnType YesNoCancel(string message, string title)
        {
            return DialogManager.YesNoCancel(message, title);
        }
    }
}