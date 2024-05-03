using Auth.Core.Entities;

namespace Auth.Infrastructure.Repositories.Interfaces;

public interface IFileDataRepository : IRepositoryBase<FileData>
{
    ValueTask<FileData> CreateFileData(FileData fileData);
    ValueTask<FileData> FindByFileName(string fileName);
    ValueTask<FileData> FindByFileNameAndBucketName(string fileName, string bucketName);
    ValueTask<List<string>> FindNamesByBucket(string bucketName);
    ValueTask DeleteFile(FileData fileData);
}