using System.Collections;
using System.Collections.Generic;
using System;

public class ExpansionAttribute : Attribute
{
    private string _name;
    public ExpansionAttribute(string name)
    {
        _name = name;
    }
}
