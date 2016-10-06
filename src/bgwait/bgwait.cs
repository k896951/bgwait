// bgwait
//
// Copyright (C) 2014,2015,2016 Hideki Gotoh ( k896951 )
//
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php
//
using System;
using System.Management;
using System.Diagnostics;
using System.Threading;

namespace bgwait
{
    class Program
    {

        static int Main(string[] args)
        {
            int pcount = 0;
            int ppid = -1;

            try
            {
                string q1 = string.Format("Win32_Process.Handle={0}", Process.GetCurrentProcess().Id);
                ManagementObject mo = new ManagementObject(q1);
                ppid = int.Parse(mo.Properties["ParentProcessId"].Value.ToString()); // parentProcessId
                mo.Dispose();
                mo = null;
            }
            catch (Exception)
            {
                Console.WriteLine("parentProcessId not found.");
            }
            GC.Collect();

            if (-1 == ppid)
            {
                Environment.Exit(16);
            }

            string q2 = string.Format("SELECT * FROM Win32_Process WHERE ParentProcessId={0}", ppid);
            ManagementObjectSearcher mos = new ManagementObjectSearcher(q2);
            do
            {
                if (0 != pcount)
                {
                    Thread.Sleep(10000); //10sec
                }

                ManagementObjectCollection moc = mos.Get();

                pcount = moc.Count - 1;
                moc.Dispose();
                moc = null;
                GC.Collect();
            }
            while (0 < pcount);

            return 0;
        }
    }
}