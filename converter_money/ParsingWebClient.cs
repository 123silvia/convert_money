using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PI.ConvertMoneyOther
{
    class ParsingWebClient
    {
        private void ConnectParse(string urlText)
        {
            using (var webClient = new System.Net.WebClient())
            {
                string resultJsonString = webClient.DownloadString(urlText);
                ParsingJson parseJson = new ParsingJson();
                parseJson.GetDataParseJson(resultJsonString);
            }
        }
        public bool ConnectionToParse(string urlText)
        {
            try
            {
                ConnectParse(urlText);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}