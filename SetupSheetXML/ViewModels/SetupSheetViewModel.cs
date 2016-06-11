// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetupSheetViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the SetupSheetViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    using Annotations;

    using Commands;

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

        #endregion

        #region Construction

        public SetupSheetViewModel()
        {
            this.OkCommand = new DelegateCommand(this.GenerateXml, this.CanGenerateXml);
            this.CloseCommand = new DelegateCommand<Window>(this.Close);
        }

        #endregion

        #region Commands

        public ICommand OkCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

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

        private bool CanGenerateXml()
        {
            return true;
        }

        private void GenerateXml()
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

            // Add the selected report to the list
            var rpx = new List<string> { this.Report };

            // Holds list of xml files created
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
                // TODO: Re-name the XML and copy it to where it needs to be
            }
            else
            {
                // TODO: Handle failure
            }
        }

        private void Close(Window view)
        {
            view.Close();
        }

        #endregion
    }
}
