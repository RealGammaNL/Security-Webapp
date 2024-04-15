using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Data;
using Domain;
using Security_Webapp.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Net.WebRequestMethods;
using System.ComponentModel;
using System;

//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
//You should have received a copy of the GNU General Public License along with this program.If not, see<https://www.gnu.org/licenses/>. 

namespace Security_Webapp.Controllers
{

    public class HomeController : Controller
    {
        private readonly SecurityDb _context;
        public HomeController(SecurityDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class EncryptModel
        {
            public string EncryptedData { get; set; }
        }


        [HttpPost]
        public async Task<IActionResult> EncryptAndSave([FromBody] EncryptModel model)
        {
            var data = new DataItem { Description = model.EncryptedData };

            _context.Add(data);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<string> ReturnDecryptedData(int id)
        {
            // Retrieve the data item from the database
            var dataItem = await _context.DataItems.FindAsync(id);

            if (dataItem == null)
            {
                return null;
            }

            // Return the encrypted data
            return dataItem.Description;
        }



        [HttpGet]
        public async Task<IActionResult> GetAndDecryptData(int id)
        {
            var _encryptedData = await ReturnDecryptedData(id);
            return Json(new { encryptedData = _encryptedData });
        }
    }
}
