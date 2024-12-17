namespace OrderFlow.Entities
{
    class Client
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public Client(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}