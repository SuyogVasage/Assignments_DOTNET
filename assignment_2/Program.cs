using System;
using System.Text.RegularExpressions;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "James Bond is a fictional character created by novelist Ian Fleming in 1953. A British secret agent working for MI6 under the codename 007, he has been portrayed on film by actors Sean Connery, David Niven, George Lazenby, Roger Moore, Timothy Dalton, Pierce Brosnan and Daniel Craig in twenty-seven productions. All but two films were made by Eon Productions, which now holds the adaptation rights to all of Fleming's Bond novels.[1][2]In 1961, producers Albert R.Broccoli and Harry Saltzman purchased the filming rights to Flemings novels.[3] They founded Eon Productions and, with financial backing by United Artists, produced Dr. No, directed by Terence Young and featuring Connery as Bond.[4] Following its release in 1962, Broccoli and Saltzman created the holding company Danjaq to ensure future productions in the James Bond film series.[5] The series currently has twenty-five films, with the most recent, No Time to Die, released in September 2021. With a combined gross of nearly $7 billion to date, it is the fifth-highest-grossing film series.[6] Accounting for inflation, it has earned over $14 billion at current prices.[a] The films have won five Academy Awards: for Sound Effects (now Sound Editing) in Goldfinger (at the 37th Awards), to John Stears for Visual Effects in Thunderball (at the 38th Awards), to Per Hallberg and Karen Baker Landers for Sound Editing, to Adele and Paul Epworth for Original Song in Skyfall (at the 85th Awards) and to Sam Smith and Jimmy Napes for Original Song in Spectre (at the 88th Awards). Several of the songs produced for the films have been nominated for Academy Awards for Original Song, including Paul McCartney's \"Live and Let Die\", Carly Simon's \"Nobody Does It Better\" and Sheena Easton's \"For Your Eyes Only\".In 1982 Albert R. Broccoli received the Irving G.Thalberg Memorial Award.[8]";
            //Asking users choice for operations from assignment
            int switchClose = 0;
            while (switchClose == 0)
            {
                Console.WriteLine("\nPlease enter your choice\n1 for space count\n2 for words count\n3 for fullstop count\n4 for statements count\n5 for digits count\n6 for vowels count \n7 for 'the', 'is', 'to', 'and' count & index\n8 for number and positions of comma\n9 for reverse each word in string\n10 for Reverse entire string\n11 for print each statement in separate line\n12 for print all words decorated using \" \"\n13 for convert first character of each word in upper case\n14 for list 'month names' from string\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    //Space Count
                    case 1:
                        int count = 0;
                        foreach (char c in str)
                        {
                            if (c == ' ')
                            {
                                count++;
                            }
                        }
                        Console.WriteLine(count);
                        break;

                    case 2:
                        //Word Count
                        int word = 0;
                        foreach (char c in str)
                        {
                            if (c == ' ' || c == ',' || c == '.') 
                            {
                                word++;
                            }
                        }
                        Console.WriteLine(word);
                        break;

                    case 3:
                        //Fullstop Count
                        statementFullstop(str);
                        break;

                    case 4:
                        //Statement Count
                        statementFullstop(str);
                        break;

                    case 5:
                        //Digits Count
                        int digit = 0;
                        foreach (char c in str)
                        {
                            if (char.IsDigit(c))
                            {
                                digit++;
                            }
                        }
                        Console.WriteLine(digit);
                        break;

                    case 6:
                        //Vowels Count 
                        int vowel = 0;
                        foreach (char c in str)
                        {
                            if (c == 'a' || c == 'A' || c == 'e' || c == 'E' || c == 'i' || c == 'I' || c == 'o' || c == 'O' || c == 'u' || c == 'U')
                            {
                                vowel++;
                            }
                        }
                        Console.WriteLine(vowel);
                        break;

                    case 7:
                        //'the', 'is', 'to', 'and' count and index
                        foundWord(str, "the");
                        foundWord(str, "is");
                        foundWord(str, "and");
                        foundWord(str, "to");
                        break;

                    case 8:
                        //Count and Index of Comma
                        int comma = 0;
                        char comm = ',';
                        Console.WriteLine("Indexes of comma");
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (comm.Equals(str[i]))
                            {
                                comma++;
                                Console.WriteLine(i);
                            }
                        }
                        Console.WriteLine(comma);
                        break;

                    case 9:
                        //Revesre each word
                        string strRev = "";
                        foreach (string words in str.Split(' '))
                        {
                            string tempstr = "";
                            foreach (char ch in words.ToCharArray())
                            {
                                tempstr = ch + tempstr;
                            }
                            strRev = strRev + tempstr + " ";
                        }
                        Console.WriteLine(strRev);
                        break;

                    case 10:
                        //Reverse entire string
                        string reverseStr = string.Empty;
                        for (int i = str.Length - 1; i >= 0; i--)
                        {
                            reverseStr += str[i];
                        }
                        Console.WriteLine($"Reverse String is:\n {reverseStr}");

                        break;

                    case 11:
                        //Print each statement in separate line
                        foreach (string a in str.Split('.'))
                        {
                            Console.WriteLine(a);
                        }
                        break;

                    case 12:
                        //Print all words decorated using ""
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(str);
                        foreach (var item in matches)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;

                    case 13:
                        //First character of each word in upper case
                        string[] words1 = str.Split(' ');
                        string t = "";
                        foreach (string words in words1)
                        {
                            t += char.ToUpper(words[0]) + words.Substring(1) + ' ';
                        }
                        Console.WriteLine(t);
                        break;

                    case 14:
                        //List month names from String
                        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                        foreach (string item in months)
                        {
                            if (str.Contains(item))
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case 15:
                        switchClose = 1;
                        break;

                    default:
                        Console.WriteLine("\nPlease enter correct choice");
                        break;
                }
            }
            
           

        }
        static void statementFullstop(string str)
        {
            int Fullstop = 0;
             foreach (char c in str)
             {
                   if (c == '.')
                   {
                      Fullstop++;
                    }
             }
               Console.WriteLine(Fullstop);     
         }
        static void foundWord(string str, string word)
        {
            string[] split = str.Split(" ");
            int countW = 0;
            Console.WriteLine($"Indexes of \"{word}\"");
            for (int i = 0; i < split.Length; i++)
            {
                if (word.Equals(split[i]))
                {
                    Console.WriteLine(i);
                    countW++;
                }
            }
            Console.WriteLine($"Count of \"{word}\" = {countW}\n");
        }
            
    }
}
