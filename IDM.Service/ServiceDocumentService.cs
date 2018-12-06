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
    public class ServiceDocumentService
    {
        ServiceDocumentRepository serviceDoc = new ServiceDocumentRepository();
        public int Insert(ServiceDocumentDTO entity)
        {
            serviceDoc.AddInputParameters("@docID", entity.docID);
            serviceDoc.AddInputParameters("@sdEntryNo", entity.sdEntryNo);
            if (entity.sdEntryDate == null) entity.sdEntryDate = DateTime.Now.ToString("dd/MM/yyyy");
            serviceDoc.AddInputParameters("@sdEntryDate", DateTime.ParseExact(entity.sdEntryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            serviceDoc.AddInputParameters("@appealTypeID", entity.appealTypeID);
            serviceDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            serviceDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            serviceDoc.AddInputParameters("@officeID", entity.officeID);
            serviceDoc.AddInputParameters("@organID", entity.organID);
            serviceDoc.AddInputParameters("@contactTypeID", entity.contactTypeID);
            serviceDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            serviceDoc.AddInputParameters("@userID", entity.userID);
            return serviceDoc.IUD("sp_ServiceDocument_Insert", CommandType.StoredProcedure);
        }
        public int Update(ServiceDocumentDTO entity)
        {
            serviceDoc.AddInputParameters("@docID", entity.docID);
            serviceDoc.AddInputParameters("@sdEntryNo", entity.sdEntryNo);
            if (entity.sdEntryDate == null) entity.sdEntryDate = DateTime.Now.ToString("dd/MM/yyyy");
            serviceDoc.AddInputParameters("@sdEntryDate", DateTime.ParseExact(entity.sdEntryDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            serviceDoc.AddInputParameters("@appealTypeID", entity.appealTypeID);
            serviceDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            serviceDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            serviceDoc.AddInputParameters("@officeID", entity.officeID);
            serviceDoc.AddInputParameters("@organID", entity.organID);
            serviceDoc.AddInputParameters("@contactTypeID", entity.contactTypeID);
            serviceDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            serviceDoc.AddInputParameters("@userID", entity.userID);
            return serviceDoc.IUD("sp_ServiceDocument_Update", CommandType.StoredProcedure);
        }

        public Custom_DocServiceDTO GetDocumentByID(long id)
        {
            serviceDoc.AddInputParameters("@id", id);
            DataTable dt = serviceDoc.GetList("sp_DocService_GetById", CommandType.StoredProcedure);
            Custom_DocServiceDTO doc = new Custom_DocServiceDTO();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegNo = dt.Rows[0]["docRegNo"].ToString();
            if (!(dt.Rows[0]["docRegDate"] is DBNull))
                doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd/MM/yyyy");
            doc.docDayCount= Convert.ToInt32(dt.Rows[0]["docDayCount"]);
            if (!(dt.Rows[0]["docFinishDate"] is DBNull))
                doc.docFinishDate = Convert.ToDateTime(dt.Rows[0]["docFinishDate"]).ToString("dd/MM/yyyy");
            doc.docType = Convert.ToByte(dt.Rows[0]["docType"]);
            doc.docNote = dt.Rows[0]["docNote"].ToString();
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            doc.sdEntryNo = dt.Rows[0]["sdEntryNo"].ToString();
            if (!(dt.Rows[0]["sdEntryDate"] is DBNull))
                doc.sdEntryDate = Convert.ToDateTime(dt.Rows[0]["sdEntryDate"]).ToString("dd/MM/yyyy");
            doc.appealTypeID = Convert.ToInt32(dt.Rows[0]["appealTypeID"]);
            doc.relatedDocNo = dt.Rows[0]["relatedDocNo"].ToString();
            doc.relatedDocRegDate = dt.Rows[0]["relatedDocRegDate"].ToString();
            doc.contactTypeID = Convert.ToInt32(dt.Rows[0]["contactTypeID"]);
            doc.tematikaID = Convert.ToInt32(dt.Rows[0]["tematikaID"]);
            doc.senderName = dt.Rows[0]["senderName"].ToString();
            doc.senderSurname = dt.Rows[0]["senderSurname"].ToString();
            doc.senderMiddlename = dt.Rows[0]["senderMiddlename"].ToString();


            doc.officeID = (dt.Rows[0]["officeID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["officeID"]) : 0);
            doc.organID = (dt.Rows[0]["organID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["organID"]) : 0);
            //doc.doID = Convert.ToInt64(dt.Rows[0]["doID"]);
            //doc.operationID = (dt.Rows[0]["operationID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["operationID"]) : 0);

            doc.countryID = (dt.Rows[0]["countryID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["countryID"]) : 0);
            doc.cityID = (dt.Rows[0]["cityID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["cityID"]) : 0);
            doc.townID = (dt.Rows[0]["townID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["townID"]) : 0);

            doc.adrFullAddress = dt.Rows[0]["adrFullAddress"].ToString();
            doc.adrFIN = dt.Rows[0]["adrFIN"].ToString();
            //doc.actionTypeID = (dt.Rows[0]["actionTypeID"] != DBNull.Value ? Convert.ToByte(dt.Rows[0]["actionTypeID"]) : (byte)0);
            //doc.responseDocNo = dt.Rows[0]["responseDocNo"].ToString();
            //doc.conTypeID = (dt.Rows[0]["conTypeID"] != DBNull.Value ? Convert.ToByte(dt.Rows[0]["conTypeID"]) : (byte)0);
            doc.userID = (dt.Rows[0]["userID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["userID"]) : 0);
            return doc;
        }

        public ServiceRegFileDocument GetRegDocumentByDocID(long docID)
        {
            serviceDoc.AddInputParameters("@docID", docID);
            DataTable dt = serviceDoc.GetList("[sp_ServiceRegFileDocument]", CommandType.StoredProcedure);
            ServiceRegFileDocument doc = new ServiceRegFileDocument();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegNo = dt.Rows[0]["docRegNo"].ToString();
            doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd/MM/yyyy");
            doc.docNote = dt.Rows[0]["docNote"].ToString();
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            doc.name = dt.Rows[0]["senderName"].ToString();
            doc.surname = dt.Rows[0]["senderSurname"].ToString();
            doc.tematika = dt.Rows[0]["tematika"].ToString();
            doc.city = dt.Rows[0]["city"].ToString();
            doc.town = dt.Rows[0]["town"].ToString();
            doc.middlename = dt.Rows[0]["senderMiddlename"].ToString();
            doc.appealType = dt.Rows[0]["appealType"].ToString();
            doc.docType = dt.Rows[0]["documentType"].ToString();
            return doc;
        }

    }
}
