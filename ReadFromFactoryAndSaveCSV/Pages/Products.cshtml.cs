using ReadFromFactoryAndSaveCSV.Models;
using System.Collections.Generic;
using System.Text;

namespace ReadFromFactoryAndSaveCSV.Pages
{
    public class ProductsModel : Item
    {
        private FileHelper _fileHelper = new FileHelper();

        public List<Item> Products { get; set; }

        public void OnGet()
        {
            var items = _fileHelper.GetProducts();
            Products = items;
        }

        private void SaveToCSV(List<Item> items)
        {
            StringBuilder sb = new StringBuilder();

            int howManyPhoto = 0;

            foreach (var item in items)
            {
                sb.Append(item.prod_symbol).Append(";");
                sb.Append("0").Append(";");
                sb.Append(item.prod_name).Append(";");
                sb.Append(item.prod_price).Append(";");
                sb.Append(item.taxpercent).Append(";");
                sb.Append(item.cat_path).Append(";");
                sb.Append(item.prod_unit).Append(";");
                sb.Append(item.prd_name).Append(";");
                sb.Append(item.prod_shortdesc).Append(";");
                sb.Append(item.prod_desc).Append("<br /><br />").Append(item.prod_info1).Append(item.prod_info2).Append(item.prod_info3).Append(item.prod_info4).Append(item.prod_info5).Append(";");
                sb.Append(item.prod_price).Append(";");
                sb.Append(item.prod_price).Append(";");
                sb.Append("0.00").Append(";");
                sb.Append(item.prod_amount).Append(";");
                sb.Append("auto").Append(";");
                sb.Append("3 day").Append(";");
                howManyPhoto = 0;
                foreach (var photoUrl in item.prod_img)
                {
                    sb.Append(photoUrl).Append(";");
                    howManyPhoto++;
                }
                int counterSecond = 0;
                counterSecond = 19 - howManyPhoto;
                for (int i = 0; i < counterSecond; i++)
                {
                    sb.Append(i).Append(";");
                }

                sb.Append(item.prod_name).Append(";");
                sb.Append(item.prod_id).Append(";");
                sb.Append(item.prod_id).Append(";");
                sb.Append(_fileHelper.linkReplace(item.prod_name)).Append(";");
                sb.Append(item.prod_symbol).Append(";");
                sb.Append("").Append(";");
                sb.Append("PLN").Append(";");
                sb.Append("0.00").Append(";");
                sb.Append(item.prod_pkwiu).Append(";");
                sb.Append(item.prod_weight).Append(";");
                sb.Append(item.prod_id).Append(";");
                sb.Append("1").Append(";");
                sb.Append("0").Append(";");
                sb.Append("0").Append(";");
                sb.Append("0").Append(";");
                sb.Append("0").Append(";");
                sb.Append("0").Append(";");
                sb.Append("5").Append(";");
                sb.Append("6").Append(";");
                sb.Append("").Append(";");
                sb.Append("").Append(";");
                sb.Append("").Append(";");
                sb.Append("").Append(";");
                sb.Append("");

                sb.Append("\r");
            }

            var csvData = new List<string>();
            //csvData.Add(headerLine);
            csvData.Add(sb.ToString());

            string csvFilePath = @"C:\SaveToCsv.csv";

            //Write New File
            //System.IO.File.WriteAllLines(csvFilePath, csvData);

            //AddToEndOfFile
            System.IO.File.AppendAllLines(csvFilePath, csvData);
        }
    }
}