using System.Data;
using System.Data.SqlClient;

namespace TestTask
{
    class MSSQL
    {
        SqlConnection conn;
        public MSSQL()//Коннектимся к серверу с БД
        {
            conn = new SqlConnection(@"Data Source = NIKITA\SQLEXPRESS;Initial Catalog=TeskTaskBD;Integrated Security=True");
        }

        public void Save(APIreader reader)//Сохранение данных в БД
        {
            int City_id = check("SELECT City_id, Name FROM City", reader.Capital);                          //Проверяем записи о сохранении данного города
            if (City_id != -1)
                Command("INSERT INTO City(City_id, Name) VALUES(" + City_id + ",'" + reader.Capital + "')");//Если данного города нет в БД, то сохраняем его
            else
                City_id = get_id("SELECT City_id, Name FROM City", reader.Capital);                         //Если город есть в БД, то находим его id
            int Region_id = check("SELECT Region_id, Name FROM Region", reader.Region);                     //Аналогично для региона и страны. Кроме поска id страны
            if (Region_id != -1)
                Command("INSERT INTO Region(Region_id, Name) VALUES(" + Region_id + ",'" + reader.Region + "')");
            else
                Region_id = get_id("SELECT Region_id, Name FROM Region", reader.Region);
            int Country_id = check("SELECT Country_id, Name FROM Country", reader.Country);
            if (Country_id != -1)
                Command("INSERT INTO Country(Country_id, Name, CodeName, Capital, Area, Population, Region) " +
                    "VALUES(" + Country_id + ", '" + reader.Country + "', '" + reader.Code + "', " + City_id + ", " + reader.Area + ", " + reader.Population + ", " + Region_id + ")");
            else                                                                                             //Обновляем данные Страны 
            {
                Country_id = get_id("SELECT Country_id, Name FROM Country", reader.Country);
                Command("UPDATE Country " +
                    "SET Name='" + reader.Country + "', CodeName='" + reader.Code + "', Capital=" + City_id + ", Area=" + reader.Area + ", Population=" + reader.Population + ", Region=" + Region_id + " " +
                    "WHERE Country_id=" + Country_id);
            }

        }

        private void Command(string command)//Выполняем команду
        {
            conn.Open();
            SqlCommand city = new SqlCommand(command);
            city.Connection = conn;
            city.ExecuteNonQuery();
            conn.Close();
        }

        private int check(string table, string zapros)//Проверяем наличие данных в БД
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(table);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            int id = -1;
            while (reader.Read())
            {
                if (reader[1].ToString() == zapros)
                {
                    conn.Close();
                    return -1;
                }
                id = (int)reader[0] + 1;
            }
            conn.Close();
            return id;
        }

        private int get_id(string table, string zapros)//Получаем id из БД
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(table);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == zapros)
                {
                    int id = (int)reader[0];
                    conn.Close();
                    return id;
                }
            }
            conn.Close();
            return -1;
        }

        public DataTable Load()//Загрузка отображения из БД
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Country.Name, Country.CodeName, City.Name AS Capital, Country.Area, Country.Population, Region.Name AS Region " +
                "FROM City INNER JOIN Country ON City.City_id = Country.Capital INNER JOIN Region ON Country.Region = Region.Region_id");
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }


    }
}
