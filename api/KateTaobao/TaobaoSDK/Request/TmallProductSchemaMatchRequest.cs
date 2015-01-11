using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.product.schema.match
    /// </summary>
    public class TmallProductSchemaMatchRequest : ITopRequest<TmallProductSchemaMatchResponse>
    {
        /// <summary>
        /// 商品发布的目标类目，必须是叶子类目
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 入参字段信息<?xml version="1.0" encoding="utf-8"?> <itemParam>     <field id="title" name="商品标题" type="input">   <value>Samsung/三星 N7102 测试商品不要拍</value>     </field>     <field id="sell_point" name="商品卖点" type="input">      <value>测试专用</value>     </field> </itemParam>
        /// </summary>
        public string Propvalues { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "tmall.product.schema.match";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("propvalues", this.Propvalues);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("category_id", this.CategoryId);
            RequestValidator.ValidateRequired("propvalues", this.Propvalues);
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
