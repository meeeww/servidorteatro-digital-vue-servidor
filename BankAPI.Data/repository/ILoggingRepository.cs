namespace BankAPI.Data;

public interface ILoggingRepository
{
    void SaveLog(Exception ex);
}