using System;
using System.Collections.Generic;
using System.Text;

namespace LOVA.Models
{
    public class ErrorCase
    {
        public int Id { get; set; }
        public string Well { get; set; }
        public string ErrorDescription { get; set; }
        public string SerialNewAktivator { get; set; }
        public string SerialOldAktivator { get; set; }

        public int MyProperty { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
