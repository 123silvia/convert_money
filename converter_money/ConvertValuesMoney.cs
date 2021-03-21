using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;

namespace converter_money
{
    class ConvertValuesMoney
    {
        static private double convert1Value;
        static private double convert2Value;
        static private string convert1Text;
        static private string convert2Text;
        static private double convert1Nominal;
        static private double convert2Nominal;
        static public bool checkButton1 = false;
        static public bool checkButton2 = false;
        static private string printSum1;
        static private string printSum2;
        static public double Convert1Value { get => convert1Value; set => convert1Value = value; }
        static public double Convert2Value { get => convert2Value; set => convert2Value = value; }
        static public string Convert1Text { get => convert1Text; set => convert1Text = value; }
        static public string Convert2Text { get => convert2Text; set => convert2Text = value; }
        static public double Convert1Nominal { get => convert1Nominal; set => convert1Nominal = value; }
        static public double Convert2Nominal { get => convert2Nominal; set => convert2Nominal = value; }
        static public string PrintSum1 { get => printSum1; set => printSum1 = value; }
        static public string PrintSum2 { get => printSum2; set => printSum2 = value; }
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
