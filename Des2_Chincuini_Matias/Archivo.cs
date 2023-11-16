using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Des2_Chincuini_Matias
{
    public class Archivo
    {
       public string Name { get; set; } 
       public string Path { get; set; } 
       public Archivo(string name, string path) {
            Name = name;
            Path = path;
        }
    }
}