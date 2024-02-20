using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services;

public class LogginService
{
    private readonly ILoggingRepository _loggingRepository;

    public LogginService(ILoggingRepository loggingRepository)
    {
        _loggingRepository = loggingRepository;
    }

    void SaveLog(Exception ex)
    {
        _loggingRepository.SaveLog(ex);
    }

}