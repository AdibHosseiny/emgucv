//----------------------------------------------------------------------------
//  Copyright (C) 2004-2012 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using PedestrianDetection;

namespace Emgu.CV.Example.MonoTouch
{
    public class PedestrianDetectionDialogViewController : ButtonMessageImageDialogViewController
    {
        public PedestrianDetectionDialogViewController()
         : base()
        {
        }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
        ButtonText = "Detect Pedestrian";
            OnButtonClick += delegate
            { 
            long processingTime;
            using (Image<Bgr, byte> image = new Image<Bgr, byte>("pedestrian.png"))
            using (Image<Bgr, Byte> result = FindPedestrian.Find(image,  out processingTime))
            using (Image<Bgr, Byte> resized = result.Resize((int)View.Frame.Width, (int)View.Frame.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN, true))
            {
               MessageText = String.Format("Detection Time: {0} milliseconds.", processingTime);
               SetImage(resized);
            }
         };
           
      }
    }
}

