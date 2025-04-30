using AspireApp1.ApiService.IServices;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace AspireApp1.ApiService.Services;

public class ConnectDbService(IDbContextFactory<DbModelContext> context) : IConnectDbService
{

    public async Task<Assets> AddAssets(Assets assets)
    {
        using var dbcontext = await context.CreateDbContextAsync();
        using var trans = await dbcontext.Database.BeginTransactionAsync();

        try
        {
            await dbcontext.Assets.AddRangeAsync(assets);
            await dbcontext.SaveChangesAsync();
            await trans.CommitAsync();
            return assets;
        }
        catch (Exception)
        {
            await trans.RollbackAsync();
            throw;
        }
    }

    public async Task<List<Assets>> GetAllAssets()
    {
        using var dbcontext = await context.CreateDbContextAsync();

        try
        {
            return await dbcontext.Assets.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Assets>> GetFilterByTableAssets(string? status)
    {
        using var dbcontext = await context.CreateDbContextAsync();

        try
        {
            IQueryable<Assets> query = dbcontext.Assets.OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(x => x.Status == status);
            }

            return await query.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<AssetCategories>> GetAllCategories()
    {
        using var dbcontext = await context.CreateDbContextAsync();

        try
        {
            return await dbcontext.AssetCategories.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Departments>> GetAllDepartments()
    {
        using var dbcontext = await context.CreateDbContextAsync();

        try
        {
            return await dbcontext.Departments.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Users>> GetAllUsers()
    {
        using var dbcontext = await context.CreateDbContextAsync();

        try
        {
            return await dbcontext.Users.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //public async Task<List<ResumeCustomer>> GetAllResumeCustomer()
    //{
    //    using var dbcontext = await context.CreateDbContextAsync();

    //    try
    //    {
    //        return await dbcontext.ResumeCustomer
    //            .Select(x => new ResumeCustomer()
    //            {
    //                CusNameTh = x.CusNameTh,
    //            })
    //            .OrderBy(x => x.CusNameTh)
    //            .ThenBy(x => x.CusPid)
    //            .Take(500)
    //            .ToListAsync();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    //public async Task<ResumeCustomer?> GetResumeCustomerById(string? id)
    //{
    //    using var dbcontext = await context.CreateDbContextAsync();
    //    try
    //    {
    //        return await dbcontext.ResumeCustomer
    //            .Where(c => c.CusPid == id)
    //            .Select(x => new ResumeCustomer()
    //            {
    //                CusNameTh = x.CusNameTh,
    //            })
    //            .FirstOrDefaultAsync();
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    //public async Task<ResumeCustomer?> AddResumeCustomer(ResumeCustomer resumeCustomer)
    //{
    //    using var dbcontext = await context.CreateDbContextAsync();
    //    using var trans = await dbcontext.Database.BeginTransactionAsync();

    //    try
    //    {
    //        await dbcontext.ResumeCustomer.AddRangeAsync(resumeCustomer);
    //        await dbcontext.SaveChangesAsync();
    //        await trans.CommitAsync();
    //        return resumeCustomer;
    //    }
    //    catch (Exception)
    //    {
    //        await trans.RollbackAsync();
    //        throw;
    //    }
    //}

    //public async Task UpdateResumeCustomer(ResumeCustomer resumeCustomer)
    //{
    //    using var dbcontext = await context.CreateDbContextAsync();
    //    using var trans = await dbcontext.Database.BeginTransactionAsync();

    //    try
    //    {
    //        dbcontext.ResumeCustomer.Update(resumeCustomer);
    //        await dbcontext.SaveChangesAsync();
    //        await trans.CommitAsync();
    //    }
    //    catch (Exception)
    //    {
    //        await trans.RollbackAsync();
    //        throw;
    //    }
    //}

    //public async Task<bool> DeleteResumeCustomerById(string? id)
    //{
    //    using var dbcontext = await context.CreateDbContextAsync();
    //    using var trans = await dbcontext.Database.BeginTransactionAsync();

    //    try
    //    {
    //        ResumeCustomer? temp = await dbcontext.ResumeCustomer
    //            .Where(c => c.CusPid == id)
    //            .FirstOrDefaultAsync();
    //        if (temp == null)
    //        {
    //            return false;
    //        }

    //        dbcontext.ResumeCustomer.RemoveRange(temp);
    //        await dbcontext.SaveChangesAsync();
    //        await trans.CommitAsync();
    //        return true;
    //    }
    //    catch (Exception)
    //    {
    //        await trans.RollbackAsync();
    //        throw;
    //    }
    //}
}
