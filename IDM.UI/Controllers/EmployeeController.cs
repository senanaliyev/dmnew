using IDM.DTO;
using IDM.Service;
using IDM.UI.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDM.UI.Controllers
{


    public class RolePopUpParams
    {
        public int usrID { get; set; }
    }
    [Authorize]
    [MyActionFilter]
    public class EmployeeController : Controller
    {
        EmployeeService employee = new EmployeeService();
        PositionService posServ = new PositionService();
        UserService userServ = new UserService();
        PositionToUserService posToUserServ = new PositionToUserService();


        public ActionResult Index()
        {
            return View(employee.GetList());
        }

        public ActionResult Create()
        {
            PositionService posServ = new PositionService();
            ViewBag.Structure = posServ.GetStructureListByParentID(0);
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(UserDTO userEntity, EmployeeDTO empEntity, PositionToUserDTO posEntity)
        {
            empEntity.usrID = userServ.Insert(userEntity);
            posEntity.usrID = empEntity.usrID;
            employee.Insert(empEntity);
            posToUserServ.Insert(posEntity);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            PositionService posServ = new PositionService();
            ViewBag.Structure = posServ.GetStructureListByParentID(0);
            ViewBag.Positions = posToUserServ.GetPositionsByUserID(id);
            return PartialView("Edit", employee.GetByUserID(id));
        }
        [HttpPost]
        public ActionResult Edit(EmployeeDTO empEntity, PositionToUserDTO posEntity)
        {
            posEntity.usrID = empEntity.usrID;
            employee.Update(empEntity);
            posToUserServ.Insert(posEntity);
            return RedirectToAction("Index");
        }
        public ActionResult MyProfile()
        {
            return View(employee.GetByUserID(Convert.ToInt32(Session["userID"])));
        }
         public ActionResult Profile(int id)
        {
            return PartialView("_Profile", employee.GetByUserID(id));
        }

        public JsonResult FillSubStructures(int id)
        {
            return Json(posServ.GetStructureListByParentID(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillPositions(int id)
        {
            return Json(posServ.GetPositionListByStrID(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Role(int id)
        {
            ViewBag.Roles = new Srv_Role().GetList();
            return PartialView("_Role", new RolePopUpParams { usrID = id });
        }

        public ActionResult GetAssignedRoles(int usrID)
        {
            return Json(new { data = new Srv_Role().GetListByUserID(usrID) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AssignRoleToUser(int usrID, int roleID)
        {
            new Srv_Role().AssignRole(usrID, roleID);
            return Json(new { success = true });
        }

        public JsonResult Delete(long id)
        {
            new Srv_Role().deleteRole(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}