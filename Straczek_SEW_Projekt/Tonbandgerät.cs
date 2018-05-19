using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straczek_SEW_Projekt
{
    class Tonbandgerät:Musikplayer
    {
        public string Tonband { get; set; }
        public Tonbandgerät(int id, string titel, string künstler, string album, string tonband) : base(id, titel, künstler, album)
        {
            ID = id;
            Titel = titel;
            Künstler = künstler;
            Album = album;
            Tonband = tonband;
        }
    }
}
