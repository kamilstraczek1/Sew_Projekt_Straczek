﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Straczek_SEW_Projekt
{
    class CD_Player:Musikplayer
    {
        public double Länge { get; set; }

        public CD_Player(int id, string titel, string künstler, string album, double länge) : base(id, titel, künstler, album)
        {
            ID = id;
            Titel = titel;
            Künstler = künstler;
            Album = album;
            Länge = länge;
            
        }
        public override string ToString()
        {
            return "ID: " + ID + "  Titel: " + Titel + "  Künstler: " + Künstler + "  Album: " + Album + "  Länge: " + Länge + "min";
        }
    }
}
