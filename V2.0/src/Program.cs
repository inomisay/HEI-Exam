// Target Framework .NET 7.0

// using file operations

Console.WriteLine("                     Welcome To");
Console.WriteLine("    Higher Education Institution (HEI) - Exam");
Console.WriteLine("  Yükseköğretim Kurumları Sınavı (YKS) - Sınavı\n");

/************************************************************************************************************************/
// Candidates
// create the file for Candidates datas!
// StreamWriter candidates_file = File.CreateText("candidates.txt");

// ERROR: If there isnt any file by that name
try
{
    // Open the .txt file for candidate datas
    StreamReader candidates_file = File.OpenText("candidates.txt");

    // Read each line of the file into a string array. 
    string[] candidates = System.IO.File.ReadAllLines("candidates.txt");
    /*
    // Each element of the array is one line of the file.
    for (int i = 0; i < candidates.Length; i++)
    Console.WriteLine(candidates[i]);
    */
    string[,] temp_1 = new string[candidates.Length, 31];

    // ERROR: The number of candidates is dynamic (maximum 40).

    // no, name surname, diploma-grade, dept-choice1, dept-choice2, dept-choice3, answer1, answer2, answer3, ..., answer251
    for (int i = 0; i < temp_1.GetLength(0); i++) // line
    {
        for (int j = 0; j < temp_1.GetLength(1); j++) // elements
        {
            temp_1[i, j] = candidates[i].Split(',')[j];
        }
    }
    // -The first three elements are the candidate’s personal information
    // - After that, three elements are the candidate’s department choices to where she/he wishes to enroll
    string[,] candidatesInfo = new string[candidates.Length, 6];
    // - The last twenty-five elements are the exam answers of the candidate.
    string[,] candidatesExamAnswer = new string[candidates.Length, 25];
    int k = 0;
    for (int i = 0; i < temp_1.GetLength(0); i++)
    {
        for (int j = 0; j < temp_1.GetLength(1); j++)
        {
            if (j < 6)
            {
                candidatesInfo[i, j] = temp_1[i, j];
            }
            else
            {
                candidatesExamAnswer[i, k] = temp_1[i, j];
                k++;
            }
        }
        k = 0;
    }

    int[] diploma_grade = new int[candidates.Length];

    for (int i = 0; i < candidates.GetLength(0); i++)
    {
        diploma_grade[i] = Convert.ToInt32(temp_1[i, 2]);
    }

    // ERROR: The number of candidates is dynamic (maximum 40).

    // close the files
    candidates_file.Close();

    /************************************************************************************************************************/
    // Department
    // create the file for Departments datas!
    // StreamWriter department_file = File.CreateText("departments.txt");

    // ERROR: If there isnt any file by that name

    // Open the .txt file for candidate datas
    StreamReader departments_file = File.OpenText("departments.txt");

    // Read each line of the file into a string array.
    string[] departments = System.IO.File.ReadAllLines("departments.txt");
    /*
    // Each element of the array is one line of the file.
    for (int i = 0; i < department_lines.Length; i++)
    Console.WriteLine(department_lines[i]);
    */
    string[,] temp_2 = new string[departments.Length, 3];

    // ERROR: The number of departments is dynamic (maximum 10).

    // dept-no, dept-name, quotaq
    for (int i = 0; i < temp_2.GetLength(0); i++) // line
    {
        for (int j = 0; j < temp_2.GetLength(1); j++) // elements
        {
            temp_2[i, j] = departments[i].Split(',')[j];
        }
    }

    // ERROR: The maximum quota for any department is 8.

    int[] quota = new int[departments.Length];

    for (int i = 0; i < temp_2.GetLength(0); i++)
    {
        quota[i] = Convert.ToInt32(temp_2[i, 2]);
    }

    // close the files
    departments_file.Close();

    /************************************************************************************************************************/
    // Answer Sheet
    char[] key = { 'A', 'B', 'D', 'C', 'C', 'C', 'A', 'D', 'B', 'C', 'D', 'B', 'A', 'C', 'B', 'A', 'C', 'D', 'C', 'D', 'A', 'D', 'B', 'C', 'D' };

    // changing array character to the string array 
    string[] examkey = null;
    Array.Resize(ref examkey, key.Length);

    for (int i = 0; i < key.Length; i++)
    {
        examkey[i] = new string(key[i], 1);
    }

    /*
    Grades
    Every correct answer will be graded as 4 points
    The maximum grade is 100.
    Empty answers will not affect the grading.
    The candidate will lose 3 points for each wrong answer.
    */

    // controling the exam answers withe the key
    int[,] grade = new int[candidatesExamAnswer.GetLength(0), candidatesExamAnswer.GetLength(1)];
    int[] gradeint = new int[candidatesExamAnswer.GetLength(0)];
    for (int i = 0; i < candidatesExamAnswer.GetLength(0); i++)
    {
        for (int j = 0; j < candidatesExamAnswer.GetLength(1); j++)
        {
            if (candidatesExamAnswer[i, j] == examkey[j])
            {
                grade[i, j] = 4;
            }
            else if (candidatesExamAnswer[i, j] == " ")
            {
                grade[i, j] = 0;
            }
            else
            {
                grade[i, j] = -3;
            }
            gradeint[i] = gradeint[i] + grade[i, j];
        }
    }

    // Int array to string array
    string[] score = gradeint.Select(i => i.ToString()).ToArray();

    // Result of the Exam
    string[,] examResult = new string[candidatesInfo.GetLength(0), 3];

    for (int i = 0; i < examResult.GetLength(0); i++)
    {
        for (int j = 0; j < examResult.GetLength(1); j++)
        {
            if (j < 2)
            {
                examResult[i, j] = candidatesInfo[i, j];
            }
            else
            {
                examResult[i, j] = score[i];
            }
        }
    }

    int length = 0;
    for (int i = 0; i < temp_1.GetLength(0); i++) // temp_1 student numbers
    {
        if (temp_1[i, 1].Length > length) // temp_1 candidates row
        {
            length = temp_1[i, 1].Length;
        }
    }
    // Output
    Console.WriteLine("\n✼The grades of all candidates:");
    Console.Write("Number    Name & Surname");
    for (int i = 0; i < length - 3; i++)
    {
        Console.Write(" ");
    }
    Console.WriteLine("Grade");
    for (int i = 0; i < candidatesInfo.GetLength(0); i++)
    {
        for (int j = 0; j < candidatesInfo.GetLength(1) - 4; j++)
        {
            Console.Write(candidatesInfo[i, j] + "       ");
        }
        for (int j = 0; j < length + 5 - candidatesInfo[i, 1].Length; j++) //length + 5(space)
        {
            Console.Write(" ");
        }
        Console.Write(gradeint[i]);

        Console.WriteLine();
    }



    /************************************************************************************************************************/
    //Department Choice

    int[,] winers = new int[temp_1.GetLength(0), 2]; // showing the number and the points

    int[] number = new int[40]; // number of students
    for (int i = 0; i < temp_1.GetLength(0); i++)
    {
        number[i] = Convert.ToInt32(temp_1[i, 0]);
    }
    // number of stundent and their scores
    for (int i = 0; i < examResult.GetLength(0); i++)
    {
        for (int j = 0, l = 0; j < winers.GetLength(1); j++, l++)
        {
            winers[i, 0] = number[i];
            winers[i, 1] = gradeint[i];
        }
    }

    // BUBBLE Sort the grades
    int[] temp = new int[2];

    for (int i = 0; i < winers.GetLength(0) - 1; i++)
    {
        int j;
        j = 0;
        for (; j < winers.GetLength(0) - 1; j++)
        {
            if ((winers[j, 1] < winers[j + 1, 1]) || (winers[j, 1] == winers[j + 1, 1]))
            {
                //make a swap
                //put array record j into temp holder
                temp[0] = winers[j, 0];
                temp[1] = winers[j, 1];

                //copy j + 1 into j
                winers[j, 0] = winers[j + 1, 0];
                winers[j, 1] = winers[j + 1, 1];

                //copy temp into j + 1
                winers[j + 1, 0] = temp[0];
                winers[j + 1, 1] = temp[1];

            }
        }
    }

    string[] temp1 = new string[6];
    // Sorting the candidatesInfo by the grades that students got.with bubble sort.
    for (int i = 0; i < candidatesInfo.GetLength(0) - 1; i++)
    {
        int j;
        j = 0;
        for (; j < candidatesInfo.GetLength(0) - 1; j++)
        {
            if (Convert.ToInt32(candidatesInfo[j, 0]) == winers[j + 1, 0])
            {
                //make a swap
                //put array record j into temp holder
                temp1[0] = candidatesInfo[j, 0];
                temp1[1] = candidatesInfo[j, 1];
                temp1[2] = candidatesInfo[j, 2];
                temp1[3] = candidatesInfo[j, 3];
                temp1[4] = candidatesInfo[j, 4];
                temp1[5] = candidatesInfo[j, 5];

                //copy j + 1 into j
                candidatesInfo[j, 0] = candidatesInfo[j + 1, 0];
                candidatesInfo[j, 1] = candidatesInfo[j + 1, 1];
                candidatesInfo[j, 2] = candidatesInfo[j + 1, 2];
                candidatesInfo[j, 3] = candidatesInfo[j + 1, 3];
                candidatesInfo[j, 4] = candidatesInfo[j + 1, 4];
                candidatesInfo[j, 5] = candidatesInfo[j + 1, 5];

                //copy temp into j + 1
                candidatesInfo[j + 1, 0] = temp1[0];
                candidatesInfo[j + 1, 1] = temp1[1];
                candidatesInfo[j + 1, 2] = temp1[2];
                candidatesInfo[j + 1, 3] = temp1[3];
                candidatesInfo[j + 1, 4] = temp1[4];
                candidatesInfo[j + 1, 5] = temp1[5];
            }
        }
    }


    string[] placement = new string[temp_1.GetLength(0)];

    // Candidates are required to get a minimum score of 40 on the exam for enrolling in an undergraduate program.
    /* If the grades of two or more candidates are equal, 
     * the candidate with a higher “school diploma grade” will be chosen as the first.
    * If they are equal again, the program can assign any of them to the department.*/

    for (int i = 0; i < candidatesInfo.GetLength(0); i++)
    {
        if (winers[i, 1] > 40 && winers[i, 1] > winers[i + 1, 1])
        {
            bool placed = false;
            for (int h = 0; h < candidatesInfo.GetLength(0); h++)
                if (winers[i, 0] == Convert.ToInt16(candidatesInfo[h, 0]))
                {
                    for (int n = 3; n <= 5; n++)
                    {
                        if (candidatesInfo[h, n] == "D1" && placed == false) // D1,Computer Engineering,5
                        {
                            if (quota[0] != 0 && quota[0] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[0] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D2" && placed == false) // D2,Electronics Engineering,4
                        {
                            if (quota[1] != 0 && quota[1] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[1] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D3" && placed == false) // D3,Mathematics,3
                        {
                            if (quota[2] != 0 && quota[2] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[2] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D4" && placed == false) // D4,Physics,2
                        {
                            if (quota[3] != 0 && quota[3] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[3] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D5" && placed == false) // D5,Medicine,6
                        {
                            if (quota[4] != 0 && quota[4] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[4] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D6" && placed == false) // D6,,
                        {
                            if (quota[5] != 0 && quota[5] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[5] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D7" && placed == false) // D7,,
                        {
                            if (quota[6] != 0 && quota[6] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[6] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D8" && placed == false) // D8,,
                        {
                            if (quota[7] != 0 && quota[7] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[7] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D2" && placed == false) // D9,,
                        {
                            if (quota[8] != 0 && quota[8] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[8] -= 1;
                                placed = true;
                            }
                        }
                        else if (candidatesInfo[h, n] == "D10" && placed == false) // D10,,
                        {
                            if (quota[9] != 0 && quota[9] <= 8)
                            {
                                placement[i] = candidatesInfo[h, n]; // seçenek
                                quota[9] -= 1;
                                placed = true;
                            }
                        }
                        else if (placed == false)
                        {
                            placed = false;
                        }

                    }
                }
        }
        else if (winers[i, 1] > 40 && winers[i, 1] == winers[i + 1, 1] && diploma_grade[i] > diploma_grade[i + 1])
        {
            bool placed = false;
            for (int n = 3; n <= 5; n++)
            {
                if (candidatesInfo[i, n] == "D1" && placed == false) // D1,Computer Engineering,5
                {
                    if (quota[0] != 0 && quota[0] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[0] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D2" && placed == false) // D2,Electronics Engineering,4
                {
                    if (quota[1] != 0 && quota[1] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[1] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D3" && placed == false) // D3,Mathematics,3
                {
                    if (quota[2] != 0 && quota[2] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[2] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D4" && placed == false) // D4,Physics,2
                {
                    if (quota[3] != 0 && quota[3] <= 8)
                    {
                        placement[i] = candidatesInfo[i, 1]; // seçenek
                        quota[3] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D5" && placed == false) // D5,Medicine,6
                {
                    if (quota[4] != 0 && quota[4] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[4] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D6" && placed == false) // D6,,
                {
                    if (quota[5] != 0 && quota[5] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[5] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D7" && placed == false) // D7,,
                {
                    if (quota[6] != 0 && quota[6] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[6] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D8" && placed == false) // D8,,
                {
                    if (quota[7] != 0 && quota[7] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[7] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D2" && placed == false) // D9,,
                {
                    if (quota[8] != 0 && quota[8] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[8] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D10" && placed == false) // D10,,
                {
                    if (quota[9] != 0 && quota[9] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[9] -= 1;
                        placed = true;
                    }
                }
                else if (placed == false)
                {
                    placed = false;
                }
            }
        }
        else if (winers[i, 1] > 40 && winers[i, 1] == winers[i + 1, 1] && diploma_grade[i] == diploma_grade[i + 1])
        {
            bool placed = false;
            for (int n = 3; n <= 5; n++)
            {
                if (candidatesInfo[i, n] == "D1" && placed == false) // D1,Computer Engineering,5
                {
                    if (quota[0] != 0 && quota[0] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[0] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D2" && placed == false) // D2,Electronics Engineering,4
                {
                    if (quota[1] != 0 && quota[1] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[1] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D3" && placed == false) // D3,Mathematics,3
                {
                    if (quota[2] != 0 && quota[2] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[2] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D4" && placed == false) // D4,Physics,2
                {
                    if (quota[3] != 0 && quota[3] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[3] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D5" && placed == false) // D5,Medicine,6
                {
                    if (quota[4] != 0 && quota[4] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[4] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D6" && placed == false) // D6,,
                {
                    if (quota[5] != 0 && quota[5] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[5] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D7" && placed == false) // D7,,
                {
                    if (quota[6] != 0 && quota[6] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[6] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D8" && placed == false) // D8,,
                {
                    if (quota[7] != 0 && quota[7] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[7] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D2" && placed == false) // D9,,
                {
                    if (quota[8] != 0 && quota[8] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[8] -= 1;
                        placed = true;
                    }
                }
                else if (candidatesInfo[i, n] == "D10" && placed == false) // D10,,
                {
                    if (quota[9] != 0 && quota[9] <= 8)
                    {
                        placement[i] = candidatesInfo[i, n]; // seçenek
                        quota[9] -= 1;
                        placed = true;
                    }
                }
                else if (placed == false)
                {
                    placed = false;
                }
            }
        }
    }

    // students number
    string[,] students = new string[temp_2.GetLength(0), quota.Length];
    int[] select = new int[quota.Length];

    for (int i = 0; i < placement.GetLength(0); i++)
    {
        if (placement[i] == "D1")
        {
            students[0, select[0]] = Convert.ToString(winers[i, 0]);
            select[0]++;
        }
        else if (placement[i] == "D2")
        {
            students[1, select[1]] = Convert.ToString(winers[i, 0]);
            select[1]++;
        }
        else if (placement[i] == "D3")
        {
            students[2, select[2]] = Convert.ToString(winers[i, 0]);
            select[2]++;
        }
        else if (placement[i] == "D4")
        {
            students[3, select[3]] = Convert.ToString(winers[i, 0]);
            select[3]++;
        }
        else if (placement[i] == "D5")
        {
            students[4, select[4]] = Convert.ToString(winers[i, 0]);
            select[4]++;
        }
        else if (placement[i] == "D6")
        {
            students[5, select[5]] = Convert.ToString(winers[i, 0]);
            select[5]++;
        }
        else if (placement[i] == "D7")
        {
            students[6, select[6]] = Convert.ToString(winers[i, 0]);
            select[6]++;
        }
        else if (placement[i] == "D8")
        {
            students[7, select[7]] = Convert.ToString(winers[i, 0]);
            select[7]++;
        }
        else if (placement[i] == "D9")
        {
            students[8, select[8]] = Convert.ToString(winers[i, 0]);
            select[8]++;
        }
        else if (placement[i] == "D10")
        {
            students[9, select[9]] = Convert.ToString(winers[i, 0]);
            select[9]++;
        }
    }

    /* 
     * Hocam, i didnt know how to show the result in a nice way so i asked a friend to help me in this problem
     * , we didnt share codes just told me what to do 
     * because i couln't figure it out how to use the Console.CursorPosition(,) in the for :D 
     */
    int length1 = 0;
    for (int i = 0; i < temp_2.GetLength(0); i++) // temp_2 student numbers
    {
        if (temp_2[i, 1].Length > length1) // temp_2 departments row
        {
            length1 = temp_2[i, 1].Length;
        }
    }
    // Output
    Console.WriteLine("\n✼The Result of department assignments:");
    Console.Write("No    Department");
    for (int i = 0; i < length1; i++)
    {
        Console.Write(" ");
    }
    Console.Write("Students\n");
    for (int i = 0; i < temp_2.GetLength(0); i++)
    {
        for (int j = 0; j < temp_2.GetLength(1) - 1; j++)
        {
            Console.Write(temp_2[i, j] + "    ");
        }
        for (int j = 0; j < length1 + 4 - temp_2[i, 1].Length; j++) // length+4(space)
        {
            Console.Write(" ");
        }
        for (int j = 0; j < students.GetLength(1); j++)
        {
            Console.Write("   " + students[i, j]);
        }
        Console.WriteLine();
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("\nFileNotFound. {0}", ex.Message);
    Console.WriteLine("\nPlease make sure that your file is in the right place.");
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("\nYour file has a wrong value in it.", ex.Message);
    Console.WriteLine("\nPlease make sure that your file has the correct number of students,question numbers, departments and quota inside of it.");
}
catch (Exception ex)
{
    Console.WriteLine("\nGeneral exception. {0}", ex.Message);
    Console.WriteLine("\nOps! Something has gone wrong... :) \nPlease try again.");
}
Console.ReadKey();