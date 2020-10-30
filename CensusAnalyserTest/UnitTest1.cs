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
        public string wrongIndianStateCensusFileType = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCensusData.txt";
        public string wrongIndianStateCodeFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\WrongIndiaStateCode.csv";
        public string delimiterIndianStateCodeFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\DelimiterIndiaStateCode.csv";
        public string indianStateCensusWrongFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCensus.csv";
        public string indianStateCodeWrongFilePath = @"C:\Users\Kartikeya\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCensus.csv";

        IndiaCensus.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndiaCensus.CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();

        }

        /// <summary>
        /// TC 1.1 : 
        /// Given the states code csv file when read should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecords.Count);
        }

        /// <summary>
        /// TC 1.2 : 
        /// Given the wrong file path of code data should throw custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeDataFile_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeWrongFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianStateCodeResult.exception);
        }

        /// <summary>
        /// TC 1.3 : 
        /// Given the wrong indian code file type should throw custom exceotion.
        /// </summary>
        [Test]
        public void GivenWrongIndianCodeDataFileType_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianStateCodeResult.exception);
        }

        /// <summary>
        /// TC 1.4 : 
        /// Given the state code CSV file when correct but delimeter incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFileWhenCorrectButDelimeterIncorrect_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, indianStateCodeResult.exception);
        }

        /// <summary>
        /// TC 1.5 : 
        /// Given the state code CSV file when correct but CSV header incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFileWhenCorrectButCSVHeaderIncorrect_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, indianStateCodeResult.exception);
        }
    }
}