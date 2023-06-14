using Microsoft.AspNetCore.Http;


namespace Services.Helpers.Extentions
{
    public static class FileExtention
    {
        public static async Task<byte[]> GetBytes(this IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
