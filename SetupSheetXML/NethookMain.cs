// ---------------------------------------------------------------------------------------
// <copyright file="NethookMain.cs" company="CNC Software,Inc.">
//   mick.george@mastercam.com
//
// NET-Hook project examples can be found at mastercam.com
// Active API forums can be found at mastercam.com and eMastercam.com
// For all things API support/requests send an e-mail to sdk@mastercam.com
// </copyright>
// --------------------------------------------------------------------------------------

namespace SetupSheetXML
{
    using System;
    using System.Linq;

    using Mastercam.App;
    using Mastercam.App.Exceptions;
    using Mastercam.App.Types;
    using Mastercam.IO;

    using Services;

    using ViewModels;
    using Views;

    /// <summary>
    /// Defines the NethookMain type
    /// </summary>
    public class NethookMain : NetHook3App
    {
        #region Public Override Methods

        /// <summary>
        /// The main entry point for your NETHook.
        /// </summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of your NetHook application.</returns>
        public override MCamReturn Run(int param)
        {
            try
            {
                // Make sure we have at least one operation
                if (!Mastercam.Support.SearchManager.GetOperations().Any())
                {
                    return MCamReturn.FunctionExit;
                }

                // Create the view and attach the viewmodel
                // Using PRISM, Ninject or somekind of IOC container would be a better idea.
                var view = new SetupSheetView { DataContext = new SetupSheetViewModel(new MessageBoxService()) };
                var ret = view.ShowDialog();

                if (ret != null && (bool)ret)
                {
                    SetupSheetInterop.SetupSheet.SetupSheet_DoFreeSetupSheetCaptures();
                }
            }
            catch (Exception e)
            {
                DialogManager.Exception(new MastercamException(e.Message));
            }

            return MCamReturn.NoErrors;
        }

        #endregion
    }
}
