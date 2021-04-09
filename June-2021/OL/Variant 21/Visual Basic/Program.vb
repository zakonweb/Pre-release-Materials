
Module Program
    Sub Main()

        Dim choice As Integer

        Console.Clear()
        Console.WriteLine("OL Computer Science 2210/P22, Pre Release Material (Variant 1) -- May/June 2021")
        Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
        Console.WriteLine(StrDup(95, "-"))
        Do
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("1. Task 1 & 2 - Setup and Voting.")
            Console.WriteLine("2. Task 3 – Statistics Display.")
            Console.WriteLine("3. Quit.")
            Console.WriteLine("")
            Console.WriteLine("")
            Console.Write("Enter your choice [1-3]: ")
            choice = Console.ReadLine()

            If choice = 1 Then
                Call Task1()
            ElseIf choice = 2 Then
                Call Task3()
            ElseIf choice = 3 Then
                Console.Write("")
            Else
                Console.WriteLine("Enter a choice between 1 and 3, inclusive.")
                Console.WriteLine("")
            End If
        Loop Until choice = 3


    End Sub

    Dim candidateNames(4) As String
    Dim candidateVotes(4) As Integer
    Dim voterIDs(35) As String
    Dim groupName As String

    Dim groupStudents As Integer
    Dim voteAbstentions As Integer
    Dim numCandidates As Integer


    Sub Task1()

        Dim maxVotes = -1000

        Console.WriteLine("")
        Console.Write("Enter the tutor group name: ")
        groupName = Console.ReadLine()

        Console.WriteLine("")
        Console.Write("Enter the number of students [28-35]: ")
        groupStudents = CInt(Console.ReadLine())

        While groupStudents < 28 Or groupStudents > 35
            Console.WriteLine("")
            Console.Write("Enter a valid number of students [28-35]: ")
            groupStudents = CInt(Console.ReadLine())
        End While


        Console.WriteLine("")
        Console.Write("Enter the number of candidates [1-4]: ")
        numCandidates = CInt(Console.ReadLine())
        While numCandidates < 1 Or numCandidates > 4
            Console.WriteLine("")
            Console.Write("Enter a valid number of candidates [1-4]: ")
            numCandidates = CInt(Console.ReadLine())
        End While

        Console.WriteLine("")
        Console.Write("Enter the name of the first candidate: ")
        candidateNames(1) = Console.ReadLine()
        If numCandidates >= 2 Then
            Console.WriteLine("")
            Console.Write("Enter the name of the second candidate: ")
            candidateNames(2) = Console.ReadLine()
            If numCandidates >= 3 Then
                Console.WriteLine("")
                Console.Write("Enter the name of the third candidate: ")
                candidateNames(3) = Console.ReadLine()
                If numCandidates = 4 Then
                    Console.WriteLine("")
                    Console.Write("Enter the name of the fourth candidate: ")
                    candidateNames(4) = Console.ReadLine()
                End If
            End If
        End If

        Task2()

        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("Tutor group: " & groupName)
        Console.WriteLine("")
        Console.WriteLine("Votes for " & candidateNames(1) & ": " & CStr(candidateVotes(1)))
        If numCandidates >= 2 Then
            Console.WriteLine("")
            Console.WriteLine("Votes for " & candidateNames(2) & ": " & CStr(candidateVotes(2)))
            If numCandidates >= 3 Then
                Console.WriteLine("")
                Console.WriteLine("Votes for " & candidateNames(3) & ": " & CStr(candidateVotes(3)))
                If numCandidates = 4 Then
                    Console.WriteLine("")
                    Console.WriteLine("Votes for " & candidateNames(4) & ": " & CStr(candidateVotes(4)))
                End If
            End If
        End If

        maxVotes = -1000

        If candidateVotes(1) > maxVotes Or candidateVotes(1) = maxVotes Then
            Console.WriteLine("")
            Console.WriteLine("Candidate " & candidateNames(1) & ", with " & CStr(candidateVotes(1)) & " vote(s) has the most votes!")
            maxVotes = candidateVotes(1)
        End If
        If candidateVotes(2) > maxVotes Or candidateVotes(2) = maxVotes Then
            Console.WriteLine("")
            Console.WriteLine("Candidate " & candidateNames(2) & ", with " & CStr(candidateVotes(2)) & " vote(s) has the most votes!")
            maxVotes = candidateVotes(2)
        End If
        If candidateVotes(3) > maxVotes Or candidateVotes(3) = maxVotes Then
            Console.WriteLine("")
            Console.WriteLine("Candidate " & candidateNames(3) & ", with " & CStr(candidateVotes(3)) & " vote(s) has the most votes!")
            maxVotes = candidateVotes(3)
        End If
        If candidateVotes(4) > maxVotes Or candidateVotes(4) = maxVotes Then
            Console.WriteLine("")
            Console.WriteLine("Candidate " & candidateNames(4) & ", with " & CStr(candidateVotes(4)) & " vote(s) has the most votes!")
            maxVotes = candidateVotes(4)
        End If



    End Sub

    Sub Task2()

        Dim groupStudentsLoop
        Dim studentID As String
        Dim Count As Integer
        Dim nextFreeIndex As Integer
        Dim studentChoice As String



        groupStudentsLoop = groupStudents

        While groupStudentsLoop >= 1
            Console.WriteLine("")
            Console.Write("Enter your voter number: ")
            studentID = Console.ReadLine()

            For Count = 1 To 35
                If voterIDs(Count) = "" Then
                    nextFreeIndex = Count
                End If
                If voterIDs(Count) = studentID Then
                    Console.WriteLine("")
                    Console.WriteLine("You have already voted!")
                    Console.WriteLine("")
                Else
                    voterIDs(nextFreeIndex) = studentID
                    Console.WriteLine("")
                    Console.Write("Enter the voting choice of the next student (Enter 'SKIP' for abstention): ")
                    studentChoice = Console.ReadLine()

                    If studentChoice = candidateNames(1) Then
                        candidateVotes(1) = candidateVotes(1) + 1
                        groupStudentsLoop = groupStudentsLoop - 1
                    ElseIf studentChoice = candidateNames(2) Then
                        candidateVotes(2) = candidateVotes(2) + 1
                        groupStudentsLoop = groupStudentsLoop - 1
                    ElseIf studentChoice = candidateNames(3) Then
                        candidateVotes(3) = candidateVotes(3) + 1
                        groupStudentsLoop = groupStudentsLoop - 1
                    ElseIf studentChoice = candidateNames(4) Then
                        candidateVotes(4) = candidateVotes(4) + 1
                        groupStudentsLoop = groupStudentsLoop - 1
                    ElseIf studentChoice = "SKIP" Then
                        voteAbstentions = voteAbstentions + 1
                        groupStudentsLoop = groupStudentsLoop - 1
                    Else
                        Console.WriteLine("")
                        Console.WriteLine("Enter a correct choice.")
                        Console.WriteLine("")
                    End If
                End If
            Next
        End While


    End Sub


    Sub Task3()
        Dim numVotes As Integer
        Dim percOne As Double
        Dim percTwo As Double
        Dim percThree As Double
        Dim percFour As Double

        numVotes = groupStudents - voteAbstentions

        Console.WriteLine("")
        Console.WriteLine("The total votes cast were: " & CStr(numVotes) & " votes.")
        Console.WriteLine("The total number of astentions were: " & CStr(voteAbstentions))

        percOne = (candidateVotes(1) / numVotes) * 100
        Console.WriteLine("")
        Console.WriteLine("Candidate name: " & CStr(candidateNames(1)))
        Console.WriteLine("Number of votes: " & CStr(candidateVotes(1)))
        Console.WriteLine("Percentage votes: " & CStr(percOne) & "%")

        If numCandidates >= 2 Then
            percTwo = (candidateVotes(2) / numVotes) * 100
            Console.WriteLine("")
            Console.WriteLine("Candidate name: " & CStr(candidateNames(2)))
            Console.WriteLine("Number of votes: " & CStr(candidateVotes(2)))
            Console.WriteLine("Percentage votes: " & CStr(percTwo) & "%")
            If numCandidates >= 3 Then
                percThree = (candidateVotes(3) / numVotes) * 100
                Console.WriteLine("")
                Console.WriteLine("Candidate name: " & CStr(candidateNames(3)))
                Console.WriteLine("Number of votes: " & CStr(candidateVotes(3)))
                Console.WriteLine("Percentage votes: " & CStr(percThree) & "%")
                If numCandidates = 4 Then
                    percFour = (candidateVotes(4) / numVotes) * 100
                    Console.WriteLine("")
                    Console.WriteLine("Candidate name: " & CStr(candidateNames(4)))
                    Console.WriteLine("Number of votes: " & CStr(candidateVotes(4)))
                    Console.WriteLine("Percentage votes: " & CStr(percFour) & "%")
                End If
            End If
        End If

        If numCandidates >= 2 Then
            If percOne = percTwo Then
                Console.WriteLine("")
                Console.WriteLine("The elections are to be run again with " & candidateNames(1) & " and " & candidateNames(2))
            End If
        End If
        If numCandidates >= 3 Then
            If percOne = percThree Then
                Console.WriteLine("")
                Console.WriteLine("The elections are to be run again with " & candidateNames(1) & " and " & candidateNames(3))
            End If
            If percTwo = percThree Then
                Console.WriteLine("")
                Console.WriteLine("The elections are to be run again with " & candidateNames(2) & " and " & candidateNames(3))
            End If
        End If
        If numCandidates = 4 Then
            If percOne = percFour Then
                Console.WriteLine("")
                Console.WriteLine("The elections are to be run again with " & candidateNames(1) & " and " & candidateNames(4))
            End If
            If percTwo = percFour Then
                Console.WriteLine("")
                Console.WriteLine("The elections are to be run again with " & candidateNames(2) & " and " & candidateNames(4))
            End If
            If percThree = percFour Then
                Console.WriteLine("")
                Console.WriteLine("The elections are to be run again with " & candidateNames(3) & " and " & candidateNames(4))
            End If
        End If

    End Sub


End Module
