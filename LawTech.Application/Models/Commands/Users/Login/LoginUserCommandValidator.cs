using FluentValidation;

namespace LawTech.Application.Models.Commands.Users.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
        }
    }
}
