namespace ITISystem.Utilities
{
    public class DocumentSettings
    {
        public static async Task<string> UploadFile(IFormFile file)
        {
            string filename = $"{Guid.NewGuid()}.{file.FileName.Split('.').Last()}";
            using (FileStream f = new FileStream($"wwwroot/Images/{filename}", FileMode.Create))
            {
                await file.CopyToAsync(f);
            }
            return filename ;
        }
    }
}
