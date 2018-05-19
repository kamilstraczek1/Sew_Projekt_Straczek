using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straczek_SEW_Projekt
{
   abstract class Musikplayer
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Künstler { get; set; }
        public string Album { get; set; }
       
        public Musikplayer(int id, string titel, string künstler, string album)
        {
            ID = id;
            Titel = titel;
            Künstler = künstler;
            Album = album;
        }
    }
}
