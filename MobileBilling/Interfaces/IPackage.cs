using MobileBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.PackageCalculations
{
   interface IPackage
    {
        double packagechargersCalculation(CDR call);

    }
}
