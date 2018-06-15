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
            //��ȡָ��·����ͼƬ
            IImage image = new UMat("images/IMG_1288.jpg", ImreadModes.Color); //UMat version

            //��������ʶ���ʱ��
            long detectionTime;

            //�����б�
            List<Rectangle> faces = new List<Rectangle>();

            //�۾��б�
            List<Rectangle> eyes = new List<Rectangle>();

            //��ʼʶ��
            DetectFace.Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);

            //��ʶ���������沿���þ��������ע����
            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
            }

            /* 
             * 2017-10-19 ����Ҫ��ע�۾����Ƚϻ���
             * 
            //��ʶ���������۾����þ��������ע����
            foreach (Rectangle eye in eyes)
            {
                CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);
            }
            */
            
            using (InputArray iaImage = image.GetInputArray())
            {
                //��ȡ������ⷽʽ
                String method = (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda) ? "CUDA" : (iaImage.IsUMat && CvInvoke.UseOpenCL) ? "OpenCL" : "CPU";

                //��ʾͼƬ
                ImageViewer.Show(image, String.Format("�����ϣ�ʹ�� {0} ģʽ�� ��ʱ {1} ����", method, detectionTime));
            }
        }

    }
}