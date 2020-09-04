using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TestTask
{
    class APIreader
    {
        public string Country;
        private string Country_name;
        public string Code;
        public string Capital;
        public string Area;
        public string Population;
        public string Region;
        public string[] All;
        public APIreader(string CountryName)
        {
            Country_name = CountryName;
            FillingInData();
        }

        public bool CheckNewCountry(string NewCountry)
        {
            if (NewCountry == Country_name)
                return false;
            else
                return true;
        }

        private void FillingInData()
        {
            try//Пробуем запросить данные и сохраняем их 
            {
                Country = ApiSearch("name");
                Code = ApiSearch("alpha2Code");
                Capital = ApiSearch("capital");
                Area = ApiSearch("area");
                Population = ApiSearch("population");
                Region = ApiSearch("region");
                All = new string[] { "Название страны: " + Country, "Код страны: " + Code, "Столица: " + Capital, "Площадь: " + Area, "Население: " + Population, "Регион: " + Region };
            }
            catch (Exception)//Если данные не найдены или таких данных нет, то сообщаем об ошибке 
            {
                All = new string[] { "Данной страны не существует" };
            }
        }

        private string ApiSearch(string Field)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://restcountries.eu/rest/v2/name/" + Country_name + "?fields=" + Field);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            return Regex.Replace(reader.ReadToEnd().Split(new char[] {':',','}, StringSplitOptions.RemoveEmptyEntries)[1], "[^ a-zA-Z0-9.]", "");
        }
    }
}
