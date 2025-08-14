using System;
using System.IO;

namespace MobileSecureStarter.Platforms.iOS
{
    public static class RootDetection
    {
        public static bool IsJailbroken()
        {
#if DEBUG
            // Em debug, muitas heurísticas falham; não confie neste resultado.
            return false;
#endif
            return CheckFiles() || CanWriteOutsideSandbox();
        }

        private static bool CheckFiles()
        {
            string[] indicators = {
                "/Applications/Cydia.app",
                "/Library/MobileSubstrate/MobileSubstrate.dylib",
                "/bin/bash",
                "/usr/sbin/sshd",
                "/etc/apt"
            };
            foreach (var path in indicators)
            {
                try { if (File.Exists(path)) return true; } catch { }
            }
            return false;
        }

        private static bool CanWriteOutsideSandbox()
        {
            try
            {
                var testPath = "/private/jb_test.txt";
                File.WriteAllText(testPath, "test");
                if (File.Exists(testPath))
                {
                    File.Delete(testPath);
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
