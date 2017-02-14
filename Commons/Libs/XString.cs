using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

static public class Xstring
{
    static public string ReplaceInsensitive(this String str, String from, String to)
    {
        str = Regex.Replace(str, from, to, RegexOptions.IgnoreCase);
        return str;
    }

    public static Double? KRound(this Double num)
    {
        if (num < 1000)
        {
            return num;
        }

        return num - (num % 1000);
    }

    public static String ToAscii(this String s)
    {
        if (s == null) return "";

        String[][] symbols = { 
                                 new String[] { "[áàảãạăắằẳẵặâấầẩẫậ]", "a" }, 
                                 new String[] { "[đ]", "d" },
                                 new String[] { "[éèẻẽẹêếềểễệ]", "e" },
                                 new String[] { "[íìỉĩị]", "i" },
                                 new String[] { "[óòỏõọôốồổỗộơớờởỡợ]", "o" },
                                 new String[] { "[úùủũụưứừửữự]", "u" },
                                 new String[] { "[ýỳỷỹỵ]", "y" },
                                 new String[] { "[&+?.,)(]", "-" },
                                 new String[] { "[\\s'\" ]", "-" },
                                 new String[] { "-{2,10}", "-" }
                             };
        s = s.ToLower();
        foreach (var ss in symbols)
        {
            s = Regex.Replace(s, ss[0], ss[1]);
        }
        return s;
    }
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source.IndexOf(toCheck, comp) >= 0;
    }

    public static String HighlightKeywords(this String input, String keywords)
    {
        if (input == string.Empty || keywords == string.Empty)
        {
            return input;
        }

        string[] sKeywords = keywords.Split(' ');
        foreach (string sKeyword in sKeywords)
        {
            try
            {
                input = Regex.Replace(input, sKeyword, string.Format("<span class=\"highlighted\">{0}</span>", "$0"), RegexOptions.IgnoreCase);
            }
            catch
            {
                //
            }
        }
        return input;
    }



    /// <summary>
    /// Remove HTML from string with Regex.
    /// </summary>
    public static string StripTagsRegex(this string source)
    {
        return Regex.Replace(source, "<.*?>", string.Empty);
    }

    public static string Remove_Html_Tags(this string Html)
    {
        string Only_Text = Regex.Replace(Html, @"<(.|\n)*?>", string.Empty);
        return Only_Text;
    }

    public static string LimitLength(this string orgText, int maxLength, string append)
    {
        if (orgText == null) return null;
        if (orgText.Length <= maxLength) return orgText;
        orgText = HttpContext.Current.Server.HtmlDecode(orgText);
        var words = orgText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();
        foreach (var word in words)
        {
            if ((sb + word).Length > maxLength)
                return string.Format("{0}{1}", sb.ToString().TrimEnd(' '), append);
            sb.Append(word + " ");
        }
        return string.Format("{0}{1}", sb.ToString().TrimEnd(' '), append);

        //return string.Format("{0}{1}", orgText.Substring(0, maxLength), append);
    }

    public static string ResolveServerUrl(this string serverUrl, bool forceHttps = false)
    {
        if (serverUrl.IndexOf("://") > -1)
            return serverUrl;

        string newUrl = serverUrl;
        Uri originalUri = System.Web.HttpContext.Current.Request.Url;
        newUrl = (forceHttps ? "https" : originalUri.Scheme) +
            "://" + originalUri.Authority + newUrl;
        return newUrl;
    }


    public static string GeneratePassword()
    {
        //Since I'm big on security, I wanted to generate passwords that contained numbers, letters and special
        //characters - and not easily hacked.

        //I started with creating three string variables.
        //This one tells you how many characters the string will contain.
        string PasswordLength = "12";
        //This one, is empty for now - but will ultimately hold the finised randomly generated password
        string NewPassword = "";

        //This one tells you which characters are allowed in this new password
        string allowedChars = "";
        allowedChars = "1,2,3,4,5,6,7,8,9,0";
        allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
        allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
        allowedChars += "~,!,@,#,$,%,^,&,*,+,?";

        //Then working with an array...

        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);

        string IDString = "";
        string temp = "";

        //utilize the "random" class
        Random rand = new Random();

        //and lastly - loop through the generation process...
        for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            IDString += temp;
            NewPassword = IDString;

            //For Testing purposes, I used a label on the front end to show me the generated password.
            //lblProduct.Text = IDString;
        }

        return NewPassword;
    }
}
