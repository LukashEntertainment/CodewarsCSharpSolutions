using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class CountSmileys
{

        //    Given an array(arr) as an argument complete the function countSmileys that should return the total number of smiling faces.

        //Rules for a smiling face:


        //Each smiley face must contain a valid pair of eyes. Eyes can be marked as : or ;
        //    A smiley face can have a nose but it does not have to.Valid characters for a nose are - or ~
        //   Every smiling face must have a smiling mouth that should be marked with either ) or D
        //No additional characters are allowed except for those mentioned.

        //Valid smiley face examples: :) :D ;-D :~)
        //Invalid smiley faces: ;( :> :} :]

    // мое решение
    public static int CountSmileysMethod(string[] smileys)
    {
        Dictionary<int, String> smileysPatterns = new Dictionary<int, String>
        {
            [1] = ":D",
            [2] = ":-D",
            [3] = ":~D",
            [4] = ";D",
            [5] = ";~D",
            [6] = ";-D",
            [7] = ";~)",
            [8] = ":~)",
            [9] = ":-)",
            [10] = ";-)",
            [11] = ":)",
            [12] = ";)"
        };

        int count = 0;

        foreach (string str in smileys)
        {
            if (smileysPatterns.ContainsValue(str))
            {
                count++;
            }
        }

        return count;
  }

    //вариант с сайта
    public static int CountSmileysTwo(string[] smileys)
    {
        return smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));
    }
}
