namespace Auth.Application.Services.Interfaces;

public interface IFileService
{
    ValueTask<bool> BucketExists(string name);
    ValueTask CreateBucket(string name);
    ValueTask UploadFile(string bucketName, string fileName, string fileType, long fileLength, Stream fileStream);
    ValueTask<MemoryStream> DownloadFile(string bucketName, string fileName);
    ValueTask DeleteFile(string bucketName, string fileName);
}