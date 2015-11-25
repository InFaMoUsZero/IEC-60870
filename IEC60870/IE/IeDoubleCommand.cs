﻿using IEC60870.IE.Base;
using System;
using System.IO;

namespace IEC60870.IE
{
    public enum DoubleCommandState
    {
        NOT_PERMITTED_A = 0,
        OFF,
        ON,
        NOT_PERMITTED_B
    }

    public class IeDoubleCommand : IeAbstractQualifierOfCommand
    {
        public static DoubleCommandState createDoubleCommandState(int code)
        {
            switch (code)
            {
                case 0:
                    return DoubleCommandState.NOT_PERMITTED_A;
                case 1:
                    return DoubleCommandState.OFF;
                case 2:
                    return DoubleCommandState.ON;
                case 3:
                    return DoubleCommandState.NOT_PERMITTED_B;
                default:
                    throw new ArgumentException("Invalid code");
            }
        }

        public IeDoubleCommand(DoubleCommandState commandState, int qualifier, bool select) : base(qualifier, select)
        {
            value |= (int)commandState;
        }

        public IeDoubleCommand(BinaryReader reader) : base(reader)
        {
        }

        public DoubleCommandState getCommandState()
        {
            return createDoubleCommandState(value & 0x03);
        }

        public override string ToString()
        {
            return "Double command state: " + getCommandState() + ", " + base.ToString();
        }
    }
}
