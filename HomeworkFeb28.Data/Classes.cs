using System.Data.SqlClient;

namespace HomeworkFeb28.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PeopleDbMngr
    {
        private readonly string _connectionString;

        public PeopleDbMngr(string connectionString)
        {
            _connectionString = connectionString;
        }  
        
        public List<Person> GetAllPeople()
        {
            using SqlConnection connection = new(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from PeopleInfo";

            List<Person> people = new List<Person>();

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                people.Add(new Person()
                {
                    Id = (int)reader["ID"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }
        public void AddPeople(List<Person> people)
        {
            using SqlConnection connection = new(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"insert into PeopleInfo
                                values (@firstName, @lastName, @age)";

            connection.Open();

            foreach (Person person in people)
            {
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }
    }

}