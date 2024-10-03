namespace bienesoft.models
{
    public class loginUser
    {
        [Required(ErrorMessage = "el campo es requerido")]
        public string Email { get; set; }

        public string password { get; set; }

        public int id { get; set; }
    }

    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
    public class ResetPassUser
    {
        public string Email { get; set; }
    }
    public class User
    {

    }
}
