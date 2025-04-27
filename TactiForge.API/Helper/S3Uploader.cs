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

        var files = Directory.GetFiles(folderPath);
        Console.WriteLine($"Total files found: {files.Length}");

        foreach (var filePath in files)
        {
            var playerId = Path.GetFileNameWithoutExtension(filePath);
            var fileName = Path.GetFileName(filePath);
            var keyName = $"images/{fileName}";

            // Check if the image already exists in S3
            bool imageExists = await CheckIfImageExistsAsync(keyName);
            if (imageExists)
            {
                Console.WriteLine($"[SKIP] Image for PlayerId {playerId} already exists in S3.");
                continue;
            }

            Console.WriteLine($"[UPLOAD] Uploading image for PlayerId {playerId}...");

            // Upload the image to S3
            await transferUtility.UploadAsync(filePath, bucketName, keyName);

            Console.WriteLine($"[SUCCESS] Image uploaded for PlayerId {playerId}.");

            // Get the URL of the uploaded image
            var url = $"https://{bucketName}.s3.{RegionEndpoint.EUNorth1.SystemName}.amazonaws.com/{keyName}";

            // Save the image URL in the database for the corresponding player
            await SaveFaceUrlToDatabaseAsync(url, playerId);
        }

        Console.WriteLine("All uploads finished ✅");
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
        using (var context = new Fifa24DbContext())
        {
            var player = await context.Players.FirstOrDefaultAsync(p => p.PlayerId.ToString() == playerId);
            if (player != null)
            {
                player.PlayerFaceUrl = faceUrl;
                await context.SaveChangesAsync();
                Console.WriteLine($"[DB] Updated PlayerFaceUrl for PlayerId {playerId}.");
            }
            else
            {
                Console.WriteLine($"[DB] PlayerId {playerId} not found in database ❗");
            }
        }
    }
}
