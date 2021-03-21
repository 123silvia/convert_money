using System;
using System.Collections.Generic;
using System.Text;

namespace converter_money
{
    public class ConvertMoney
    {
        private string nameMoney;
        private double valueMoney;
        private string idMoney;
        private double nominalMoney;
        public string NameMoney { get => nameMoney; set => nameMoney = value; }
        public double ValueMoney { get => valueMoney; set => valueMoney=value; }
        public string IdMoney { get => idMoney; set=> idMoney=value; }
        public double NominalMoney { get => nominalMoney; set => nominalMoney = value; }
        public ConvertMoney(string idMoney, string nameMoney, double valueMoney, double nominalMoney)
        {
            this.IdMoney = idMoney;
            this.NameMoney = nameMoney;
            this.ValueMoney = valueMoney;
            this.NominalMoney = nominalMoney;
        }
        public string toString()
        {
            return "ID: " + this.idMoney + "; Name: " + this.nameMoney + "; Value: " + this.valueMoney +"; Nominal: " + nominalMoney;
        }
    }
}
