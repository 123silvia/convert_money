﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;

namespace PI.ConvertMoneyOther
{
    class ConvertingValuesMoney
    {
        static private double _convert1Value;
        static private double _convert2Value;
        static private string _convert1Text;
        static private string _convert2Text;
        static private double _convert1Nominal;
        static private double _convert2Nominal;
        /// <summary>
        /// кнопка вызова смены валюты для одного поля-валюты
        /// </summary>
        static public bool checkButton1 = false;
        /// <summary>
        /// кнопка вызова смены валюты для другого поля-валюты
        /// </summary>
        static public bool checkButton2 = false;
        static private string _printSum1;
        static private string _printSum2;
        static public double Convert1Value { get => _convert1Value; set => _convert1Value = value; }
        static public double Convert2Value { get => _convert2Value; set => _convert2Value = value; }
        static public string Convert1Text { get => _convert1Text; set => _convert1Text = value; }
        static public string Convert2Text { get => _convert2Text; set => _convert2Text = value; }
        static public double Convert1Nominal { get => _convert1Nominal; set => _convert1Nominal = value; }
        static public double Convert2Nominal { get => _convert2Nominal; set => _convert2Nominal = value; }
        static public string PrintSum1 { get => _printSum1; set => _printSum1 = value; }
        static public string PrintSum2 { get => _printSum2; set => _printSum2 = value; }
        static private bool isInteger(String s)
        {
            try
            {
                System.Convert.ToInt64(s);
            }
            catch (FormatException e)
            {
                return false;
            }
            return true;
        }
        static private bool isDouble(String s)
        {
            try
            {
                double res = System.Convert.ToDouble(s);
            }
            catch (FormatException e)
            {
                return false;
            }
            return true;
        }
        static public string Convert1Convert2(string sum)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            if (sum != "0.0" && sum != "" && (isInteger(sum) || isDouble(sum)))
            {
                double result = Math.Round((System.Convert.ToDouble(sum) * Convert1Value * Convert2Nominal) / (Convert1Nominal * Convert2Value), 4);
                return System.Convert.ToString(result);
            }
            return "0.0";
        }
        static public string Convert2Convert1(string sum)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            if (sum != "0.0" && sum != "" && (isInteger(sum) || isDouble(sum)))
            {
                double result = Math.Round((System.Convert.ToDouble(sum) * Convert2Value * Convert1Nominal) / (Convert1Value * Convert2Nominal), 4);
                return System.Convert.ToString(result);
            }
            return "0.0";
        }
        static public void TranspositionConvert()
        {
            string buffVal = Convert1Text;
            Convert1Text = Convert2Text;
            Convert2Text = buffVal;
            double buffVal1=Convert1Value;
            Convert1Value = Convert2Value;
            Convert2Value = buffVal1;
            buffVal1 = Convert1Nominal;
            Convert1Nominal = Convert2Nominal;
            Convert2Nominal = buffVal1;
        }
    }
}
