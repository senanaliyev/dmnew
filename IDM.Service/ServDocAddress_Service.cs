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
    public class ServDocAddress_Service
    {
        ServDocAddress_Repository senderServ = new ServDocAddress_Repository();

        public int Insert(ServDocAddress_DTO entity)
        {
            senderServ.AddInputParameters("@docID", entity.docID);
            senderServ.AddInputParameters("@countryID", entity.countryID);
            senderServ.AddInputParameters("@cityID", entity.cityID);
            senderServ.AddInputParameters("@townID", entity.townID);
            senderServ.AddInputParameters("@adrFullAddress", entity.adrFullAddress);
            senderServ.AddInputParameters("@adrFIN", entity.adrFIN);
            return senderServ.IUD("sp_ServDocAddress_Insert", CommandType.StoredProcedure);
        }

        public int Update(ServDocAddress_DTO entity)
        {
            senderServ.AddInputParameters("@docID", entity.docID);
            senderServ.AddInputParameters("@countryID", entity.countryID);
            senderServ.AddInputParameters("@cityID", entity.cityID);
            senderServ.AddInputParameters("@townID", entity.townID);
            senderServ.AddInputParameters("@adrFullAddress", entity.adrFullAddress);
            senderServ.AddInputParameters("@adrFIN", entity.adrFIN);
            return senderServ.IUD("sp_ServDocAddress_UpdateByDocID", CommandType.StoredProcedure);
        }
    }
}
