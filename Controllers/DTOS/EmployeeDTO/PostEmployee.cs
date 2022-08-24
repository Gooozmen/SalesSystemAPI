namespace SalesSystemAPI.Controllers.DTOS
{
    public class PostEmployee
    {
        private string name;
        private string lastName;
        private string logOnCredential;
        private string password;
        private string mail;

        public string Name { get; set; }
        public string LastName { get; set; }
        public string LogOnCredential { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
