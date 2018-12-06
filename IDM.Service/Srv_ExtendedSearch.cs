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
    public class Srv_ExtendedSearch
    {
        Rpst_ExtendedSearch searchRpst = new Rpst_ExtendedSearch();

        public List<ExtendedSearch_DTO> Search(ExtendedSearch_DTO entity)
        {
            searchRpst.AddInputParameters("@docContentType", entity.docContentType);
            searchRpst.AddInputParameters("@docRegNo", entity.docRegNo);
            searchRpst.AddInputParameters("@docType", entity.docType);
            searchRpst.AddInputParameters("@tematikaID", entity.tematikaID);
            searchRpst.AddInputParameters("@docContent", entity.docContent);
            searchRpst.AddInputParameters("@docNote", entity.docNote);
            DataTable dt = new DataTable();
            switch (Convert.ToInt32(entity.docContentType))
            {
                case 1:
                    searchRpst.AddInputParameters("@actionTypeID", entity.actionTypeID);
                    searchRpst.AddInputParameters("@conTypeID", entity.conTypeID);
                    searchRpst.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
                    dt = searchRpst.GetList("sp_ExtendedSearchForInternals", CommandType.StoredProcedure);
                    break;
                case 2:
                    searchRpst.AddInputParameters("@appealTypeID", entity.appealTypeID);
                    searchRpst.AddInputParameters("@sdEntryNo", entity.sdEntryNo);
                    searchRpst.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
                    searchRpst.AddInputParameters("@officeID", entity.officeID);
                    searchRpst.AddInputParameters("@organID", entity.organID);
                    searchRpst.AddInputParameters("@contactTypeID", entity.contactTypeID);
                    dt = searchRpst.GetList("sp_ExtendedSearchForServDoc", CommandType.StoredProcedure);
                    break;
                case 3:
                    searchRpst.AddInputParameters("@appealCharID", entity.appealCharID);
                    searchRpst.AddInputParameters("@appealTypeID", entity.appealTypeID);
                    searchRpst.AddInputParameters("@docApplyTypeID", entity.docApplyTypeID);
                    dt = searchRpst.GetList("sp_ExtendedSearchForCitizen", CommandType.StoredProcedure);
                    break;
                case 4:
                    searchRpst.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
                    searchRpst.AddInputParameters("@officeID", entity.officeID);
                    searchRpst.AddInputParameters("@organID", entity.organID);
                    dt = searchRpst.GetList("sp_ExtendedSearchForOutDoc", CommandType.StoredProcedure);
                    break;
                default:
                    dt = searchRpst.GetList("sp_ExtendedSearchCommon", CommandType.StoredProcedure);
                    break;
            }
            List<ExtendedSearch_DTO> resultList = new List<ExtendedSearch_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                resultList.Add(new ExtendedSearch_DTO
                {
                    docRegNo = dr["docRegNo"].ToString(),
                    docType = dr["docType"].ToString(),
                    dcontypeTitle = dr["dcontypeTitle"].ToString(),
                    doctypeTitle = dr["doctypeTitle"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),

                    //tematikaID = dr["tematikaID"].ToString()
                    //ID = Convert.ToInt64(dr["docID"]),
                    //doID = Convert.ToInt64(dr["doID"]),
                    //DocContentTypeID = Convert.ToInt32(dr["DocContentTypeID"]),
                    //DocRegNo = dr["docRegNo"].ToString(),
                    //DocContentTypeTitle = dr["DocContentType"].ToString(),
                    //DocTypeTitle = dr["DocType"].ToString(),
                    //fromUser = dr["fromUser"].ToString(),
                    //operationTitle = (Convert.ToInt32(dr["operationID"]) != 0 ? dr["operationTitle"].ToString() : "Yeni"),
                    //operationID = (dr["operationID"] != null ? Convert.ToInt32(dr["operationID"]) : 0)
                });
            }
            return resultList;
        }
    }
}
