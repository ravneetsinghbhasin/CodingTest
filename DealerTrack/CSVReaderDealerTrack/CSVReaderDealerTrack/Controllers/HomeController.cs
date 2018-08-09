using CSVReaderDealerTrack.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CSVReaderDealerTrack.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View(new List<DealModel>());
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<DealModel> deals = new List<DealModel>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                //Creating Uploads folder under website
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                //TextFieldParser for parsing and properly handling values containing comma, added encoding for ASCII characters
                using (TextFieldParser parser = new TextFieldParser(filePath, Encoding.GetEncoding("iso-8859-1")))
                {
                    parser.Delimiters = new string[] { "," };
                    if (!parser.EndOfData)
                    {
                        parser.ReadLine();
                    }
                    while (!parser.EndOfData)
                    {
                        string[] parts = parser.ReadFields();
                        deals.Add(new DealModel
                        {
                            DealNumber = parts[0],
                            CustomerName = parts[1],
                            DealershipName = parts[2],
                            Vehicle = parts[3],
                            Price = string.Concat("$",parts[4]),
                            Date = parts[5],
                        });
                    }
                }
            }

            return View(deals);
        }
    }
}