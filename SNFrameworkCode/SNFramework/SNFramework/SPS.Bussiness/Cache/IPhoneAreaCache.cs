using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPS.Bussiness.Code;

namespace SPS.Bussiness.Cache
{
    public interface IPhoneAreaCache
    {
        PhoneArea GetPhoneAreaByPhoneNumber(string phoneNumber);
    }
}
