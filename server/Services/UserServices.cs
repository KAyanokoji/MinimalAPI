using System.Data.SqlClient;
using System.Net;
using server.Domain.DTOs;
using server.Domain.Models;
using server.Infrastructure.IRepository;

namespace server.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public UserServices(IUserRepository userRepository, ILogger<IUserServices> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<ApiResponse> GetUsers()
        {
            ApiResponse response = new();
            try
            {
                response.Result = await _userRepository.Users();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "SQL error occurred while getting users");
                response.ErrorMessage = "A database error occurred while retrieving users.";
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting users");
                response.ErrorMessage = "An error occurred while retrieving users.";
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            finally
            {
                _logger.LogInformation("GetUsers method execution finished.");
            }
            return response;
        }

        public  async Task<ApiResponse> CreateUser(UserCreateDto user)
        {
            ApiResponse response = new();
            try
            {
                response.Result = await _userRepository.Create(user);
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.Created;
            }
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, "SQL error occurred while getting users");
                response.ErrorMessage = "A database error occurred while retrieving users.";
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting users");
                response.ErrorMessage = "An error occurred while retrieving users.";
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            finally
            {
                _logger.LogInformation("GetUsers method execution finished.");
            }
            return response;
        }

        public IResult GetUserById(int id)
        {
            var user = _userRepository.User(id);
            if (user == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(user);
        }

        public IResult UpdateUser(int id, UserUpdateDto user)
        {
            var existingUser = _userRepository.User(id);
            if (existingUser == null)
            {
                return Results.NotFound();
            }
            _userRepository.Update(id, user);
            return Results.NoContent();
        }

        public IResult DeleteUser(int id)
        {
            var user = _userRepository.User(id);
            if (user == null)
            {
                return Results.NotFound();
            }
            _userRepository.Delete(id);
            return Results.NoContent();
        }
    }
}
