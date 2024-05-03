using Auth.Core.Entities;
using Auth.Infrastructure.DataContext;
using Auth.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories;

public class FileDataRepository : RepositoryBase<FileData> , IFileDataRepository
{
    private readonly AppDbContext _dbContext;

    public FileDataRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async ValueTask<FileData> CreateFileData(FileData fileData)
    {
        await this._dbContext.FileDatas.AddAsync(fileData);
        await this._dbContext.SaveChangesAsync();
        return fileData;
    }

    public async ValueTask<FileData> FindByFileName(string fileName)
    {
        return await this._dbContext.FileDatas.FirstOrDefaultAsync(x => x.FileName == fileName.ToLower());
    }

    public async ValueTask<FileData> FindByFileNameAndBucketName(string fileName, string bucketName)
    {
        return await this._dbContext.FileDatas.FirstOrDefaultAsync(x =>
            x.FileName == fileName.ToLower() && x.BucketName == bucketName.ToLower());
    }

    public async ValueTask<List<string>> FindNamesByBucket(string bucketName)
    {
        return await this._dbContext.FileDatas.Where(x => x.BucketName == bucketName.ToLower()).Select(x => x.FileName)
            .ToListAsync();
    }

    public async ValueTask DeleteFile(FileData fileData)
    {
         this._dbContext.FileDatas.Remove(fileData);
         await this._dbContext.SaveChangesAsync();
    }
}