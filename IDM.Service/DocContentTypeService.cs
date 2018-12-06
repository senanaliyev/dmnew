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
    public class DocContentTypeService
    {
        DocContentTypeRepository docConType = new DocContentTypeRepository();

        public List<CommonDTO> GetListByID(int id, int? operposid, long? doid/*, int docid*/)
        {
            docConType.AddInputParameters("@id", id);

            DataTable dt;
            if (operposid != null)
            {
                docConType.AddInputParameters("@operposid", operposid);

                dt = docConType.GetList("sp_DocContentType_GetListByID", CommandType.StoredProcedure);
            }
            else
            {
                docConType.AddInputParameters("@doid", doid);
                dt = docConType.GetList("sp_OperationsToDocWithFilter_ListByDocID", CommandType.StoredProcedure);
            }
            List<CommonDTO> docConTypeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                docConTypeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return docConTypeList;
        }


    }
}
