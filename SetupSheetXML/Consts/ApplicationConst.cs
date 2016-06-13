// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationConst.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   Defines the ApplicationConst type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Consts
{
    using System.IO;

    using Mastercam.IO;

    /// <summary>
    /// The application const.
    /// </summary>
    public class ApplicationConst
    {
        #region Constants

        /// <summary>
        /// The header file.
        /// </summary>
        public static readonly string HeaderFile = Path.Combine(SettingsManager.SharedDirectory, "common\\reports\\TMP\\report.txt");

        /// <summary>
        /// The reports folder.
        /// </summary>
        public static readonly string ReportsFolder = Path.Combine(SettingsManager.SharedDirectory, "common\\reports\\SST");

        /// <summary>
        /// The reports filter.
        /// </summary>
        public static readonly string ReportsFilter = "Report (*.rpx)|*.rpx|All files (*.*)|*.*";

        /// <summary>
        /// The default ext.
        /// </summary>
        public static readonly string DefaultExt = "rpx";

        #endregion       
    }
}
