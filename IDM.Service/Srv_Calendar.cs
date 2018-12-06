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
    public class Srv_Calendar
    {
        Calendar_Repository calendarRep = new Calendar_Repository();

        public Calendar_DTO GetSingleRecord(int id)
        {
            calendarRep.AddInputParameters("@id", id);
            DataTable dt = calendarRep.GetList("sp_Calendar_GetByID", CommandType.StoredProcedure);
            Calendar_DTO singleRow = new Calendar_DTO();

            singleRow.id = Convert.ToInt32(dt.Rows[0]["id"]);
            singleRow.cal_title = dt.Rows[0]["cal_title"].ToString();
            singleRow.cal_date = Convert.ToDateTime(dt.Rows[0]["cal_date"]).ToString("dd/MM/yyyy");
            singleRow.cal_enddate = Convert.ToDateTime(dt.Rows[0]["cal_enddate"]).ToString("dd/MM/yyyy");
            return singleRow;
        }

        public int Insert(Calendar_DTO entity)
        {
            if (entity.cal_date == null) entity.cal_date = DateTime.Now.ToString("dd/MM/yyyy");

            if (entity.cal_enddate == null) entity.cal_enddate = DateTime.Now.ToString("dd/MM/yyyy");

            calendarRep.AddInputParameters("@cal_date", DateTime.ParseExact(entity.cal_date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));

            calendarRep.AddInputParameters("@cal_enddate", DateTime.ParseExact(entity.cal_enddate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));

            calendarRep.AddInputParameters("@cal_title", entity.cal_title);
            return calendarRep.IUD("sp_Calendar_Insert", CommandType.StoredProcedure);
        }

        public int Update(Calendar_DTO entity)
        {
            calendarRep.AddInputParameters("@id", entity.id);
            if (entity.cal_date == null) entity.cal_date = DateTime.Now.ToString("dd/MM/yyyy");
            calendarRep.AddInputParameters("@cal_date", DateTime.ParseExact(entity.cal_date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            calendarRep.AddInputParameters("@cal_enddate", DateTime.ParseExact(entity.cal_enddate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            calendarRep.AddInputParameters("@cal_title", entity.cal_title);
            return calendarRep.IUD("sp_Calendar_UpdateByID", CommandType.StoredProcedure);
        }
        public List<Calendar_DTO> GetRows()
        {
            DataTable dt = calendarRep.GetList("sp_Calendar_GetList", CommandType.StoredProcedure);
            List<Calendar_DTO> calendarRows = new List<Calendar_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                calendarRows.Add(
                    new Calendar_DTO
                    {
                        id = Convert.ToInt32(dr["id"]),
                        cal_title = dr["cal_title"].ToString(),
                        cal_date = Convert.ToDateTime(dr["cal_date"]).ToString("dd/MM/yyyy"),
                        cal_enddate = Convert.ToDateTime(dr["cal_enddate"]).ToString("dd/MM/yyyy")
                    });
            }
            return calendarRows;
        }

        public List<DateTime> GetDaysSeparately()
        {
            DateTime beginDate;
            DateTime endDate;
            int totalDays = 0;
            List<DateTime> alldays = new List<DateTime>();
            foreach (var item in GetRows())
            {
                beginDate = Convert.ToDateTime(DateTime.ParseExact(item.cal_date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                endDate = Convert.ToDateTime(DateTime.ParseExact(item.cal_enddate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                totalDays = Convert.ToInt16((endDate - beginDate).TotalDays);
                for (int i = 0; i <= totalDays; i++)
                {
                    alldays.Add(beginDate.AddDays(i));
                }
            }
            return alldays;
        }
    }
}
