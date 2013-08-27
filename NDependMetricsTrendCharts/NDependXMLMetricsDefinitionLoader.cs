﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace NDependMetricsTrendCharts
{
    class NDependXMLMetricsDefinitionLoader
    {
        string pathToXMLMetrics;

        public NDependXMLMetricsDefinitionLoader()
        {
            this.pathToXMLMetrics = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\XMLMetricDefinitions\";
        }

        public List<NDependMetricDefinition> LoadMetricsDefinitions(string xmlMetricsDefinitionFile)
        {
            return DeseralizeMetricsList(this.pathToXMLMetrics + xmlMetricsDefinitionFile);
        }

        private List<NDependMetricDefinition> DeseralizeMetricsList(string filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<NDependMetricDefinition>));
            TextReader textReader = new StreamReader(filePath);
            List<NDependMetricDefinition> metricsList;
            metricsList = (List<NDependMetricDefinition>)deserializer.Deserialize(textReader);
            textReader.Close();
            return metricsList;
        }

    }
}
