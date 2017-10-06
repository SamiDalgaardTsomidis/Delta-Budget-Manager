using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oprettelse_Af_Budget.Models
{
    public class Container
    {
        public string Text { get; set; }
        public double Value { get; set; }
        public int FK_CategoryID { get; set; }
        public int FK_SubCategory { get; set; }

    }
}