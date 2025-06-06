using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public static class PageFactory
    {
        public static T GetPage<T>() where T : BasePage, new()
        {
            return new T();
        }
    }

}
