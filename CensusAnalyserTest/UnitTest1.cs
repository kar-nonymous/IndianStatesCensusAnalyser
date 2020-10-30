using NUnit.Framework;
using IndiaCensus;
using IndiaCensus.DataDAO;
using IndiaCensus.DTO;
using System.Collections.Generic;
using static IndiaCensus.CensusAnalyser;


namespace CensusAnalyserTest
{
    public class Tests
    {
        public string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public string indianStateCensusFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCensusData.csv";
        public string wrongHeaderIndianCensusFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        public string delimiterIndianCensusFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";
        public string indianStateCodeFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCode.csv";
        public string wrongIndianStateCensusFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles";
        public string wrongIndianStateCensusFileType = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCensusData.txt";
        public string wrongIndianStateCodeFileType = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles";
        public string wrongIndianStateCodeFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles";
        public string delimiterIndianStateCodeFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\DelimiterIndiaStateCode.csv";
        public string indianStateCensusWrongFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCensus.csv";

        IndiaCensus.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndiaCensus.CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 1.1 : 
        /// Given the states census csv file when read should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecords.Count);
        }

        /// <summary>
        /// TC 1.2 : 
        /// Given the wrong file path of census data should throw custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCensusDataFile_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusWrongFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianStateCensusResult.exception);
        }

        /// <summary>
        /// TC 1.3 : 
        /// Given the wrong indian census file type should throw custom exceotion.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianStateCensusResult.exception);
        }

        /// <summary>
        /// TC 1.4 : 
        /// Given the state census CSV file when correct but delimeter incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVFileWhenCorrectButDelimeterIncorrect_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, indianStateCensusResult.exception);
        }

        /// <summary>
        /// TC 1.5 : 
        /// Given the state census CSV file when correct but CSV header incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVFileWhenCorrectButCSVHeaderIncorrect_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, indianStateCensusResult.exception);
        }
    }
}