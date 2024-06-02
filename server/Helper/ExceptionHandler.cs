namespace system.Helper;

using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

public class ExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task<T> Execute<T>(Func<Task<T>> action)
    {
        try
        {
            return await action.Invoke();
        }
        catch (SEHException ex)
        {
            _logger.LogError(ex, "A SQL error occurred");
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message ?? (ex.InnerException != null ? ex.InnerException.Message : ""));
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
    }

    public T Execute<T>(Func<T> action)
    {
        try
        {
            return action.Invoke();
        }
        catch (XmlException ex)
        {
            _logger.LogError(ex, "A SQL error occurred");
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message ?? (ex.InnerException != null ? ex.InnerException.Message : ""));
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
    }

    public void Execute(Action action)
    {
        try
        {
            action.Invoke();
        }
        catch (SEHException ex)
        {
            _logger.LogError(ex, "A SQL error occurred");
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message ?? (ex.InnerException != null ? ex.InnerException.Message : ""));
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
    }

    public void ExecuteWithFinally(Action action, Action finallyAction)
    {
        try
        {
            action.Invoke();
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "A SQL error occurred");
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message ?? (ex.InnerException != null ? ex.InnerException.Message : ""));
            throw; // Re-throw the exception to allow it to be handled further up the call stack
        }
        finally
        {
            try
            {
                finallyAction.Invoke();
            }
            catch (Exception finallyEx)
            {
                _logger.LogError(finallyEx, "An error occurred in the finally block");
                // Optionally, handle or log the error in the finally block
            }
        }
    }
}

