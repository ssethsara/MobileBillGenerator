using MobileBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations
{
   public abstract class Package
    {
        public abstract double packagechargersCalculation(CDR call);

    }
}
