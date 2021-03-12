'TASK 1 – Arrays
'Introduction
'Candidates should be able to write programs to process array data both in pseudocode and in their
'chosen programming language. It is suggested that each task is planned using pseudocode before
'writing it in program code.Module Module1

Module SDarray
    Const UB = 2
    Dim stuRecSD(UB) As String

    Sub Main()
        Dim MenuChoice As Integer = 0
        Do While MenuChoice <> 5
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608/21/22/23, Pre Release Material")
            Console.WriteLine("For SD Array")
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

    'TASK 1.1
    'A 1D array of STRING data type will be used to store the name of each 
    'student in a class together with their email address and date of birth as follows:
    '<Student Name>'*'<Email address>'*'<Date of birth>
    'An example string with this format would be:
    '"Sam Arnold*SamArnold137@email.com*25Sep2005"
    'Write program code to:
    '1. declare the array
    '2. prompt and input for student name, email address and date of birth
    '3. form the string as shown
    '4. write the string to the next array element
    '5. repeat from step 2 for all students in the class
    '6. output each element of the array in a suitable format, together with 
    '   explanatory text such as column headings
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
                Case 1 : addElementSD()
                Case 2 : outputElementsSD()
                Case 3 'Quit Task1.1
                Case Else : Console.WriteLine("Wrong menu choice. Please try again.")
            End Select
        Loop
    End Sub

    Sub addElementSD()
        Dim stuName, stuEmail, stuDOB, concatStr As String
        Dim i As Integer

        Console.WriteLine("Input & add " & UB & " students to an SD array")
        For i = 1 To UB
            Console.Write(i & ". Input student name: ") : stuName = Console.ReadLine
            Console.Write(i & ". Input student email: ") : stuEmail = Console.ReadLine
            Console.Write(i & ". Input student date of birth: ") : stuDOB = Console.ReadLine

            concatStr = stuName & "*" & stuEmail & "*" & stuDOB
            stuRecSD(i) = concatStr
        Next
    End Sub

    Sub outputElementsSD()
        Dim i, starPos, starPos1 As Integer
        Dim stuName, stuEmail, stuDOB, concatStr As String

        Console.WriteLine("Record " & Space(4) & "Student Name" & Space(12) & " Student Email" & Space(12) & " Student Date of Birth")
        Console.WriteLine("-------" & Space(4) & "------------" & Space(12) & " -------------" & Space(12) & " ---------------------")
        For i = 1 To UB
            If stuRecSD(i) <> "*****" Then 'Check for Task 1.2
                concatStr = stuRecSD(i)
                starPos = InStr(concatStr, "*")
                stuName = Left(concatStr, starPos - 1)

                starPos1 = InStr(starPos + 1, concatStr, "*")
                stuEmail = Mid(concatStr, starPos + 1, starPos1 - starPos - 1)

                stuDOB = Right(concatStr, Len(concatStr) - starPos1)

                Console.WriteLine(i & Space(10) & stuName & Space(25 - Len(stuName)) & _
                                  stuEmail & Space(26 - Len(stuEmail)) & stuDOB)
            End If
        Next

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
    End Sub

    'TASK 1.2
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

                Case 2 : outputElementsSD()
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
            stuRecSD(index) = "*****"
            Return True
        End If
    End Function

    'TASK 1.3
    'Extend your program so that after assigning values to the array, the program will prompt the user to
    'input a name, and then search the array to find that name and output the corresponding email address.
    Sub Task13()
        Dim stuName, stuEmail, concatStr As String
        Dim index, starPos, starPos1 As Integer

        Console.WriteLine()
        Console.Write("Input student name to search for: ")
        stuName = Console.ReadLine

        index = searchFullName(stuName)
        If index = 0 Then
            Console.WriteLine("Record not found...")
        Else
            concatStr = stuRecSD(index)
            starPos = InStr(concatStr, "*")
            starPos1 = InStr(starPos + 1, concatStr, "*")
            stuEmail = Mid(concatStr, starPos + 1, starPos1 - starPos - 1)

            Console.WriteLine("Email address of " & stuName & " is: " & stuEmail)
        End If

        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()

    End Sub

    'TASK 1.4
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
        Dim i, starPos As Integer
        Dim isFound As Boolean = False
        Dim stuName, concatStr As String
        i = 0

        Do
            i = i + 1
            If stuRecSD(i) <> "*****" Then 'Check for Task 1.2
                concatStr = stuRecSD(i)
                starPos = InStr(concatStr, "*")
                stuName = Left(concatStr, starPos - 1)

                If UCase(val) = UCase(stuName) Then isFound = True
            End If
        Loop Until i = UB Or isFound = True

        If isFound Then
            Return i
        Else
            Return 0
        End If
    End Function

    Sub searchPartialName(ByVal val As String)
        Dim i, starPos, starPos1 As Integer
        Dim stuName, stuEmail, stuDOB, concatStr As String

        Console.WriteLine("Record " & Space(4) & "Student Name" & Space(12) & " Student Email" & Space(12) & " Student Date of Birth")
        Console.WriteLine("-------" & Space(4) & "------------" & Space(12) & " -------------" & Space(12) & " ---------------------")
        For i = 1 To UB
            If stuRecSD(i) <> "*****" Then 'Check for Task 1.2
                concatStr = stuRecSD(i)
                starPos = InStr(concatStr, "*")
                stuName = Left(concatStr, starPos - 1)

                starPos1 = InStr(starPos + 1, concatStr, "*")
                stuEmail = Mid(concatStr, starPos + 1, starPos1 - starPos - 1)

                stuDOB = Right(concatStr, Len(concatStr) - starPos1)
                If InStr(UCase(stuName), UCase(val)) > 0 Then
                    Console.WriteLine(i & Space(10) & stuName & Space(25 - Len(stuName)) & _
                                      stuEmail & Space(26 - Len(stuEmail)) & stuDOB)
                End If
            End If
        Next

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()

    End Sub

End Module
