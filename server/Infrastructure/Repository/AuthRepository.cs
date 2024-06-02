using System.Net;
using FluentValidation;
using server.Domain.Data;
using server.Domain.Models;
using server.Domain.Validations;
using server.Infrastructure.IRepository;

namespace server.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IValidator<Login> _validator;
        public AuthRepository(IValidator<Login> validator)
        {
            _validator = validator;
        }
        public async Task<ApiResponse> Login(Login login)
        {
            ApiResponse response = new();
            var ValidationResult = await _validator.ValidateAsync(login);
            if (!ValidationResult.IsValid)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ValidationResult.Errors.FirstOrDefault()?.ToString();
                return response;
            }
            if (UserStore.UserList.FirstOrDefault(u => u.UserName.ToLower() == login.UserName.ToLower()) != null)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = "UserName already exists";
                return response;
            }

            response.IsSuccess= true;
            response.StatusCode=HttpStatusCode.OK;
            response.Result= login;
            return response;

            throw new NotImplementedException();
        }
    }

}