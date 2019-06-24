using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFolderApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string baseFolderPath = ConfigurationManager.AppSettings["BaseFolderPath"];

            var now = DateTime.Now;
            var taiwanCalander = new System.Globalization.TaiwanCalendar();
            string taiwanTime = string.Format("{0}{1}{2}",
                                taiwanCalander.GetYear(now).ToString(), now.Month.ToString().PadLeft(2, '0'), now.Day.ToString());

            string taiwanTimePath = Path.Combine(baseFolderPath, taiwanTime);

            if (Directory.Exists(taiwanTimePath) == true)
            {
                Console.WriteLine($"taiwanTimePath already exist [{taiwanTimePath}]");
                Console.WriteLine($"按任意鍵結束!");
                return;
            }

            Directory.CreateDirectory(taiwanTimePath);

            for (int i = 1; i <= 20; i++)
            {
                string taiwanTimeSubPath = Path.Combine(baseFolderPath, taiwanTimePath, taiwanTime + i.ToString().PadLeft(2, '0'));
                Directory.CreateDirectory(taiwanTimeSubPath);
            }

#if DEBUG
            Console.WriteLine($"完成!!按任意鍵結束!");
            Console.Read();
#endif


        }
    }
}
