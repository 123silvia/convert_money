using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace converter_money
{
    class ParseJson
    {
        static private List<ConvertMoney> listConvertMoney = new List<ConvertMoney>();
        static internal List<ConvertMoney> ListConvertMoney { get => listConvertMoney; set => listConvertMoney = value; }
        public void GetDataParseJson(string resultJsonString)
        {
            JObject resultData = JObject.Parse(resultJsonString);
            JObject resultConvertMoney = (JObject)resultData["Valute"];
            foreach (JProperty res in (JToken)resultConvertMoney)
            {
                string valueId = System.Convert.ToString(res.Name);
                string valueName = System.Convert.ToString(res.Value["Name"]);
                double valueVal = System.Convert.ToDouble(res.Value["Value"]);
                double nominalValue = System.Convert.ToDouble(res.Value["Nominal"]);
                ListConvertMoney.Add(new ConvertMoney(valueId, valueName, valueVal, nominalValue));
            }
        }
    }
}
