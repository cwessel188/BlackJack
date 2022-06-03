using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public struct Card
    {
        public int Id;
        public int Face;
        public char Suite;

        /// <summary>
        /// The string representation fo the cards i.e. J♥
        /// </summary>
        /// <returns>J♥, for example</returns>
        public override string ToString()
        {
            string faceStr = Face.ToString();
            switch (Face)
            {
                case (0):
                    faceStr = "K";
                    break;
                case (1):
                    faceStr = "A";
                    break;
                case (11):
                    faceStr = "J";
                    break;
                case (12):
                    faceStr = "Q";
                    break;
            }
            return String.Format("{0}{1} ", faceStr, Suite);
        }
    }
}

// touch2