// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellHelper.cs" company="CNC SOftware,Inc.">
//   mick.george@mastercam.com
// </copyright>
// <summary>
//   Shell helper methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Services
{
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Shell helper methods.
    /// </summary>
    public static class ShellHelper
    {
        #region public Static Methods

        /// <summary>
        /// Attempts to find a suitable owner window for our message boxes.
        /// </summary>
        /// <returns>Owner window, if any.</returns>
        public static Window FindSuitableOwner()
        {
            ////// First attempt to find the currently active window to mimic the built in message box behavior.
            ////var owner = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);
            ////if (owner == null)
            ////{
                // If there is no active window check if the main window is still available.
                // The ordering of this choice is up for debate. Maybe there is a better priority sequence.
                var owner = Application.Current.MainWindow;
                if (owner == null)
                {
                    // If there is no main window... maybe there is something else! Maybe...
                    return Application.Current.Windows.Cast<Window>().FirstOrDefault();
                }
            ////}

            owner.Activate();

            return owner;
        }

        #endregion
    }
}