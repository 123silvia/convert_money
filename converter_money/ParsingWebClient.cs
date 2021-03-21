using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PI.ConvertMoneyOther
{
    class ParsingWebClient
    {
        /// <summary>
        /// Прооизводим подключение и парсинг данных о валютах
        /// </summary>
        /// <param name="urlText">ссылка на интернет ресурс, с которого берутся данные</param>
        private void ConnectParse(string urlText)
        {
            using (var webClient = new System.Net.WebClient())
            {
                string resultJsonString = webClient.DownloadString(urlText);
                ParsingJson parseJson = new ParsingJson();
                parseJson.GetDataParseJson(resultJsonString);
            }
        }
        /// <summary>
        /// Производим автоматическое подключение к интернет-ресурсу
        /// </summary>
        /// <param name="urlText">ссылка на интернет ресурс</param>
        /// <returns></returns>
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