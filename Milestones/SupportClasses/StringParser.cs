using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Milestones.SupportClasses
{
    public class StringParser
    {
        public ArrayList ParseSentence(string sTextToParse)
        {
            string sTemp = sTextToParse;
            sTemp = sTemp.Replace(Environment.NewLine, " ");

            // split the string using sentence terminations
            char[] arrSplitChars = { '.', '?', '!' };  // things that end a
           // sentence

            //do the split
            string[] splitSentences = sTemp.Split(arrSplitChars,
            StringSplitOptions.RemoveEmptyEntries);

            ArrayList al = new ArrayList();
            for (int i = 0; i < splitSentences.Length; i++)
            {
                splitSentences[i] = splitSentences[i].ToString().Trim();
                al.Add(splitSentences[i].ToString());
            }

            // show statistics
            //lblCharCount.Text = "Character Count: " +
            //GenerateCharacterCount(sTemp).ToString();
            //lblSentenceCount.Text = "Sentence Count: " +
            //GenerateSentenceCount(splitSentences).ToString();
            //lblWordCount.Text = "Word Count: " +
            //GenerateWordCount(al).ToString();

            return al;
        }
    }
    public class Image
    {
        public void UploadImage()
        {
            //if (FileuploadImage.HasFile)
            //{
            //}
        }
    }
}