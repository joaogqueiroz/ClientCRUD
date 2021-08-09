using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetMVC02.Entities;
using ProjetoAspNetMVC02.Interfaces;
using ProjetoAspNetMVC02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC02.Controllers
{
    public class ClientController : Controller
    {
        private IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(ClientRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = new Client();

                    client.Name = model.Name;
                    client.Email = model.Email;
                    _clientRepository.Insert(client);

                    TempData["Messege"] = $"Client {client.Name}, was registred successfully.";
                }
                catch (Exception e)
                {

                    TempData["Messege"] = e.Message;
                }
                
            }
            return View();

        }

        public IActionResult Consult()
        {
            try
            {
                TempData["Consult"] = _clientRepository.Consult();
            }
            catch (Exception e)
            {

                TempData["Messege"] = e.Message;
            }
            return View();
        }
    }
}
