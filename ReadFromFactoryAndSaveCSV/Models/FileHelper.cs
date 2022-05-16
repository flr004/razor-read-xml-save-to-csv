using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace ReadFromFactoryAndSaveCSV.Models
{
    public class FileHelper
    {
        public List<Item> GetProducts()
        {
            var _itemList = new List<Item>();
            ArrayList _listPhoto = new ArrayList();

            XPathDocument FromXML = new XPathDocument(@"C:\products.xml");
            XPathNavigator Navigation = FromXML.CreateNavigator();
            XPathNodeIterator ListOfProduct = Navigation.Select("/products/item");
            foreach (XPathNavigator produkt in ListOfProduct)
            {
                var prod_name = produkt.SelectSingleNode("prod_name").Value;
                var prod_id = produkt.SelectSingleNode("prod_id").Value;

                var prod_price = produkt.SelectSingleNode("prod_price").Value;

                var prod_boxamount = produkt.SelectSingleNode("prod_boxamount").Value;
                var prod_tax_id = produkt.SelectSingleNode("prod_tax_id").Value;
                var taxpercent = produkt.SelectSingleNode("taxpercent").Value;
                var prod_oldprice = produkt.SelectSingleNode("prod_oldprice").Value;
                var prod_amount = produkt.SelectSingleNode("prod_amount").Value;
                var prod_unit = produkt.SelectSingleNode("prod_unit").Value;
                var prod_hidden = produkt.SelectSingleNode("prod_hidden").Value;
                var prod_search_hidden = produkt.SelectSingleNode("prod_search_hidden").Value;
                var prod_symbol = produkt.SelectSingleNode("prod_symbol").Value;
                var prod_weight = produkt.SelectSingleNode("prod_weight").Value;
                var prd_name = produkt.SelectSingleNode("prd_name").Value;
                var prod_override_by_stock = produkt.SelectSingleNode("prod_override_by_stock").Value;
                var prod_pkwiu = produkt.SelectSingleNode("prod_pkwiu").Value;
                var prod_ean = produkt.SelectSingleNode("prod_ean").Value;
                var prod_isbn = produkt.SelectSingleNode("prod_isbn").Value;
                var prod_barcode = produkt.SelectSingleNode("prod_barcode").Value;
                var prod_gtu = produkt.SelectSingleNode("prod_gtu").Value;
                var prod_shipping_time = produkt.SelectSingleNode("prod_shipping_time").Value;
                var prod_dimensions = produkt.SelectSingleNode("prod_dimensions").Value;

                var prod_desc = produkt.SelectSingleNode("prod_desc").Value;
                var prod_shortdesc = produkt.SelectSingleNode("prod_shortdesc").Value;
                var prod_info1 = produkt.SelectSingleNode("prod_info1").Value;
                var prod_info2 = produkt.SelectSingleNode("prod_info2").Value;
                var prod_info3 = produkt.SelectSingleNode("prod_info3").Value;
                var prod_info4 = produkt.SelectSingleNode("prod_info4").Value;
                var prod_info5 = produkt.SelectSingleNode("prod_info5").Value;
                var prod_note = produkt.SelectSingleNode("prod_note").Value;
                var prod_link = produkt.SelectSingleNode("prod_link").Value;
                var info_options = produkt.SelectSingleNode("info_options").Value;
                var prod_price_base = produkt.SelectSingleNode("prod_price_base").Value;
                var prod_price_net_base = produkt.SelectSingleNode("prod_price_net_base").Value;
                var prod_price_net = produkt.SelectSingleNode("prod_price_net").Value;

                var cat_path = produkt.SelectSingleNode("cat_path").Value;

                var _productPhoto = produkt.SelectSingleNode("prod_img").InnerXml;

                var photoList = produkt.SelectSingleNode("prod_img").InnerXml;

                var photoListCount = CountPhoto(photoList, "<img>");

                for (int i = 0; i < photoListCount; i++)
                {
                    //Add to table photo
                    _listPhoto.Add(Between(photoList, "<img>", "</img>"));

                    int start = photoList.IndexOf("<img>") + "<img>".Length;
                    int end = photoList.IndexOf("</img>", start);
                    //remove tag img
                    string result = photoList.Remove(start, end - start);
                    //clear list from empty tags
                    result = result.Replace("<img></img>\r\n", "").Replace("<img></img>", "");
                    photoList = result;
                }

                _itemList.Add(new Item
                {
                    prod_name = prod_name,
                    prod_id = int.Parse(prod_id),
                    prod_price = prod_price,
                    prod_boxamount = prod_boxamount,
                    prod_tax_id = prod_tax_id,
                    taxpercent = int.Parse(taxpercent),
                    prod_oldprice = prod_oldprice,
                    prod_amount = prod_amount,
                    prod_unit = prod_unit,
                    prod_hidden = int.Parse(prod_hidden),
                    prod_search_hidden = int.Parse(prod_search_hidden),
                    prod_symbol = prod_symbol,
                    prod_weight = prod_weight,
                    prd_name = prd_name,
                    prod_override_by_stock = prod_override_by_stock,
                    prod_pkwiu = prod_pkwiu,
                    prod_ean = prod_ean,
                    prod_isbn = prod_isbn,
                    prod_barcode = prod_barcode,
                    prod_gtu = prod_gtu,
                    prod_shipping_time = prod_shipping_time,
                    prod_dimensions = prod_dimensions,
                    prod_desc = prod_desc,
                    prod_shortdesc = prod_shortdesc,
                    prod_info1 = prod_info1,
                    prod_info2 = prod_info2,
                    prod_info3 = prod_info3,
                    prod_info4 = prod_info4,
                    prod_info5 = prod_info5,
                    prod_note = prod_note,
                    prod_link = prod_link,
                    info_options = info_options,
                    prod_price_base = prod_price_base,
                    prod_price_net_base = prod_price_net_base,
                    prod_price_net = prod_price_net,
                    cat_path = cat_path,
                    prod_img = _listPhoto.Cast<string>().ToList()
                });

                _listPhoto.Clear();
            }

            return _itemList;
        }

        public string Between(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }

        public int CountPhoto(string str1, string pattern)
        {
            int count = 0;
            int a = 0;
            while ((a = str1.IndexOf(pattern, a)) != -1)
            {
                a += pattern.Length;
                count++;
            }
            return count;
        }

        public string linkReplace(string s)
        {
            int i = s.Length;
            if (i > 100) i = 100;
            s = s.Substring(0, i).ToLower();
            return s.Replace("<h1>", "").Replace("</h1>", "").Replace("<h2>", "").Replace("</h2>", "").Replace("<h3>", "").Replace("</h3>", "").Replace("<h4>", "").Replace("</h4>", "").Replace("<h5>", "").Replace("</h5>", "").Replace("<h6>", "").Replace("</h6>", "").Replace("<h7>", "").Replace("</h7>", "").Replace("<h8>", "").Replace("</h8>", "").Replace("<h9>", "").Replace("</h9>", "").Replace("-", "").Replace(" ", "-").Replace(",", "").Replace(":", "").Replace(";", "").Replace(".", "").Replace("/", "-").Replace("+", "-").Replace("\"", "").Replace("&", "").Replace("?", "").Replace("!", "").Replace("\\", "").Replace(">", "").Replace("<", "").Replace("*", "").Replace("ą", "a").Replace("ć", "c").Replace("ę", "e").Replace("ł", "l").Replace("ń", "n").Replace("ó", "o").Replace("ś", "s").Replace("ż", "z").Replace("ź", "z").ToLower();
        }
    }
}