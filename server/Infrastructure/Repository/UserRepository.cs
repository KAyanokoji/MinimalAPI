using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Net;
using AutoMapper;
using Dapper;
using FluentValidation;
using Npgsql;
using server.Domain.Data;
using server.Domain.DTOs;
using server.Domain.Models;
using server.Infrastructure.IRepository;

namespace server.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly ILogger<IUserRepository> _logger;
    private readonly IMapper _mapper;
    private readonly IValidator<UserCreateDto> _validator;
    private readonly string _connectionstring;
    public UserRepository(ILogger<IUserRepository> logger, IMapper mapper, IValidator<UserCreateDto> validator, IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _connectionstring = configuration.GetConnectionString("DbConnString");
        _validator = validator;
    }
    #region GET ALL USERS
    public async Task<List<UserDto>> Users()
    {
        List<UserDto> data;
        try
        {
            _logger.Log(LogLevel.Information, "GettingAll User Data");
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionstring))
            {
                conn.Open();
                string query = $@"select * from ""Identity"".""Users"" u; ";
                data = (await conn.QueryAsync<UserDto>(query)).ToList();
            }

        }
        catch (SqlException sqlEx)
        {
            _logger.LogError(sqlEx, "SQL error occurred while getting users");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting users");
            throw;
        }
        finally
        {
            _logger.LogInformation("Users method execution finished.");
        }
        return data;
    }
    #endregion
    public async Task<User> Update(int id, UserUpdateDto request)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse> User(int id)
    {
        ApiResponse response = new();
        UserDto data;
        _logger.Log(LogLevel.Information, "GettingAll User Data");
        using (NpgsqlConnection conn = new NpgsqlConnection(_connectionstring))
        {
            conn.Open();
            string query = $@"select * from ""Identity"".""Users"" u where u.""Id"" = @id; ";
            data = await conn.QueryFirstOrDefaultAsync<UserDto>(query, new { id = id });
        }
        response.Result = data;
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.OK;
        return response;
    }
    #region CREATE USERS
    public async Task<ApiResponse> Create(UserCreateDto request)
    {
        ApiResponse response = new();
         var ValidationResult = await _validator.ValidateAsync(request);
            if (!ValidationResult.IsValid)
            {
                _logger.LogWarning(ValidationResult.Errors.FirstOrDefault()?.ToString());
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessage = ValidationResult.Errors.FirstOrDefault()?.ToString();
                return response;
            }
        try
        {
           
            _logger.Log(LogLevel.Information, "GettingAll User Data");
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionstring))
            {
                conn.Open();

                User userrequest = _mapper.Map<User>(request);
                string insertQuery = @"
                        INSERT INTO ""Identity"".""Users""
                        (""FirstName"", ""MiddleName"", ""LastName"", ""UserName"", ""Email"", ""Phone"", ""Password"",
                         ""Gender"", ""AddressId"", ""Otp"", ""RoleId"", ""CreatedAt"",""Status"")
                        VALUES( @FirstName, @MiddleName, @LastName, @UserName, @Email, @Phone, @Password, @Gender,
                        @AddressId, @Otp, @RoleId, @CreatedAt,@Status)RETURNING *;";
                userrequest.CreatedAt = DateTime.Now;
                userrequest.Otp = GenerateOtp().ToString();
                userrequest.Status = true;
                var result = await conn.QuerySingleOrDefaultAsync<User>(insertQuery, userrequest);
                response.Result = _mapper.Map<UserDto>(result);
                response.StatusCode = HttpStatusCode.Created;
                response.IsSuccess = true;
                return response;
            }
        }
        catch (SqlException sqlEx)
        {
            _logger.LogError(sqlEx, "SQL error occurred while creating user");
            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessage = "A database error occurred while creating the user.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating user");
            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessage = "An error occurred while creating the user.";

        }
        finally
        {
            _logger.LogInformation("Create method execution finished.");
        }
        return response;
    }
    #endregion

    private static int GenerateOtp()
    {
        Random random = new();
        return random.Next(100000, 1000000); // Generates a number between 1000 and 9999
    }
}

