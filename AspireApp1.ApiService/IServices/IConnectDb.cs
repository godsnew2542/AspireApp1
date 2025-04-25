using Model.Entity;

namespace AspireApp1.ApiService.IServices;

public interface IConnectDb
{
    Task<List<ResumeCustomer>> GetAllResumeCustomer();
    Task<ResumeCustomer?> GetResumeCustomerById(string? id);
}
