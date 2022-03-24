Imports System

Module Program

    Dim ticketTypes(5), extraAttractions(3), days(7), ticketPricesOneDay(5), ticketPricesTwoDays(5), extraAttractionsPrice(3) As String
    Dim displayCount As Integer

    Sub Main(args As String())

        Dim choice As Integer

        Console.Clear()
        Console.WriteLine("OL Computer Science 2210/P22, Pre Release Material (Variant 2) -- May/June 2022")
        Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
        Console.WriteLine(StrDup(95, "-"))
        Do
            Console.WriteLine("")
            Console.WriteLine("1. Task 1 - Display Options")
            Console.WriteLine("2. Task 2 and 3 – Purchasing tickets.")
            Console.WriteLine("3. Quit.")
            Console.WriteLine("")
            Console.Write("Enter your choice [1-3]: ")
            choice = Console.ReadLine()

            If choice = 1 Then
                Call Task1()
            ElseIf choice = 2 Then
                Call Task2_3()
            ElseIf choice = 3 Then
                Console.Write("")
            Else
                Console.WriteLine("Enter a choice between 1 and 3, inclusive.")
                Console.WriteLine("")
            End If
        Loop Until choice = 1 Or choice = 2 Or choice = 3


    End Sub

    'TASK 1
    Sub Task1()

        Console.Clear()

        ticketTypes(1) = "One Adult"
        ticketTypes(2) = "One Child"
        ticketTypes(3) = "One Senior"
        ticketTypes(4) = "Family (Two Adults/Seniors, Three Children)"
        ticketTypes(5) = "Group (Six+ People, price per person)"

        days(1) = "Monday"
        days(2) = "Tuesday"
        days(3) = "Wednesday"
        days(4) = "Thursday"
        days(5) = "Friday"
        days(6) = "Saturday"
        days(7) = "Sunday"

        extraAttractions(1) = "Lion Feeding"
        extraAttractions(2) = "Penguin Feeding"
        extraAttractions(3) = "Evening Barbeque (two-day tickets only)"

        ticketPricesOneDay(1) = "20.00"
        ticketPricesOneDay(2) = "12.00"
        ticketPricesOneDay(3) = "16.00"
        ticketPricesOneDay(4) = "60.00"
        ticketPricesOneDay(5) = "15.00"

        ticketPricesTwoDays(1) = "30.00"
        ticketPricesTwoDays(2) = "18.00"
        ticketPricesTwoDays(3) = "24.00"
        ticketPricesTwoDays(4) = "90.00"
        ticketPricesTwoDays(5) = "22.50"

        extraAttractionsPrice(1) = "2.50"
        extraAttractionsPrice(2) = "2.00"
        extraAttractionsPrice(3) = "5.00"

        displayCount = 0


        Console.WriteLine("One-Day Tickets")
        Console.WriteLine("---------------")
        For displayCount = 1 To 5
            Console.WriteLine(CStr(displayCount) + ". " + ticketTypes(displayCount) + ": $" + CStr(ticketPricesOneDay(displayCount)))
        Next

        Console.WriteLine("")

        Console.WriteLine("Two-Days Tickets")
        Console.WriteLine("----------------")
        For displayCount = 1 To 5
            Console.WriteLine(CStr(displayCount) + ". " + ticketTypes(displayCount) + ": $" + CStr(ticketPricesTwoDays(displayCount)))
        Next

        Console.WriteLine("")

        Console.WriteLine("Extra Attractions")
        Console.WriteLine("-----------------")
        For displayCount = 1 To 3
            Console.WriteLine(CStr(displayCount) + ". " + extraAttractions(displayCount) + ": $" + CStr(extraAttractionsPrice(displayCount)))
        Next

        Console.WriteLine("")

        Console.WriteLine("Available Days")
        Console.WriteLine("--------------")
        For displayCount = 1 To 7
            Console.WriteLine(CStr(displayCount) + ". " + days(displayCount))
        Next

        Task2_3()

    End Sub


    'TASK 2 and 3
    Sub Task2_3()
        Dim bookingNum As Integer
        Dim numPeople, numAdults, numChildren, numChildrenTickets, numSeniors, numFamily, numGroup, numPenguin, numLion, numBBQ As Integer
        Dim ticketType, ticketChoice, extraChoice, individual, dayChoice, proceed As Integer
        Dim extraCost, totalPrice As Single
        Dim continueFlag As Boolean
        Dim continueChecker, bestOption As String


        continueChecker = ""
        continueFlag = True
        bookingNum = 0

        ticketType = 0
        bestOption = ""

        numPeople = 0
        numAdults = 0
        numChildren = -1
        numChildrenTickets = -1
        numSeniors = 0
        numFamily = 0
        numGroup = 0
        numPenguin = 0
        numLion = 0
        numBBQ = 0

        ticketChoice = 0
        extraChoice = 1
        dayChoice = 0

        totalPrice = 0.00

        individual = 2
        proceed = 1

        bookingNum = bookingNum + 1

        While dayChoice < 1 Or dayChoice > 7
            Console.WriteLine()
            Console.Write("Please enter the day of visit from available days shown (1-7): ")
            dayChoice = CInt(Console.ReadLine())
            If dayChoice < 1 Or dayChoice > 7 Then
                Console.WriteLine("ERROR: Please enter a valid day from the days shown above (1-7).")
                Console.WriteLine()
            End If
        End While
        Console.WriteLine()

        Console.Write("Please enter the number of adults visiting: ")
        numAdults = CInt(Console.ReadLine())

        While numChildren > (numAdults * 2) Or numChildren = -1
            Console.WriteLine()
            Console.Write("Please enter the number of children visiting: ")
            numChildren = CInt(Console.ReadLine())
            If numChildren > (numAdults * 2) Then
                Console.WriteLine()
                Console.WriteLine("ERROR: Maximum 2 children allowed per adult.")
            End If
        End While

        Console.WriteLine()
        Console.Write("Please enter the number of seniors visiting: ")
        numSeniors = CInt(Console.ReadLine())

        Console.WriteLine("---------------------------------------------")
        While ticketType <> 1 And ticketType <> 2
            Console.WriteLine()
            Console.Write("Please enter your ticket type (One-Day: 1, Two-Day: 2): ")
            ticketType = CInt(Console.ReadLine())
            If ticketType <> 1 And ticketType <> 2 Then
                Console.WriteLine()
                Console.WriteLine("ERROR: Please enter a valid ticket type (One-Day: enter 1, Two-Day: enter 2).")
            End If
        End While

        Console.WriteLine()

        While individual < 0 Or individual > 1
            Console.Write("Would you like individual booking? (Yes: 1, No: 0): ")
            individual = CInt(Console.ReadLine())
            If individual < 0 Or individual > 1 Then
                Console.WriteLine()
                Console.WriteLine("ERROR: Please enter a valid input (Yes: 1, No: 0).")
            End If
        End While

        If individual = 1 Then
            Console.WriteLine()
            Console.Write("Please enter the number of Adult Tickets you wish to purchase: ")
            numAdults = CInt(Console.ReadLine())

            While numChildrenTickets > (numAdults * 2) Or numChildrenTickets = -1
                Console.WriteLine()
                Console.Write("Please enter the number of Children Tickets you wish to purchase: ")
                numChildrenTickets = CInt(Console.ReadLine())
                If numChildrenTickets > (numAdults * 2) Then
                    Console.WriteLine()
                    Console.WriteLine("ERROR: Maximum 2 children allowed per adult.")
                End If
            End While

            Console.WriteLine()
            Console.Write("Please enter the number of Senior Tickets you wish to purchase: ")
            numSeniors = CInt(Console.ReadLine())
        Else
            Console.WriteLine()
            Console.Write("Please enter the number of Family Tickets you wish to purchase: ")
            numFamily = CInt(Console.ReadLine())

            Console.WriteLine()
            Console.Write("Please enter the number of Group Tickets you wish to purchase: ")
            numGroup = CInt(Console.ReadLine())
        End If

        numPeople = numAdults + numChildren + numSeniors

        If ticketType = 1 Then
            totalPrice = (numAdults * ticketPricesOneDay(1)) + (numChildren * ticketPricesOneDay(2)) + (numSeniors * ticketPricesOneDay(3)) + (numFamily * ticketPricesOneDay(4)) + (numGroup * ticketPricesOneDay(5))
        Else
            totalPrice = (numAdults * ticketPricesTwoDays(1)) + (numChildren * ticketPricesTwoDays(2)) + (numSeniors * ticketPricesTwoDays(3)) + (numFamily * ticketPricesTwoDays(4)) + (numGroup * ticketPricesTwoDays(5))
        End If

        Console.WriteLine("")
        Console.Write("Would you like to book an extra attraction? (Yes: 1, No: 0): ")
        extraChoice = CInt(Console.ReadLine())

        If extraChoice = 1 Then
            Console.WriteLine()
            Console.Write("Please enter the number of tickets for Lion Feeding: ")
            numLion = CInt(Console.ReadLine())
            Console.WriteLine()
            Console.Write("Please enter the number of tickets for Penguin Feeding: ")
            numPenguin = CInt(Console.ReadLine())
            If ticketType = 2 Then
                Console.WriteLine()
                Console.Write("Please enter the number of tickets for BBQ: ")
                numBBQ = CInt(Console.ReadLine())
            Else
                Console.WriteLine()
                Console.WriteLine("BBQ Not Applicable on One-Day Tickets.")
            End If
            totalPrice = totalPrice + (numLion * extraAttractionsPrice(1)) + (numPenguin * extraAttractionsPrice(2)) + (numBBQ * extraAttractionsPrice(3))
        End If

        If ((numAdults + numSeniors) Mod 2 = 0) And (numChildren Mod 3 = 0) And (numChildren = (2 / 3) * (numAdults + numSeniors)) Then
            bestOption = ticketTypes(3)
        ElseIf numPeople >= 6 Then
            bestOption = ticketTypes(4)
        Else
            bestOption = "Individual"
        End If

        If (bestOption = "Individual" And individual <> 1) Or (bestOption = ticketTypes(4) And numGroup = 0) Or (bestOption = ticketTypes(3) And numFamily = 0) Then
            Console.WriteLine()
            Console.WriteLine("The ticket options chosen are not the best value.")
            If bestOption = "Individual" Then
                Console.WriteLine("The best value option is: Individual Tickets(s)")
            ElseIf bestOption = ticketTypes(3) Then
                Console.WriteLine("The best value option is: Family Ticket(s)")
            Else
                Console.WriteLine("The best value option is: Group Ticket")
            End If
            Console.WriteLine()
            Console.Write("Would you like to proceed with your current booking? (Proceed - 1, Make New Booking - 0): ")
            proceed = CInt(Console.ReadLine())
        End If

        If proceed = 0 Then
            continueFlag = True
        Else
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("---------------")
            Console.WriteLine("BOOKING DETAILS")
            Console.WriteLine("---------------")
            Console.WriteLine("Booking Number: " + CStr(bookingNum))
            Console.WriteLine("Day of visit: " + CStr(days(dayChoice)))
            If ticketType = 1 Then
                If individual = 1 Then
                    If numAdults > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Adult (One Day) | Num. of Tickets: " + CStr(numAdults) + " | Price Per Ticket: $" + CStr(ticketPricesOneDay(1)))
                    End If
                    If numChildren > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Child (One Day) | Num. of Tickets: " + CStr(numChildren) + " | Price Per Ticket: $" + CStr(ticketPricesOneDay(2)))
                    End If
                    If numSeniors > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Senior (One Day) | Num. of Tickets: " + CStr(numSeniors) + " | Price Per Ticket: $" + CStr(ticketPricesOneDay(2)))
                    End If
                Else
                    If numFamily > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Family [2 Adults/Senior + 3 Children] (One Day) | Num. of Tickets: " + CStr(numFamily) + " | Price Per Ticket: $" + CStr(ticketPricesOneDay(4)))
                    End If
                    If numGroup > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Group [6+, price per person] (One Day) | Num. of Tickets: " + CStr(numGroup) + " | Price Per Ticket: $" + CStr(ticketPricesOneDay(5)))
                    End If
                End If
            Else
                If individual = 1 Then
                    If numAdults > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Adult (Two Days) | Num. of Tickets: " + CStr(numAdults) + " | Price Per Ticket: $" + CStr(ticketPricesTwoDays(1)))
                    End If
                    If numChildrenTickets > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Child (Two Days) | Num. of Tickets: " + CStr(numChildrenTickets) + " | Price Per Ticket: $" + CStr(ticketPricesTwoDays(2)))
                    End If
                    If numSeniors > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Senior (Two Days) | Num. of Tickets: " + CStr(numSeniors) + " | Price Per Ticket: $" + CStr(ticketPricesTwoDays(3)))
                    End If
                Else
                    If numFamily > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Family [2 Adults/Senior + 3 Children] (Two Days) | Num. of Tickets: " + CStr(numFamily) + " | Price Per Ticket: $" + CStr(ticketPricesTwoDays(4)))
                    End If
                    If numGroup > 0 Then
                        Console.WriteLine("----------")
                        Console.WriteLine("Ticket: Group [6+, price per person] (Two Days) | Num. of Tickets: " + CStr(numGroup) + " | Price Per Ticket: $" + CStr(ticketPricesTwoDays(5)))
                    End If
                End If
            End If

            If numLion > 0 Then
                Console.WriteLine("----------")
                Console.WriteLine("Extra Attraction: Lion Feeding | Price per person: $" + CStr(extraAttractionsPrice(1)))
            End If
            If numPenguin > 0 Then
                Console.WriteLine("----------")
                Console.WriteLine("Extra Attraction: Penguin Feeding | Price per person: $" + CStr(extraAttractionsPrice(2)))
            End If
            If numBBQ > 0 Then
                Console.WriteLine("----------")
                Console.WriteLine("Extra Attraction: Evening BBQ | Price per person: $" + CStr(extraAttractionsPrice(3)))
            End If
            Console.WriteLine("----------")
            Console.WriteLine("Total Cost: $" + CStr(totalPrice))

            While continueChecker <> "1" And continueChecker <> "0"
                Console.WriteLine("")
                Console.Write("Would you like to make another booking? (Yes - 1, No - 0): ")
                continueChecker = Console.ReadLine()
                If continueChecker <> "1" And continueChecker <> "0" Then
                    Console.WriteLine("ERROR: Please enter a valid response (Yes - 1, No - 0).")
                    Console.WriteLine("")
                End If
            End While

            If continueChecker = 1 Then
                Task1()
            End If

        End If


    End Sub

End Module
