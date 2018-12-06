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
    public class OutDoc_Service
    {
        OutDoc_Repository outDoc = new OutDoc_Repository();

        public int Insert(OutDoc_DTO entity)
        {
            outDoc.AddInputParameters("@docID", entity.docID);
            outDoc.AddInputParameters("@countryID", entity.countryID);
            outDoc.AddInputParameters("@cityID", entity.cityID);
            outDoc.AddInputParameters("@townID", entity.townID);
            outDoc.AddInputParameters("@name", entity.name);
            outDoc.AddInputParameters("@surname", entity.surname);
            outDoc.AddInputParameters("@middlename", entity.middlename);
            outDoc.AddInputParameters("@voen", entity.voen);
            outDoc.AddInputParameters("@fulladdress", entity.fulladdress);
            outDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            outDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            outDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            return outDoc.IUD("sp_OutDocument_Insert", CommandType.StoredProcedure);
        }

        public int UpdateByDocID(OutDoc_DTO entity)
        {
            outDoc.AddInputParameters("@docID", entity.docID);
            outDoc.AddInputParameters("@countryID", entity.countryID);
            outDoc.AddInputParameters("@cityID", entity.cityID);
            outDoc.AddInputParameters("@townID", entity.townID);
            outDoc.AddInputParameters("@name", entity.name);
            outDoc.AddInputParameters("@surname", entity.surname);
            outDoc.AddInputParameters("@middlename", entity.middlename);
            outDoc.AddInputParameters("@voen", entity.voen);
            outDoc.AddInputParameters("@fulladdress", entity.fulladdress);
            outDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            outDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            outDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            return outDoc.IUD("sp_OutDocument_Update", CommandType.StoredProcedure);
        }

        public Custom_OutDoc_DTO GetDocumentByDocID(long docID)
        {
            outDoc.AddInputParameters("@docID", docID);
            DataTable dt = outDoc.GetList("sp_OutDoc_GetByDocID", CommandType.StoredProcedure);
            Custom_OutDoc_DTO doc = new Custom_OutDoc_DTO();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegNo = dt.Rows[0]["docRegNo"].ToString();
            doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd/MM/yyyy");
            doc.docDayCount = Convert.ToInt32(dt.Rows[0]["docDayCount"]);
            doc.docFinishDate = Convert.ToDateTime(dt.Rows[0]["docFinishDate"]).ToString("dd/MM/yyyy");
            doc.docType = Convert.ToByte(dt.Rows[0]["docType"]);
            doc.docNote = dt.Rows[0]["docNote"].ToString();
            doc.docInCharge = Convert.ToBoolean(dt.Rows[0]["docInCharge"]);
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            doc.countryID = Convert.ToInt32(dt.Rows[0]["countryID"]);
            doc.cityID = Convert.ToInt32(dt.Rows[0]["cityID"]);
            doc.townID = Convert.ToInt32(dt.Rows[0]["townID"]);
            doc.name = dt.Rows[0]["name"].ToString();
            doc.surname = dt.Rows[0]["surname"].ToString();
            doc.middlename = dt.Rows[0]["middlename"].ToString();
            doc.voen = dt.Rows[0]["voen"].ToString();
            doc.fulladdress = dt.Rows[0]["fulladdress"].ToString();
            doc.tematikaID = Convert.ToInt32(dt.Rows[0]["tematikaID"]);
            doc.relatedDocNo = dt.Rows[0]["relatedDocNo"].ToString();
            doc.relatedDocRegDate = dt.Rows[0]["relatedDocRegDate"].ToString();
            return doc;
        }

        public OutRegFileDoc GetRegDocumentByDocID(long docID)
        {
            outDoc.AddInputParameters("@docID", docID);
            DataTable dt = outDoc.GetList("sp_OutRegFileDocument", CommandType.StoredProcedure);
            OutRegFileDoc doc = new OutRegFileDoc();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegNo = dt.Rows[0]["docRegNo"].ToString();
            doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd/MM/yyyy");
            doc.docNote = dt.Rows[0]["docNote"].ToString();
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            doc.name = dt.Rows[0]["name"].ToString();
            doc.surname = dt.Rows[0]["surname"].ToString();
            doc.tematika = dt.Rows[0]["tematika"].ToString();
            doc.city = dt.Rows[0]["city"].ToString();
            doc.town = dt.Rows[0]["town"].ToString();
            doc.voen = dt.Rows[0]["voen"].ToString();
            doc.middlename = dt.Rows[0]["middlename"].ToString();
            doc.docType = dt.Rows[0]["documentType"].ToString();
            return doc;
        }
    }
}
