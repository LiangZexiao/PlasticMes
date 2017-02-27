using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Security;

namespace Admin.App_Code
{
    public class GifOrJpg
    {
        public GifOrJpg() { }

        public byte[] ReadeImage(Stream strm)
        {
            byte[] myImage = null;
            try
            {
                Image image = Image.FromStream(strm);

                if (image.RawFormat.Guid != ImageFormat.Jpeg.Guid && image.RawFormat.Guid != ImageFormat.Bmp.Guid)
                {
                    MemoryStream memStream = new MemoryStream();
                    image.Save(memStream, ImageFormat.Jpeg);
                    myImage = memStream.GetBuffer();
                    memStream.Close();
                    memStream.Dispose();
                }
                else
                {
                    strm.Position = 0;
                    myImage = new byte[strm.Length];
                    strm.Read(myImage, 0, (int)strm.Length);
                }
                image.Dispose();
                return myImage;
                
            }
            catch
            {
                return new byte[0];
            }
            finally
            {
                myImage = null;
                strm.Dispose();
            }
        }

        // 按模版比例生成缩略图（以流的方式获取源文件）
        //生成缩略图函数
        //顺序参数：源图文件流、模版宽、模版高
        //注：缩略图大小控制在模版区域内
        public byte[] MakeSmallImg(System.IO.Stream fromFileStream, System.Double templateWidth, System.Double templateHeight)
        {
            try
            {
                //从文件取得图片对象，并使用流中嵌入的颜色管理信息
                System.Drawing.Image myImage = System.Drawing.Image.FromStream(fromFileStream, true);

                //缩略图宽、高
                System.Double newWidth = myImage.Width, newHeight = myImage.Height;
                //宽大于模版的横图
                if (myImage.Width > myImage.Height || myImage.Width == myImage.Height)
                {

                    if (myImage.Width > templateWidth)
                    {
                        if (templateWidth != 0.0)
                        {
                            //宽按模版，高按比例缩放
                            newWidth = templateWidth;
                            newHeight = myImage.Height * (newWidth / myImage.Width);
                        }
                        else
                        {
                            newWidth = myImage.Width;
                            newHeight = myImage.Height;
                        }
                    }
                }
                //高大于模版的竖图
                else
                {
                    if (myImage.Height > templateHeight)
                    {
                        if (templateHeight != 0.0)
                        {
                            //高按模版，宽按比例缩放
                            newHeight = templateHeight;
                            newWidth = myImage.Width * (newHeight / myImage.Height);
                        }
                        else
                        {
                            //高按模版，宽按比例缩放
                            newHeight = myImage.Height;
                            newWidth = myImage.Width;
                        }
                    }
                }

                //取得图片大小
                System.Drawing.Size mySize = new Size((int)newWidth, (int)newHeight);
                //新建一个bmp图片
                System.Drawing.Image bitmap = new System.Drawing.Bitmap(mySize.Width, mySize.Height);
                //新建一个画板
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                //设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //清空一下画布
                g.Clear(Color.White);
                //在指定位置画图
                g.DrawImage(myImage, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                new System.Drawing.Rectangle(0, 0, myImage.Width, myImage.Height),
                System.Drawing.GraphicsUnit.Pixel);

                ///文字水印
                //System.Drawing.Graphics G=System.Drawing.Graphics.FromImage(bitmap);
                //System.Drawing.Font f=new Font("宋体",10);
                //System.Drawing.Brush b=new SolidBrush(Color.Black);
                //G.DrawString("myohmine",f,b,10,10);
                //G.Dispose(); 

                ///图片水印
                //System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("pic/1.gif"));
                //Graphics a = Graphics.FromImage(bitmap);
                //a.DrawImage(copyImage, new Rectangle(bitmap.Width-copyImage.Width,bitmap.Height-copyImage.Height,copyImage.Width, copyImage.Height),0,0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel); 

                //copyImage.Dispose();
                //a.Dispose();
                //copyImage.Dispose(); 
                byte[] myImageByte = null;
                if (bitmap.RawFormat.Guid != ImageFormat.Jpeg.Guid && bitmap.RawFormat.Guid != ImageFormat.Bmp.Guid)
                {
                    MemoryStream memStream = new MemoryStream();
                    bitmap.Save(memStream, ImageFormat.Jpeg);
                    myImageByte = memStream.GetBuffer();
                    memStream.Close();
                    memStream.Dispose();
                }
                else
                {
                    fromFileStream.Position = 0;
                    myImageByte = new byte[fromFileStream.Length];
                    fromFileStream.Read(myImageByte, 0, (int)fromFileStream.Length);
                }
                return myImageByte;

                //MemoryStream memStream = new MemoryStream();
                //保存缩略图
                // bitmap.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);

                // bitmap.Save(memStream, ImageFormat.Jpeg);
                //return bitmap;
                g.Dispose();
                myImage.Dispose();
                bitmap.Dispose();
            }
            catch
            {
                return new byte[0];
            }
            finally
            {
                fromFileStream.Dispose();
            }
        }
    }
}
