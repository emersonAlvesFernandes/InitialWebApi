using FluentValidation;

namespace InitialWebApi.ViewModels
{
    public class UserCreateViewModel
    {
        public UserCreateViewModel(string name, string cpf, string email)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
        }

        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }

    public class UserCreateViewModelValidator : AbstractValidator<UserCreateViewModel>
    {
        public UserCreateViewModelValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Name).NotEmpty().MinimumLength(11);
            RuleFor(r => r.Email).EmailAddress();
        }        
    }
}
