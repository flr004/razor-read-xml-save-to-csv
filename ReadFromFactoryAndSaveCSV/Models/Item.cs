using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ReadFromFactoryAndSaveCSV.Models
{
    public class Item : PageModel
    {
        public string prod_name { get; set; }
        public int prod_id { get; set; }

        public string prod_price { get; set; }

        public string prod_boxamount { get; set; }
        public string prod_tax_id { get; set; }
        public int taxpercent { get; set; }
        public string prod_oldprice { get; set; }
        public string prod_amount { get; set; }
        public string prod_unit { get; set; }
        public int prod_hidden { get; set; }
        public int prod_search_hidden { get; set; }
        public string prod_symbol { get; set; }
        public string prod_weight { get; set; }
        public string prd_name { get; set; }
        public string prod_override_by_stock { get; set; }
        public string prod_pkwiu { get; set; }
        public string prod_ean { get; set; }
        public string prod_isbn { get; set; }
        public string prod_barcode { get; set; }
        public string prod_gtu { get; set; }
        public string prod_shipping_time { get; set; }
        public string prod_dimensions { get; set; }

        public string prod_desc { get; set; }
        public string prod_shortdesc { get; set; }
        public string prod_info1 { get; set; }
        public string prod_info2 { get; set; }
        public string prod_info3 { get; set; }
        public string prod_info4 { get; set; }
        public string prod_info5 { get; set; }
        public string prod_note { get; set; }
        public string prod_link { get; set; }
        public string info_options { get; set; }
        public string prod_price_base { get; set; }
        public string prod_price_net_base { get; set; }
        public string prod_price_net { get; set; }

        public string cat_path { get; set; }

        public List<string> prod_img { get; set; }
    }
}