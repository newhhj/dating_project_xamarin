using FFImageLoading;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Helpers
{
    public class ImageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageStream"></param>
        /// <returns>orientation : 1 - 0, 6 - 90, 3 - 180, 8 - 270</returns>
        public static async Task<int> GetOrientationAsync(Task<Stream> imageStream)
        {
            var returnValue = default(int);

            await ImageService.Instance.LoadStream((token) => { return imageStream; })
                .Success((info, result) =>
                {
                    var data = info.Exif?
                        .Select(x => x.Tags?.Where(z => z.Name == "Orientation" && z.Value != null).FirstOrDefault()?.Value)
                        .FirstOrDefault();

                    if (data != null)
                    {
                        returnValue = int.Parse(data);
                    }
                    else
                    {
                        returnValue = 1;
                    }
                })
                .PreloadAsync();

            return returnValue;
        }

        public static async Task<byte[]> ImageRotateToDefaultAsync(int orientation, Task<Stream> imageStream, int maxSize)
        {
            if (orientation == 0)
                orientation = 1;

            using (var fileStream = await imageStream)
            using (var memoryStream = new MemoryStream())
            using (var bitmap = SKBitmap.Decode(fileStream.ToByteArray()))
            {
                var scale = 1f;
                var size = (float)Math.Max(bitmap.Width, bitmap.Height);
                if (size > maxSize)
                    scale = maxSize / size;

                var width = orientation == 1 || orientation == 3 ? (int)(bitmap.Width * scale) : (int)(bitmap.Height * scale);
                var height = orientation == 1 || orientation == 3 ? (int)(bitmap.Height * scale) : (int)(bitmap.Width * scale);

                using (var rotateBitmap = new SKBitmap(width, height))
                using (var rotateCanvas = new SKCanvas(rotateBitmap))
                {
                    rotateCanvas.Clear();
                    switch (orientation)
                    {
                        case 6:
                            rotateCanvas.Translate(rotateBitmap.Width, 0);
                            rotateCanvas.RotateDegrees(90);
                            rotateCanvas.DrawBitmap(bitmap, SKRect.Create(bitmap.Width, bitmap.Height), SKRect.Create(rotateBitmap.Height, rotateBitmap.Width));
                            break;
                        case 3:
                            rotateCanvas.Translate(rotateBitmap.Width, rotateBitmap.Height);
                            rotateCanvas.RotateDegrees(180);
                            rotateCanvas.DrawBitmap(bitmap, SKRect.Create(bitmap.Width, bitmap.Height), SKRect.Create(rotateBitmap.Width, rotateBitmap.Height));
                            break;
                        case 8:
                            rotateCanvas.Translate(0, rotateBitmap.Height);
                            rotateCanvas.RotateDegrees(270);
                            rotateCanvas.DrawBitmap(bitmap, SKRect.Create(bitmap.Width, bitmap.Height), SKRect.Create(rotateBitmap.Height, rotateBitmap.Width));
                            break;
                        default:
                            rotateCanvas.DrawBitmap(bitmap, SKRect.Create(bitmap.Width, bitmap.Height), SKRect.Create(rotateBitmap.Width, rotateBitmap.Height));
                            break;
                    }

                    rotateBitmap.Encode(memoryStream, SKEncodedImageFormat.Jpeg, 100);

                    return memoryStream.ToArray();
                }
            }
        }
    }

    public static class ImageHelperExtenstion
    {
        public static async Task<(string filename, byte[] buffer)> TakeImageAsync(this ContentPage page)
        {
            var fileResult = default(FileResult);

            if (MediaPicker.IsCaptureSupported)
            {
                var selectSource = await page.DisplayActionSheet("선택", "취소", null, "카메라", "갤러리");
                switch (selectSource)
                {
                    case "카메라":
                        fileResult = await MediaPicker.CapturePhotoAsync();
                        break;
                    case "갤러리":
                        fileResult = await MediaPicker.PickPhotoAsync();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                fileResult = await MediaPicker.PickPhotoAsync();
            }

            if (fileResult == null)
                return (null, null);

            var orientation = await ImageHelper.GetOrientationAsync(fileResult.OpenReadAsync());
            var buffer = await ImageHelper.ImageRotateToDefaultAsync(orientation, fileResult.OpenReadAsync(), 1024);
            return (fileResult.FileName, buffer);
        }
    }
}
