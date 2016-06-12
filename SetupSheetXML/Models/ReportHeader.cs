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
    using SetupSheetXML.ResourceStrings;

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
    public class ReportHeader
    {
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

        #region Public Properties

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets the programmer.
        /// </summary>
        public string Programmer { get; set; }

        /// <summary>
        /// Gets or sets the drawing.
        /// </summary>
        public string Drawing { get; set; }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        public string Revision { get; set; }

        /// <summary>
        /// Gets or sets the note one.
        /// </summary>
        public string NoteOne { get; set; }

        /// <summary>
        /// Gets or sets the note two.
        /// </summary>
        public string NoteTwo { get; set; }

        /// <summary>
        /// Gets or sets the note three.
        /// </summary>
        public string NoteThree { get; set; }

        /// <summary>
        /// Gets or sets the report.
        /// </summary>
        public string Report { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether generate automatic images.
        /// </summary>
        public bool GenerateAutomaticImages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether generate automatic operation images.
        /// </summary>
        public bool GenerateAutomaticOperationImages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether generate color images.
        /// </summary>
        public bool GenerateColorImages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether display viewer.
        /// </summary>
        public bool DisplayViewer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether write pdf.
        /// </summary>
        public bool WritePdf { get; set; }

        /// <summary>
        /// Gets or sets the xml.
        /// </summary>
        public string Xml { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public GraphicsView View { get; set; }

        #endregion    
    }
}
