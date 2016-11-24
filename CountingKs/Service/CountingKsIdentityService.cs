using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountingKs.Service
{
    public class CountingKsIdentityService : CountingKs.Service.ICountingKsIdentityService
    {
        public string CurrentUser
        {
            get { return "michaelburns"; }
        }
    }
}