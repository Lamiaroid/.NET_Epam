using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace NET.S._2019.Tkachenko._18
{
    public class UrlDataExporter
    {
        private string _logFilePath = Directory.GetCurrentDirectory() + "Errors.log";
        private string _resultFilePath = Directory.GetCurrentDirectory() + "URLs.xml";       

        XmlElement parameters;
        XmlElement uri;
        XmlElement urlAddress;
        XmlElement urlAddresses;
        XmlDocument xDoc;

        public UrlDataExporter()
        {
            xDoc = new XmlDocument();
            urlAddresses = xDoc.CreateElement("urlAddresses");           
        }

        /// <summary>
        /// Exports data from file to xml document
        /// </summary>
        /// <param name="fileName">File with data for export</param>
        public void ExportData(string fileName)
        {          
            Regex urlAddressPattern = new Regex(@"^http[s]{0,1}:\/\/([^?\/]+(\/)?){1,}((?<=\/)[^\?\/\=\&]+\?([^\?\/\=\&]+=[^\?\/\=\&]+(&[^\?\/\=]+=[^\?\/\=\&]+){0,}){0,1}[\/]{0,1}){0,1}$");
            Regex partWithoutParamsPattern = new Regex(@"(?<=\/).+?(?=\/|$)");
            Regex partWithParamsPattern = new Regex(@"(.+)(\?)(.+)(?=\/|$)");
            Regex extraParamsPattern = new Regex(@"([^=&]+)(=)([^=&]+)");

            string fileDataString = "";
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (sr.Peek() != -1)
                    {
                        fileDataString = sr.ReadLine();
                        if (urlAddressPattern.IsMatch(fileDataString))
                        {
                            urlAddress = xDoc.CreateElement("urlAddress");

                            bool firstParameters = true;
                            bool firstTime = true;  
                            bool firstUri = true;                       

                            foreach (Match foundPartsWithoutParams in partWithoutParamsPattern.Matches(fileDataString))
                            {
                                if (firstTime)
                                {
                                    CreateNewHost(foundPartsWithoutParams.ToString(), ref firstTime);
                                }
                                else
                                {
                                    if (!partWithParamsPattern.IsMatch(foundPartsWithoutParams.ToString()))
                                    {
                                        CreateNewSegment(foundPartsWithoutParams.ToString(), ref firstUri);
                                    }
                                    else
                                    {
                                        foreach (Match foundPartsWithParams in partWithParamsPattern.Matches(foundPartsWithoutParams.ToString()))
                                        {
                                            CreateNewSegment(foundPartsWithParams.Groups[1].ToString(), ref firstUri);
                                            foreach (Match foundExtraParams in extraParamsPattern.Matches(foundPartsWithParams.Groups[3].Value))
                                            {
                                                CreateNewParam(foundExtraParams.Groups[1].ToString(), foundExtraParams.Groups[3].ToString(), ref firstParameters);
                                            }
                                        }
                                    }
                                }
                            }
                            urlAddresses.AppendChild(urlAddress);
                        }
                        else
                        {
                            Log(fileDataString);
                        }
                    }

                    xDoc.AppendChild(urlAddresses);
                    WriteToFile(xDoc);
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        // Creates new <host> element
        private void CreateNewHost(string hostValue, ref bool firstTime)
        {
            XmlElement host = xDoc.CreateElement("host");
            hostValue = hostValue.Remove(0, 1);
            host.SetAttribute("name", hostValue);
            urlAddress.AppendChild(host);
            firstTime = false;
        }

        // Creates new <segment> element
        private void CreateNewSegment(string segmentValue, ref bool firstUri)
        {
            if (firstUri)
            {
                uri = xDoc.CreateElement("uri");
                firstUri = false;
            }

            XmlElement segment = xDoc.CreateElement("segment");
            segment.InnerText = segmentValue;
            uri.AppendChild(segment);
            urlAddress.AppendChild(uri);
        }

        // Creates new <parametr> element
        private void CreateNewParam(string paramKey, string paramValue, ref bool firstParameters)
        {
            if (firstParameters)
            {
                parameters = xDoc.CreateElement("parameters");
                firstParameters = false;
            }

            XmlElement parametr = xDoc.CreateElement("parametr");
            parametr.SetAttribute("key", paramKey);
            parametr.SetAttribute("value", paramValue);
            parameters.AppendChild(parametr);
            urlAddress.AppendChild(parameters);
        }

        // Writes exported data to file
        private void WriteToFile(XmlDocument xDoc)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlElement));

            try
            {
                using (TextWriter tw = new StreamWriter(_resultFilePath))
                {
                    serializer.Serialize(tw, xDoc);
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        // Logs errors
        private void Log(string problemString)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(_logFilePath, FileMode.Append)))
                {
                    sw.WriteLine($"[ERROR] Couldn't export data from string: {problemString}");
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }
    }
}