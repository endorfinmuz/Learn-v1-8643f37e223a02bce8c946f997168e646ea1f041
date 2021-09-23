using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    class RatingGridData
    {
        public RatingGridData(int Id, string Name, int Score)
        {
            this.Id = Id;
            this.Name = Name;
            this.Score = Score;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
