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
    public class DocTypeService
    {
        DocTypeRepository doctype = new DocTypeRepository();

        public List<CommonDTO> GetList()
        {
            DataTable dt = doctype.GetList("sp_DocType_GetList", CommandType.StoredProcedure);
            List<CommonDTO> doctypeList = new List<CommonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                doctypeList.Add(new CommonDTO { id = Convert.ToInt32(dr["id"]), title = dr["title"].ToString() });
            }
            return doctypeList;
        }



        //public List<DocMainTypeDTO>  MainTypesGetList()
        //{
        //    DataTable dt = doctype.GetList("sp_DocMainType_GetList", CommandType.StoredProcedure);
        //    List<DocMainTypeDTO> doctypeList = new List<DocMainTypeDTO>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        doctypeList.Add(new DocMainTypeDTO { dmtID = Convert.ToByte(dr["dmtID"]), dmtTitle = dr["dmtTitle"].ToString() });
        //    }
        //    return doctypeList;
        //}
        //public List<DocSubTypeDTO> SubTypesGetList(int id)
        //{
        //    doctype.AddInputParameters("@id", id);
        //    DataTable dt = doctype.GetList("sp_DocSubType_GetById", CommandType.StoredProcedure);
        //    List<DocSubTypeDTO> docsubtypeList = new List<DocSubTypeDTO>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        docsubtypeList.Add(new DocSubTypeDTO { dstID = Convert.ToByte(dr["dstID"]), dstTitle = dr["dstTitle"].ToString() });
        //    }
        //    return docsubtypeList;
        //}
    }
}
