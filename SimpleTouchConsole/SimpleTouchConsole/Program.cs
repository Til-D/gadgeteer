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
 *@author Tilman
 *
 * simple component setup using a T35 display and displaying touch position on the touchscreen using a label
 * Components: FEZ Spider Mainboard, USB Client DP module, Display T35 Module
 **/
namespace SimpleTouchConsole
{
    public partial class Program
    {

        private static int interval = 3000;
        Window touchScreen;
        Text console;
        GT.Timer timer = new GT.Timer(interval);

        void ProgramStarted()
        {
            Debug.Print("Program Started");
            setupUI();

            touchScreen.TouchDown += new Microsoft.SPOT.Input.TouchEventHandler(touchScreen_TouchDown);

            //timer to reset display
            timer.Tick += new GT.Timer.TickEventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(GT.Timer timer)
        {
            Debug.Print("Reset screen");
            console.TextContent = "";
        }

        void touchScreen_TouchDown(object sender, Microsoft.SPOT.Input.TouchEventArgs e)
        {
            timer.Stop();
            String str = "touch detected at: " + e.Touches[0].X + "x" + e.Touches[0].Y;
            Debug.Print(str);
            console.TextContent = str;
            timer.Start();
        }

        void setupUI()
        {
            touchScreen = display_T35.WPFWindow;
            //setup layout
            Canvas layout = new Canvas();
            Border background = new Border();
            background.Background = new SolidColorBrush(Colors.Black);
            background.Height = 240;
            background.Width = 320;
            layout.Children.Add(background);
            Canvas.SetLeft(background, 0);
            Canvas.SetTop(background, 0);

            //add label
            console = new Text("Hello World!");
            console.Height = 100;
            console.Width = 320;
            console.ForeColor = Colors.Green;
            console.Font = Resources.GetFont(Resources.FontResources.NinaB);
            console.TextAlignment = TextAlignment.Left;

            layout.Children.Add(console);
            Canvas.SetLeft(console, 0);
            Canvas.SetTop(console, 10);

            touchScreen.Child = layout;
        }
    }
}
