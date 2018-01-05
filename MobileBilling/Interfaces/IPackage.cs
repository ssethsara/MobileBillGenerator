﻿using MobileBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Interfaces
{
   interface IPackage
    {
        double CalculateChargers(int peektime, int duration, bool isLocal);

    }
}
