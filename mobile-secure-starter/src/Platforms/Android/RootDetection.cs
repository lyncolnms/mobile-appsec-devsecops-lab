using System.IO;
using Android.OS;

namespace MobileSecureStarter.Platforms.Android
{
    public static class RootDetection
    {
        public static bool IsDeviceRooted()
        {
            return CheckBuildTags() || CheckSuBinary() || CheckDangerousPaths();
        }

        private static bool CheckBuildTags()
        {
            try
            {
                return Build.Tags != null && Build.Tags.Contains("test-keys");
            }
            catch { return false; }
        }

        private static bool CheckSuBinary()
        {
            string[] paths = {
                "/system/bin/su","/system/xbin/su","/sbin/su","/system/bin/.ext/.su","/system/usr/we-need-root/su","/system/app/Superuser.apk"
            };
            foreach (var p in paths)
            {
                try { if (File.Exists(p)) return true; } catch { }
            }
            return false;
        }

        private static bool CheckDangerousPaths()
        {
            string[] paths = {
                "/system/app/Superuser.apk", "/system/app/Magisk.apk", "/cache/su", "/data/su"
            };
            foreach (var p in paths)
            {
                try { if (File.Exists(p)) return true; } catch { }
            }
            return false;
        }
    }
}
