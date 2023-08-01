using HUCEAdmin_API.Common;
using HUCEAdmin_API.Ctrl;
using HUCEAdmin_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HUCEAdmin_API
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        TaiKhoan_Ctrl ctrl = new TaiKhoan_Ctrl();

        [WebMethod]
        public FunctResult_ett<tbl_TaiKhoan> Login(string tk, string mk)
        {
            return ctrl.Login(tk, mk);
        }
        [WebMethod]
        public FunctResult_ett<tbl_TaiKhoan> Logout(string tk)
        {
            return ctrl.Logout(tk);
        }
        [WebMethod]
        public FunctResult_ett<List<tbl_TaiKhoan>> GetData(string tk)
        {
            return ctrl.GetData(tk);
        }
        [WebMethod]
        public FunctResult_ett<tbl_TaiKhoan> GetDataByID(string tk, string id)
        {
            return ctrl.GetDataByID(tk, id);
        }
        [WebMethod]
        public FunctResult_ett<List<tbl_TaiKhoan>> Search_Paging(string tk, string search_val, EnumDataType data_type = EnumDataType.All, int crr_page = 1, int page_size = 10)
        {
            return ctrl.Search_Paging(tk, search_val,data_type,crr_page,page_size);
        }
        [WebMethod]
        public FunctResult_ett<tbl_TaiKhoan> Create(string tk, tbl_TaiKhoan obj)
        {
            return ctrl.Create(tk, obj);
        }
        [WebMethod]
        public FunctResult_ett<tbl_TaiKhoan> Edit(string tk, tbl_TaiKhoan obj)
        {
            return ctrl.Edit(tk, obj);
        }
        [WebMethod]
        public FunctResult_ett<bool> Delete(string tk, string id)
        {
            return ctrl.Delete(tk, id);
        }
    }
}
