using Model.Entity;

namespace AspireApp1.ApiService.IServices;

public interface IConnectDbService
{
    //Task<List<ResumeCustomer>> GetAllResumeCustomer();
    //Task<ResumeCustomer?> GetResumeCustomerById(string? id);
    //Task<ResumeCustomer?> AddResumeCustomer(ResumeCustomer resumeCustomer);
    //Task UpdateResumeCustomer(ResumeCustomer resumeCustomer);
    //Task<bool> DeleteResumeCustomerById(string? id);

    Task<Assets> AddAssets(Assets assets);
    Task<List<Assets>> GetAllAssets();
    Task<List<Assets>> GetFilterByTableAssets(string? status);
    Task<List<AssetCategories>> GetAllCategories();
    Task<List<Departments>> GetAllDepartments();
    Task<List<Users>> GetAllUsers();
}
