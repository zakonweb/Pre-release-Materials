Imports System

Module Program
    Sub Main()

        Dim choice As Integer

        Console.Clear()
        Console.WriteLine("OL Computer Science 2210/P22, Pre Release Material (Variant 2) -- May/June 2021")
        Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
        Console.WriteLine(StrDup(95, "-"))
        Do
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("1. Task 1 - Recording Preferences.")
            Console.WriteLine("2. Task 2 – Results Tabulation.")
            Console.WriteLine("3. Task 3 – Preference '1' Count.")
            Console.WriteLine("4. Quit.")
            Console.WriteLine("")
            Console.WriteLine("")
            Console.Write("Enter your choice [1-4]: ")
            choice = Console.ReadLine()

            If choice = 1 Then
                Call Task1()
            ElseIf choice = 2 Then
                Call Task2()
            ElseIf choice = 3 Then
                Call Task3()
            ElseIf choice = 4 Then
                Console.Write("")
            Else
                Console.WriteLine("Enter a choice between 1 and 4, inclusive.")
                Console.WriteLine("")
            End If
        Loop Until choice = 4

    End Sub


    Dim optionsDesc(5) As String
    Dim studentIDs(150) As String
    Dim studentPref(5) As String
    Dim studentPrefOne(5) As String
    Dim staffIDs(20) As String
    Dim staffPref(5) As String
    Dim staffPrefOne(5) As String

    Sub Task1()
        Dim continueFlag As Boolean
        Dim switchFlag As Boolean
        Dim enterFlag As Boolean

        Dim switch As String
        Dim preference As Integer
        Dim studentIDStr As String
        Dim staffIDStr As String
        Dim continueFlagStr As String

        Dim e As Integer

        Console.WriteLine("")
        Console.Write("Enter the description of Option A: ")
        optionsDesc(1) = Console.ReadLine()
        Console.WriteLine("")
        Console.Write("Enter the description of Option B: ")
        optionsDesc(2) = Console.ReadLine()
        Console.WriteLine("")
        Console.Write("Enter the description of Option C: ")
        optionsDesc(3) = Console.ReadLine()
        Console.WriteLine("")
        Console.Write("Enter the description of Option D: ")
        optionsDesc(4) = Console.ReadLine()
        Console.WriteLine("")
        Console.Write("Enter the description of Option E: ")
        optionsDesc(5) = Console.ReadLine()

        continueFlag = True
        Do
            switchFlag = True
            Do
                Console.WriteLine("")
                Console.Write("Are you a student or a staff (Student/Staff): ")
                switch = Console.ReadLine()

                If UCase(switch) = "STUDENT" Then
                    switchFlag = False

                    Console.WriteLine("")
                    Console.Write("Enter your student ID: ")
                    studentIDStr = Console.ReadLine()

                    enterFlag = True
                    For e = 1 To 150
                        If studentIDs(e) = studentIDStr Then
                            Console.WriteLine("")
                            Console.WriteLine("You have already entered your preference!")
                            enterFlag = False
                        End If
                    Next

                    If enterFlag = True Then
                        Console.WriteLine("")
                        Console.WriteLine("Option A: " & optionsDesc(1))
                        Console.WriteLine("Option B: " & optionsDesc(2))
                        Console.WriteLine("Option C: " & optionsDesc(3))
                        Console.WriteLine("Option D: " & optionsDesc(4))
                        Console.WriteLine("Option E: " & optionsDesc(5))
                        Console.WriteLine("")
                        Console.WriteLine("Enter your preference ('1': 'Strongly Agree' - '5': 'Strong Disagree')")

                        'Option A
                        Console.WriteLine("")
                        Console.Write("Preference for Option A: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.WriteLine("Enter a correct value (1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        studentPref(1) = studentPref(1) + preference

                        If preference = 1 Then
                            studentPrefOne(1) = studentPrefOne(1) + 1
                        End If

                        'Option B
                        Console.WriteLine("")
                        Console.Write("Preference for Option B: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.WriteLine("Enter a correct value (1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        studentPref(2) = studentPref(2) + preference

                        If preference = 1 Then
                            studentPrefOne(2) = studentPrefOne(2) + 1
                        End If

                        'Option C
                        Console.WriteLine("")
                        Console.Write("Preference for Option C: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.WriteLine("Enter a correct value (1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        studentPref(3) = studentPref(3) + preference

                        If preference = 1 Then
                            studentPrefOne(3) = studentPrefOne(3) + 1
                        End If

                        'Option D
                        Console.WriteLine("")
                        Console.Write("Preference for Option D: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.WriteLine("Enter a correct value (1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        studentPref(4) = studentPref(4) + preference

                        If preference = 1 Then
                            studentPrefOne(4) = studentPrefOne(4) + 1
                        End If

                        'Option E
                        Console.WriteLine("")
                        Console.Write("Preference for Option E: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.WriteLine("Enter a correct value (1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        studentPref(5) = studentPref(5) + preference

                        If preference = 1 Then
                            studentPrefOne(5) = studentPrefOne(5) + 1
                        End If
                    End If

                ElseIf UCase(switch) = "STAFF" Then
                    switchFlag = False

                    Console.WriteLine("")
                    Console.Write("Enter your staff ID: ")
                    staffIDStr = Console.ReadLine()

                    enterFlag = True
                    For e = 1 To 20
                        If staffIDs(e) = staffIDStr Then
                            Console.WriteLine("You have already entered your preference!")
                            enterFlag = False
                        End If
                    Next

                    If enterFlag = True Then
                        Console.WriteLine("")
                        Console.WriteLine("Option A: " & optionsDesc(1))
                        Console.WriteLine("Option B: " & optionsDesc(2))
                        Console.WriteLine("Option C: " & optionsDesc(3))
                        Console.WriteLine("Option D: " & optionsDesc(4))
                        Console.WriteLine("Option E: " & optionsDesc(5))
                        Console.WriteLine("")
                        Console.WriteLine("Enter your preference ('1': 'Strongly Agree' - '5': 'Strong Disagree')")

                        'Option A
                        Console.WriteLine("")
                        Console.Write("Preference for Option A: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.Write("Enter a correct value(1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        staffPref(1) = staffPref(1) + preference

                        If preference = 1 Then
                            staffPrefOne(1) = staffPrefOne(1) + 1
                        End If

                        'Option B
                        Console.WriteLine("")
                        Console.Write("Preference for Option B: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.Write("Enter a correct value(1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        staffPref(2) = staffPref(2) + preference

                        If preference = 1 Then
                            staffPrefOne(2) = staffPrefOne(2) + 1
                        End If

                        'Option C
                        Console.WriteLine("")
                        Console.Write("Preference for Option C: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.Write("Enter a correct value(1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        staffPref(3) = staffPref(3) + preference

                        If preference = 1 Then
                            staffPrefOne(3) = staffPrefOne(3) + 1
                        End If

                        'Option D
                        Console.WriteLine("")
                        Console.Write("Preference for Option D: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.Write("Enter a correct value(1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        staffPref(4) = staffPref(4) + preference

                        If preference = 1 Then
                            staffPrefOne(4) = staffPrefOne(4) + 1
                        End If

                        'Option E
                        Console.WriteLine("")
                        Console.Write("Preference for Option E: ")
                        preference = CInt(Console.ReadLine())

                        While preference < 1 Or preference > 5
                            Console.Write("Enter a correct value(1-5): ")
                            preference = CInt(Console.ReadLine())
                        End While

                        staffPref(5) = staffPref(5) + preference

                        If preference = 1 Then
                            staffPrefOne(5) = staffPrefOne(5) + 1
                        End If

                    End If
                Else
                    Console.WriteLine("Error: Enter a valid response (Student/Staff)!")
                End If
            Loop Until switchFlag = False

            Console.WriteLine("")
            Console.Write("Would you like to add another preference? (Y/N): ")
            continueFlagStr = Console.ReadLine()

            If continueFlagStr = "Y" Then
                continueFlag = True
            ElseIf continueFlagStr = "N" Then
                continueFlag = False
            Else
                Console.WriteLine("Enter a correct value (Y/N)")
            End If

        Loop Until continueFlag = False
    End Sub

    Sub Task2()
        Console.WriteLine("Option A: " & optionsDesc(1))
        Console.WriteLine("Total staff preference: " & staffPref(1))
        Console.WriteLine("Total student preference: " & studentPref(1))
        Console.WriteLine("Total combined preference: " & (staffPref(1) + studentPref(1)))
        Console.WriteLine("")

        Console.WriteLine("Option B: " & optionsDesc(2))
        Console.WriteLine("Total staff preference: " & staffPref(2))
        Console.WriteLine("Total student preference: " & studentPref(2))
        Console.WriteLine("Total combined preference: " & (staffPref(2) + studentPref(2)))
        Console.WriteLine("")

        Console.WriteLine("Option C: " & optionsDesc(3))
        Console.WriteLine("Total staff preference: " & staffPref(3))
        Console.WriteLine("Total student preference: " & studentPref(3))
        Console.WriteLine("Total combined preference: " & (staffPref(3) + studentPref(3)))
        Console.WriteLine("")

        Console.WriteLine("Option D: " & optionsDesc(4))
        Console.WriteLine("Total staff preference: " & staffPref(4))
        Console.WriteLine("Total student preference: " & studentPref(4))
        Console.WriteLine("Total combined preference: " & (staffPref(4) + studentPref(4)))
        Console.WriteLine("")

        Console.WriteLine("Option E: " & optionsDesc(5))
        Console.WriteLine("Total staff preference: " & staffPref(5))
        Console.WriteLine("Total student preference: " & studentPref(5))
        Console.WriteLine("Total combined preference: " & (staffPref(5) + studentPref(5)))
        Console.WriteLine("")
    End Sub

    Sub Task3()
        Console.WriteLine("")
        Console.WriteLine("Option A: " & optionsDesc(1))
        Console.WriteLine("Total times preference '1' was given by staff: " & staffPrefOne(1))
        Console.WriteLine("Total times preference '1' was given by students: " & studentPrefOne(1))
        Console.WriteLine("Combined total preference of '1': " & (staffPrefOne(1) + studentPrefOne(1)))

        Console.WriteLine("")
        Console.WriteLine("Option B: " & optionsDesc(2))
        Console.WriteLine("Total times preference '1' was given by staff: " & staffPrefOne(2))
        Console.WriteLine("Total times preference '1' was given by students: " & studentPrefOne(2))
        Console.WriteLine("Combined total preference of '1': " & (staffPrefOne(2) + studentPrefOne(2)))

        Console.WriteLine("")
        Console.WriteLine("Option C: " & optionsDesc(3))
        Console.WriteLine("Total times preference '1' was given by staff: " & staffPrefOne(3))
        Console.WriteLine("Total times preference '1' was given by students: " & studentPrefOne(3))
        Console.WriteLine("Combined total preference of '1': " & (staffPrefOne(3) + studentPrefOne(3)))

        Console.WriteLine("")
        Console.WriteLine("Option D: " & optionsDesc(4))
        Console.WriteLine("Total times preference '1' was given by staff: " & staffPrefOne(4))
        Console.WriteLine("Total times preference '1' was given by students: " & studentPrefOne(4))
        Console.WriteLine("Combined total preference of '1': " & (staffPrefOne(4) + studentPrefOne(4)))

        Console.WriteLine("")
        Console.WriteLine("Option E: " & optionsDesc(5))
        Console.WriteLine("Total times preference '1' was given by staff: " & staffPrefOne(5))
        Console.WriteLine("Total times preference '1' was given by students: " & studentPrefOne(5))
        Console.WriteLine("Combined total preference of '1': " & (staffPrefOne(5) + studentPrefOne(5)))
    End Sub

End Module
