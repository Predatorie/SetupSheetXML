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

    using Mastercam.App.Exceptions;
    using Mastercam.IO;

    using Services;

    using Models;

    using ResourceStrings;

    using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

    public class SetupSheetViewModel : INotifyPropertyChanged
    {
        #region Backing Fields

        private readonly IMessageBoxService messageBoxService;

        private readonly ISerializerService serializerService;

        private string title;

        #endregion

        #region Constants

        private static readonly string HeaderFile = Path.Combine(SettingsManager.SharedDirectory, "common\\reports\\TMP\\report.txt");

        private static readonly string ReportsFolder = Path.Combine(SettingsManager.SharedDirectory, "common\\reports\\SST");

        #endregion

        #region Construction

        /// <summary>
        ///  The SetupSheetViewModel constructor
        /// </summary>
        /// <param name="messageBoxService">The MessageBoxService instance</param>
        /// <param name="serializerService">The SerializerService instance</param>
        public SetupSheetViewModel(IMessageBoxService messageBoxService, ISerializerService serializerService)
        {
            // Wire up our services
            this.messageBoxService = messageBoxService;
            this.serializerService = serializerService;

            // Wire up our commands
            this.OkCommand = new DelegateCommand(this.GenerateXml, this.CanGenerateXml);
            this.CloseCommand = new DelegateCommand<Window>(this.Close);
            this.BrowseCommand = new DelegateCommand(this.BrowseReport);

            //  Initialize view from previous session 
            this.LoadValues();

            this.Title = ApplicationStrings.Title;
        }

        #endregion

        #region Commands

        public ICommand OkCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public ICommand BrowseCommand { get; private set; }

        #endregion

        #region Public Properties

        public ReportHeader Header { get; set; }

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

        public string Project
        {
            get
            {
                return this.Header.Project;
            }

            set
            {
                this.Header.Project = value;
                this.OnPropertyChanged();
            }
        }

        public string Customer
        {
            get
            {
                return this.Header.Customer;
            }

            set
            {
                this.Header.Customer = value;
                this.OnPropertyChanged();
            }
        }

        public string Programmer
        {
            get
            {
                return this.Header.Programmer;
            }
            set
            {
                this.Header.Programmer = value;
                this.OnPropertyChanged();
            }
        }

        public string Drawing
        {
            get
            {
                return this.Header.Drawing;
            }
            set
            {
                this.Header.Drawing = value;
                this.OnPropertyChanged();
            }
        }

        public string Revision
        {
            get
            {
                return this.Header.Revision;
            }
            set
            {
                this.Header.Revision = value;
                this.OnPropertyChanged();
            }
        }

        public string NoteOne
        {
            get
            {
                return this.Header.NoteOne;
            }
            set
            {
                this.Header.NoteOne = value;
                this.OnPropertyChanged();
            }
        }

        public string NoteTwo
        {
            get
            {
                return this.Header.NoteTwo;
            }
            set
            {
                this.Header.NoteTwo = value;
                this.OnPropertyChanged();
            }
        }

        public string NoteThree
        {
            get
            {
                return this.Header.NoteThree;
            }
            set
            {
                this.Header.NoteThree = value;
                this.OnPropertyChanged();
            }
        }

        public string Report
        {
            get
            {
                return this.Header.Report;
            }
            set
            {
                this.Header.Report = value;
                this.OnPropertyChanged();
            }
        }

        public bool GenerateAutomaticImages
        {
            get
            {
                return this.Header.GenerateAutomaticImages;
            }
            set
            {
                this.Header.GenerateAutomaticImages = value;
                this.OnPropertyChanged();
            }
        }

        public bool GenerateAutomaticOperationImages
        {
            get
            {
                return this.Header.GenerateAutomaticOperationImages;
            }
            set
            {
                this.Header.GenerateAutomaticOperationImages = value;
                this.OnPropertyChanged();
            }
        }

        public bool GenerateColorImages
        {
            get
            {
                return this.Header.GenerateColorImages;
            }
            set
            {
                this.Header.GenerateColorImages = value;
                this.OnPropertyChanged();
            }
        }

        public bool DisplayViewer
        {
            get
            {
                return this.Header.DisplayViewer;
            }
            set
            {
                this.Header.DisplayViewer = value;
                this.OnPropertyChanged();
            }
        }

        public bool WritePdf
        {
            get
            {
                return this.Header.WritePdf;
            }
            set
            {
                this.Header.WritePdf = value;
                this.OnPropertyChanged();
            }
        }

        public string Xml
        {
            get
            {
                return this.Header.Xml;
            }
            set
            {
                this.Header.Xml = value;
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
        /// Load previous values from disk.
        /// </summary>
        private void LoadValues()
        {
            this.Header = File.Exists(HeaderFile) ?
                this.serializerService.DeserializeObject<ReportHeader>(HeaderFile) :
                new ReportHeader();
        }

        /// <summary>
        /// Save values to disk.
        /// </summary>
        private void SaveValues()
        {
            this.serializerService.SerializeObject(HeaderFile, this.Header);
        }

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
                DefaultExt = "rpx",
                Filter = "Report (*.rpx)|*.rpx|All files (*.*)|*.*",
                Title = ApplicationStrings.SelectReport,
                ValidateNames = true,
                InitialDirectory = ReportsFolder
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
        /// <returns></returns>
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
                var success = SetupSheetInterop.SetupSheet.SetupSheet_DoRunNoDialog(ref drawingInfo,
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
                    this.messageBoxService.MastercamError(
                        "XML generation failed, call to 'SetupSheet_DoRunNoDialog' returned false.",
                        ApplicationStrings.Title);
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
