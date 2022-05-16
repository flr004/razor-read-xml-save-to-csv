using Microsoft.AspNetCore.Mvc.RazorPages;
using ReadFromFactoryAndSaveCSV.Extensions;
using ReadFromFactoryAndSaveCSV.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadFromFactoryAndSaveCSV.Pages
{
    public class GetProductModel : PageModel
    {
        private FileHelper _fileHelper = new FileHelper();

        public void OnGet(int productId)
        {
            var items = _fileHelper.GetProducts();

            if (productId != 0)
                SaveProduct(items, productId);
        }

        private void SaveProduct(List<Item> items, int productId)
        {
            var item = items.SingleOrDefault(x => x.prod_id == productId);

            StringBuilder sb = new StringBuilder();

            sb.Append("AL-").Append(item.prod_symbol).Append(";");
            sb.Append("0").Append(";");
            sb.Append(item.prod_name).Append(";");
            sb.Append(item.prod_price).Append(";");
            sb.Append(item.taxpercent).Append(";");
            sb.Append(item.prod_unit).Append(";");
            sb.Append(item.cat_path).Append(";");
            sb.Append(item.prod_barcode).Append(";");
            sb.Append(item.prd_name).Append(";");
            sb.Append(item.prod_shortdesc.StripHTML()).Append(";");

            var productDesc = item.prod_desc.Replace(";", "").Replace("\n", "<br />").StripHTML();
            sb.Append(productDesc).Append(";");

            sb.Append("auto").Append(";");
            sb.Append(_fileHelper.linkReplace(item.prod_name)).Append(";");
            sb.Append(item.prod_symbol).Append(";");
            sb.Append("400").Append(";");

            foreach (var photoUrl in item.prod_img)
            {
                sb.Append(photoUrl).Append(";");
            }

            sb.Append("\r");

            var csvData = new List<string>();
            csvData.Add(sb.ToString());

            string csvFilePath = @"C:\SaveToCsv.csv";

            //Write New File
            //System.IO.File.WriteAllLines(csvFilePath, csvData);

            //AddToEndOfFile
            System.IO.File.AppendAllLines(csvFilePath, csvData);
        }
    }
}