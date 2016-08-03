using BuisnessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIBank.Controllers
{
    public class BankController : Controller
    {
        LogicBankSystem _logic;
        public BankController()
        {
            var file = ConfigurationManager.AppSettings["FileRepository"];
            _logic = new LogicBankSystem(file);
        }

        public ActionResult Index()
        {
            var model = _logic.GetListBank();
            return View(model);
        }

        public ActionResult DeleteBank(Bank bank)
        {
            _logic.DeleteBank(bank);
            return Index();
        }

        public ActionResult InfoAboutBank(Bank bank)
        {
            _logic.DeleteBank(bank);
            return Index();
        }
    }
}
