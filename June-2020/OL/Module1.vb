Module Module1
    Const midnight = 24
    Const eveningPrice = 2.0

    Dim day, answer, cardNumber, discountAllowed As String
    Dim stayHours, arrivalHour, departureHour, d1, d2, d3, d4, cd, x, morningHours, eveningHours As Integer
    Dim price, morningPrice, amount, payment, total As Decimal
    Dim hoursAllowed, discount As Boolean
    Dim discountRate As Single

    Sub Main()
        Dim choice As Integer

        Do
            choice = 0
            Console.Clear()
            Console.WriteLine("OL Computer Science 2210/22, Pre Release Material -- May/June 2020")
            Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
            Console.WriteLine("1. Task 1")
            Console.WriteLine("2. Task 2")
            Console.WriteLine("3. Task 3")
            Console.WriteLine("4. Quit PRM")

            Do
                Console.Write("Enter your choice... ")
                Try
                    choice = Console.ReadLine
                    If choice < 1 Or choice > 4 Then
                        Console.WriteLine("Wrong choice. Please enter between 1 and 4...")
                    End If
                Catch
                    Console.WriteLine("Wrong choice. Please enter between 1 and 4...")
                End Try
            Loop Until choice >= 1 And choice <= 4

            Select Case choice
                Case 1 : Call Task1()
                Case 2 : Call Task2()
                Case 3 : Call Task3()
            End Select

        Loop Until choice = 4
    End Sub

    Sub Task1()

        Do
            Console.Write("Enter Day: ") : day = Console.ReadLine
            If day = "" Then Console.WriteLine("You can't leave the day blank.")
        Loop Until Trim(UCase(day)) = "MONDAY" Or Trim(UCase(day)) = "TUESDAY" Or _
            Trim(UCase(day)) = "WEDNESDAY" Or Trim(UCase(day)) = "THURSDAY" Or _
            Trim(UCase(day)) = "FRIDAY" Or Trim(UCase(day)) = "SATURDAY" Or _
            Trim(UCase(day)) = "SUNDAY"

        Do
            Console.Write("Enter hour of arrival (8-23): ") : arrivalHour = Console.ReadLine
            If arrivalHour < 8 Or arrivalHour > 23 Then Console.WriteLine("Allowed hours for parking are from 8 till midnight!")
        Loop Until arrivalHour >= 8 And arrivalHour < midnight

        hoursAllowed = False
        Do
            Console.Write("Enter max stay in hours: ") : stayHours = Console.ReadLine
            departureHour = arrivalHour + stayHours
            If departureHour <= midnight Then
                If arrivalHour < 16 Then
                    If day = "Sunday" And stayHours <= 8 Then
                        hoursAllowed = True
                    ElseIf day = "Saturday" And stayHours <= 4 Then
                        hoursAllowed = True
                    ElseIf stayHours <= 2 Then
                        hoursAllowed = True
                    Else
                        Console.WriteLine("Today " & stayHours & " hours stay is not allowed!")
                    End If
                Else
                    hoursAllowed = True
                End If
            Else
                Console.WriteLine("You cannot stay beyond midnight!")
            End If
        Loop Until hoursAllowed = True

        discount = False
        discountAllowed = "0%"
        Console.Write("Do you have frequent parking card? ") : answer = Console.ReadLine
        If UCase(answer) = "YES" Then
            Console.Write("Enter frequent parking card number: ") : cardNumber = Console.ReadLine
            d1 = Mid(cardNumber, 1, 1)
            d2 = Mid(cardNumber, 2, 1)
            d3 = Mid(cardNumber, 3, 1)
            d4 = Mid(cardNumber, 4, 1)
            cd = Mid(cardNumber, 5, 1)
            x = ((d1 * 5) + (d2 * 4) + (d3 * 3) + (d4 * 2) + (cd * 1)) Mod 11
            If x = 0 Then discount = True
        End If

        If arrivalHour >= 16 Then
            amount = eveningPrice
        Else
            If day = "Sunday" Then
                price = 2
            ElseIf day = "Saturday" Then
                price = 3
            Else
                price = 10
            End If
            amount = stayHours * price
        End If

        If discount = True Then
            If arrivalHour >= 16 Then
                discountAllowed = "50%"
                amount = amount * 0.5
            Else
                discountAllowed = "10%"
                amount = amount * 0.9
            End If
        End If

        Console.WriteLine()
        Console.WriteLine("Data entered and price to park calculated")
        Console.WriteLine("-------------------------------------------------------")
        Console.WriteLine("Day: " & day)
        Console.WriteLine("Time of arrival: " & arrivalHour)
        Console.WriteLine("Hours stayed: " & stayHours)
        If arrivalHour >= 16 Then
            Console.WriteLine("Car parking price for full evening: " & price)
        Else
            Console.WriteLine("Car parking price per hour: " & price)
        End If
        Console.WriteLine("Discount given: " & discount)
        If discount = True Then Console.WriteLine("Discount : " & discountAllowed)
        Console.WriteLine("Price to park: " & amount)
        Console.ReadKey()
    End Sub

    Sub Task2()

        total = 0
        Do
            Console.Write("Enter Day: ") : day = Console.ReadLine
            If day = "" Then Console.WriteLine("You can't leave the day blank.")
        Loop Until Trim(UCase(day)) = "MONDAY" Or Trim(UCase(day)) = "TUESDAY" Or _
            Trim(UCase(day)) = "WEDNESDAY" Or Trim(UCase(day)) = "THURSDAY" Or _
            Trim(UCase(day)) = "FRIDAY" Or Trim(UCase(day)) = "SATURDAY" Or _
            Trim(UCase(day)) = "SUNDAY"

        Do
            Console.Clear()
            Do
                Console.Write("Enter hour of arrival (8-23): ") : arrivalHour = Console.ReadLine
                If arrivalHour < 8 Or arrivalHour > 23 Then Console.WriteLine("Allowed hours for parking are from 8 to 23!")
            Loop Until arrivalHour >= 8 And arrivalHour < midnight

            hoursAllowed = False
            Do
                Console.Write("Enter max stay in hours: ") : stayHours = Console.ReadLine
                departureHour = arrivalHour + stayHours
                If departureHour <= midnight Then
                    If arrivalHour < 16 Then
                        If day = "Sunday" And stayHours <= 8 Then
                            hoursAllowed = True
                        ElseIf day = "Saturday" And stayHours <= 4 Then
                            hoursAllowed = True
                        ElseIf stayHours <= 2 Then
                            hoursAllowed = True
                        Else
                            Console.WriteLine("Today " & stayHours & " hours stay is not allowed!")
                        End If
                    Else
                        hoursAllowed = True
                    End If
                Else
                    Console.WriteLine("You cannot stay beyond midnight!")
                End If
            Loop Until hoursAllowed = True

            discount = False
            discountAllowed = "0%"
            Console.Write("Do you have frequent parking card? ") : answer = Console.ReadLine
            If UCase(answer) = "YES" Then
                Console.Write("Enter frequent parking card number: ") : cardNumber = Console.ReadLine
                d1 = Mid(cardNumber, 1, 1)
                d2 = Mid(cardNumber, 2, 1)
                d3 = Mid(cardNumber, 3, 1)
                d4 = Mid(cardNumber, 4, 1)
                cd = Mid(cardNumber, 5, 1)
                x = ((d1 * 5) + (d2 * 4) + (d3 * 3) + (d4 * 2) + (cd * 1)) Mod 11
                If x = 0 Then discount = True
            End If

            If arrivalHour >= 16 Then
                amount = eveningPrice
            Else
                If day = "Sunday" Then
                    price = 2
                ElseIf day = "Saturday" Then
                    price = 3
                Else
                    price = 10
                End If
                amount = stayHours * price
            End If

            If discount = True Then
                If arrivalHour >= 16 Then
                    discountAllowed = "50%"
                    amount = amount * 0.5
                Else
                    discountAllowed = "10%"
                    amount = amount * 0.9
                End If
            End If

            Console.WriteLine()
            Console.WriteLine("Data entered and price to park calculated")
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine("Day: " & day)
            Console.WriteLine("Time of arrival: " & arrivalHour)
            If arrivalHour >= 16 Then
                Console.WriteLine("Car parking price for full evening: " & price)
            Else
                Console.WriteLine("Car parking price per hour: " & price)
            End If
            Console.WriteLine("Discount given: " & discount)
            If discount = True Then Console.WriteLine("Discount : " & discountAllowed)
            Console.WriteLine("Price to park: " & amount)

            Do
                Console.Write("Enter payment amount: ") : payment = Console.ReadLine
                If payment < amount Then Console.WriteLine("Your payment cannot be less than Rs." & amount)
            Loop Until payment >= amount
            total = total + payment

            Console.Write("Do you want to finish data entry and see total takings (collection)? ")
            answer = Console.ReadLine
        Loop Until UCase(answer) = "YES"

        Console.WriteLine("Total takings/collection for the day = " & total)
        Console.ReadKey()
    End Sub

    Sub Task3()
        Do
            Console.Write("Enter Day: ") : day = Console.ReadLine
            If day = "" Then Console.WriteLine("You can't leave the day blank.")
        Loop Until Trim(UCase(day)) = "MONDAY" Or Trim(UCase(day)) = "TUESDAY" Or _
            Trim(UCase(day)) = "WEDNESDAY" Or Trim(UCase(day)) = "THURSDAY" Or _
            Trim(UCase(day)) = "FRIDAY" Or Trim(UCase(day)) = "SATURDAY" Or _
            Trim(UCase(day)) = "SUNDAY"

        Do
            Console.Write("Enter hour of arrival (8-23): ") : arrivalHour = Console.ReadLine
            If arrivalHour < 8 Or arrivalHour > 23 Then Console.WriteLine("Allowed hours for parking are from 8 to 23!")
        Loop Until arrivalHour >= 8 And arrivalHour < midnight

        hoursAllowed = False
        Do
            Console.Write("Enter max stay in hours: ") : stayHours = Console.ReadLine
            departureHour = arrivalHour + stayHours
            If departureHour <= midnight Then
                If arrivalHour < 16 Then
                    If day = "Sunday" And stayHours <= 8 Then
                        hoursAllowed = True
                    ElseIf day = "Saturday" And stayHours <= 4 Then
                        hoursAllowed = True
                    ElseIf stayHours <= 2 Then
                        hoursAllowed = True
                    Else
                        Console.WriteLine("Today " & stayHours & " hours stay is not allowed!")
                    End If
                Else
                    hoursAllowed = True
                End If
            Else
                Console.WriteLine("You cannot stay beyond midnight!")
            End If
        Loop Until hoursAllowed = True

        discount = False
        discountAllowed = "0%"
        Console.Write("Do you have frequent parking card? ") : answer = Console.ReadLine
        If UCase(answer) = "YES" Then
            Console.Write("Enter frequent parking card number: ") : cardNumber = Console.ReadLine
            d1 = Mid(cardNumber, 1, 1)
            d2 = Mid(cardNumber, 2, 1)
            d3 = Mid(cardNumber, 3, 1)
            d4 = Mid(cardNumber, 4, 1)
            cd = Mid(cardNumber, 5, 1)
            x = ((d1 * 5) + (d2 * 4) + (d3 * 3) + (d4 * 2) + (cd * 1)) Mod 11
            If x = 0 Then discount = True
        End If

        morningHours = 0
        eveningHours = 0
        discountRate = 1
        If arrivalHour >= 16 Then
            eveningHours = stayHours
            If discount = True Then discountRate = 0.5
        ElseIf departureHour < 16 Then
            morningHours = stayHours
            If discount = True Then discountRate = 0.9
        ElseIf arrivalHour < 16 And departureHour >= 16 Then
            morningHours = 16 - arrivalHour
            eveningHours = stayHours - morningHours
            If discount = True Then discountRate = 0.9
        End If

        morningPrice = 0
        If day = "Sunday" Or arrivalHour >= 16 Then
            morningPrice = eveningPrice
        ElseIf day = "Saturday" Then
            morningPrice = 3
        Else
            morningPrice = 10
        End If

        Select Case discountRate
            Case 1 : discountAllowed = "0%"
            Case 0.5 : discountAllowed = "50%"
            Case 0.9 : discountAllowed = "10%"
        End Select

        amount = (morningHours * morningPrice)
        If eveningHours > 0 Then amount = amount + eveningPrice
        amount = amount * discountRate
        amount = Math.Round(amount, 2)

        Console.WriteLine()
        Console.WriteLine("Data entered and price to park calculated")
        Console.WriteLine("-------------------------------------------------------")
        Console.WriteLine("Day: " & day)
        Console.WriteLine("Time of arrival: " & arrivalHour)
        Console.WriteLine("Morning hours stay: " & morningHours)
        Console.WriteLine("Evening hours stay: " & eveningHours)
        Console.WriteLine("Morning car parking price per hour: " & morningPrice)
        Console.WriteLine("Evening parking price for full evening: " & eveningPrice)
        Console.WriteLine("Discount given: " & discount)
        If discount = True Then Console.WriteLine("Discount : " & discountAllowed)
        Console.WriteLine("Price to park: " & amount)
        Console.ReadKey()
    End Sub
End Module
