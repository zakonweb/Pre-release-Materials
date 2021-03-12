'TASK 2 – Files
'Introduction
'Candidates should be able to write programs to process text file data both in pseudocode and their
'chosen programming language. It is suggested that each task is planned using pseudocode before
'writing it in program code.

Module singleRecFile
    Sub Main()
        Dim MenuChoice As Integer = 0
        Do While MenuChoice <> 6
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608/22, Pre Release Material")
            Console.WriteLine("For Single Line Record")
            Console.WriteLine("1. Task 2.1")
            Console.WriteLine("2. Task 2.2")
            Console.WriteLine("3. Task 2.3")
            Console.WriteLine("4. Task 2.4")
            Console.WriteLine("5. Output all records")
            Console.WriteLine("6. Quit")

            Console.WriteLine()
            Console.Write("Enter menu choice... ")
            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1 : Task21()
                Case 2 : Task22()
                Case 3 : Task23()
                Case 4 : appendRecord()
                Case 5 : outputRecords()
                Case 6 'quit menu
                Case Else : Console.WriteLine("Wrong menu choice. Please try again.")
            End Select
        Loop
    End Sub

    'TASK 2.1
    'Define a structure for a text file that could be used to store information about each student as a string.
    'Each line of the file will contain a single string.
    'Store at least two pieces of information. For example, you could store each student’s ID together with
    'their email address as follows:
    '<StudentID>'#'<EmailAddress>
    'Define a fixed format for the Student ID, for example, two letters followed by four numbers.
    'An example string with this format would be:
    '"AB1234#Jim99@email.com"
    'Write program code to:
    '1. open a new text file
    '2. prompt and input a Student ID and email address (validate if required)
    '3. form the string as shown
    '4. write the string to the file
    '5. repeat from step 2 for all students in the class
    '6. close the file
    'Check the contents of the file using a text editor.
    Sub Task21()
        Dim MenuChoice As Integer = 0
        Do While MenuChoice <> 3
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608/21/22/23, Pre Release Material")
            Console.WriteLine("1. Input records and add to next record")
            Console.WriteLine("2. Output all records")
            Console.WriteLine("3. Quit")

            Console.WriteLine()
            Console.Write("Enter menu choice... ")
            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1 : addRecord()
                Case 2 : outputRecords()
                Case 3 'Quit Task2.1
                Case Else : Console.WriteLine("Wrong menu choice. Please try again.")
            End Select
        Loop
    End Sub

    Sub addRecord()
        Dim stuID, stuEmail, concatStr As String
        Dim moreRec As Boolean = False

        Console.WriteLine("Input & add students to file")

        FileOpen(1, "c:\filePractice\task2.txt", OpenMode.Output)
        Do
            Do
                Console.Write("Input student ID: ") : stuID = Console.ReadLine
            Loop Until validID(stuID) = True

            Do
                Console.Write("Input student email: ") : stuEmail = Console.ReadLine
            Loop Until isEmailValid(stuEmail) = True

            concatStr = stuID & "#" & stuEmail
            WriteLine(1, concatStr)

            Console.Write("Enter next record (true/false): ") : moreRec = Console.ReadLine
        Loop Until moreRec = False
        FileClose(1)
    End Sub

    'TASK 2.4
    'Modify the program to allow the details of additional students to be appended to the file.
    Sub appendRecord()
        Dim stuID, stuEmail, concatStr As String
        Dim moreRec As Boolean = False

        Console.WriteLine("Input & add students to file")

        FileOpen(1, "c:\filePractice\task2.txt", OpenMode.Append)
        Do
            Do
                Console.Write("Input student ID: ") : stuID = Console.ReadLine
            Loop Until validID(stuID) = True

            Do
                Console.Write("Input student email: ") : stuEmail = Console.ReadLine
            Loop Until isEmailValid(stuEmail) = True

            concatStr = stuID & "#" & stuEmail
            WriteLine(1, concatStr)

            Console.Write("Enter next record (true/false): ") : moreRec = Console.ReadLine
        Loop Until moreRec = False
        FileClose(1)
    End Sub

    Sub outputRecords()
        Dim hashPos As Integer
        Dim stuID, stuEmail, concatStr As String

        Console.WriteLine("Student ID" & Space(5) & " Student Email")
        Console.WriteLine("----------" & Space(5) & " -------------")
        FileOpen(1, "c:\filePractice\task2.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, concatStr)
            hashPos = InStr(concatStr, "#")
            stuID = Left(concatStr, hashPos - 1)
            stuEmail = Right(concatStr, Len(concatStr) - hashPos)

            Console.WriteLine(stuID & Space(10) & stuEmail)
        End While
        FileClose(1)

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
    End Sub

    'TASK 2.2
    'Write a second program to search the file for a given Student ID and output the email address if the ID
    'was found, or a suitable message if the ID was not found.
    Sub Task22()
        Dim stuID, stuEmail As String

        Console.WriteLine()
        Console.Write("Input student ID to search for: ")
        stuID = Console.ReadLine

        stuEmail = searchFullID(stuID)
        If stuEmail = "*****" Then
            Console.WriteLine("Record not found...")
        Else
            Console.WriteLine("Email address of ID " & stuID & " is: " & stuEmail)
        End If

        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()

    End Sub

    'TASK 2.3
    'Modify the search code to also perform a substring match on the Student ID. For example, search for
    'all the Student IDs that begin with “AB”.
    Sub Task23()
        Dim stuID As String

        Console.WriteLine()
        Console.Write("Input part, or the whole, of an ID to search for: ")
        stuID = Console.ReadLine

        searchPartialID(stuID)

    End Sub

    Function searchFullID(ByVal Val As String) As String
        Dim hashPos As Integer
        Dim isFound As Boolean = False
        Dim stuID, stuEmail, concatStr As String

        FileOpen(1, "c:\filePractice\task2.txt", OpenMode.Input)
        Do

            Input(1, concatStr)
            hashPos = InStr(concatStr, "#")
            stuID = Left(concatStr, hashPos - 1)
            stuEmail = Right(concatStr, Len(concatStr) - hashPos)

            If UCase(val) = UCase(stuID) Then isFound = True

        Loop Until EOF(1) = True Or isFound = True
        FileClose(1)

        If isFound Then
            Return stuEmail
        Else
            Return "*****"
        End If
    End Function

    Sub searchPartialID(ByVal val As String)
        Dim hashPos As Integer
        Dim stuID, stuEmail, concatStr As String

        Console.WriteLine("Student ID" & Space(5) & " Student Email")
        Console.WriteLine("----------" & Space(5) & " -------------")
        FileOpen(1, "c:\filePractice\Task2.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, concatStr)
            hashPos = InStr(concatStr, "#")
            stuID = Left(concatStr, hashPos - 1)
            stuEmail = Right(concatStr, Len(concatStr) - hashPos)

            If InStr(UCase(stuID), UCase(val)) > 0 Then
                Console.WriteLine(stuID & Space(10) & stuEmail)
            End If
        End While
        FileClose(1)

        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
    End Sub


    Function validID(ByVal Val As String) As Boolean
        Dim CH As Char
        Dim Count As Integer
        Dim isValid As Boolean = True

        'validate string in Format AA9999. E.g. "AB1234"
        If Len(Val) = 6 Then
            If Left(Val, 1) >= "A" And Left(Val, 1) <= "Z" Then
                If Mid(Val, 2, 1) >= "A" And Mid(Val, 2, 1) <= "Z" Then
                    For Count = 3 To 6
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

    Function isEmailValid(ByVal strCheck As String) As Boolean
        Try
            Dim isValid As Boolean
            Dim strDomainType As String


            Const sInvalidChars As String = "!#$%^&*()=+{}[]|\;:'/?>,< "
            Dim i As Integer

            'Check to see if there is a double quote
            isValid = Not InStr(1, strCheck, Chr(34)) > 0
            If Not isValid Then GoTo ExitFunction

            'Check to see if there are consecutive dots
            isValid = Not InStr(1, strCheck, "..") > 0
            If Not isValid Then GoTo ExitFunction

            ' Check for invalid characters.
            If Len(strCheck) > Len(sInvalidChars) Then
                For i = 1 To Len(sInvalidChars)
                    If InStr(strCheck, Mid(sInvalidChars, i, 1)) > 0 Then
                        isValid = False
                        GoTo ExitFunction
                    End If
                Next
            Else
                For i = 1 To Len(strCheck)
                    If InStr(sInvalidChars, Mid(strCheck, i, 1)) > 0 Then
                        isValid = False
                        GoTo ExitFunction
                    End If
                Next
            End If

            If InStr(1, strCheck, "@") > 1 Then 'Check for an @ symbol
                isValid = Len(Left(strCheck, InStr(1, strCheck, "@") - 1)) > 0
            Else
                isValid = False
            End If
            If Not isValid Then GoTo ExitFunction

            strCheck = Right(strCheck, Len(strCheck) - InStr(1, strCheck, "@"))
            isValid = Not InStr(1, strCheck, "@") > 0 'Check to see if there are too many @'s
            If Not isValid Then GoTo ExitFunction

            strDomainType = Right(strCheck, Len(strCheck) - InStr(1, strCheck, "."))
            isValid = Len(strDomainType) > 0 And InStr(1, strCheck, ".") < Len(strCheck)
            If Not isValid Then GoTo ExitFunction

            strCheck = Left(strCheck, Len(strCheck) - Len(strDomainType) - 1)
            Do Until InStr(1, strCheck, ".") <= 1
                If Len(strCheck) >= InStr(1, strCheck, ".") Then
                    strCheck = Left(strCheck, Len(strCheck) - (InStr(1, strCheck, ".") - 1))
                Else
                    isValid = False
                    GoTo ExitFunction
                End If
            Loop
            If strCheck = "." Or Len(strCheck) = 0 Then isValid = False

ExitFunction:
            Return isValid
        Catch
            Return False
        End Try

    End Function
End Module
