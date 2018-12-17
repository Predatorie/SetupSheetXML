// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetupSheetViewModel.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
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

    using Consts;

    using Mastercam.App.Exceptions;

    using Models;

    using ResourceStrings;

    using Services;

    using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

    /// <summary>
    /// The setup sheet view model.
    /// </summary>
    public class SetupSheetViewModel : INotifyPropertyChanged
    {
        #region Backing Fields

        /// <summary>
        /// The message box service.
        /// </summary>
        private readonly IMessageBoxService messageBoxService;

        /// <summary>
        /// The serializer service.
        /// </summary>
        private readonly ISerializerService serializerService;

        /// <summary>
        /// The title.
        /// </summary>
        private string title;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="SetupSheetViewModel"/> class. 
        ///  The SetupSheetViewModel constructor
        /// </summary>
        /// <param name="messageBoxService">
        /// The MessageBoxService instance
        /// </param>
        /// <param name="serializerService">
        /// The SerializerService instance
        /// </param>
        public SetupSheetViewModel(IMessageBoxService messageBoxService, ISerializerService serializerService)
        {
            // Wire up our services
            this.messageBoxService = messageBoxService;
            this.serializerService = serializerService;

            // Wire up our commands
            this.OkCommand = new DelegateCommand(this.GenerateXml, this.CanGenerateXml);
            this.CloseCommand = new DelegateCommand<Window>(this.Close);
            this.BrowseCommand = new DelegateCommand(this.BrowseReport);

            // Initialize view from previous session 
            this.LoadValues();

            this.Title = ApplicationStrings.Title;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the ok command.
        /// </summary>
        public ICommand OkCommand { get; private set; }

        /// <summary>
        /// Gets the close command.
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        /// <summary>
        /// Gets the browse command.
        /// </summary>
        public ICommand BrowseCommand { get; private set; }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public ReportHeader Header { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => this.title;

            set
            {
                this.title = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// The project.
        /// </summary>
        public string Project => this.Header.Project;

        /// <summary>
        /// The customer.
        /// </summary>
        public string Customer => this.Header.Customer;

        /// <summary>
        /// The programmer.
        /// </summary>
        public string Programmer => this.Header.Programmer;

        /// <summary>
        /// The drawing.
        /// </summary>
        public string Drawing => this.Header.Drawing;

        /// <summary>
        /// The revision.
        /// </summary>
        public string Revision => this.Header.Revision;

        /// <summary>
        /// The note one.
        /// </summary>
        public string NoteOne => this.Header.NoteOne;

        /// <summary>
        /// The note two.
        /// </summary>
        public string NoteTwo => this.Header.NoteTwo;

        /// <summary>
        /// The note three.
        /// </summary>
        public string NoteThree => this.Header.NoteThree;

        /// <summary>
        /// The report.
        /// </summary>
        public string Report => this.Header.Report;

        /// <summary>
        /// The generate automatic images.
        /// </summary>
        public bool GenerateAutomaticImages => this.Header.GenerateAutomaticImages;

        /// <summary>
        /// The generate automatic operation images.
        /// </summary>
        public bool GenerateAutomaticOperationImages => this.Header.GenerateAutomaticOperationImages;

        /// <summary>
        /// The generate color images.
        /// </summary>
        public bool GenerateColorImages => this.Header.GenerateColorImages;

        /// <summary>
        /// The display viewer.
        /// </summary>
        public bool DisplayViewer => this.Header.DisplayViewer;

        /// <summary>
        /// The write pdf.
        /// </summary>
        public bool WritePdf => this.Header.WritePdf;

        /// <summary>
        /// The xml.
        /// </summary>
        public string Xml => this.Header.Xml;

        #endregion   

        #region Protected Methods

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load previous values from disk.
        /// </summary>
        private void LoadValues()
        {
            this.Header = File.Exists(ApplicationConst.HeaderFile) ?
                this.serializerService.DeserializeObject<ReportHeader>(ApplicationConst.HeaderFile) :
                new ReportHeader();
        }

        /// <summary>
        /// Save values to disk.
        /// </summary>
        private void SaveValues() => this.serializerService.SerializeObject(ApplicationConst.HeaderFile, this.Header);

        /// <summary>
        /// Select a rpx (report)
        /// </summary>
        private void BrowseReport()
        {
            var f = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = ApplicationConst.DefaultExt,
                Filter = ApplicationConst.ReportsFilter,
                Title = ApplicationStrings.SelectReport,
                ValidateNames = true,
                InitialDirectory = ApplicationConst.ReportsFolder
            };

            var success = f.ShowDialog();
            if (success != null && (bool)success)
            {
                this.Header.Report = f.FileName;
            }
        }

        /// <summary>
        /// Make sure we have a report selected and a xml file name
        /// Note: A report is needed because that determines what data is exported to the xml
        /// </summary>
        /// <returns>True if file exits, false otherwise</returns>
        private bool CanGenerateXml()
        {
            // Only if we have a report name and a report
            return !string.IsNullOrEmpty(this.Header.Report) &&
                !string.IsNullOrEmpty(this.Header.Xml) &&
                File.Exists(this.Header.Report);
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
                                            this.Header.Project,
                                            this.Header.Customer,
                                            this.Header.Programmer,
                                            this.Header.Drawing,
                                            this.Header.Revision,
                                            this.Header.NoteOne,
                                            this.Header.NoteTwo,
                                            this.Header.NoteThree
                                        };

                // Add the selected report to the list so we know what data fields are to be output
                var rpx = new List<string> { this.Header.Report };

                // Holds list of xml files created, should be one.
                var xmlFiles = new List<string>();

                // Run the C-Hook command to generate the XML
                var success = SetupSheetInterop.SetupSheet.SetupSheet_DoRunNoDialog(
                    ref drawingInfo,
                    ref rpx,
                    this.Header.GenerateAutomaticImages,
                    this.Header.GenerateAutomaticOperationImages,
                    this.Header.GenerateColorImages,
                    (int)this.Header.View,
                    this.Header.DisplayViewer,
                    this.Header.WritePdf,
                    ref xmlFiles);

                if (success)
                {
                    if (xmlFiles.Count != 1)
                    {
                        this.messageBoxService.MastercamError(
                        $"XML generation failed, expected 1 xml file, {xmlFiles.Count} found.",
                        ApplicationStrings.Title);

                        return;
                    }

                    var path = new FileInfo(xmlFiles[0]);
                    var name = Path.Combine(path.DirectoryName, this.Header.Xml + ".xml");

                    // Overwrite the previous file
                    File.Copy(xmlFiles[0], name, true);

                    this.messageBoxService.Ok("XML generation complete", ApplicationStrings.Title);
                }
                else
                {
                    this.messageBoxService.MastercamError(ApplicationStrings.XmlFailed, ApplicationStrings.Title);
                }
            }
            catch (Exception e)
            {
                this.messageBoxService.MastercamException(new MastercamException($"An unexpected error has occured {e.Message}."));
            }
        }

        /// <summary>
        /// Saves the current report header data and closes the main view
        /// </summary>
        /// <param name="view">The view to close</param>
        private void Close(Window view)
        {
            // Save report values to disk
            this.SaveValues();

            view.Close();
        }

        #endregion
    }
}
