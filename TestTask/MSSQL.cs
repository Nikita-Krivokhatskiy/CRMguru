using System.Data;
using System.Data.SqlClient;
using TestTask.Properties;

namespace TestTask
{
    class MSSQL
    {
        SqlConnection BDConnection;
        public MSSQL()
        {
            BDConnection = new SqlConnection(Settings.Default.TeskTaskBDConnectionString);
        }

        public string Save(APIreader Reader)
        {
            string SaveOut = "";
            //Проверяем записи о сохранении данного города
            //Если данного города нет в БД, то сохраняем его
            //Если город есть в БД, то находим его id
            //Аналогично для региона и страны. Кроме поска id страны
            int City_id = СheckInBD("SELECT City_id, Name FROM City", Reader.Capital);                          
            if (City_id != -1)
                Query("INSERT INTO City(City_id, Name) VALUES(" + City_id + ",'" + Reader.Capital + "')");
            else
                City_id = GetIdFromBD("SELECT City_id, Name FROM City", Reader.Capital);                         
            int Region_id = СheckInBD("SELECT Region_id, Name FROM Region", Reader.Region);                     
            if (Region_id != -1)
                Query("INSERT INTO Region(Region_id, Name) VALUES(" + Region_id + ",'" + Reader.Region + "')");
            else
                Region_id = GetIdFromBD("SELECT Region_id, Name FROM Region", Reader.Region);
            int Country_id = СheckInBD("SELECT Country_id, Name FROM Country", Reader.Country);
            if (Country_id != -1)
            {
                Query("INSERT INTO Country(Country_id, Name, CodeName, Capital, Area, Population, Region) " +
                    "VALUES(" + Country_id + ", '" + Reader.Country + "', '" + Reader.Code + "', " + City_id + ", " + Reader.Area + ", " + Reader.Population + ", " + Region_id + ")");
                SaveOut = "Успешно сохранено";
            }
            else
            //Обновляем данные Страны
            {
                Country_id = GetIdFromBD("SELECT Country_id, Name FROM Country", Reader.Country);
                Query("UPDATE Country " +
                    "SET Name='" + Reader.Country + "', CodeName='" + Reader.Code + "', Capital=" + City_id + ", Area=" + Reader.Area + ", Population=" + Reader.Population + ", Region=" + Region_id + " " +
                    "WHERE Country_id=" + Country_id);
                SaveOut = "Успешно обновлено";
            }
            return SaveOut;
        }

        private void Query(string Operator)
        {
            BDConnection.Open();
            SqlCommand Command = new SqlCommand(Operator) { Connection = BDConnection };
            Command.ExecuteNonQuery();
            BDConnection.Close();
        }

        private int СheckInBD(string Operator, string SearchName)
        {
            BDConnection.Open();
            SqlCommand Command = new SqlCommand(Operator) { Connection = BDConnection };
            SqlDataReader Reader = Command.ExecuteReader();
            int id = -1;
            while (Reader.Read())
            {
                if (Reader[1].ToString() == SearchName)
                {
                    BDConnection.Close();
                    return -1;
                }
                id = (int)Reader[0] + 1;
            }
            BDConnection.Close();
            return id;
        }

        private int GetIdFromBD(string Operator, string SearchName)
        {
            BDConnection.Open();
            SqlCommand Command = new SqlCommand(Operator) { Connection = BDConnection };
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader[1].ToString() == SearchName)
                {
                    int id = (int)Reader[0];
                    BDConnection.Close();
                    return id;
                }
            }
            BDConnection.Close();
            return -1;
        }

        public DataTable Load()
        {
            BDConnection.Open();
            SqlCommand Command = new SqlCommand("SELECT Country.Name, Country.CodeName, City.Name AS Capital, Country.Area, Country.Population, Region.Name AS Region " +
                "FROM City INNER JOIN Country ON City.City_id = Country.Capital INNER JOIN Region ON Country.Region = Region.Region_id") { Connection = BDConnection };
            Command.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
            dataAdapter.Fill(dataTable);
            BDConnection.Close();
            return dataTable;
        }


    }
}
