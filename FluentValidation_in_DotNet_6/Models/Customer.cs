using FluentValidation_in_DotNet_6.Enums;

namespace FluentValidation_in_DotNet_6.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age {  get; set; }
        public string Url { get; set; }
        public Status.StatusTypes Status { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string CreditCard { get; set; }
    }
}
