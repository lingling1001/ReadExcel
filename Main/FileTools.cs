using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FileTools
{


    /// <summary>
    /// 获取文件夹下所有的文件
    /// </summary>
    /// <param name="dirPath">路径</param>
    /// <param name="dirs">文件列表</param>
    /// <param name="extensions">后缀</param>
    public static void GetObjectDirFiles(string dirPath, List<string> dirs, params string[] extensions)
    {
        if (!Directory.Exists(dirPath))
        {
            return;
        }
        foreach (string path in Directory.GetFiles(dirPath))
        {
            //获取所有文件夹中包含后缀
            foreach (var item in extensions)
            {
                if (System.IO.Path.GetExtension(path) == item)//".prefab")
                {
                    dirs.Add(path);
                }
            }
        }

        if (Directory.GetDirectories(dirPath).Length > 0)  //遍历所有文件夹
        {
            foreach (string path in Directory.GetDirectories(dirPath))
            {
                GetObjectDirFiles(path, dirs, extensions);
            }
        }
    }


}
