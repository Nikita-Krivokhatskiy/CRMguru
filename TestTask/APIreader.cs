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
        public APIreader(string name)
        {
            Country_name = name;
            spisok();
        }

        public bool NewCountry(string name)
        {
            if (name == Country_name)
                return false;
            else
                return true;
        }

        private void spisok()
        {
            try//Пробуем запросить данные и сохраняем их 
            {
                Country = read("name");
                Code = read("alpha2Code");
                Capital = read("capital");
                Area = read("area");
                Population = read("population");
                Region = read("region");
                All = new string[] { "Название страны: " + Country, "Код страны: " + Code, "Столица: " + Capital, "Площадь: " + Area, "Население: " + Population, "Регион: " + Region };
            }
            catch (Exception)//Если данные не найдены или таких данных нет, то сообщаем об ошибке 
            {
                All = new string[] { "Данной страны не существует" };
            }
        }

        private string read(string zapros)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://restcountries.eu/rest/v2/name/" + Country_name + "?fields=" + zapros);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string otvet = Regex.Replace(reader.ReadToEnd().Split(new char[] {':',','}, StringSplitOptions.RemoveEmptyEntries)[1], "[^ a-zA-Z0-9.]", "");
            return otvet;
        }
    }
}
