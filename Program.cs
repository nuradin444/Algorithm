using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayTextFile();//This bit is very important as it allows the textfiles to have a connnection which allows the program to recognise the text files and display them

            // This bit allows the text files to be read in order to use it in the search.
            string[] searchingLine = File.ReadAllLines("Month.txt");
            string[] searchingLine2 = File.ReadAllLines("Year.txt");
            string[] searchingLine3 = File.ReadAllLines("WS1_TMax.txt");
            string[] searchingLine4 = File.ReadAllLines("WS1_TMin.txt");
            string[] searchingLine5 = File.ReadAllLines("WS1_AF.txt");
            string[] searchingLine6 = File.ReadAllLines("WS1_Rain.txt");
            string[] searchingLine7 = File.ReadAllLines("WS1_Sun.txt");


            Console.Write("\n\nEnter a search term to display all lines containing the term: ");
            //This allows the user to enter a commmand to display the results
            string searchTerm = Convert.ToString(Console.ReadLine());




            //This is used in the search where the search uses a for loop to loop around and find the correct year or month
            for (int x = 0; x < searchingLine.Length; x++)
            {

                //An if statement is used to decide which one the user chooses to display. 
                if (searchingLine[x] == searchTerm)
                {
                    //This bit is important as it displays the results in columns. This makes it look more presentable but also easier to read 
                    Console.Write("{0,9} {1,9} {2,9} {3,9} {4,9} {5,9} {6,9} \n", searchingLine[x], searchingLine2[x], searchingLine3[x], searchingLine4[x], searchingLine5[x], searchingLine6[x], searchingLine7[x]);


                }
                if (searchingLine2[x] == searchTerm)
                {
                    //This one also displays the results in columns
                    Console.Write("{0,9} {1,9} {2,9} {3,9} {4,9} {5,9} {6,9} \n", searchingLine[x], searchingLine2[x], searchingLine3[x], searchingLine4[x], searchingLine5[x], searchingLine6[x], searchingLine7[x]);


                }
            }

            // }


            Console.ReadLine();//This stops the window from closing 
        }

        static void DisplayTextFile()//This bit will display the test file
        {
            //i used streamreader in order to read the files which in turn allowed me to display the weather results
            StreamReader reader = File.OpenText(@"Weather\Month.txt");
            String line = reader.ReadLine();
            using (StreamReader alternateReader = File.OpenText(@"Weather\WS1_TMax.txt"))
            {
                line = alternateReader.ReadLine();
                //while loop will loop around in order to find the correct file and then display it. 
                while (line != null)
                {
                    Console.WriteLine("{0}", line);
                    // i used an array which would help me display the results into columns
                    line = alternateReader.ReadLine();
                    string[,] reading = new string[12, 1022];
                    string[] filePaths = new string[12];

                    filePaths[0] = @"Weather\Year.txt";
                    filePaths[1] = @"Weather\Month.txt";
                    filePaths[2] = @"Weather\WS1_TMax.txt";
                    filePaths[3] = @"Weather\WS1_TMin.txt";
                    filePaths[4] = @"Weather\WS1_AF.txt";
                    filePaths[5] = @"Weather\WS1_Rain.txt";
                    filePaths[6] = @"Weather\WS1_Sun.txt";




                    Console.WriteLine("a");
                    Console.WriteLine(filePaths[0]);

                    //This for loop decribes the amount of text files i am using which is the one above. Then the for loop would use it to loop around it 
                    for (int i = 0; i < 6; i++)
                    {
                        // i declared the counter here to help me out with the text file 
                        int counter = 0;
                        foreach (string a in File.ReadLines(filePaths[i]))
                        {
                            //i have used a counter here alondside the string i declared earlier
                            reading[i, counter] = a;
                            counter++;
                        }
                        Console.WriteLine(filePaths[i]);
                    }
                    //Used my second counter here to help me with my while loop 
                    int counter2 = 0;
                    string theline;
                    // Reads the file and as it goes down it displays it line by line 
                    System.IO.StreamReader file2 = new System.IO.StreamReader(@"Weather\Year.txt");
                    while ((theline = file2.ReadLine()) != null)
                    {

                        counter2++;
                    }
                    int[] yearArr = new int[counter2];
                    counter2 = 0;
                    // i used streamreader again here to display my file 
                    System.IO.StreamReader file3 = new System.IO.StreamReader(@"Weather\Year.txt");
                    //This while loop will loop to find the year
                    while ((line = file3.ReadLine()) != null)
                    {
                        yearArr[counter2] = Convert.ToInt32(line);
                        counter2++;
                    }
                    int length = yearArr.Length;

                    int temp = yearArr[0];
                    //This for loop checks if it is the right year and then displays it 
                    for (int i = 0; i < length; i++)
                    {
                        //This for loop does the job of looping around the year
                        for (int j = i + 1; j < length; j++)
                        {
                            if (yearArr[i] > yearArr[j])
                            {
                                temp = yearArr[i];

                                yearArr[i] = yearArr[j];

                                yearArr[j] = temp;
                            }
                        }
                    }
                    //This bit is my bubble sort where i sort the year and display it i use a string and int 
                    string[] arr = File.ReadAllLines("Year.txt");
                    int[] num = Array.ConvertAll(arr, int.Parse);

                    int bubble = 0;
                    //i used a for loop to go around and implement the bubble sort
                    for (int write = 0; write < num.Length; write++)
                    {
                        for (int sort = 0; sort < num.Length - 1 - write; sort++)
                        {
                            if (num[sort] > num[sort + 1])
                            {
                                bubble = num[sort + 1];
                                num[sort + 1] = num[sort];
                                num[sort] = bubble;
                            }
                        }
                    }
                    //This displays it on the console application 
                    for (int i = 0; i < arr.Length; i++)
                        Console.WriteLine(arr[i] + " ");

                    //Now i did the bubble sort for the year
                    string[] num2 = File.ReadAllLines("Month.txt");
                    int[] num3 = new int[1022];
                    int b = 0;
                    //I then used a while loop with a switch statement as i needed to change them first into numbers then back into letters 
                    while (b < num2.Length)
                    {
                        switch (num2[b])
                        {
                            case ("January"):
                                num3[b] = 1;
                                break;
                            case ("February"):
                                num3[b] = 2;
                                break;
                            case ("March"):
                                num3[b] = 3;
                                break;
                            case ("April"):
                                num3[b] = 4;
                                break;
                            case ("May"):
                                num3[b] = 5;
                                break;
                            case ("June"):
                                num3[b] = 6;
                                break;
                            case ("July"):
                                num3[b] = 7;
                                break;
                            case ("August"):
                                num3[b] = 8;
                                break;
                            case ("September"):
                                num3[b] = 9;
                                break;
                            case ("October"):
                                num3[b] = 10;
                                break;
                            case ("November"):
                                num3[b] = 11;
                                break;
                            case ("December"):
                                num3[b] = 12;
                                break;
                        }
                        b++;

                    }

                    //This is where i implemented the bubble sort for the months 

                    for (int write = 0; write < num2.Length; write++)
                    {
                        for (int sort = 0; sort < num3.Length - 1; sort++)
                        {
                            if (num3[sort] > num3[sort + 1])
                            {
                                int bubble2 = num3[sort + 1];
                                num3[sort + 1] = num3[sort];
                                num3[sort] = bubble2;

                            }
                        }
                    }
                    //i then reserved it in order to change the number back to letters by using another switch statement 
                    for (int write = 0; write < num2.Length; write++)
                        switch (num3[write])
                        {
                            case 1:
                                num2[write] = "January";
                                break;
                            case 2:
                                num2[write] = "February";
                                break;
                            case 3:
                                num2[write] = "March";
                                break;
                            case 4:
                                num2[write] = "April";
                                break;
                            case 5:
                                num2[write] = "May";
                                break;
                            case 6:
                                num2[write] = "June";
                                break;
                            case 7:
                                num2[write] = "July";
                                break;
                            case 8:
                                num2[write] = "August";
                                break;
                            case 9:
                                num2[write] = "September";
                                break;
                            case 10:
                                num2[write] = "October";
                                break;
                            case 11:
                                num2[write] = "November";
                                break;
                            case 12:
                                num2[write] = "December";
                                break;
                        }

                    for (int i = 0; i < num3.Length; i++)
                    {
                        //This is where i displayed it
                        Console.WriteLine(num2[i]);
                    }
                    //Using another bubble sort for a another text file 
                    string[] max = File.ReadAllLines("WS1_AF.txt");
                    int[] dec = Array.ConvertAll(max, int.Parse);

                   
                    //Using a for loop in order to sort it 
                    for (int move = 0; move < max.Length; move++)
                    {
                        for (int sort = 0; sort < max.Length - 1 - move; sort++)
                        {
                            if (Convert.ToInt32(max[sort]) > Convert.ToInt32(max[sort + 1]))
                            {
                                string bubble3 = max[sort + 1];
                                max[sort + 1] = max[sort];
                                max[sort] = bubble3;
                                
                            }
                        }
                    }

                    for (int i = 0; i < dec.Length; i++)
                        Console.WriteLine(max[i] + " ");

                    //sorting the rain file 
                    string[] rain = File.ReadAllLines("WS1_Rain.txt");
                   
                    for (int turn = 0; turn < rain.Length; turn++)
                    {
                        for (int sort = 0; sort < rain.Length - 1 - turn; sort++)
                        {
                            if (Convert.ToDouble(rain[sort]) > Convert.ToDouble(rain[sort + 1]))
                            {
                                string bubble3 = rain[sort + 1];
                                rain[sort + 1] = rain[sort];
                                rain[sort] = bubble3;
                               
                            }
                        }
                    }

                    for (int i = 0; i < rain.Length; i++)
                        Console.WriteLine(rain[i] + " ");


                    //sorting the file named sun alongside a bubble sort 
                    string[] sun = File.ReadAllLines("WS1_Sun.txt");

                    for (int turn = 0; turn < sun.Length; turn++)
                    {
                        for (int sort = 0; sort < sun.Length - 1 - turn; sort++)
                        {
                            if (Convert.ToDouble(sun[sort]) > Convert.ToDouble(sun[sort + 1]))
                            {
                                string bubble3 = sun[sort + 1];
                                sun[sort + 1] = sun[sort];
                                sun[sort] = bubble3;
                            }
                        }
                    }

                    for (int i = 0; i < sun.Length; i++)
                        Console.WriteLine(sun[i] + " ");

                    // i had to use a string to read the text file
                    string[] fast = File.ReadAllLines("WS1_TMax.txt");
                    // i used a for loop in order to use a bubble sort.
                    for (int turn = 0; turn < fast.Length; turn++)
                    {
                        for (int sort = 0; sort < fast.Length - 1 - turn; sort++)
                        {
                            if (Convert.ToDouble(fast[sort]) > Convert.ToDouble(fast[sort + 1]))
                            {
                                string bubble3 = fast[sort + 1];
                                fast[sort + 1] = fast[sort];
                                fast[sort] = bubble3;
                                //Console.WriteLine("switched");
                            }
                        }
                    }

                    for (int i = 0; i < fast.Length; i++)
                        Console.WriteLine(fast[i] + " ");


                    //bubble sorting the file 
                    string[] min = File.ReadAllLines("WS1_TMin.txt");
                   //i used a for loop to do the bubble sort 
                    for (int turn = 0; turn < min.Length; turn++)
                    {
                        for (int sort = 0; sort < min.Length - 1 - turn; sort++)
                        {//i had to convert it into double as the numbers were in decimal points 
                            if (Convert.ToDouble(min[sort]) > Convert.ToDouble(min[sort + 1]))
                            {
                                string bubble3 = min[sort + 1];
                                min[sort + 1] = min[sort];
                                min[sort] = bubble3;
                              
                            }
                        }
                    }

                    for (int i = 0; i < min.Length; i++)
                        Console.WriteLine(min[i] + " ");
                    //this displays the sorted files into columns where i spaced it out 
					for(int i = 0; i < min.Length; i++)
						Console.WriteLine("{0,9} {1,9} {2,9} {3,9} {4,9} {5,9} {6,9}", arr[i], num2[i], max[i], rain[i], sun[i], fast[i], min[i]);


                    //This is where the user is prompted to enter the year or month they want to see which is sorted
                    Console.ReadKey();
                    Console.Write("\n\nEnter a Year or Month to display part of the sorted Month and Year:");
                    //This is the search i used where it is again displaying it into columns
                    string searchTerm = Convert.ToString(Console.ReadLine());
                    for (int x = 0; x < arr.Length; x++)
                    {
                        //if statement used to show if what the user enters matches what is inside the text file 
                        if (arr[x] == searchTerm)
                        {

                            Console.Write("{0,9} {1,9}{2,9} {3,9} {4,9} {5,9} {6,9} \n", arr[x], num2[x], max[x], rain[x], sun[x], fast[x], min[x]);


                        }
                        if (num2[x] == searchTerm)
                        {
                            //This displays the result in the console application
                            Console.Write("{0,9} {1,9}{2,9} {3,9} {4,9} {5,9} {6,9} \n", arr[x], num2[x], max[x], rain[x], sun[x], fast[x], min[x]);


                        }
                    }





                    //Console.WriteLine was used in order to see if it worked.
                    Console.WriteLine("c");
                    //This is where i prompt the user to enter a letter "r"
                    string UserResponse = "";
                    Console.WriteLine("TO Display the results of the weather stations press R");
                    UserResponse = Console.ReadLine();
                    //I used this if statement because even if the user writes a capital r or a lower case r it will still display the text file.
                    if (UserResponse == "R" || UserResponse == "r")
                        //This try statement is used because i wanted to see 
                        try
                        {
                            //for loop used in order to space out the columns 
                            for (int i = 0; i < 1022; i++)
                            {
                                for (int a = 0; a < 6; a++)
                                {
                                    Console.Write("{0,10}", reading[a, i]);
                                }
                                Console.Write("\n");

                            }

                            {




                            }
                        }
                        catch (Exception e)
                        {

                            //Error message appears if the test file couldnt be read 
                            Console.WriteLine("Problem reading the file:");
                            Console.WriteLine(e.Message);
                        }
                    //This displays it again 
                    Console.ReadKey();
                }
            }
        }
    }
}

