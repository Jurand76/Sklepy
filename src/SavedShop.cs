using System;
using System.IO;

namespace shops
{
    public class SavedShop : ShopBase
    {
        public SavedShop(string name, string city) : base(name, city)
        {

        }
        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedBelow3Delegate GradeAddedBelow3;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}_{City}.txt"))
            {
                if (grade < 0 || grade > 5)
                {
                    Console.WriteLine("Only 0-5 grades or q are allowed");
                    return;
                }

                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                    if (grade < 3)
                    {
                        GradeAddedBelow3(this, new EventArgs());
                    }
                }
            }
        }

        public override Statistic GetStatistics()
        {
            var result = new Statistic();
            using (var reader = File.OpenText($"{Name}_{City}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}