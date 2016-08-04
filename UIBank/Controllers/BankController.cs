using BuisnessLogic;
using DAL;
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
            _logic = new LogicBankSystem(new XmlRepository(file));
        }

        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            _banksModel = _logic.GetListBank();
            return View("Index", _banksModel);
        }

        /// <summary>
        /// Добавление банка
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBank()
        {
            return View(new Bank());
        }

        /// <summary>
        /// POST Добавление банка
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBank(Bank model)
        {
            try
            {
                model.Clients = new List<Client>();
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

        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="idBank"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddClient(string idBank)
        {
            ViewBag.IdBank = idBank;
            return View(new Client());
        }

        /// <summary>
        /// POST Добавление клиента
        /// </summary>
        /// <param name="model"></param>
        /// <param name="idBank"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddClient(Client model, string idBank)
        {
            try
            {
                _logic.AddNewClient(model,new Guid(idBank));
                return RedirectToAction("EditBank", new { id = new Guid(idBank)});
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

        /// <summary>
        /// Удаление банка
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteBank(Guid id)
        {
            _logic.DeleteBank(id);
            return Index();
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idBank"></param>
        /// <returns></returns>
        public ActionResult DeleteClient(Guid id, string idBank)
        {
            _logic.DeleteClient(id);
            return RedirectToAction("EditBank", new { id = new Guid(idBank) });
        }

        /// <summary>
        /// Редактирование банка
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditBank(Guid id)
        {
            Bank bank = _logic.GetListBank(new Bank { Id = id }).FirstOrDefault();
            return View("EditBank", bank);
        }

        /// <summary>
        /// POST редактирование банка
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Редактирование клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idBank"></param>
        /// <returns></returns>
        public ActionResult EditClient(string id, string idBank)
        {
            ViewBag.IdBank = idBank;
            Client client = _logic.GetListClient(new Client { Id = new Guid(id) }).FirstOrDefault();
            return View("EditClient", client);
        }

        /// <summary>
        /// POST Редактирование клиента
        /// </summary>
        /// <param name="client"></param>
        /// <param name="idBank"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditClient(Client client, string idBank)
        {
            try
            {
                _logic.UpdateClient(client);
                return RedirectToAction("EditBank", new { id = new Guid(idBank) });
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
