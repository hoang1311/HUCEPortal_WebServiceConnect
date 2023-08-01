
using HUCEAdmin.sv1;
using HUCEAdmin_API.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HUCEAdmin.Controllers
{
    public class TaiKhoanController : Controller
    {
        sv1.WebService1SoapClient wsv = new sv1.WebService1SoapClient();
        // GET: TaiKhoan
        public ActionResult Index()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return RedirectToAction("Login", "TaiKhoan");

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            var rs = wsv.Logout(Session[Constant.Sesstion_User_Tk_Acc].ToString());
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
        public ActionResult Create()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return RedirectToAction("Login", "TaiKhoan");

            }
            return View();
        }
        public ActionResult Edit()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return RedirectToAction("Login", "TaiKhoan");

            }
            return View();
        }
        [HttpPost]
        public string Login_act()
        {         
            string tk = Request["txt_taikhoan"].Trim();
            string mk = Request["txt_matkhau"];            
            var rs = wsv.Login(tk, mk);
            Session[Constant.Sesstion_User_Tk_Acc] = tk;
            return JsonConvert.SerializeObject(rs);                      
        }
        [HttpPost]
        public string Get_Info_TaiKhoan()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return null;
            }
            return Session[Constant.Sesstion_User_Tk_Acc].ToString();
        }
        [HttpGet]
        public string GetData()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return "-1";
            }                    
            var rs = wsv.GetData(Session[Constant.Sesstion_User_Tk_Acc].ToString());
            return JsonConvert.SerializeObject(rs);
        }
        [HttpGet]
        public string GetDataByID()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return "-1";
            }
            string id = Request["id"];          
            var rs = wsv.GetDataByID(Session[Constant.Sesstion_User_Tk_Acc].ToString(), id);
            return JsonConvert.SerializeObject(rs);
        }
        [HttpPost]
        public string Create_act()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return "-1";
            }
            
            tbl_TaiKhoan obj = new tbl_TaiKhoan();

            obj.ID = Request["txt_TaiKhoan"];
            obj.TaiKhoan = Request["txt_TaiKhoan"];
            obj.MatKhau = Request["txt_MatKhau"];
            var rs = wsv.Create(Session[Constant.Sesstion_User_Tk_Acc].ToString(), obj);
            return JsonConvert.SerializeObject(rs);
        }
        [HttpPost]
        public string Edit_act()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return "-1";
            }
            tbl_TaiKhoan obj = new tbl_TaiKhoan();

            obj.ID = Request["txt_ID"];
            obj.TaiKhoan = Request["txt_TaiKhoan"];
            obj.MatKhau = Request["txt_MatKhau"];
            var rs = wsv.Edit(Session[Constant.Sesstion_User_Tk_Acc].ToString(), obj);
            return JsonConvert.SerializeObject(rs);
        }
        [HttpPost]
        public string Delete()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return "-1";
            }           
            string id = Request["id"];
            var rs = wsv.Delete(Session[Constant.Sesstion_User_Tk_Acc].ToString(), id);
            return JsonConvert.SerializeObject(rs);
        }
        [HttpGet]
        public string Search()
        {
            if (Session[Constant.Sesstion_User_Tk_Acc] == null)
            {
                return "-1";
            }
            

            string search_val = Request["txt_search_val"];
            string search_type_string = Request["slc_search_type"];
            sv1.EnumDataType search_type;
            Enum.TryParse<sv1.EnumDataType>(search_type_string, out search_type);

            var rs = wsv.Search_Paging(Session[Constant.Sesstion_User_Tk_Acc].ToString(), search_val, search_type, 1, 10);
            return JsonConvert.SerializeObject(rs);
        }
    }
}