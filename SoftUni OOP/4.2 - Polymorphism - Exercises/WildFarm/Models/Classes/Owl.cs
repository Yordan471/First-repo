﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Abstract_Classes;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes
{
    public class Owl : Bird
    {
        private const double OwlWeight = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ToString()
        {
            return base.ToString() + "Hoot Hoot";
        }
    }
}
