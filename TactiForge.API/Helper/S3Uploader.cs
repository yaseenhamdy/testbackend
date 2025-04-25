using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using TactiForge.Repository.Data.Context;

public class S3Uploader
{
    // Define the S3 bucket name
    private static readonly string bucketName = "playersimagefifa";
    // Define the local folder path where the images are stored
    private static readonly string folderPath = @"E:\Yassen\images_scraping\player_images_scraping\player_images\"; // المسار الكامل للفولدر المحلي

    // Initialize S3 client with the region
    private static readonly IAmazonS3 s3Client = new AmazonS3Client(RegionEndpoint.EUNorth1);  

    // Main method to upload the folder to S3 and update database
    public static async Task UploadFolderToS3Async()
    {
        var transferUtility = new TransferUtility(s3Client);

        // Get all files from the local folder
        var files = Directory.GetFiles(folderPath);

        foreach (var filePath in files)
        {
            // Get the PlayerId from the file name (without extension)
            var playerId = Path.GetFileNameWithoutExtension(filePath); // اسم الملف بدون الامتداد هو الـ PlayerId
            var fileName = Path.GetFileName(filePath); // اسم الصورة (PlayerId.jpg أو PlayerId.png)
            var keyName = $"images/{fileName}"; // اسم الـ key داخل الـ S3 باستخدام اسم الصورة كـ key

            // Check if the image already exists in S3 to avoid re-uploading it
            bool imageExists = await CheckIfImageExistsAsync(keyName);
            if (imageExists)
            {
                Console.WriteLine($"Player's image {playerId} already exists in S3. It won't be uploaded again.");
                continue; 
            }

            // Upload the image to S3
            await transferUtility.UploadAsync(filePath, bucketName, keyName);

            // Get the URL of the uploaded image
            var url = $"https://{bucketName}.s3.{RegionEndpoint.EUNorth1.SystemName}.amazonaws.com/{keyName}";

            // Save the image URL in the database for the corresponding player
            await SaveFaceUrlToDatabaseAsync(url, playerId); // دالة لتخزين الـ URL في قاعدة البيانات
        }
    }

    // Check if the image already exists in S3
    private static async Task<bool> CheckIfImageExistsAsync(string keyName)
    {
        try
        {
            var request = new GetObjectMetadataRequest
            {
                BucketName = bucketName,
                Key = keyName
            };

            var response = await s3Client.GetObjectMetadataAsync(request);
            return response != null; // If metadata is found, it means the image exists
        }
        catch (AmazonS3Exception e)
        {
            // If the image doesn't exist, it will throw an exception and we return false
            return false;
        }
    }

    // Save the image URL in the database for the corresponding player
    private static async Task SaveFaceUrlToDatabaseAsync(string faceUrl, string playerId)
    {
        // Code to save the face URL in the Player table
        using (var context = new Fifa24DbContext()) // استخدم الـ DbContext الخاص بك
        {
            var player = await context.Players.FirstOrDefaultAsync(p => p.PlayerId.ToString() == playerId); // تحديد الـ Player
            if (player != null)
            {
                player.PlayerFaceUrl = faceUrl; // تخزين الـ URL في العمود PlayerFaceUrl
                await context.SaveChangesAsync(); // حفظ التغييرات في قاعدة البيانات
            }
        }
    }
}
