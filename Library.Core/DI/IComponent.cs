using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DI
{
    public interface IComponent
    {
        void SetUp(IRegisterComponent registerComponent);
    }
}
