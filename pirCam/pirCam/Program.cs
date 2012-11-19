using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;


/**
 * 
 * @author Tilman
 * 
 * pirCam uses a PIR motion sensor to trigger the camera to take a picture and display it on a T35 display
 * components: FEZ Spider Mainboard, USB Client DP module, Display T35 Module, Camera, PIR Motion Sensor
 * 
 * PIR: has two potentiometers, one of which affects alert duration, the other one the activation sensitivity
 * */
namespace pirCam
{
    public partial class Program
    {
        void ProgramStarted()
        {
            Debug.Print("Program Started");
            motion_Sensor.Motion_Sensed += new Motion_Sensor.Motion_SensorEventHandler(motion_Sensor_Motion_Sensed);
            camera.PictureCaptured += new Camera.PictureCapturedEventHandler(camera_PictureCaptured);
        }

        //displays captured picture on T35 Display
        void camera_PictureCaptured(Camera sender, GT.Picture picture)
        {
            Debug.Print("picture captured");
            display_TE35.SimpleGraphics.DisplayImage(picture, 0, 0);
        }

        //motion sensor triggers camera snapshot
        void motion_Sensor_Motion_Sensed(Motion_Sensor sender, Motion_Sensor.Motion_SensorState state)
        {
            Debug.Print("motion detected");
            camera.TakePicture();
        }
    }
}
