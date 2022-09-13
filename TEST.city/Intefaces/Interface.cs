using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.city.Intefaces
{
    public interface ICityService
    {
        IEnumerable GetSheetData<T>(string file, int? sheetIndex = 0);
        public IEnumerable<string> GetCityList(string name);
        public IEnumerable<City> GetDataByCity(string name);
    }
}
