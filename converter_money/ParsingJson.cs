using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace PI.ConvertMoneyOther
{
    class ParsingJson
    {
        static private List<ConvertingMoney> _listConvertMoney = new List<ConvertingMoney>();
        static internal List<ConvertingMoney> ListConvertMoney { get => _listConvertMoney; set => _listConvertMoney = value; }
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
                ListConvertMoney.Add(new ConvertingMoney(valueId, valueName, valueVal, nominalValue));
            }
        }
    }
}
