'TASK 1 – Arrays
'Introduction
'Candidates should be able to write programs to process array data both in pseudocode and in their
'chosen programming language. It is suggested that each task is planned using pseudocode before
'writing it in program code.Module Module1

'TASK 1.5
'Convert your design of SD array to use a 2D array and add additional pieces of information for each student.
'For example:
'Array element    Information     Example data
'MyArray[1,1]     Student Name    "Sam Arnold"
'MyArray[1,2]     Email Address   ""SamArnold137@email.com"
'MyArray[1,3]     Date of Birth   "25 Sep 2005"
'MyArray[1,4]     Student ID      "C3452-B"
'MyArray[1,5]     Tutor ID        "CHL"

Module twoD_Array
    Const UB = 2
    Dim stuRec2D(UB, 5) As String

    Sub Main()
        Dim MenuChoice As Integer = 0
        Do While MenuChoice <> 5
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608/21/22/23, Pre Release Material")
            Console.WriteLine("Task 1.5 & 1.6 done over Tasks 1.1 to 1.4 for 2D Array")
            Console.WriteLine("1. Task 1.1")
            Console.WriteLine("2. Task 1.2")
            Console.WriteLine("3. Task 1.3")
            Console.WriteLine("4. Task 1.4")
            Console.WriteLine("5. Quit")

            Console.WriteLine()
            Console.Write("Enter menu choice... ")
            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1 : Task11()
                Case 2 : Task12()
                Case 3 : Task13()
                Case 4 : Task14()
                Case 5 'Quit Program
                Case Else : Console.WriteLine("Wrong menu choice. Please try again.")
            End Select
        Loop
    End Sub

    'TASK 1.1 modified for Task 1.5
    'A 2D array of STRING data type will be used to store the data of each 
    'student in a class as follows:

    'Array element    Information     Example data
    'MyArray[1,1]     Student Name    "Sam Arnold"
    'MyArray[1,2]     Email Address   ""SamArnold137@email.com"
    'MyArray[1,3]     Date of Birth   "25 Sep 2005"
    'MyArray[1,4]     Student ID      "C3452-B"
    'MyArray[1,5]     Tutor ID        "CHL"

    'Write program code to:
    '1. declare the array
    '2. prompt and input data
    '3. as shown above
    '4. write the data to the next array element
    '5. repeat from step 2 for all students in the class
    '6. output each element of the array in a suitable format, together with 
    'explanatory text such as column headings
    Sub Task11()
        Dim MenuChoice As Integer = 0
        Do While MenuChoice <> 3
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608/22, Pre Release Material")
            Console.WriteLine("1. Input records and add to next array element")
            Console.WriteLine("2. Output array elements")
            Console.WriteLine("3. Quit")

            Console.WriteLine()
            Console.Write("Enter menu choice... ")
            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1 : addElement2D()
                Case 2 : outputElements2D()
                Case 3 'Quit Task1.1
                Case Else : Console.WriteLine("Wrong menu choice. Please try again.")
            End Select
        Loop
    End Sub

    Sub addElement2D()
        Dim stuName, stuEmail, DOB, stuID, tutorID As String
        Dim i As Integer

        Console.WriteLine("Input & add " & UB & " students to a 2D array")
        For i = 1 To UB
            Console.Write(i & ". Input student name: ") : stuName = Console.ReadLine
            Console.Write(i & ". Input student email: ") : stuEmail = Console.ReadLine
            Console.Write(i & ". Input student date of birth: ") : DOB = Console.ReadLine
            Do
                Console.Write(i & ". Input student ID: in Format A9999-A. E.g. ""C3452-B"": ")
                stuID = Console.ReadLine
            Loop Until validID(stuID) = True
            Console.Write(i & ". Input tutor ID: ") : tutorID = Console.ReadLine

            stuRec2D(i, 1) = stuName
            stuRec2D(i, 2) = stuEmail
            stuRec2D(i, 3) = DOB
            stuRec2D(i, 4) = stuID
            stuRec2D(i, 5) = tutorID
        Next
    End Sub

    Sub outputElements2D()
        Dim i As Integer

        Console.WriteLine("Record " & Space(4) & "Student Name" & Space(12) & _
                          " Student Email" & Space(11) & " Student DOB" & Space(13) _
                          & " Student ID" & Space(13) & " Tutor ID")
        Console.WriteLine("-------" & Space(4) & "------------" & Space(12) & _
                          " -------------" & Space(11) & " -----------" & Space(13) _
                          & " ----------" & Space(13) & " ----------")
        For i = 1 To UB
            If stuRec2D(i, 1) <> "*****" Then 'Check for Task 1.2
                Console.WriteLine(i & Space(10) & stuRec2D(i, 1) & _
                                  Space(25 - Len(stuRec2D(i, 1))) & _
                                  stuRec2D(i, 2) & Space(25 - Len(stuRec2D(i, 2))) & _
                                  stuRec2D(i, 3) & Space(25 - Len(stuRec2D(i, 3))) & _
                                  stuRec2D(i, 4) & Space(25 - Len(stuRec2D(i, 4))) & _
                                  stuRec2D(i, 5))
            End If
        Next

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
    End Sub

    'TASK 1.2 modified for Task 1.5
    'Consider what happens when a student leaves the class and their data item is deleted from the array.
    'Decide on a way of identifying unused array elements and only output elements that contain student
    'details. Modify your program to include this.
    Sub Task12()
        Dim stuName As String = ""
        Dim MenuChoice As Integer = 0
        Do While MenuChoice <> 3
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608/22, Pre Release Material")
            Console.WriteLine("1. Delete record")
            Console.WriteLine("2. Output array elements")
            Console.WriteLine("3. Quit")

            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1
                    Console.Write("Input student name to delete: ")
                    stuName = Console.ReadLine

                    If delRecord(stuName) = True Then
                        Console.WriteLine("Record deleted successfully.")
                    Else
                        Console.WriteLine("Record not found...")
                    End If

                    Console.WriteLine("Press any key to continue...")
                    Console.ReadKey()

                Case 2 : outputElements2D()
                Case 3 'Quit Task1.2
                Case Else : Console.WriteLine("Wrong menu choice. Please try again.")
            End Select
        Loop
    End Sub

    Function delRecord(ByVal stuName As String) As Boolean
        Dim index As Integer

        index = searchFullName(stuName)
        If index = 0 Then
            Return False
        Else
            stuRec2D(index, 1) = "*****"
            Return True
        End If
    End Function

    'TASK 1.3 modified for Task 1.5
    'Extend your program so that after assigning values to the array, the program will prompt the user to
    'input a name, and then search the array to find that name and output the corresponding email address.
    Sub Task13()
        Dim stuName As String
        Dim index As Integer

        Console.WriteLine()
        Console.Write("Input student name to search for: ")
        stuName = Console.ReadLine

        index = searchFullName(stuName)
        If index = 0 Then
            Console.WriteLine("Record not found...")
        Else
            Console.WriteLine("Email address of " & stuName & " is: " & stuRec2D(index, 2))
        End If

        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()

    End Sub

    'TASK 1.4 modified for 1.5
    'Modify your program so that it will:
    'prompt the user to input part, or the whole, of a name
    'search the whole array to find the search term within the <StudentName> string
    'for each array element in which the search term is found within the <StudentName> string, output
    'the element in a suitable format.
    Sub Task14()
        Dim stuName As String

        Console.WriteLine()
        Console.Write("Input part, or the whole, of a name to search for: ")
        stuName = Console.ReadLine

        searchPartialName(stuName)

    End Sub

    Function searchFullName(ByVal val As String) As Integer
        Dim i As Integer
        Dim isFound As Boolean = False
        i = 0

        Do
            i = i + 1
            If UCase(val) = UCase(stuRec2D(i, 1)) Then isFound = True
        Loop Until i = UB Or isFound = True

        If isFound Then
            Return i
        Else
            Return 0
        End If
    End Function

    Sub searchPartialName(ByVal val As String)
        Dim i As Integer

        Console.WriteLine("Record " & Space(4) & "Student Name" & Space(12) & _
                          " Student Email" & Space(11) & " Student DOB" & Space(13) _
                          & " Student ID" & Space(13) & " Tutor ID")
        Console.WriteLine("-------" & Space(4) & "------------" & Space(12) & _
                          " -------------" & Space(11) & " -----------" & Space(13) _
                          & " ----------" & Space(13) & " ----------")

        For i = 1 To UB
            If stuRec2D(i, 1) <> "*****" Then 'Check for Task 1.2
                If InStr(UCase(stuRec2D(i, 1)), UCase(val)) > 0 Then
                    Console.WriteLine(i & Space(10) & stuRec2D(i, 1) & _
                                      Space(25 - Len(stuRec2D(i, 1))) & _
                                      stuRec2D(i, 2) & Space(25 - Len(stuRec2D(i, 2))) & _
                                      stuRec2D(i, 3) & Space(25 - Len(stuRec2D(i, 3))) & _
                                      stuRec2D(i, 4) & Space(25 - Len(stuRec2D(i, 4))) & _
                                      stuRec2D(i, 5))
                End If
            End If
        Next

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
    End Sub

    Function validID(ByVal Val As String) As Boolean
        Dim CH As Char
        Dim Count As Integer
        Dim isValid As Boolean = True

        'validate string in Format A9999-A. E.g. "C3452-B"
        If Len(val) = 7 And Mid(val, 6, 1) = "-" Then
            If Left(val, 1) >= "A" And Left(val, 1) <= "Z" Then
                If Right(val, 1) >= "A" And Right(val, 1) <= "Z" Then
                    For Count = 2 To 5
                        CH = Mid(Val, Count, 1)
                        If CH < "0" Or CH > "9" Then
                            isValid = False
                            Exit For
                        End If
                    Next Count
                Else
                    isValid = False
                End If
            Else
                isValid = False
            End If

        Else
            isValid = False
        End If

        Return isValid
    End Function

End Module
