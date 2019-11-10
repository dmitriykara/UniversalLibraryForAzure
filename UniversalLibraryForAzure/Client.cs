namespace UniversalLibraryForAzure
{
    public class Client
    {
        private readonly int id;
        private readonly string surname;
        private readonly string name;
        private readonly string secondname;
        private readonly string email;
        private readonly string password;

        public int Id => id;
        public string Surname => surname;
        public string Name => name;
        public string Secondname => secondname;
        public string Email => email;
        public string Password => password;

        public Client()
        {
            id = 0;
            surname = "";
            name = "";
            secondname = "";
            email = "";
            password = "";
        }

        public Client(int id, string surname, string name,
            string secondname, string email, string password)
        {
            this.id = 0;
            this.surname = surname;
            this.name = name;
            this.secondname = secondname;
            this.email = email;
            this.password = password;
        }

        public override string ToString()
        {
            return $"id = {Id}\nSurname = {Surname}\nName = {Name}\nSecondname = {Secondname}\nEmail = {Email}";
        }
    }
}
