// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerService.cs" company="Mick George @Osoy">
//   Copyright (c) 2016 Mick George developer@seidr.net
// </copyright>
// <summary>
//   Defines the SerializerService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SetupSheetXML.Services
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The serializer service.
    /// </summary>
    public class SerializerService : ISerializerService
    {
       [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
       public bool SerializeObject<T>(string filepath, T o)
        {
            // Avoiding mutliple using's here, see-> CA2202: Do not dispose objects multiple times
            XmlWriter xmlWriter = null;
            try
            {
                using (
                    xmlWriter =
                    XmlWriter.Create(
                        filepath,
                        new XmlWriterSettings { Encoding = Encoding.UTF8, CloseOutput = false, Indent = true }))
                {
                    var serializer = new XmlSerializer(o.GetType());
                    serializer.Serialize(xmlWriter, o);
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                xmlWriter?.Dispose();
            }

            return true;
        }

        /// <summary>De-serializes an object from file.</summary>
        /// <param name="filepath">The filepath to the file location.</param>
        /// <typeparam name="T">The object type</typeparam>
        /// <returns>The <see cref="T"/> object type to return.</returns>
        public T DeserializeObject<T>(string filepath)
        {
            XmlReader xmlReader = null;
            try
            {
                using (xmlReader = XmlReader.Create(filepath))
                {
                    var xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(xmlReader);
                }
            }
            finally
            {
                xmlReader?.Dispose();
            }
        }
    }
}
