using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LabBigSchool_LamQuangTruong.ViewModel
{
    public class FutureDate: ValidationAttribute
    {
        public override bool IsValid (object value)
        {
            DateTime datetime;
            var isvalid = DateTime.TryParseExact(Convert.ToString(value), "dd/M/yyyy", CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out datetime);
            return (isvalid && datetime >DateTime.Now);
        }
    }
}