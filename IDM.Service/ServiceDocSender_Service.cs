using IDM.DTO;
using IDM.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Service
{
    public class ServiceDocSender_Service
    {
        ServiceDocSender_Repository senderServ = new ServiceDocSender_Repository();

        public int Insert(ServDocSender_DTO entity)
        {
            senderServ.AddInputParameters("@docID", entity.docID);
            senderServ.AddInputParameters("@senderName", entity.senderName);
            senderServ.AddInputParameters("@senderSurname", entity.senderSurname);
            senderServ.AddInputParameters("@senderMiddlename", entity.senderMiddlename);
            return senderServ.IUD("sp_ServDocSender_Insert", CommandType.StoredProcedure);
        }

        public int Update(ServDocSender_DTO entity)
        {
            senderServ.AddInputParameters("@docID", entity.docID);
            senderServ.AddInputParameters("@senderName", entity.senderName);
            senderServ.AddInputParameters("@senderSurname", entity.senderSurname);
            senderServ.AddInputParameters("@senderMiddlename", entity.senderMiddlename);
            return senderServ.IUD("sp_ServDocSender_Update", CommandType.StoredProcedure);
        }
    }
}
