using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TPDev.SimpleReport.Logger.Models;

namespace TPDev.SimpleReport.SharedLibrary.Services.Helper
{
    public class XmlHelper
    {
        private string m_Path { get; set; }
        public XmlHelper(string xmlPath)
        {
            if (!Directory.Exists(xmlPath))
                Directory.CreateDirectory(xmlPath);

            m_Path = xmlPath;
        }

        public void Write<T>(T data, string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                TextWriter WriteFileStream = new StreamWriter(Path.Combine(m_Path, fileName));
                serializer.Serialize(WriteFileStream, data);

                // Cleanup
                WriteFileStream.Close();
            }
            catch (Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {                
                    Type = LogType.Error,
                    Source = ToString(),
                    FunctionName = "Write Error!",
                    Ex = ex,
                });
            }
        }

        public T Read<T>(string fileName)
        {
            try
            {
                if (!File.Exists(Path.Combine(m_Path, fileName))) return default(T);
                var serializer = new XmlSerializer(typeof(T));

                TextReader ReadFileStream = new StreamReader(Path.Combine(m_Path, fileName));
                var result = serializer.Deserialize(ReadFileStream);

                ReadFileStream.Close();
                return (T)result;
            }
            catch (Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = ToString(),
                    FunctionName = "Read Error!",
                    Ex = ex,
                });
            }

            return default(T);
        }

        public static string WriteToString<T>(T value)
        {
            try
            {
                if (value == null) return null;

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = new UnicodeEncoding(false, false);
                settings.Indent = false;
                settings.OmitXmlDeclaration = false;

                using (StringWriter textWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        serializer.Serialize(xmlWriter, value);
                    }
                    return textWriter.ToString();
                }
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "XmlHelper",
                    FunctionName = "WriteToString Error!",
                    Ex = ex,
                });
            }

            return null;
        }

        public static T ReadFromString<T>(string xml)
        {
            try
            {
                if (string.IsNullOrEmpty(xml)) return default(T);

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlReaderSettings settings = new XmlReaderSettings();

                using (StringReader textReader = new StringReader(xml))
                {
                    using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                    {
                        return (T)serializer.Deserialize(xmlReader);
                    }
                }
            }
            catch(Exception ex)
            {
                SLLog.Logger.WriteError(new LogData
                {
                    Type = LogType.Error,
                    Source = "XmlHelper",
                    FunctionName = "ReadFromString Error!",
                    Ex = ex,
                });
            }

            return default(T);
        }
    }
}
