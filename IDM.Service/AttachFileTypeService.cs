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
    public class AttachFileTypeService
    {
        AttachFileTypeRepository attFileTypeRep = new AttachFileTypeRepository();
        public List<CommonDTO> GetList(int docContentType)
        {
            attFileTypeRep.AddInputParameters("@docContentType", docContentType); 
            DataTable dt = attFileTypeRep.GetList("sp_AttachFileType_GetList", CommandType.StoredProcedure);
            List<CommonDTO> attFileTypeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                attFileTypeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return attFileTypeList;
        }

        public int UpdateDocID(long docID, string guid)
        {
            attFileTypeRep.AddInputParameters("@docID", docID);
            attFileTypeRep.AddInputParameters("@guid", guid);
            return attFileTypeRep.IUD("sp_DocumentFiles_UpdateByGUID", CommandType.StoredProcedure);
        }
    }
}
