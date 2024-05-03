using Auth.Application.Services.Interfaces;

namespace Auth.Application.Services;

public class FileService : IFileService
{
    public async ValueTask<bool> BucketExists(string name)
    {
        throw new NotImplementedException();
    }

    public async ValueTask CreateBucket(string name)
    {
        throw new NotImplementedException();
    }

    public async ValueTask UploadFile(string bucketName, string fileName, string fileType, long fileLength, Stream fileStream)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<MemoryStream> DownloadFile(string bucketName, string fileName)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DeleteFile(string bucketName, string fileName)
    {
        throw new NotImplementedException();
    }
}