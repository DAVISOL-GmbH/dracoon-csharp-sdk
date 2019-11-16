using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dracoon.Sdk.Model {
    public enum AuthMethodType : int {
        BasicOrSql = 0,
        ActiveDirectory = 1,
        Radius = 2,
        OpenId = 3
    }
}
