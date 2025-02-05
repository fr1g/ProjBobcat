﻿using System;

namespace ProjBobcat.Class.Model.Version.Item;

public class LongItem : IItem
{
    readonly long _value;

    public LongItem(string longStr)
    {
        _value = long.TryParse(longStr, out var outLong) ? outLong : 0;
    }

    public int CompareTo(object obj)
    {
        if (obj is not IItem item) return _value == 0 ? 0 : 1; // 1.0 == 1, 1.1 > 1

        switch (item)
        {
            case IntItem:
                return 1;
            case LongItem longItem:
                var itemValue = longItem._value;
                return _value.CompareTo(itemValue);
            case BigIntegerItem:
                return -1;
            case StringItem:
                return 1; // 1.1 > 1-sp
            case ListItem:
                return 1; // 1.1 > 1-1
            default:
                throw new ArgumentOutOfRangeException($"invalid item: {item.GetType()}");
        }
    }

    public bool IsNull()
    {
        return _value == 0;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj is not LongItem that) return false;

        return _value == that._value;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}