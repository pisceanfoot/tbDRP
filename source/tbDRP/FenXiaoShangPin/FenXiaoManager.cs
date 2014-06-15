using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using tbDRP.Http;

namespace tbDRP.FenXiaoShangPin
{
    public class FenXiaoManager
    {
        public static List<FenXiaoModel> GetProductOffline()
        {
            string url = "http://goods.gongxiao.tmall.com/distributor/item/my_item_list.htm?onSale=0";

            string content = NetDataManager.GetString(url);


            return SplitTable(content);
        }

        public static List<FenXiaoModel> SplitTable(string content)
        {
            string body = NetDataManager.GetContent(content, "J_FormMyItemList", ">", "</form>");

            List<FenXiaoModel> list = new List<FenXiaoModel>();

            const string find = "<tr class=\"itemtop\">";
            int index = body.IndexOf(find);
            while (index != -1)
            {
                string tmp;
                int endIndex = body.IndexOf(find, index + 21);
                if (endIndex == -1)
                {
                    tmp = body.Substring(index);
                }
                else
                {
                    tmp = body.Substring(index, endIndex - index);
                }

                FenXiaoModel model = new FenXiaoModel();

                GroupCollection idCol = RegexUtils.Match(tmp, "href=\"(?<url>http://sell.taobao.com/auction/publish/edit.htm\\?item_num_id=(?<id>\\d+?)&auto=false?)\"[^>]+>编辑商品</a></p>");
                model.ID = idCol["id"].Value;
                model.Url = idCol["url"].Value;

                #region 标题
                model.Title = RegexUtils.Match(tmp, "\\<a title=\"产品标题：(?<title>.*?)\"[^>]+\\>")["title"].Value;
                model.TitleStatus = RegexUtils.Match(tmp, "\\<a title=\"产品标题[^>]+\\> 请修改标题，")[0].Success ? "请修改标题" : "";
                #endregion

                model.PartenerCode = RegexUtils.Match(tmp, "\\<span\\>商家编码： (?<name>.*?)\\</span\\>")["name"].Value;

                #region 价格
                GroupCollection priceCol = RegexUtils.Match(tmp, "<td>(?<price>[\\d.]+?)</td>[\\s\\n]*<td>[\\s\\n]*<p>(?<cost>[\\d.]+?)[\\s\\n]*</p>[\\s\\n]*</td>[\\s\\n]*<td>[\\s\\n]*(?<differ>[\\d.]+?)[\\s\\n]*</td>");
                model.Price = priceCol["price"].Value;
                model.Cost = priceCol["cost"].Value;
                model.DiffertialCost = priceCol["differ"].Value;
                #endregion

                #region Partener
                GroupCollection partenerCol = RegexUtils.Match(tmp, "\\<a href=\"http://gongxiao.tmall.com/distributor/user/supplier_detail.htm\\?supplierId=(?<id>\\d+?)\"[^>]*>(?<name>.*?)</a>");
                model.Partener = partenerCol["name"].Value;
                model.PartenerID = partenerCol["id"].Value;
                #endregion

                model.Inventory = RegexUtils.Match(tmp, "<td id=\"J_store[^\"]+\">[^<]*<p>(?<i>.*?)</p>")["i"].Value;

                list.Add(model);
                index = body.IndexOf(find, index + 21);
            }

            return list;
        }
    }
}
