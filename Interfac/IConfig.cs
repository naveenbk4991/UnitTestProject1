using UnitTestProject1.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Interfac
{
    public interface IConfig
    {

        BrowserType GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetWebsite();
        int GetPageloadTimeout();
        int GetElementloadTimeout();


    }
}
