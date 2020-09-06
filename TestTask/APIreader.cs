using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TestTask
{
    class APIreader
    {
        private string countryName;
        public string country;
        public string code;
        public string capital;
        public string area;
        public string population;
        public string region;
        public string[] allData;

        public APIreader(string inputCountryName)
        {
            countryName = inputCountryName;
            FillingInData();
        }

        public bool CheckNewCountry(string newCountry)
        {
            return newCountry != countryName;
        }

        private void FillingInData()
        {
            //Пробуем запросить данные и сохраняем их 
            try
            {
                country = ApiSearch("name");
                code = ApiSearch("alpha2Code");
                capital = ApiSearch("capital");
                area = ApiSearch("area");
                population = ApiSearch("population");
                region = ApiSearch("region");
                allData = new string[] 
                {
                    "Название страны: " + country,
                    "Код страны: " + code,
                    "Столица: " + capital,
                    "Площадь: " + area,
                    "Население: " + population,
                    "Регион: " + region
                };
            }
            //Если данные не найдены или таких данных нет, то сообщаем об ошибке 
            catch
            {
                allData = new string[] { "Данной страны не существует" };
            }
        }

        private string ApiSearch(string field)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://restcountries.eu/rest/v2/name/" + countryName + "?fields=" + field);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            return Regex.Replace(reader.ReadToEnd().Split(new char[] {':',','}, StringSplitOptions.RemoveEmptyEntries)[1], "[^ a-zA-Z0-9.]", "");
        }
    }
}
