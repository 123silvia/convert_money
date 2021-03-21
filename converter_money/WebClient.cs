using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace converter_money
{
    class WebClient
    {
        private void ConnectParse(string urlText)
        {
            using (var webClient = new System.Net.WebClient())
            {
                string resultJsonString = webClient.DownloadString(urlText);
                ParseJson parseJson = new ParseJson();
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