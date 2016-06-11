// ---------------------------------------------------------------------------------------
// <copyright file="NethookMain.cs" company="TODO: Add company">
// TODO: Update copyright text.
// NOTE: If are only going to use the Run method it is good practice to delete the others.
//
// NET-Hook project examples can be found at mastercam.com
// Active API forums can be found at mastercam.com and eMastercam.com
// For all things API support/requests send an e-mail to sdk@mastercam.com
// </copyright>
// --------------------------------------------------------------------------------------

namespace SetupSheetXML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;

    using Mastercam.App;
    using Mastercam.App.Exceptions;
    using Mastercam.App.Types;
    using Mastercam.IO;

    using SetupSheetXML.ViewModels;
    using SetupSheetXML.Views;

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
                var view = new SetupSheetView { DataContext = new SetupSheetViewModel() };
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

           

            //////var report = Path.Combine(SettingsManager.SharedDirectory, @"common\reports\SST\") + "Setup Sheet (MILL).rpx";

            //////// There MUST be the same number of rpx files in this list as there are Machine Groups in the file!
            //////var rpxFiles = new List<string> { report };

            //////// Set options as desired...
            //////var automaticImages = true;

            //////var automaticOperationImages = true;

            //////var colorImages = true;

            //////var graphicsView = 2;

            //////var displayViewer = false;

            //////var writePdfToDisk = true;

            //////// This will be filled in with the list of XML file that were produced.
            //////var xmlFiles = new List<string>();

            //////var ok = SetupSheetInterop.SetupSheet.SetupSheet_DoRunNoDialog(
            //////    ref drawingInfo,   // I:	strings to use instead of dialog items (Programmer, etc)
            //////    ref rpxFiles,   // I/O:	rpx templates
            //////    automaticImages,      // I:	generate automatic images
            //////    automaticOperationImages,       // I:	generate automatic operation images (anyImages must be true)
            //////    colorImages,         // I:	generate color images (anyImage or opImages must be true)
            //////    graphicsView,     // I:	0=WCS, 1=TPLANE, 2=Isometric relative to WCS, 3=Isometric (WORLD)
            //////    displayViewer,      // I:	display results in viewer
            //////    writePdfToDisk,       // I:	write PDF files (useViewer must be false)
            //////    ref xmlFiles);  // O:	list xml written

            return MCamReturn.NoErrors;
        }

        #endregion
    }
}
