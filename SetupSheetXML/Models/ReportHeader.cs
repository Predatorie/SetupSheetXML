// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportHeader.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   Defines the ReportHeader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Models
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Annotations;
    using ResourceStrings;

    /// <summary>
    /// The graphics view.
    /// </summary>
    public enum GraphicsView
    {
        /// <summary>
        /// The wcs.
        /// </summary>
        Wcs = 0,

        /// <summary>
        /// The tool plane.
        /// </summary>
        ToolPlane,

        /// <summary>
        /// The isometric relative to wcs.
        /// </summary>
        IsometricRelativeToWcs,

        /// <summary>
        /// The isometric world.
        /// </summary>
        IsometricWorld
    }

    /// <summary>
    /// The report header.
    /// </summary>
    public class ReportHeader : INotifyPropertyChanged
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

        private string xml;

        private bool generateAutomaticImages;

        private bool generateAutomaticOperationImages;

        private bool generateColorImages;

        private bool displayViewer;

        private bool writePdf;

        #endregion

        #region Construction

        public ReportHeader()
        {
            this.GenerateColorImages = true;
            this.GenerateAutomaticImages = true;
            this.GenerateAutomaticOperationImages = true;
            this.WritePdf = false;
            this.DisplayViewer = false;
            this.Xml = ApplicationStrings.SetupSheetName;
            this.View = GraphicsView.Wcs;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the programmer.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the drawing.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the note one.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the note two.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the note three.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the report.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether generate automatic images.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether generate automatic operation images.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether generate color images.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether display viewer.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether write pdf.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the xml.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public GraphicsView View { get; set; }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Methods

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
