using AspireApp1.ApiService.IServices;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace AspireApp1.ApiService.Services;

public class ConnectDb(IDbContextFactory<DbModelContext> context) : IConnectDb
{
    public async Task<List<ResumeCustomer>> GetAllResumeCustomer()
    {
        using var dbcontext = await context.CreateDbContextAsync();

        try
        {
            return await dbcontext.ResumeCustomer
                .Select(x => new ResumeCustomer()
                {
                    CusNameTh = x.CusNameTh,
                })
                .Take(500)
                .ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ResumeCustomer?> GetResumeCustomerById(string? id)
    {
        using var dbcontext = await context.CreateDbContextAsync();
        try
        {
            return await dbcontext.ResumeCustomer
                .Where(c => c.CusPid == id)
                .Select(x => new ResumeCustomer()
                {
                    CusNameTh = x.CusNameTh,
                })
                .FirstOrDefaultAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
