using IDM.DTO;
using IDM.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Service
{
   public class DocOperationLog_Service
    {
        DocOperationLog_Repository docOperationLog = new DocOperationLog_Repository();

        public long Insert(DocOperationLog_DTO entity)
        {
            docOperationLog.AddInputParameters("@docID", entity.docID);
            docOperationLog.AddInputParameters("@docContentType", entity.docContentType);
            docOperationLog.AddInputParameters("@userID", entity.userID);
            docOperationLog.AddInputParameters("@operationID", entity.operationID);
            docOperationLog.AddInputParameters("@dologdate", DateTime.Now.ToString());
            return docOperationLog.IUD("sp_DocOperationLog_Insert", CommandType.StoredProcedure);
        }

    }
}
