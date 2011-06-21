using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Auto_Compiler
{
    class TimerHandler
    {
        private static Button MainButton;
        private static Timer timeCompile;
        private static int timeInterval; 

        public static void RunTimer(Button _btnCompile)
        {
            MainButton = _btnCompile;
            timeCompile = new Timer();

            string[] _timer = ConfigSettings.ReadTimer().Split(',');

            if ((Convert.ToInt16(_timer[0]) == 0) && (Convert.ToInt16(_timer[1]) == 0) && (Convert.ToInt16(_timer[2]) == 0))
                GetInterval();
            else
                GetInterval(Convert.ToInt16(_timer[0]), Convert.ToInt16(_timer[1]), Convert.ToInt16(_timer[2]));

            timeCompile.Interval = timeInterval;
            timeCompile.Tick += new EventHandler(timer_Tick);
            StartTimer();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            MainButton.PerformClick();
        }

        public static void GetInterval(int _hour = 24, int _min = 0, int _sec = 0)
        {
            int ihour, iMin, iSec = 0;

            ihour   = _hour * 3600000;
            iMin    = _min * 60000;
            iSec    = _sec * 1000;

            timeInterval = ihour + iMin + iSec;
        }

        public static void StartTimer()
        {
            timeCompile.Start();
        }

        public static void StopTimer()
        {
            timeCompile.Stop();
        }
    }
}
