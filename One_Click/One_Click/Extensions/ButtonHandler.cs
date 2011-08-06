using System;
using System.Windows.Forms;

namespace One_Click
{
    public enum ButtonEvent
    {
        Online,
        Offline
    }

    public class StatusHandler
    {
        public static void ButtonHandler(Button bStart, Button bStop, Button bRestart, ButtonEvent Event)
        {
            switch ((ButtonEvent)Event)
            {
                case ButtonEvent.Online:
                    bStart.Enabled = false;
                    bStop.Enabled = true;
                    bRestart.Enabled = true;
                    break;
                case ButtonEvent.Offline:
                    bStart.Enabled = true;
                    bStop.Enabled = false;
                    bRestart.Enabled = false;
                    break;
            }
        }
    }
}