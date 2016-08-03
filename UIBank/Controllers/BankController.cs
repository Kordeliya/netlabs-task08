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
        List<Bank> _banksModel;
        public BankController()
        {
            var file = ConfigurationManager.AppSettings["FileRepository"];
            _logic = new LogicBankSystem(file);
        }

        public ActionResult Index()
        {
            _banksModel = _logic.GetListBank();
            return View("Index", _banksModel);
        }


        public ActionResult AddBank()
        {
            return View(new Bank());
        }

        [HttpPost]
        public ActionResult AddBank(Bank model)
        {
            try
            {
                _logic.AddNewBank(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                Exception inner = e.InnerException;

                while (inner != null)
                {
                    ModelState.AddModelError(string.Empty, inner.Message);
                    inner = inner.InnerException;
                }
            }
            return View();
        }
        public ActionResult DeleteBank(Guid id)
        {
            _logic.DeleteBank(id);
            return Index();
        }

        public ActionResult EditBank(Guid id)
        {
            Bank bank = _logic.GetListBank(new Bank { Id = id }).FirstOrDefault();
            return View("EditBank", bank);
        }
        [HttpPost]
        public ActionResult EditBank(Bank bank)
        {
            try
            {
                _logic.UpdateBank(bank);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                Exception inner = e.InnerException;

                while (inner != null)
                {
                    ModelState.AddModelError(string.Empty, inner.Message);
                    inner = inner.InnerException;
                }
            }
            return View();
        }
    }
}
