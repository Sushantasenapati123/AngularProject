using ApiForAngular.Model;
using ApiForAngular.Repository;

using Microsoft.AspNetCore.Mvc;
using PdfSharp;
using PdfSharpCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace ApiForAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Irepo _repo;
        public ProductController(Irepo prodService)
        {
            _repo = prodService;
        }

        [HttpGet]   //[HttpGet("GetallProduct")]//[HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetallProduct()
        {
            return await _repo.GetAllproduct();
        }
        // [HttpGet("generatepdf")]
        //public async Task<IActionResult> GeneratePDF()
        //{
        //    PdfSharpCore.Pdf.PdfDocument document = new PdfSharpCore.Pdf.PdfDocument();
        //    string s;
        //    string[] copies = { "Employee copy", "Comapny Copy" };
        //    for (int i = 0; i < copies.Length; i++)
        //    {
        //        List<Entity> detail = await this._repo.GetAllproduct();
        //        string htmlcontent = "<div style='width:100%; text-align:center'>";
        //        htmlcontent += "<h2>" + copies[i] + "</h2>";
        //        htmlcontent += "<h2>Employee Data</h2>";
        //        htmlcontent += "<hr>";
        //        htmlcontent += "<br>";
        //        htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
        //        htmlcontent += "<thead style='font-weight:bold'>";
        //        htmlcontent += "<tr>";
        //        htmlcontent += "<td style='border:1px solid #000'> Product ID </td>";
        //        htmlcontent += "<td style='border:1px solid #000'> Product Name </td>";
        //        htmlcontent += "<td style='border:1px solid #000'> Product Quantity </td>";
        //        htmlcontent += "<td style='border:1px solid #000'> Product Price </td >";
               
        //        htmlcontent += "</tr>";
        //        htmlcontent += "</thead >";

        //        htmlcontent += "<tbody>";
        //        if (detail != null && detail.Count > 0)
        //        {
        //            detail.ForEach(item =>
        //            {
        //                htmlcontent += "<tr>";
        //                htmlcontent += "<td style='border:1px solid #000'>" + item.pid + "</td>";
        //                htmlcontent += "<td style='border:1px solid #000'>" + item.pname + "</td>";
        //                htmlcontent += "<td style='border:1px solid #000'>" + item.pqty + "</td >";
        //                htmlcontent += "<td style='border:1px solid #000'>" + item.price + "</td>";
                       
        //                htmlcontent += "</tr>";
        //            });
        //        }
        //        htmlcontent += "</tbody>";

        //        htmlcontent += "</table>";
        //        htmlcontent += "</div>";

        //        htmlcontent += "</div>";

        //        PdfGenerator.AddPdfPages(document, htmlcontent, (PdfSharpCore.PageSize)PdfSharp.PageSize.A4);
        //    }
        //    byte[]? response = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        document.Save(ms);
        //        response = ms.ToArray();
        //    }
        //    string Filename = "Employee" + ".pdf";
        //    return File(response, "application/pdf", Filename);
        //}

        [HttpPut("{pid}")]
        public async Task<ActionResult<Entity>> PostProduct(int pid, Entity product)
        {
            if (pid != product.pid)
            {
                return BadRequest();
            }

            await _repo.CreateAndUpdate(product);

            return CreatedAtAction("GetallProduct", new { pid = product.pid }, product);
        }

        [HttpDelete("{pid}")]
        public async Task<ActionResult<Entity>> DeleteProduct(int pid)
        {
            var product = await _repo.GetProductByid(pid);
            if (product == null)
            {
                return NotFound();
            }
            await _repo.Delete(pid);

            return product;
        }

        [HttpGet("{pid}")]
        public async Task<ActionResult<Entity>> GetallProductbyid(int pid)
        {
            return await _repo.GetProductByid(pid);
        }
    }
}
