

using System.Runtime.InteropServices;

namespace UV_DLP_3D_Printer.Integration.FluidManagement
{
    sealed class INIAccess
    {

        #region API Calls
        // standard API declarations for INI access
        // changing only "As Long" to "As Int32" (As Integer would work also)
        [DllImport("kernel32", EntryPoint = "WritePrivateProfileStringW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileStringW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, string lpReturnedString, int nSize, string lpFileName);
        #endregion

        public static string INIRead(string INIPath, string SectionName,
            string KeyName,
            string DefaultValue)
        {
            string returnValue = "";
            // primary version of call gets single value given all parameters
            int n = 0;
            string sData = new string(' ', 1024);
            n = System.Convert.ToInt32(GetPrivateProfileString(SectionName, KeyName, DefaultValue,
                sData, sData.Length, INIPath));
            if (n > 0) // return whatever it gave us
            {
                returnValue = sData.Substring(0, n);
            }
            else
            {
                returnValue = "";
            }
            return returnValue;
        }

        #region INIRead Overloads
        public static string INIRead(string INIPath, string SectionName,
            string KeyName)
        {
            // overload 1 assumes zero-length default
            return INIRead(INIPath, SectionName, KeyName, "");
        }

        public static string INIRead(string INIPath,
            string SectionName)
        {
            // overload 2 returns all keys in a given section of the given file
            return INIRead(INIPath, SectionName, null, "");
        }

        public static string INIRead(string INIPath)
        {
            // overload 3 returns all section names given just path
            return INIRead(INIPath, null, null, "");
        }
        #endregion

        public static void INIWrite(string INIPath, string SectionName, string KeyName,
            string TheValue)
        {
            WritePrivateProfileString(SectionName, KeyName, TheValue, INIPath);
        }

        public static void INIDelete(string INIPath, string SectionName,
            string KeyName) // delete single line from section
        {
            WritePrivateProfileString(SectionName, KeyName, null, INIPath);
        }

        public static void INIDelete(string INIPath, string SectionName)
        {
            // delete section from INI file
            WritePrivateProfileString(SectionName, null, null, INIPath);
        }

    }


}
