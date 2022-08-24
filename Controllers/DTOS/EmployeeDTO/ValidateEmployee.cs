namespace SalesSystemAPI.Controllers.DTOS
{
    public class ValidateEmployee
    {
        private string logOnCredential;
        private string password;

        public string LogOnCredential { get; set; }
        public string Password { get; set; }
    }
}
