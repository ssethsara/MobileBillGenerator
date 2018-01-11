using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBilling.Interfaces
{
    public interface ICharges
    {
        int GetPeekLocalCharges();
        int GetPeekLongDistanceCharges();
        int GetOffPeekLocalCharges();
        int GetOffPeekLongDistanceCharges();
        double GetRental();
        TimeSpan getPeekEndTime();
        TimeSpan getPeekStartTime();
        int getFreeLocalPeekMinutes();
        int getFreeLocalOffPeekMinutes();
        int getFreeLongDistancePeekMinutes();
        int getFreeLongDistanceOffPeekMinutes();
        double getDiscounts();

    }
}
