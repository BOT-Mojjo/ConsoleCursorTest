using System;
using System.Collections.Generic;
static class database{
    static public List<(string str, int column, int row)> onScreenText = new List<(string str, int column, int row)>();
    static public List<(string str, int word , int rowInText )> onScreenTextPrime = new List<(string str, int column, int row)>();

    static public void Clear(){
        onScreenText.RemoveRange(0,onScreenText.Count);
        onScreenTextPrime.RemoveRange(0,onScreenTextPrime.Count);
    }
}