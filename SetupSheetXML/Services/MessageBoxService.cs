// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxService.cs" company="CNC SOftware,Inc.">
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
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether any post output interaction should be disabled.
        /// </summary>
        public bool IsSilentPosting { get; set; }

        #endregion

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
            if (this.IsSilentPosting)
            {
                return MessageBoxResult.None;
            }

            var owner = ShellHelper.FindSuitableOwner();
            return owner != null
                   ? MessageBox.Show(owner, messageBoxText)
                   : MessageBox.Show(messageBoxText);
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
            if (this.IsSilentPosting)
            {
                return MessageBoxResult.None;
            }

            var owner = ShellHelper.FindSuitableOwner();
            return owner != null
                   ? MessageBox.Show(owner, messageBoxText, caption)
                   : MessageBox.Show(messageBoxText, caption);
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
            if (this.IsSilentPosting)
            {
                return MessageBoxResult.None;
            }

            var owner = ShellHelper.FindSuitableOwner();
            return owner != null
                   ? MessageBox.Show(owner, messageBoxText, caption, button)
                   : MessageBox.Show(messageBoxText, caption, button);
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
            if (this.IsSilentPosting)
            {
                return MessageBoxResult.None;
            }

            var owner = ShellHelper.FindSuitableOwner();
            return owner != null
                   ? MessageBox.Show(owner, messageBoxText, caption, button, icon)
                   : MessageBox.Show(messageBoxText, caption, button, icon);
        }

        #endregion
    }
}