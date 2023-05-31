# HEI-Exam

<img width="137" alt="Screen Shot 2023-05-31 at 16 43 27" src="https://github.com/inomisay/HEI-Exam/assets/98346164/d5539103-1bb9-439a-8ef9-6bd75d8e9772">

# HEI Exam
Higher Education Institutions (HEI) (Yükseköğretim Kurumları Sınavı - YKS) exam is a standardized test for admission to higher education in Turkey administered by ÖSYM.
Write a program for a simple student selection and placement system with candidates, exam answer sheets, department preferences, and the assignments of the candidates to the departments.

# Candidates
The candidate information is stored in a text file, named candidates.txt, in the following format:

<img width="546" alt="Screen Shot 2023-05-31 at 16 43 53" src="https://github.com/inomisay/HEI-Exam/assets/98346164/af54487a-7eb8-4c25-82eb-27685be76c2e">

- The first three elements are the candidate’s personal information
- After that, three elements are the candidate’s department choices to where she/he wishes to enroll 
- The last twenty-five elements are the exam answers of the candidate.

The number of candidates is dynamic (maximum 40).

# Departments
The quota information related to the departments is read from a text file, named departments.txt, in the following format:

<img width="550" alt="Screen Shot 2023-05-31 at 16 44 47" src="https://github.com/inomisay/HEI-Exam/assets/98346164/e24f05cc-5f89-4b56-b32d-36c4d1fc205f">

The number of departments is dynamic (maximum 10). The maximum quota for any department is 8.

# Answer Sheet
The correct answers for the exam are stored in the array, named key, as follows:
char[] key = {'A','B','D','C','C','C','A','D','B','C','D','B','A','C','B','A','C','D','C','D','A','D','B','C','D'};

# Grades
The answers of the candidates will be graded by the system. The program must print the scores of all candidates on the screen.
There are 25 questions in the exam. Each question has four options (A, B, C, and D). Every correct answer will be graded as 4 points, therefore, the maximum grade is 100. Empty answers will not affect the grading. The candidate will lose 3 points for each wrong answer.

# Assignment
Candidates are required to get a minimum score of 40 on the exam for enrolling in an undergraduate program.
The candidates can be placed in a department list according to their choices and the available quotas. Each candidate specifies at most three department choices to where she/he wishes to enroll.

If the grades of two or more candidates are equal, the candidate with a higher “school diploma grade” will be chosen as the first. If they are equal again, the program can assign any of them to the department.
The program should print the final results of assignments on the screen.

**Notes:**
1- Don't use automatic array-related commands such as Array.Sort()
2- Don’t change the file names and array name (key). candidates.txt
departments.txt
3- If any error exists in the files, the program must print an error message.

<img width="551" alt="Screen Shot 2023-05-31 at 16 46 05" src="https://github.com/inomisay/HEI-Exam/assets/98346164/f0400caa-f484-45a3-b81f-c272232e2fcb">

<img width="375" alt="Screen Shot 2023-05-31 at 16 46 17" src="https://github.com/inomisay/HEI-Exam/assets/98346164/3ba8c739-153c-4d26-bcb9-36028ab0688c">

**Notes:**
1. Your program must work correctly under all conditions. Try to control all possible errors.
2. You should use meaningful variable names, appropriate comments, and good prompting messages.
4. If you want, you may write your own **“procedures / functions”.**
