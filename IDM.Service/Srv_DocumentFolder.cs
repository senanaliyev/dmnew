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
    public class Srv_DocumentFolder
    {
        Rpst_DocumentFolder docFolderRep = new Rpst_DocumentFolder();

        public int MoveToFolder(long docID, int folderid)
        {
            docFolderRep.AddInputParameters("@docID", docID);
            docFolderRep.AddInputParameters("@folderid", folderid);
            return docFolderRep.IUD("sp_DocumentFolder_MoveTo", CommandType.StoredProcedure);
        }

        public List<DocumentFolder_DTO> GetList(int usrID)
        {
            docFolderRep.AddInputParameters("@usrID", usrID);
            DataTable dt = docFolderRep.GetList("sp_DocumentFolder_GetList", CommandType.StoredProcedure);
            List<DocumentFolder_DTO> tableRows = new List<DocumentFolder_DTO>();

            foreach (DataRow dr in dt.Rows)
            {
                tableRows.Add(
                    new DocumentFolder_DTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        title = dr["title"].ToString()+" ("+ dr["doccount"].ToString() + ")",
                    });
            }
            return tableRows;
        }

        public int Insert(DocumentFolder_DTO entity)
        {
            docFolderRep.AddInputParameters("@usrID", entity.usrID);
            docFolderRep.AddInputParameters("@title", entity.title);
            return docFolderRep.IUD("sp_DocumentFolder_Insert", CommandType.StoredProcedure);
        }
    }
}
