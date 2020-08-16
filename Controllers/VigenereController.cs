using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEncryption.Models;

namespace WebEncryption.Controllers
{
    public class VigenereController : Controller
    {
        public IActionResult Input()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Encrypt(string key, string message)
        {
            string result = MessageModel.VigenereEncrypt(message, key);
            return View("Result", result);
        }
        [HttpPost]
        public ViewResult Decrypt(string key, string message)
        {
            string result = MessageModel.VigenereDecrypt(message, key);
            return View("Result", result);
        }
    }
}
