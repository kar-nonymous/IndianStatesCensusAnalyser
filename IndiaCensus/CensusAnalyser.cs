using IndiaCensus.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaCensus
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA,
            US
        }
        public Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            datamap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return datamap;
        }
    }
}
