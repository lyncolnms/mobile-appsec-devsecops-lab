using System;
using System.Diagnostics;

namespace MobileSecureStarter.Security
{
    public static class AntiTamperService
    {
        public static bool IsDebuggerAttached()
        {
            return Debugger.IsAttached || IsDebugBuild();
        }

        public static bool IsCompromisedDevice()
        {
#if ANDROID
            return MobileSecureStarter.Platforms.Android.RootDetection.IsDeviceRooted();
#elif IOS
            return MobileSecureStarter.Platforms.iOS.RootDetection.IsJailbroken();
#else
            return false;
#endif
        }

        private static bool IsDebugBuild()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
