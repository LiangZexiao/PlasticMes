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

        // ��ģ�������������ͼ�������ķ�ʽ��ȡԴ�ļ���
        //��������ͼ����
        //˳�������Դͼ�ļ�����ģ���ģ���
        //ע������ͼ��С������ģ��������
        public byte[] MakeSmallImg(System.IO.Stream fromFileStream, System.Double templateWidth, System.Double templateHeight)
        {
            try
            {
                //���ļ�ȡ��ͼƬ���󣬲�ʹ������Ƕ�����ɫ������Ϣ
                System.Drawing.Image myImage = System.Drawing.Image.FromStream(fromFileStream, true);

                //����ͼ����
                System.Double newWidth = myImage.Width, newHeight = myImage.Height;
                //�����ģ��ĺ�ͼ
                if (myImage.Width > myImage.Height || myImage.Width == myImage.Height)
                {

                    if (myImage.Width > templateWidth)
                    {
                        if (templateWidth != 0.0)
                        {
                            //��ģ�棬�߰���������
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
                //�ߴ���ģ�����ͼ
                else
                {
                    if (myImage.Height > templateHeight)
                    {
                        if (templateHeight != 0.0)
                        {
                            //�߰�ģ�棬����������
                            newHeight = templateHeight;
                            newWidth = myImage.Width * (newHeight / myImage.Height);
                        }
                        else
                        {
                            //�߰�ģ�棬����������
                            newHeight = myImage.Height;
                            newWidth = myImage.Width;
                        }
                    }
                }

                //ȡ��ͼƬ��С
                System.Drawing.Size mySize = new Size((int)newWidth, (int)newHeight);
                //�½�һ��bmpͼƬ
                System.Drawing.Image bitmap = new System.Drawing.Bitmap(mySize.Width, mySize.Height);
                //�½�һ������
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                //���ø�������ֵ��
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                //���ø�����,���ٶȳ���ƽ���̶�
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //���һ�»���
                g.Clear(Color.White);
                //��ָ��λ�û�ͼ
                g.DrawImage(myImage, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                new System.Drawing.Rectangle(0, 0, myImage.Width, myImage.Height),
                System.Drawing.GraphicsUnit.Pixel);

                ///����ˮӡ
                //System.Drawing.Graphics G=System.Drawing.Graphics.FromImage(bitmap);
                //System.Drawing.Font f=new Font("����",10);
                //System.Drawing.Brush b=new SolidBrush(Color.Black);
                //G.DrawString("myohmine",f,b,10,10);
                //G.Dispose(); 

                ///ͼƬˮӡ
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
                //��������ͼ
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
