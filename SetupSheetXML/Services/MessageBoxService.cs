// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxService.cs" company="CNC Software,Inc.">
//   mick.george@mastercam.com
// </copyright>
// <summary>
//   Defines the MessageBoxService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Services
{
    using System.Windows;

    /// <summary>
    /// The message box service.
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        #region IMessageBoxService Members

        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <returns>
        /// A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        public MessageBoxResult Show(string messageBoxText)
        {
            return MessageBox.Show(messageBoxText);
        }

        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <returns>
        /// A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        public MessageBoxResult Show(string messageBoxText, string caption)
        {
            return MessageBox.Show(messageBoxText, caption);
        }

        /// <summary>
        /// Displays a message box that has a message and that returns a result.
        /// </summary>
        /// <param name="messageBoxText">A System.String that specifies the text to display.</param>
        /// <param name="caption">A System.String that specifies the title bar caption to display.</param>
        /// <param name="button">A System.Windows.MessageBoxButton value that specifies which button or buttons to display.</param>
        /// <returns>
        /// A System.Windows.MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return MessageBox.Show(messageBoxText, caption, button);
        }

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
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon);
        }

        #endregion
    }
}