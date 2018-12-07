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
    public class CitizenDoc_Service
    {
        CitizenDoc_Repository ctzDoc = new CitizenDoc_Repository();

        public int Insert(CitizenDoc_DTO entity)
        {
            ctzDoc.AddInputParameters("@docID", entity.docID);
            ctzDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            ctzDoc.AddInputParameters("@appealCharID", entity.appealCharID);
            ctzDoc.AddInputParameters("@appealTypeID", entity.appealTypeID);
            ctzDoc.AddInputParameters("@docApplyTypeID", entity.docApplyTypeID);
            ctzDoc.AddInputParameters("@name", entity.name);
            ctzDoc.AddInputParameters("@surname", entity.surname);
            ctzDoc.AddInputParameters("@middlename", entity.middlename);
            ctzDoc.AddInputParameters("@citizenshipID", entity.citizenshipID);
            ctzDoc.AddInputParameters("@nationID", entity.nationID);
            ctzDoc.AddInputParameters("@countryID", entity.countryID);
            ctzDoc.AddInputParameters("@cityID", entity.cityID);
            ctzDoc.AddInputParameters("@townID", entity.townID);
            ctzDoc.AddInputParameters("@fulladdress", entity.fulladdress);
            ctzDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            ctzDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            ctzDoc.AddInputParameters("@userID", entity.userID);
            ctzDoc.AddInputParameters("@categoryID", entity.categoryID);
            ctzDoc.AddInputParameters("@genderID", entity.genderID);
            ctzDoc.AddInputParameters("@socialStatusID", entity.socialStatusID);
            ctzDoc.AddInputParameters("@companyID", entity.companyID);
            ctzDoc.AddInputParameters("@letterAuthor", entity.letterAuthor);
            ctzDoc.AddInputParameters("@letterNo", entity.letterNo);
            if (entity.letterDate == null) entity.letterDate = DateTime.Now.ToString("dd/MM/yyyy");
            ctzDoc.AddInputParameters("@letterDate", DateTime.ParseExact(entity.letterDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            return ctzDoc.IUD("sp_CitizenDocument_Insert", CommandType.StoredProcedure);
        }

        public int UpdateByDocID(CitizenDoc_DTO entity)
        {
            ctzDoc.AddInputParameters("@docID", entity.docID);
            ctzDoc.AddInputParameters("@tematikaID", entity.tematikaID);
            ctzDoc.AddInputParameters("@appealCharID", entity.appealCharID);
            ctzDoc.AddInputParameters("@appealTypeID", entity.appealTypeID);
            ctzDoc.AddInputParameters("@docApplyTypeID", entity.docApplyTypeID);
            ctzDoc.AddInputParameters("@name", entity.name);
            ctzDoc.AddInputParameters("@surname", entity.surname);
            ctzDoc.AddInputParameters("@middlename", entity.middlename);
            ctzDoc.AddInputParameters("@citizenshipID", entity.citizenshipID);
            ctzDoc.AddInputParameters("@nationID", entity.nationID);
            ctzDoc.AddInputParameters("@countryID", entity.countryID);
            ctzDoc.AddInputParameters("@cityID", entity.cityID);
            ctzDoc.AddInputParameters("@townID", entity.townID);
            ctzDoc.AddInputParameters("@fulladdress", entity.fulladdress);
            ctzDoc.AddInputParameters("@relatedDocNo", entity.relatedDocNo);
            ctzDoc.AddInputParameters("@relatedDocRegDate", entity.relatedDocRegDate);
            ctzDoc.AddInputParameters("@userID", entity.userID);
            ctzDoc.AddInputParameters("@categoryID", entity.categoryID);
            ctzDoc.AddInputParameters("@genderID", entity.genderID);
            ctzDoc.AddInputParameters("@socialStatusID", entity.socialStatusID);
            ctzDoc.AddInputParameters("@companyID", entity.companyID);
            ctzDoc.AddInputParameters("@letterAuthor", entity.letterAuthor);
            ctzDoc.AddInputParameters("@letterNo", entity.letterNo);
            if (entity.letterDate == null) entity.letterDate = DateTime.Now.ToString("dd/MM/yyyy");
            ctzDoc.AddInputParameters("@letterDate", DateTime.ParseExact(entity.letterDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            return ctzDoc.IUD("sp_CitizenDocument_UpdateByDocID", CommandType.StoredProcedure);
        }

        public Custom_CtzDocument_DTO GetDocumentByDocID(long docID)
        {
            ctzDoc.AddInputParameters("@docID", docID);
            DataTable dt = ctzDoc.GetList("sp_CitizenDoc_GetByDocID", CommandType.StoredProcedure);
            Custom_CtzDocument_DTO doc = new Custom_CtzDocument_DTO();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegNo = dt.Rows[0]["docRegNo"].ToString();
            doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd/MM/yyyy");
            doc.docDayCount = Convert.ToInt32(dt.Rows[0]["docDayCount"]);
            doc.docFinishDate = Convert.ToDateTime(dt.Rows[0]["docFinishDate"]).ToString("dd/MM/yyyy");
            doc.docType = Convert.ToByte(dt.Rows[0]["docType"]);
            doc.docNote = dt.Rows[0]["docNote"].ToString();
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            doc.appealCharID = Convert.ToInt32(dt.Rows[0]["appealCharID"]);
            doc.tematikaID = Convert.ToInt32(dt.Rows[0]["tematikaID"]);
            doc.appealTypeID = Convert.ToInt32(dt.Rows[0]["appealTypeID"]);
            doc.docApplyTypeID = Convert.ToInt32(dt.Rows[0]["docApplyTypeID"]);
            doc.name = dt.Rows[0]["name"].ToString();
            doc.surname = dt.Rows[0]["surname"].ToString();
            doc.middlename = dt.Rows[0]["middlename"].ToString();
            doc.citizenshipID = Convert.ToInt32(dt.Rows[0]["citizenshipID"]);
            doc.nationID = Convert.ToInt32(dt.Rows[0]["nationID"]);
            doc.countryID = Convert.ToInt32(dt.Rows[0]["countryID"]);
            doc.cityID = Convert.ToInt32(dt.Rows[0]["cityID"]);
            doc.townID = Convert.ToInt32(dt.Rows[0]["townID"]);
            doc.fulladdress = dt.Rows[0]["fulladdress"].ToString();
            doc.relatedDocNo= dt.Rows[0]["relatedDocNo"].ToString();
            doc.relatedDocRegDate = dt.Rows[0]["relatedDocRegDate"].ToString();
            doc.userID = Convert.ToInt32(dt.Rows[0]["userID"]);
            doc.genderID= Convert.ToInt32(dt.Rows[0]["genderID"]);
            doc.socialStatusID= Convert.ToInt32(dt.Rows[0]["socialStatusID"]);
            doc.categoryID= Convert.ToInt32(dt.Rows[0]["categoryID"]);
            doc.companyID = Convert.ToInt32(dt.Rows[0]["companyID"]);
            doc.letterAuthor = dt.Rows[0]["letterAuthor"].ToString();
            doc.letterNo = dt.Rows[0]["letterNo"].ToString();
            doc.letterDate = Convert.ToDateTime(dt.Rows[0]["letterDate"]).ToString("dd/MM/yyyy");
            return doc;
        }

        public CtzRegFileDocument GetCtzDocumentByDocID(long docID)
        {
            ctzDoc.AddInputParameters("@docID", docID);
            DataTable dt = ctzDoc.GetList("[sp_CtzRegFileDocument]", CommandType.StoredProcedure);
            CtzRegFileDocument doc = new CtzRegFileDocument();
            doc.docID = Convert.ToInt64(dt.Rows[0]["docID"]);
            doc.docRegNo = dt.Rows[0]["docRegNo"].ToString();
            doc.docRegDate = Convert.ToDateTime(dt.Rows[0]["docRegDate"]).ToString("dd/MM/yyyy");
            doc.docNote = dt.Rows[0]["docNote"].ToString();
            doc.docContent = dt.Rows[0]["docContent"].ToString();
            doc.name = dt.Rows[0]["name"].ToString();
            doc.surname = dt.Rows[0]["surname"].ToString();
            doc.tematika = dt.Rows[0]["tematika"].ToString();
            doc.city = dt.Rows[0]["city"].ToString();
            doc.nation = dt.Rows[0]["nation"].ToString();
            doc.town = dt.Rows[0]["town"].ToString();
            doc.middlename = dt.Rows[0]["middlename"].ToString();
            doc.appealType = dt.Rows[0]["appealType"].ToString();
            doc.docType = dt.Rows[0]["documentType"].ToString();
            doc.gender = dt.Rows[0]["gender"].ToString();
            doc.socialStatus = dt.Rows[0]["socialStatus"].ToString();
            doc.category = dt.Rows[0]["category"].ToString();
            doc.letterAuthor = dt.Rows[0]["letterAuthor"].ToString();
            doc.letterNo = dt.Rows[0]["letterNo"].ToString();
            doc.letterDate = Convert.ToDateTime(dt.Rows[0]["letterDate"]).ToString("dd/MM/yyyy");
            doc.companyName = dt.Rows[0]["companyName"].ToString();
            return doc;
        }
    }
}
