using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMatrimony.DAL;

namespace eMatrimony.BLL.Model
{
    public class CreateNewProfileModel
    {
        public Profile Profile { get; set; }
        public string Password { get; set; }
    }
}
