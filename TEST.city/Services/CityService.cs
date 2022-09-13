using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using TEST.city.Intefaces;

namespace TEST.city.Services
{
    public class CityService : ICityService
    {
        private string _fileName= @"C:\Users\rivkab\source\repos\TEST.city\TEST.city\Resources\world-cities_csv.csv";
        public IEnumerable GetSheetData<T>(string file, int? sheetIndex = 0)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(file, FileMode.Open, FileAccess.Read))
            {
                var reader = ExcelReaderFactory.CreateCsvReader(stream);
                return reader.AsDataSet().Tables[sheetIndex.Value].AsEnumerable().Cast<DataRow>().Skip(1);
            }
        }

        public IEnumerable<string> GetCityList(string name)
        {
            var data = GetSheetData<DataTable>(_fileName);
            return data.Cast<DataRow>().Select(p => p.ItemArray[0].ToString()).Where(p => p.Contains(name)).OrderBy(p => p).Distinct().ToList();
        }

        public IEnumerable<City> GetDataByCity(string name)
        {
            var data = GetSheetData<DataTable>(_fileName);
            return data.Cast<DataRow>().Select(p => new City { Name = p.ItemArray[0].ToString(), Country = p.ItemArray[1].ToString(), Subcountry = p.ItemArray[2].ToString(), Geonameid = p.ItemArray[3].ToString() }).Where(p => p.Name.Equals(name)).OrderBy(p => p).ToList();
        }
    }
}
