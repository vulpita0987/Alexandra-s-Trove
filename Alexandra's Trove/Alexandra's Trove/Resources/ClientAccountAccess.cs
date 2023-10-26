using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove.Resources
{
    public static class ClientAccountAccess
    {
        public static string ID = "C0";

        public static string GetID()
        {
            return ID;
        }

        public static void SetID(string IDUpdates)
        {
           ID = IDUpdates;
        }

    }
}
