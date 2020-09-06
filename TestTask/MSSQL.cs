using System.Data;
using System.Data.SqlClient;
using TestTask.Properties;

namespace TestTask
{
    class MSSQL
    {
        SqlConnection connectionDB;
        public MSSQL()
        {
            connectionDB = new SqlConnection(Settings.Default.TeskTaskBDConnectionString);
        }

        public bool Save(APIreader reader)
        {
            bool saveOut = false;
            //Пробуем сохранить данные в БД
            try
            {
                if (reader.allData.Length > 1)
                {
                    int cityId = SaveInBD("SELECT City_id, Name FROM City", reader.capital,
                        "INSERT INTO City(City_id, Name) VALUES(", ", '" + reader.capital + "')");
                    int regionId = SaveInBD("SELECT Region_id, Name FROM Region", reader.region,
                        "INSERT INTO Region(Region_id, Name) VALUES(", reader.region);
                    int countryId = SaveInBD("SELECT Country_id, Name FROM Country", reader.country,
                        "INSERT INTO Country(Country_id, Name) VALUES(", ", '" + reader.country + "')");
                    Query("UPDATE Country " +
                        "SET Name='" + reader.country + 
                        "', CodeName='" + reader.code + 
                        "', Capital=" + cityId + 
                        ", Area=" + reader.area + 
                        ", Population=" + reader.population + 
                        ", Region=" + regionId + " " +
                        "WHERE Country_id=" + countryId);
                    saveOut = true;
                }
            }
            catch
            {
                saveOut = false;
                connectionDB.Close();
            }
            return saveOut;
        }

        private int SaveInBD(string select, string searchName, string insert, string data)
        {
            //Проверяем записи о сохранении
            //Если данных нет в БД, то сохраняем их
            //Если данные есть в БД, то возвращаем их id
            int id = 1;
            bool existInDB = false;
            connectionDB.Open();
            SqlCommand command = new SqlCommand(select) { Connection = connectionDB };
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == searchName)
                {
                    id = (int)reader[0];
                    existInDB = true;
                    break;
                }
                id = (int)reader[0] + 1;
            }
            connectionDB.Close();
            if (!existInDB)
                Query(insert + id + data);
            return id;
        }

        private void Query(string sqlOperator)
        {
            connectionDB.Open();
            SqlCommand command = new SqlCommand(sqlOperator) { Connection = connectionDB };
            command.ExecuteNonQuery();
            connectionDB.Close();
        }

        public DataTable Load()
        {
            connectionDB.Open();
            SqlCommand command = new SqlCommand("SELECT Country.Name, Country.CodeName, City.Name AS Capital, Country.Area, Country.Population, Region.Name AS Region " +
                "FROM City INNER JOIN Country ON City.City_id = Country.Capital INNER JOIN Region ON Country.Region = Region.Region_id") { Connection = connectionDB };
            command.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            connectionDB.Close();
            return dataTable;
        }


    }
}
