using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using TactiForge.Repository.Data.Context;


namespace TactiForge.API.Helper
{
    public static class ImageSeeding
    {
        //public static async Task Run(IServiceProvider services)
        //{
        //    var env = services.GetRequiredService<IWebHostEnvironment>();
        //    var db = services.GetRequiredService<Fifa24DbContext>();

        //    // لو كل اللاعبين PlayerFaceUrl مش فاضي ⇒ خلاص
        //    if (!db.Players.Any(p => p.PlayerFaceUrl == null))
        //        return;

        //    var sourceDir = @"E:\Yassen\images_scraping\player_images_scraping\player_images\";  // غيّر للمسار اللي عندك
        //    var destDir = Path.Combine(env.WebRootPath, "images", "players");
        //    Directory.CreateDirectory(destDir);

        //    foreach (var p in db.Players.AsNoTracking().ToList())
        //    {
        //        var fileName = $"{p.PlayerId}.png";  // استخدام player_id بدلاً من Id
        //        var src = Path.Combine(sourceDir, fileName);
        //        var dst = Path.Combine(destDir, fileName);

        //        if (!File.Exists(src)) continue;

        //        File.Copy(src, dst, overwrite: true);

        //        db.Players
        //          .Where(x => x.PlayerId == p.PlayerId)  // استخدام player_id في الشرط
        //          .ExecuteUpdate(setters =>
        //             setters.SetProperty(x => x.PlayerFaceUrl,
        //                                 $"/images/players/{fileName}"));
        //    }

        //    db.SaveChanges();
        //}
    }
    }
