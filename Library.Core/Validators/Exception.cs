using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{

    public class CustomException : System.Exception
    {
        public CustomException(String message) : base(message)
        {

        }

    }
}
