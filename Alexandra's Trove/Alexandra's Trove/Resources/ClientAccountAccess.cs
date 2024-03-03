using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove.Resources
{
    public static class ClientAccountAccess//used to handle account access - different types of ids could be used to identify clients with different authorisation levels
    {
        public static string ID = "C0";//guests will have ID C0 - the id of the client using the account will be firtly set to C0

        public static string GetID()//get the id of the client - to display other details
        {
            return ID;
        }

        public static void SetID(string IDUpdates)//set the ID of the client when they use the application - this is used when the client is not a guest
        {
           ID = IDUpdates;
        }

    }
}
