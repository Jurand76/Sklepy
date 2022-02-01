using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Numerics;

namespace shops
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public delegate void GradeAddedBelow3Delegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }
        public string Name { get; set; }
        public string City { get; set; }
    }
}