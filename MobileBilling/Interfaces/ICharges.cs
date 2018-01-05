using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Interfaces
{
    public interface ICharges
    {
         int GetOffPeekLocalCharges();

         int GetOffPeekLongDistanceCharges();

         int GetPeekLocalCharges();

         int GetPeekLongDistanceCharges();
    }
}
