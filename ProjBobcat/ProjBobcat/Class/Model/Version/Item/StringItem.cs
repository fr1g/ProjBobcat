﻿using System;
using System.Collections.Generic;

namespace ProjBobcat.Class.Model.Version.Item;

public class StringItem : IItem
{
    static readonly List<string> Qualifiers = new()
    {
        "alpha",
        "beta",
        "milestone",
        "rc",
        "snapshot",
        string.Empty,
        "sp"
    };

    static readonly Dictionary<string, string> Aliases = new()
    {
        { "ga", string.Empty },
        { "final", string.Empty },
        { "release", string.Empty },
        { "cr", "rc" }
    };

    static readonly string ReleaseVersionIndex = Qualifiers.IndexOf(string.Empty).ToString();

    readonly string _value;

    public StringItem(string str, bool followedByDigit)
    {
        if (followedByDigit && str.Length == 1)
            // a1 = alpha-1, b1 = beta-1, m1 = milestone-1
            str = str[0] switch
            {
                'a' => "alpha",
                'b' => "beta",
                'm' => "milestone",
                _ => string.Empty
            };

        _value = Aliases.TryGetValue(str, out var outVal) ? outVal : str;
    }

    public int CompareTo(object obj)
    {
        if (obj is not IItem item)
            // 1-rc < 1, 1-ga > 1
            return ComparableQualifier(_value).CompareTo(ReleaseVersionIndex);

        return item switch
        {
            IntItem or LongItem or BigIntegerItem => -1, // 1.any < 1.1 ?
            StringItem strItem => ComparableQualifier(_value).CompareTo(ComparableQualifier(strItem._value)),
            ListItem => -1, // 1.any < 1-1
            _ => throw new ArgumentOutOfRangeException($"invalid item: {item.GetType()}")
        };
    }

    public bool IsNull()
    {
        return ComparableQualifier(_value).CompareTo(ReleaseVersionIndex) == 0;
    }

    /**
         * Returns a comparable value for a qualifier.
         *
         * This method takes into account the ordering of known qualifiers then unknown qualifiers with lexical
         * ordering.
         *
         * just returning an Integer with the index here is faster, but requires a lot of if/then/else to check for -1
         * or QUALIFIERS.size and then resort to lexical ordering. Most comparisons are decided by the first character,
         * so this is still fast. If more characters are needed then it requires a lexical sort anyway.
         *
         * @param qualifier
         * @return an equivalent value that can be used with lexical comparison
         */
    public static string ComparableQualifier(string qualifier)
    {
        var i = Qualifiers.IndexOf(qualifier);

        return i == -1 ? $"{Qualifiers.Count}-{qualifier}" : i.ToString();
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj is not StringItem that) return false;

        return _value == that._value;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public override string ToString()
    {
        return _value;
    }
}