Imports System

Module Program
    Dim leaveTickets(4) As Integer
    Dim returnTickets(4) As Integer
    Dim leavePassengers(4) As Integer
    Dim returnPassengers(4) As Integer
    Dim leaveTotal(4) As Integer
    Dim returnTotal(4) As Integer
    Dim choice As Integer
    Dim choiceFlag As Boolean = False
    Sub Main()



        Console.Clear()
        Console.WriteLine("OL Computer Science 2210/P22, Pre Release Material (Variant 2) -- May/June 2021")
        Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
        Console.WriteLine(StrDup(95, "-"))
        Do
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("1. Task 1 - Start-of-the-day display")
            Console.WriteLine("2. Task 2 – Purchasing tickets.")
            Console.WriteLine("3. Task 3 – Day-end display.")
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


    Sub Task1()

        '   Write a program to set up the screen display for the start of the day. Initialise suitable data structure(s)
        '   to total passengers for each train journey And total the money taken for each train journey. Each train
        '   journey must be totalled separately. There are four journeys up And four journeys down every day.

        leaveTickets(1) = 480
        leaveTickets(2) = 480
        leaveTickets(3) = 480
        leaveTickets(4) = 480


        returnTickets(1) = 480
        returnTickets(2) = 480
        returnTickets(3) = 480
        returnTickets(4) = 620

        leavePassengers(1) = 0
        leavePassengers(2) = 0
        leavePassengers(3) = 0
        leavePassengers(4) = 0

        returnPassengers(1) = 0
        returnPassengers(2) = 0
        returnPassengers(3) = 0
        returnPassengers(4) = 0

        leaveTotal(1) = 0
        leaveTotal(2) = 0
        leaveTotal(3) = 0
        leaveTotal(4) = 0

        returnTotal(1) = 0
        returnTotal(2) = 0
        returnTotal(3) = 0
        returnTotal(4) = 0


        Console.WriteLine("Departure train - 09:00. Tickets left: " & CStr(leaveTickets(1)))
        Console.WriteLine("Departure train - 11:00. Tickets left: " & CStr(leaveTickets(2)))
        Console.WriteLine("Departure train - 13:00. Tickets left: " & CStr(leaveTickets(3)))
        Console.WriteLine("Departure train - 15:00. Tickets left: " & CStr(leaveTickets(4)))
        Console.WriteLine("")
        Console.WriteLine("Return train - 10:00. Tickets left: " & CStr(returnTickets(1)))
        Console.WriteLine("Return train - 12:00. Tickets left: " & CStr(returnTickets(2)))
        Console.WriteLine("Return train - 14:00. Tickets left: " & CStr(returnTickets(3)))
        Console.WriteLine("Return train - 16:00. Tickets left: " & CStr(returnTickets(4)))

    End Sub

    Dim continueFlag As Boolean
    Dim discountFlag As Boolean
    Dim departureFlag As Boolean
    Dim returnFlag As Boolean

    Dim continueFlagStr As String
    Dim departureJourney As String
    Dim returnJourney As String

    Dim numPassengers As Integer
    Dim numPassengersTemp As Integer
    Dim discount As Integer
    Dim cost As Integer

    'TASK 2
    Sub Task2()

        '   Tickets can be purchased For a Single passenger Or a group. When making a purchase, check that the
        '   number of tickets for the required train journeys up And down the mountain Is available. If the tickets
        '   are available, calculate the total price including any group discount. Update the screen display And the
        '   Data for the totals. 


        continueFlag = True
        Do
            Console.WriteLine("")
            Console.WriteLine("")
            Console.Write("Enter the number of passengers travelling: ")
            numPassengers = Console.ReadLine()
            Console.WriteLine("")

            discountFlag = True

            discount = 0
            numPassengersTemp = numPassengers
            Do
                If numPassengersTemp - 10 >= 0 Then
                    discount = discount + 1
                    numPassengersTemp = numPassengersTemp - 10
                Else
                    discountFlag = False
                End If

            Loop Until discountFlag = False Or discount >= 8

            departureFlag = True
            Do
                Console.WriteLine("")
                Console.Write("Choose the departure timings (0900/1100/1300/1500): ")
                departureJourney = Console.ReadLine


                If departureJourney = "0900" Then

                    If leaveTickets(1) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        leaveTickets(1) = leaveTickets(1) - numPassengers
                        leavePassengers(1) = leavePassengers(1) + numPassengers

                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        leaveTotal(1) = leaveTotal(1) + cost
                        departureFlag = False
                    End If

                ElseIf departureJourney = "1100" Then
                    If leaveTickets(2) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        leaveTickets(2) = leaveTickets(2) - numPassengers
                        leavePassengers(2) = leavePassengers(2) + numPassengers

                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        leaveTotal(2) = leaveTotal(2) + cost
                        departureFlag = False
                    End If

                ElseIf departureJourney = "1300" Then
                    If leaveTickets(3) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        leaveTickets(3) = leaveTickets(3) - numPassengers
                        leavePassengers(3) = leavePassengers(3) + numPassengers

                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        leaveTotal(3) = leaveTotal(3) + cost
                        departureFlag = False
                    End If

                ElseIf departureJourney = "1500" Then
                    If leaveTickets(4) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        leaveTickets(4) = leaveTickets(4) - numPassengers
                        leavePassengers(4) = leavePassengers(4) + numPassengers

                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        leaveTotal(4) = leaveTotal(4) + cost
                        departureFlag = False
                    End If
                Else
                    Console.WriteLine("")
                    Console.WriteLine("Invalid response. Please choose one of 0900/1100/1300/1500")
                    Console.WriteLine("")
                End If
            Loop Until departureFlag = False

            returnFlag = True
            Do
                Console.WriteLine("")
                Console.Write("Choose the departure timings (1000/1200/1400/1600): ")
                returnJourney = Console.ReadLine

                If returnJourney = "1000" Then
                    If returnTickets(1) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        returnTickets(1) = returnTickets(1) - numPassengers
                        returnPassengers(1) = returnPassengers(1) + numPassengers
                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        returnTotal(1) = returnTotal(1) + cost
                        returnFlag = False
                    End If

                ElseIf returnJourney = "1200" Then
                    If returnTickets(2) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        returnTickets(2) = returnTickets(2) - numPassengers
                        returnPassengers(2) = returnPassengers(2) + numPassengers
                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        returnTotal(2) = returnTotal(2) + cost
                        returnFlag = False
                    End If

                ElseIf returnJourney = "1400" Then
                    If returnTickets(3) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        returnTickets(3) = returnTickets(3) - numPassengers
                        returnPassengers(3) = returnPassengers(3) + numPassengers
                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        returnTotal(3) = returnTotal(3) + cost
                        returnFlag = False
                    End If

                ElseIf returnJourney = "1600" Then
                    If returnTickets(4) - numPassengers < 0 Then
                        Console.WriteLine("")
                        Console.WriteLine("Not enough tickets left on this train.")
                        Console.WriteLine("")
                    Else
                        returnTickets(4) = returnTickets(4) - numPassengers
                        returnPassengers(4) = returnPassengers(4) + numPassengers
                        cost = 25 * (numPassengers - discount)
                        Console.WriteLine("Total tickets price: " & CStr(cost))
                        returnTotal(4) = returnTotal(4) + cost
                        returnFlag = False
                    End If
                Else
                    Console.WriteLine("")
                    Console.WriteLine("Invalid response. Please choose one of 1000/1200/1400/1600")
                    Console.WriteLine("")
                    Console.WriteLine("")
                End If
            Loop Until returnFlag = False



            Console.WriteLine("Departure train - 09:00. Tickets left: " & CStr(leaveTickets(1)))
            Console.WriteLine("Departure train - 11:00. Tickets left: " & CStr(leaveTickets(2)))
            Console.WriteLine("Departure train - 13:00. Tickets left: " & CStr(leaveTickets(3)))
            Console.WriteLine("Departure train - 15:00. Tickets left: " & CStr(leaveTickets(4)))
            Console.WriteLine("")
            Console.WriteLine("Return train - 10:00. Tickets left: " & CStr(returnTickets(1)))
            Console.WriteLine("Return train - 12:00. Tickets left: " & CStr(returnTickets(2)))
            Console.WriteLine("Return train - 14:00. Tickets left: " & CStr(returnTickets(3)))
            Console.WriteLine("Return train - 16:00. Tickets left: " & CStr(returnTickets(4)))
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("")

            Console.Write("Are there more tickets to buy? (Y/N): ")
            continueFlagStr = Console.ReadLine()
            If continueFlagStr = "Y" Then
                continueFlag = True
            ElseIf continueFlagStr = "N" Then
                continueFlag = False
            Else
                Console.WriteLine("Enter a correct value.")
            End If

        Loop Until continueFlag = False

        Console.WriteLine("")
        Console.WriteLine("")
    End Sub

    Sub Task3()

        '   Display the number of passengers that travelled on each train journey And the total money taken for
        '   each train journey. Calculate And display the total number of passengers And the total amount of money
        '   taken for the day. Find And display the train journey with the most passengers that day.


        Dim totalPassengers As Integer
        Dim totalMoney As Integer
        Dim mostPassengers As Integer
        Dim leaveMost As Boolean
        Dim returnMost As Boolean
        Dim index As Integer


        Console.WriteLine("Number of passengers on the 0900 Departure train: " & CStr(leavePassengers(1)))
        Console.WriteLine("Total money taken for the 0900 Departure train: " & CStr(leaveTotal(1)))
        Console.WriteLine("")
        Console.WriteLine("Number of passengers on the 1100 Departure train: " & CStr(leavePassengers(2)))
        Console.WriteLine("Total money taken for the 1100 Departure train: " & CStr(leaveTotal(2)))
        Console.WriteLine("")
        Console.WriteLine("Number of passengers on the 1300 Departure train: " & CStr(leavePassengers(3)))
        Console.WriteLine("Total money taken for the 1300 Departure train: " & CStr(leaveTotal(3)))
        Console.WriteLine("")
        Console.WriteLine("Number of passengers on the 1500 Departure train: " & CStr(leavePassengers(4)))
        Console.WriteLine("Total money taken for the 1500 Departure train: " & CStr(leaveTotal(4)))
        Console.WriteLine("")
        Console.WriteLine("Number of passengers on the 1000 Return train: " & CStr(returnPassengers(1)))
        Console.WriteLine("Total money taken for the 1000 Return train: " & CStr(returnTotal(1)))
        Console.WriteLine("")
        Console.WriteLine("Number of passengers on the 1200 Return train: " & CStr(returnPassengers(2)))
        Console.WriteLine("Total money taken for the 1200 Return train: " & CStr(returnTotal(2)))
        Console.WriteLine("")
        Console.WriteLine("Number of passengers on the 1400 Return train: " & CStr(returnPassengers(3)))
        Console.WriteLine("Total money taken for the 1400 Return train: " & CStr(returnTotal(3)))
        Console.WriteLine("")
        Console.WriteLine("Number of passengers on the 1600 Return train: " & CStr(returnPassengers(4)))
        Console.WriteLine("Total money taken for the 1600 Return train: " & CStr(returnTotal(4)))
        Console.WriteLine("")
        Console.WriteLine("")

        totalPassengers = 0
        totalMoney = 0

        For i = 1 To 4
            totalPassengers = totalPassengers + leavePassengers(i)
            totalPassengers = totalPassengers + returnPassengers(i)
            totalMoney = totalMoney + leaveTotal(i)
            totalMoney = totalMoney + returnTotal(i)
        Next

        mostPassengers = -1000
        leaveMost = False
        returnMost = False

        index = 0

        For i = 1 To 4
            If leavePassengers(i) > mostPassengers Then
                mostPassengers = leavePassengers(i)
                index = i
                leaveMost = True
                returnMost = False
            End If

            If returnPassengers(i) > mostPassengers Then
                mostPassengers = returnPassengers(i)
                index = i
                returnMost = True
                leaveMost = False
            End If
        Next

        If index = 1 And leaveMost Then
            Console.WriteLine("The 0900 Departure train had the most passengers")
        ElseIf index = 1 And returnMost Then
            Console.WriteLine("The 1000 Return train had the most passengers")
        ElseIf index = 2 And leaveMost Then
            Console.WriteLine("The 1100 Departure train had the most passengers")
        ElseIf index = 2 And returnMost Then
            Console.WriteLine("The 1200 Return train had the most passengers")
        ElseIf index = 3 And leaveMost Then
            Console.WriteLine("The 1300 Departure train had the most passengers")
        ElseIf index = 3 And returnMost Then
            Console.WriteLine("The 1400 Return train had the most passengers")
        ElseIf index = 4 And leaveMost Then
            Console.WriteLine("The 1500 Departure train had the most passengers")
        ElseIf index = 4 And returnMost Then
            Console.WriteLine("The 1600 Return train had the most passengers")
        End If

        Console.WriteLine("Total money taken for the day: " & CStr(totalMoney))
        Console.WriteLine("Total passengers travelling for the day: " & CStr(totalPassengers))


    End Sub





End Module

