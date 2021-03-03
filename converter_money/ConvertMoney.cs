using System;
using System.Collections.Generic;
using System.Text;

namespace converter_money
{
    public class ConvertMoney
    {
        private string name;
        private double value_f;
        private string id_f;
        public string Name { get => name; set => name = value; }
        public double Value { get => value_f; set => value_f=value; }
        public string Id { get => id_f; set=> id_f=value; }
        public ConvertMoney(string id_f, string name, double value_f)
        {
            this.Id = id_f;
            this.Name = name;
            this.Value = value_f;
        }
        public ConvertMoney(string id_f, string name)
        {
            this.Name = name;
            this.Id = id_f;
        }
        public string toString()
        {
            return "ID: " + this.id_f + "; Name: " + this.name + "; Value: " + this.value_f;
        }
    }
}
