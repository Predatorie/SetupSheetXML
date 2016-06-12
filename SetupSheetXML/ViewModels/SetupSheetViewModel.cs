// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetupSheetViewModel.cs" company="CNC Software,Inc.">
//   mick.george@mastercam.com
// </copyright>
// <summary>
//   Defines the SetupSheetViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    using Annotations;

    using Commands;

    using Mastercam.IO;

    using Services;

    using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

    public enum GraphicsView
    {
        Wcs = 0,

        ToolPlane,

        IsometricRelativeToWcs,

        IsometricWorld
    }

    public class SetupSheetViewModel : INotifyPropertyChanged
    {
        #region Backing Fields

        private readonly IMessageBoxService messageBoxService;

        private string xml;

        private string project;

        private string customer;

        private string programmer;

        private string drawing;

        private string revision;

        private string noteOne;

        private string noteTwo;

        private string noteThree;

        private string report;

        private bool generateAutomaticImages;

        private bool generateAutomaticOperationImages;

        private bool generateColorImages;

        private bool displayViewer;

        private bool writePdf;

        private GraphicsView graphicsView;

        private string title;

        #endregion

        #region Construction

        /// <summary>
        ///  The SetupSheetViewModel constructor
        /// </summary>
        /// <param name="messageBoxService">The MessageBoxService instance</param>
        public SetupSheetViewModel(IMessageBoxService messageBoxService)
        {
            // Wire up our services
            this.messageBoxService = messageBoxService;

            // Wire up our commands
            this.OkCommand = new DelegateCommand(this.GenerateXml, this.CanGenerateXml);
            this.CloseCommand = new DelegateCommand<Window>(this.Close);
            this.BrowseCommand = new DelegateCommand(this.BrowseReport);

            // TODO: Allow user to set all properties
            this.Title = "Generate Setup Sheet XML";
            this.GenerateColorImages = true;
            this.GenerateAutomaticImages = true;
            this.GenerateAutomaticOperationImages = true;
            this.WritePdf = false;
            this.DisplayViewer = false;
            this.View  = GraphicsView.Wcs;
            this.Xml = "Setup Sheet";

            // TODO: Implement Saving and Loading previous settings
        }

        #endregion

        #region Commands

        public ICommand OkCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public ICommand BrowseCommand { get; private set; }

        #endregion

        #region Public Properties

        public string Project
        {
            get
            {
                return this.project;
            }

            set
            {
                this.project = value;
                this.OnPropertyChanged();
            }
        }

        public string Customer
        {
            get
            {
                return this.customer;
            }

            set
            {
                this.customer = value;
                this.OnPropertyChanged();
            }
        }

        public string Programmer
        {
            get
            {
                return this.programmer;
            }
            set
            {
                this.programmer = value;
                this.OnPropertyChanged();
            }
        }

        public string Drawing
        {
            get
            {
                return this.drawing;
            }
            set
            {
                this.drawing = value;
                this.OnPropertyChanged();
            }
        }

        public string Revision
        {
            get
            {
                return this.revision;
            }
            set
            {
                this.revision = value;
                this.OnPropertyChanged();
            }
        }

        public string NoteOne
        {
            get
            {
                return this.noteOne;
            }
            set
            {
                this.noteOne = value;
                this.OnPropertyChanged();
            }
        }

        public string NoteTwo
        {
            get
            {
                return this.noteTwo;
            }
            set
            {
                this.noteTwo = value;
                this.OnPropertyChanged();
            }
        }

        public string NoteThree
        {
            get
            {
                return this.noteThree;
            }
            set
            {
                this.noteThree = value;
                this.OnPropertyChanged();
            }
        }

        public string Report
        {
            get
            {
                return this.report;
            }
            set
            {
                this.report = value;
                this.OnPropertyChanged();
            }
        }

        public bool GenerateAutomaticImages
        {
            get
            {
                return this.generateAutomaticImages;
            }
            set
            {
                this.generateAutomaticImages = value;
                this.OnPropertyChanged();
            }
        }

        public bool GenerateAutomaticOperationImages
        {
            get
            {
                return this.generateAutomaticOperationImages;
            }
            set
            {
                this.generateAutomaticOperationImages = value;
                this.OnPropertyChanged();
            }
        }

        public bool GenerateColorImages
        {
            get
            {
                return this.generateColorImages;
            }
            set
            {
                this.generateColorImages = value;
                this.OnPropertyChanged();
            }
        }

        public bool DisplayViewer
        {
            get
            {
                return this.displayViewer;
            }
            set
            {
                this.displayViewer = value;
                this.OnPropertyChanged();
            }
        }

        public bool WritePdf
        {
            get
            {
                return this.writePdf;
            }
            set
            {
                this.writePdf = value;
                this.OnPropertyChanged();
            }
        }

        public GraphicsView View
        {
            get
            {
                return this.graphicsView;
            }
            set
            {
                this.graphicsView = value;
                this.OnPropertyChanged();
            }
        }

        public string Xml
        {
            get
            {
                return this.xml;
            }
            set
            {
                this.xml = value;
                this.OnPropertyChanged();
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Methods

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Select a rpx (report)
        /// C:\Users\Public\Documents\shared mcamx9\common\reports\SST
        /// </summary>
        private void BrowseReport()
        {
            var f = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "rpx",
                Filter = "Report (*.rpx)|*.rpx|All files (*.*)|*.*",
                Title = "Select a Report",
                ValidateNames = true,
                InitialDirectory = Path.Combine(SettingsManager.SharedDirectory, "common\\reports\\SST")
            };

            var success = f.ShowDialog();
            if (success != null && (bool)success)
            {
                this.Report = f.FileName;
            }
        }

        /// <summary>
        /// Make sure we have a report selected and a xml file name
        /// Note: A report is needed because that determines what data is exported to the xml
        /// </summary>
        /// <returns></returns>
        private bool CanGenerateXml()
        {
            // Only if we have a report name and a report
            return !string.IsNullOrEmpty(this.Report) &&
                !string.IsNullOrEmpty(this.Xml) &&
                File.Exists(this.Report);
        }

        /// <summary>
        /// Generates xml for a setup sheet
        /// </summary>
        private void GenerateXml()
        {
            try
            {
                // The strings that would normally be entered on the dialog
                // There MUST be 8 of them and only 8!
                var drawingInfo = new List<string>(8)
                                        {
                                            this.Project,
                                            this.Customer,
                                            this.Programmer,
                                            this.Drawing,
                                            this.Revision,
                                            this.noteOne,
                                            this.noteTwo,
                                            this.noteThree
                                        };

                // Add the selected report to the list so we know what data fields are to be output
                var rpx = new List<string> { this.Report };

                // Holds list of xml files created, should be one.
                var xmlFiles = new List<string>();

                // Run the C-Hook command to generate the XML
                var success = SetupSheetInterop.SetupSheet.SetupSheet_DoRunNoDialog(ref drawingInfo,
                    ref rpx,
                    this.generateAutomaticImages,
                    this.generateAutomaticOperationImages,
                    this.GenerateColorImages,
                    (int)this.View,
                    this.DisplayViewer,
                    this.WritePdf,
                    ref xmlFiles);

                if (success)
                {
                    if (xmlFiles.Count != 1)
                    {
                        this.messageBoxService.Show(
                        $"XML generation failed, expected 1 xml file, {xmlFiles.Count} found.",
                        "Mastercam",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);

                        return;
                    }

                    var path = new FileInfo(xmlFiles[0]);
                    var name = Path.Combine(path.DirectoryName, this.Xml + ".xml");

                    // Overwrite the previous file
                    File.Copy(xmlFiles[0], name, true);

                    this.messageBoxService.Show(
                        "XML generation complete",
                        "Mastercam",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    this.messageBoxService.Show(
                        "XML generation failed, call to 'SetupSheet_DoRunNoDialog' returned false.",
                        "Mastercam",
                        MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                }
            }
            catch (Exception e)
            {

                this.messageBoxService.Show(
                        $"An unexpected error has occured {e.Message}.",
                        "Mastercam",
                        MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// Closes the main view
        /// </summary>
        /// <param name="view"></param>
        private void Close(Window view)
        {
            view.Close();
        }

        #endregion
    }
}
