using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEncryption.Models;

namespace WebEncryption.Controllers
{
    public class CaesarController : Controller
    {
        public IActionResult Input()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Encrypt(string message)
        {
            var result = MessageModel.CaesarEncrypt(message);
            ViewData["isEncrypt"] = true;
            return View("Result", result);
        }
        [HttpPost]
        public ViewResult Decrypt(string message)
        {
            var result = MessageModel.CaesarDecrypt(message);
            ViewData["isEncrypt"] = false;
            return View("Result", result);
        }
    }
}
