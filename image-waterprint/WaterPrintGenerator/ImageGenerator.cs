using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPrintGenerator
{
    public class ImageGenerator
    {
        /// <summary>  
        /// Creating a Watermarked Photograph with GDI+ for .NET  
        /// </summary>  
        /// <param name="rSrcImgPath">原始图片的物理路径</param>  
        /// <param name="rMarkImgPath">水印图片的物理路径</param>  
        /// <param name="rMarkText">水印文字（不显示水印文字设为空串）</param>  
        /// <param name="rDstImgPath">输出合成后的图片的物理路径</param>  
        /// @整理: anyrock@mending.cn  
        public string BuildWatermark(string rSrcImgPath, string rMarkImgPath, string rMarkText, string rDstImgPath, string imgType)
        {
            //以下（代码）从一个指定文件创建了一个Image 对象，然后为它的 Width 和 Height定义变量。  
            //这些长度待会被用来建立一个以24 bits 每像素的格式作为颜色数据的Bitmap对象。  
            Image imgPhoto = Image.FromFile(rSrcImgPath);
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            //这个代码载入水印图片，水印图片已经被保存为一个BMP文件，以绿色(A=0,R=0,G=255,B=0)作为背景颜色。  
            //再一次，会为它的Width 和Height定义一个变量。  
            Image imgWatermark = new Bitmap(rMarkImgPath);
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;
            //这个代码以100%它的原始大小绘制imgPhoto 到Graphics 对象的（x=0,y=0）位置。  
            //以后所有的绘图都将发生在原来照片的顶部。  
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.DrawImage(
                 imgPhoto,
                 new Rectangle(0, 0, phWidth, phHeight),
                 0,
                 0,
                 phWidth,
                 phHeight,
                 GraphicsUnit.Pixel);
            //为了最大化版权信息的大小，我们将测试7种不同的字体大小来决定我们能为我们的照片宽度使用的可能的最大大小。  
            //为了有效地完成这个，我们将定义一个整型数组，接着遍历这些整型值测量不同大小的版权字符串。  
            //一旦我们决定了可能的最大大小，我们就退出循环，绘制文本  
            int[] sizes = new int[] { 36, 24, 16, 14, 10, 6, 4 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < 7; i++)
            {
                crFont = new Font("arial", sizes[i],
                      FontStyle.Bold);
                crSize = grPhoto.MeasureString(rMarkText,
                      crFont);
                if ((ushort)crSize.Width < (ushort)phWidth)
                    break;
            }
            //因为所有的照片都有各种各样的高度，所以就决定了从图象底部开始的5%的位置开始。  
            //使用rMarkText字符串的高度来决定绘制字符串合适的Y坐标轴。  
            //通过计算图像的中心来决定X轴，然后定义一个StringFormat 对象，设置StringAlignment 为Center。  
            int yPixlesFromBottom = (int)(phHeight * .05);
            float yPosFromBottom = ((phHeight -
                 yPixlesFromBottom) - (crSize.Height / 2));
            float xCenterOfImg = (phWidth / 2);
            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;
            //现在我们已经有了所有所需的位置坐标来使用60%黑色的一个Color(alpha值153)创建一个SolidBrush 。  
            //在偏离右边1像素，底部1像素的合适位置绘制版权字符串。  
            //这段偏离将用来创建阴影效果。使用Brush重复这样一个过程，在前一个绘制的文本顶部绘制同样的文本。  
            SolidBrush semiTransBrush2 =
                 new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            grPhoto.DrawString(rMarkText,
                 crFont,
                 semiTransBrush2,
                 new PointF(xCenterOfImg + 1, yPosFromBottom + 1),
                 StrFormat);
            SolidBrush semiTransBrush = new SolidBrush(
                 Color.FromArgb(153, 255, 255, 255));
            grPhoto.DrawString(rMarkText,
                 crFont,
                 semiTransBrush,
                 new PointF(xCenterOfImg, yPosFromBottom),
                 StrFormat);
            //根据前面修改后的照片创建一个Bitmap。把这个Bitmap载入到一个新的Graphic对象。  
            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(
                 imgPhoto.HorizontalResolution,
                 imgPhoto.VerticalResolution);
            Graphics grWatermark =
                 Graphics.FromImage(bmWatermark);
            //通过定义一个ImageAttributes 对象并设置它的两个属性，我们就是实现了两个颜色的处理，以达到半透明的水印效果。  
            //处理水印图象的第一步是把背景图案变为透明的(Alpha=0, R=0, G=0, B=0)。我们使用一个Colormap 和定义一个RemapTable来做这个。  
            //就像前面展示的，我的水印被定义为100%绿色背景，我们将搜到这个颜色，然后取代为透明。  
            ImageAttributes imageAttributes =
                 new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };
            //第二个颜色处理用来改变水印的不透明性。  
            //通过应用包含提供了坐标的RGBA空间的5x5矩阵来做这个。  
            //通过设定第三行、第三列为0.3f我们就达到了一个不透明的水平。结果是水印会轻微地显示在图象底下一些。  
            imageAttributes.SetRemapTable(remapTable,
                 ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {   
                                                     new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},  
                                                     new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},  
                                                     new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},  
                                                     new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},  
                                                     new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}  
                                                };
            ColorMatrix wmColorMatrix = new
                 ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(wmColorMatrix,
                 ColorMatrixFlag.Default,
                 ColorAdjustType.Bitmap);
            //随着两个颜色处理加入到imageAttributes 对象，我们现在就能在照片右手边上绘制水印了。  
            //我们会偏离10像素到底部，10像素到左边。  
            int markWidth;
            int markHeight;
            //mark比原来的图宽  
            if (phWidth <= wmWidth)
            {
                markWidth = phWidth - 10;
                markHeight = (markWidth * wmHeight) / wmWidth;
            }
            else if (phHeight <= wmHeight)
            {
                markHeight = phHeight - 10;
                markWidth = (markHeight * wmWidth) / wmHeight;
            }
            else
            {
                markWidth = wmWidth;
                markHeight = wmHeight;
            }

            //int xPosOfWm = ((phWidth - markWidth) - 5);
            //int yPosOfWm = ((phHeight - markHeight) - 5);
            int xPosOfWm = phWidth - 156;
            int yPosOfWm = 10;
            grWatermark.DrawImage(imgWatermark,
                 //new Rectangle(xPosOfWm, yPosOfWm, markWidth, markHeight),
                 new Rectangle(xPosOfWm, yPosOfWm, 146, 99),
                 0,
                 0,
                 wmWidth,
                 wmHeight,
                 GraphicsUnit.Pixel,
                 imageAttributes);
            //最后的步骤将是使用新的Bitmap取代原来的Image。 销毁两个Graphic对象，然后把Image 保存到文件系统。  
            imgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();

            string filename = rDstImgPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss")+ imgType;
            if(imgType == ".jpg")
            {
                imgPhoto.Save(filename, ImageFormat.Jpeg);
            }
            else
            {
                imgPhoto.Save(filename, ImageFormat.Png);
            }
            
            imgPhoto.Dispose();
            imgWatermark.Dispose();

            return filename;
        }  
    
        /// <summary>
        /// 创建带水印的图片
        /// </summary>
        /// <param name="sourcePath">原图片地址</param>
        /// <param name="watermarkPath">水印图片路径</param>
        /// <param name="targetPath">输出路径</param>
        /// <param name="targetType">输出类型</param>
        /// <param name="styleEnabled">启用自定义格式</param>
        /// <param name="textEnabled">启用自定义文字</param>
        /// <param name="width">水印宽度</param>
        /// <param name="height">水印高度</param>
        /// <param name="direction">水印位置</param>
        /// <param name="paddingleft">距左</param>
        /// <param name="paddingtop">距上</param>
        /// <param name="paddingright">距右</param>
        /// <param name="paddingbottom">距下</param>
        /// <param name="text">水印文字</param>
        /// <returns>图片路径</returns>
        public string BuildWatermark(string sourcePath, 
                                     string watermarkPath, 
                                     string targetPath,
                                     string targetType,
                                     bool styleEnabled = false,
                                     bool textEnabled = false,
                                     int width = 50,
                                     int height = 50,      
                                     Single alpha = 1.0f,                   
                                     WatermarkDirection direction = WatermarkDirection.TopLeft,
                                     int paddingleft = 0,
                                     int paddingtop = 0,
                                     int paddingright = 0,
                                     int paddingbottom = 0,
                                     string text = "")
        {
            //原图像
            Image imgSource = Image.FromFile(sourcePath);
            int sourceWidth = imgSource.Width;
            int sourceHeight = imgSource.Height;

            //水印图像
            Image imgWatermark = new Bitmap(watermarkPath);
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;

            //原Bitmap
            Bitmap bmSource = new Bitmap(sourceWidth, sourceHeight, PixelFormat.Format24bppRgb);
            bmSource.SetResolution(72, 72);
            Graphics grSource = Graphics.FromImage(bmSource);           
            grSource.SmoothingMode = SmoothingMode.AntiAlias;
            grSource.DrawImage(imgSource, new Rectangle(0, 0, sourceWidth, sourceHeight), 0, 0, sourceWidth, sourceHeight, GraphicsUnit.Pixel);

            if (textEnabled)
            {
                //找到适合的字体大小
                int[] sizes = new int[] { 36, 24, 16, 14, 10, 6, 4 };
                Font crFont = null;
                SizeF crSize = new SizeF();
                for (int i = 0; i < 7; i++)
                {
                    crFont = new Font("arial", sizes[i], FontStyle.Bold);
                    crSize = grSource.MeasureString(text, crFont);
                    if ((ushort)crSize.Width < (ushort)sourceWidth)
                    {
                        break;
                    }
                }

                //计算X,Y坐标
                int yPixlesFromBottom = (int)(sourceHeight * 0.05);
                float yPosFromBottom = ((sourceHeight - yPixlesFromBottom) - (crSize.Height / 2));
                float xCenterOfSource = (sourceWidth / 2);

                //画出水印文字
                StringFormat StrFormat = new StringFormat();
                StrFormat.Alignment = StringAlignment.Center;
                SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
                grSource.DrawString(text, crFont, semiTransBrush, new PointF(xCenterOfSource, yPosFromBottom), StrFormat);
            }

            //重新加载bitmap
            Bitmap bmWatermark = new Bitmap(bmSource);
            bmWatermark.SetResolution(imgSource.HorizontalResolution, imgSource.VerticalResolution);
            Graphics grWatermark = Graphics.FromImage(bmWatermark);

            //通过定义一个ImageAttributes 对象并设置它的两个属性，我们就是实现了两个颜色的处理，以达到半透明的水印效果。  
            //处理水印图象的第一步是把背景图案变为透明的(Alpha=0, R=0, G=0, B=0)。我们使用一个Colormap 和定义一个RemapTable来做这个。  
            //就像前面展示的，我的水印被定义为100%绿色背景，我们将搜到这个颜色，然后取代为透明。  
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            //第二个颜色处理用来改变水印的不透明性。  
            //通过应用包含提供了坐标的RGBA空间的5x5矩阵来做这个。  
            //通过设定第三行、第三列为0.3f我们就达到了一个不透明的水平。结果是水印会轻微地显示在图象底下一些。  
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {   
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},  
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},  
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},  
                                                new float[] {0.0f,  0.0f,  0.0f,  alpha, 0.0f},  
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}  
                                            };
            ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xPosOfWm = 0;
            int yPosOfWm = 0;
            switch (direction)
            {
                case WatermarkDirection.TopLeft:
                    xPosOfWm = paddingleft;
                    yPosOfWm = paddingtop;
                    break;
                case WatermarkDirection.TopRight:
                    xPosOfWm = sourceWidth - width - paddingright;
                    yPosOfWm = paddingtop;
                    break;
                case WatermarkDirection.BottomLeft:
                    xPosOfWm = paddingleft;
                    yPosOfWm = sourceHeight - height - paddingbottom;
                    break;
                case WatermarkDirection.BottomRight:
                    xPosOfWm = sourceWidth - width - paddingright;
                    yPosOfWm = sourceHeight - height - paddingbottom;
                    break;
            }

            grWatermark.DrawImage(imgWatermark, new Rectangle(xPosOfWm, yPosOfWm, width, height), 0, 0, wmWidth, wmHeight, GraphicsUnit.Pixel, imageAttributes);
            
            //最后的步骤将是使用新的Bitmap取代原来的Image。 销毁两个Graphic对象，然后把Image 保存到文件系统。  
            imgSource = bmWatermark;
            grSource.Dispose();
            grWatermark.Dispose();

            string filename = targetPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + targetType;
            if (targetType == ".jpg")
            {
                imgSource.Save(filename, ImageFormat.Jpeg);
            }
            else
            {
                imgSource.Save(filename, ImageFormat.Png);
            }
            imgSource.Dispose();
            imgWatermark.Dispose();

            return filename;
        }
    
    }
}
