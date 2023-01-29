﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineAClassPerson
{
    public class Person
    {
		private string name;
		private int age;

        public Person() 
        { 

        }

        public Person (string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
		{
			get { return age; }
			set { age = value; }
		}
	}
}
