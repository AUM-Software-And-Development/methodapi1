using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterpreterClasses.Analyzers
{
    using Enumerations;

    public static class Lexer
    {
        public static ENUM_LexerDirections Direction = ENUM_LexerDirections.Null;

        public static void RemoveNonEnglishValues(List<List<byte>> src, ref List<List<byte>> destination)
        {
            // Uses a reference to denote best practice in ensuring destination.

            int decimalListCount;
            byte decimal_;

            foreach (List<byte> decimalList in src)
            {
                decimalListCount = decimalList.Count();
                List<byte> newList = new List<byte>();
                /* #NOTE: If a list is instantiated before the foreach loop
                 * the compiler tries to optimize and skips over lines of code
                 * causing the reference to just get numerous copies of the same
                 * last item equal to the count of the source. */

                for (int i = 0; i < decimalListCount; i++)
                {
                    decimal_ = decimalList[i];

                    if (decimal_ < 64)
                    { Direction = ENUM_LexerDirections.LowerLimitNotALetter; }

                    else if (decimal_ > 64)
                    {
                        Direction = ENUM_LexerDirections.Right;
                        
                        if (decimal_ < 91)
                        { Direction = ENUM_LexerDirections.LowerCaseLetter; }

                        else if (decimal_ < 96)
                        { Direction = ENUM_LexerDirections.MiddleNotALetter; }

                        else
                        {
                            if (decimal_ < 123)
                            { Direction = ENUM_LexerDirections.UpperCaseLetter; }

                            else
                            { Direction = ENUM_LexerDirections.UpperLimitNotALetter; }
                            // Final condition only met upon being greater than 123.
                        }
                    }

                    switch (Direction)
                    {
                        case ENUM_LexerDirections.LowerCaseLetter:
                            newList.Add(decimal_);
                            break;

                        case ENUM_LexerDirections.UpperCaseLetter:
                            newList.Add(decimal_);
                            break;

                        default:
                            break;
                    }
                }

                destination.Add(newList);
            }
        }
    }
}
