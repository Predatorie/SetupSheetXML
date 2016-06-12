// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageBoxService.cs" company="CNC Software,Inc.">
//   mick.george@mastercam.com
// </copyright>
// <summary>
//   Abstraction of the System.Windows.MessageBox class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Services
{
    using System.Windows;

    /// <summary>
    /// Abstraction of the System.Windows.MessageBox class.
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <returns>
        /// A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        MessageBoxResult Show(string messageBoxText);

        /// <summary>
        /// Displays a message box that has a message, title bar caption; and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <returns>
        /// A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        MessageBoxResult Show(string messageBoxText, string caption);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, and button;
        /// and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="button">A System.Windows.MessageBoxButton value that specifies which button or buttons to display.</param>
        /// <returns>
        /// A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button);

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon;
        /// and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="button">A System.Windows.MessageBoxButton value that specifies which button or buttons to display.</param>
        /// <param name="icon">A System.Windows.MessageBoxImage value that specifies the icon to display.</param>
        /// <returns>
        /// A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);
    }
}