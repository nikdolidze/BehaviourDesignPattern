﻿using System;
/*
 The intetn of this pattern is to given a language define a representation for its grammar along with an interpreter that uses the representaion to iterpret sentences in the lenguage.
 */
namespace Interpreter
{
    public class RomanContext
    {
        public int Input { get; set; }
        public string Output { get; set; } = string.Empty;
        public RomanContext(int intput)
        {
            Input = intput;
        }
    }
    /// <summary>
    /// Abstract expression
    /// </summary>
    public abstract class RomanExpression
    {
        public abstract void Interpret(RomanContext romanContext);
    }

    public class RomanHunderdExpression : RomanExpression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 900) >= 0)
            {
                value.Output += "CM";
                value.Input -= 900;
            }

            while ((value.Input - 500) >= 0)
            {
                value.Output += "D";
                value.Input -= 500;
            }

            while ((value.Input - 400) >= 0)
            {
                value.Output += "CD";
                value.Input -= 400;
            }

            while ((value.Input - 100) >= 0)
            {
                value.Output += "C";
                value.Input -= 100;
            }
        }
    }

    public class RomanTenExpression : RomanExpression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 90) >= 0)
            {
                value.Output += "XC";
                value.Input -= 90;
            }

            while ((value.Input - 50) >= 0)
            {
                value.Output += "L";
                value.Input -= 50;
            }

            while ((value.Input - 40) >= 0)
            {
                value.Output += "XL";
                value.Input -= 40;
            }

            while ((value.Input - 10) >= 0)
            {
                value.Output += "X";
                value.Input -= 10;
            }
        }
    }

    public class RomanOneExpression : RomanExpression
    {
        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 9) >= 0)
            {
                value.Output += "IX";
                value.Input -= 9;
            }

            while ((value.Input - 5) >= 0)
            {
                value.Output += "V";
                value.Input -= 5;
            }

            while ((value.Input - 4) >= 0)
            {
                value.Output += "IV";
                value.Input -= 4;
            }

            while ((value.Input - 1) >= 0)
            {
                value.Output += "I";
                value.Input -= 1;
            }
        }
    }
}
