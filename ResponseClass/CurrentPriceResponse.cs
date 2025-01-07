using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation.ResponseClass
{
    public class CurrentPriceResponse
    {
        public Time Time { get; set; }
        public string Disclaimer { get; set; }
        public string ChartName { get; set; }
        public Bpi Bpi { get; set; }
    }

    public class Time
    {
        public string Updated { get; set; }
        public string UpdatedISO { get; set; }
        public string Updateduk { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string Rate { get; set; }
        public string Description { get; set; }
        public double RateFloat { get; set; }
    }

    public class Bpi
    {
        public Currency USD { get; set; }
        public Currency GBP { get; set; }
        public Currency EUR { get; set; }
    }

}
