﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public interface IEngineer
    {
        public Dictionary<string, int> JobNameAndHours { get; }
    }
}
