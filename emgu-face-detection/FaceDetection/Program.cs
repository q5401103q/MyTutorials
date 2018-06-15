//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cuda;

namespace FaceDetection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Run();
        }

        static void Run()
        {
            //读取指定路径的图片
            IImage image = new UMat("images/IMG_1288.jpg", ImreadModes.Color); //UMat version

            //定义人脸识别的时间
            long detectionTime;

            //人脸列表
            List<Rectangle> faces = new List<Rectangle>();

            //眼睛列表
            List<Rectangle> eyes = new List<Rectangle>();

            //开始识别
            DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);

            //将识别后的所有面部，用矩形区域标注出来
            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
            }

            /* 
             * 2017-10-19 不需要标注眼睛，比较混乱
             * 
            //将识别后的所有眼睛，用矩形区域标注出来
            foreach (Rectangle eye in eyes)
            {
                CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);
            }
            */
            
            using (InputArray iaImage = image.GetInputArray())
            {
                //获取人脸检测方式
                String method = (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda) ? "CUDA" : (iaImage.IsUMat && CvInvoke.UseOpenCL) ? "OpenCL" : "CPU";

                //显示图片
                ImageViewer.Show(image, String.Format("检测完毕，使用 {0} 模式， 耗时 {1} 毫秒", method, detectionTime));
            }
        }

    }
}