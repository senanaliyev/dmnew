using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDM.Service
{
    public class Enums
    {
        public enum ContentTypes
        {
            InternalDoc = 1,
            ServDoc = 2,
            CtzApp = 3,
            OutDoc = 4
        }

        public enum DocOperationStatus
        {
            FirstInsert=0, //sened ilk daxil olunanda
            Visible=1, //emeliyyata aciq haldadir
            Unvisible=2, //istifadecilerden gizledilir
            WaitingForConfirmation=3 //Tesdiq gozleyir
        }
    }
}
