using System;
using System.Collections.Generic;
using System.Text;

namespace PI.ConvertMoneyOther
{
    public class ConvertingMoney
    {
        private string _nameMoney;
        private double _valueMoney;
        private string _idMoney;
        private double _nominalMoney;
        public string NameMoney { get => _nameMoney; set => _nameMoney = value; }
        public double ValueMoney { get => _valueMoney; set => _valueMoney=value; }
        public string IdMoney { get => _idMoney; set=> _idMoney=value; }
        public double NominalMoney { get => _nominalMoney; set => _nominalMoney = value; }
        public ConvertingMoney(string idMoney, string nameMoney, double valueMoney, double nominalMoney)
        {
            this.IdMoney = idMoney;
            this.NameMoney = nameMoney;
            this.ValueMoney = valueMoney;
            this.NominalMoney = nominalMoney;
        }
        public string toString()
        {
            return "ID: " + this._idMoney + "; Name: " + this._nameMoney + "; Value: " + this._valueMoney +"; Nominal: " + _nominalMoney;
        }
    }
}
