﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AmiibopediaApp.Models
{

    public class Characters
    {
        public Character[] amiibo { get; set; }
    }

    public class Character
    {
        public string key { get; set; }
        public string name { get; set; }
    }

}
