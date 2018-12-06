using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDM.UI.Class
{
    public class ApplyType
    {
        public List<SelectListItem> TypeList = new List<SelectListItem>()
        {
            new SelectListItem() {Text="İlkin", Value="1"},
            new SelectListItem() { Text="Təkrar", Value="2"}
        };
    }
}