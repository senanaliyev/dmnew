using IDM.DTO;
using IDM.DTO.Report;
using IDM.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Service
{
    public class rpt_Raporlar_Srv
    {
        rpt_Reports_Rpst reportsRpst = new rpt_Reports_Rpst();

        public List<rpt_xaricolansened_DTO> XaricOlanSened_GetList(int doccontenttype)
        {
            reportsRpst.AddInputParameters("@doccontenttype", doccontenttype);
            DataTable dt = reportsRpst.GetList("sp_rpt_XaricOlanSened", CommandType.StoredProcedure);
            List<rpt_xaricolansened_DTO> reportList = new List<rpt_xaricolansened_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_xaricolansened_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                    docContent = dr["docContent"].ToString(),
                });
            }
            return reportList;
        }

        public List<rpt_ctzreports_DTO> VetendashMuracietleri_GetList(int doccontenttype)
        {
            reportsRpst.AddInputParameters("@doccontenttype", doccontenttype);
            DataTable dt = reportsRpst.GetList("sp_rpt_VetendashMuracietleri", CommandType.StoredProcedure);
            List<rpt_ctzreports_DTO> reportList = new List<rpt_ctzreports_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_ctzreports_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                    docContent = dr["docContent"].ToString(),
                });
            }
            return reportList;
        }

        public List<rpt_tapshiriqvegosterish_DTO> TapshiriqveGosterish_GetList()
        {
            DataTable dt = reportsRpst.GetList("sp_rpt_tapshiriqvegosterish", CommandType.StoredProcedure);
            List<rpt_tapshiriqvegosterish_DTO> reportList = new List<rpt_tapshiriqvegosterish_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_tapshiriqvegosterish_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                    docContent = dr["docContent"].ToString(),
                });
            }
            return reportList;
        }

        public List<rpt_strukturuzre_DTO> StrukturUzre_GetList(int usrID)
        {
            reportsRpst.AddInputParameters("@usrID", usrID);
            DataTable dt = reportsRpst.GetList("sp_rpt_StrukturUzre", CommandType.StoredProcedure);
            List<rpt_strukturuzre_DTO> reportList = new List<rpt_strukturuzre_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_strukturuzre_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                    docContent = dr["docContent"].ToString(),
                });
            }
            return reportList;
        }

        public List<rpt_icraolunmush_DTO> IcraOlunmush_GetList()
        {
            DataTable dt = reportsRpst.GetList("sp_rpt_icraolunmamish", CommandType.StoredProcedure);
            List<rpt_icraolunmush_DTO> reportList = new List<rpt_icraolunmush_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_icraolunmush_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                });
            }
            return reportList;
        }

        public List<rpt_shikayet_DTO> Shikayetler_GetList()
        {
            DataTable dt = reportsRpst.GetList("sp_rpt_icraolunmamish", CommandType.StoredProcedure);
            List<rpt_shikayet_DTO> reportList = new List<rpt_shikayet_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_shikayet_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                    docContent = dr["docContent"].ToString(),
                });
            }
            return reportList;
        }


        public List<rpt_daxilolansened_DTO> DaxilOlanSened_GetList(int doccontenttype1, int doccontenttype2)
        {
            reportsRpst.AddInputParameters("@doccontenttype1", doccontenttype1);
            reportsRpst.AddInputParameters("@doccontenttype2", doccontenttype2);
            DataTable dt = reportsRpst.GetList("sp_rpt_VetendashVeXidmeti", CommandType.StoredProcedure);
            List<rpt_daxilolansened_DTO> reportList = new List<rpt_daxilolansened_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_daxilolansened_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                    docContent = dr["docContent"].ToString(),
                });
            }
            return reportList;
        }

        public List<rpt_icraolunmamish_DTO> IcraOlunmamiw_GetList()
        {
            DataTable dt = reportsRpst.GetList("sp_rpt_icraolunmamish", CommandType.StoredProcedure);
            List<rpt_icraolunmamish_DTO> reportList = new List<rpt_icraolunmamish_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                reportList.Add(new rpt_icraolunmamish_DTO
                {
                    docID = Convert.ToInt64(dr["docID"]),
                    docRegNo = dr["docRegNo"].ToString(),
                    DocContentTypeTitle = dr["DocContentTypeTitle"].ToString(),
                    DocCreatedBy = dr["DocCreatedBy"].ToString(),
                    docRegDate = Convert.ToDateTime(dr["docRegDate"]).ToString("dd/MM/yyyy"),
                    docFinishDate = Convert.ToDateTime(dr["docFinishDate"]).ToString("dd/MM/yyyy"),
                    docCompletedOn = (dr["docCompletedOn"] != DBNull.Value ? Convert.ToDateTime(dr["docCompletedOn"]).ToString("dd/MM/yyyy") : ""),
                    docNote = dr["docNote"].ToString(),
                });
            }
            return reportList;
        }
    }
}
