using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserListTable
{
    public class Common
    {
        public Common()
        {

        }

        public string ReadFile(string fileName)
        {
            var currentDir = Path.GetDirectoryName(new Uri(typeof(Common).Assembly.CodeBase).LocalPath);

            return File.ReadAllText($"{currentDir}/{fileName}");
        }
    }
}
