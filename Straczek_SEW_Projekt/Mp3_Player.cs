using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straczek_SEW_Projekt
{
    class Mp3_Player:Musikplayer
    {
        public int Länge { get; set; }
        public int Größe { get; set; }

        public Mp3_Player(int id, string titel, string künstler, string album, int länge, int größe):base(id, titel, künstler, album)
        {
            ID = id;
            Titel = titel;
            Künstler = künstler;
            Album = album;
            Länge = länge;
            Größe = größe;
        }
    }
}
