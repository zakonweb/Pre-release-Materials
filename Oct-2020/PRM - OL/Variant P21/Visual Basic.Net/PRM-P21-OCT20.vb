Module Program
    Sub Main()
        Dim basePrice As Integer

        Dim engineSizeLtr As Decimal
        Dim priceChangePerc As Integer
        Dim ValueInThousands As Decimal
        Dim locationKept As String
        Dim locationFlag As Boolean
        Dim ThousandKilometerDriven As Decimal
        Dim driverAge As Integer
        Dim yearsWithoutClaim As Integer
        Dim discountPerc As Integer
        Dim newCustDiscountPerc As Integer
        Dim addDriverChoice As String
        Dim newDriverAge As Integer

        Dim newPrice As Decimal


        basePrice = 500
        priceChangePerc = 0
        engineSizeLtr = -1.0
        ValueInThousands = -1000.0
        locationFlag = False
        ThousandKilometerDriven = -1000.0
        driverAge = 0
        yearsWithoutClaim = -10

        While engineSizeLtr < 0
            Console.Clear()
            Console.WriteLine("OL Computer Science 0478/2210/P21, Pre Release Material (Variant 1) -- Oct/Nov 2020")
            Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
            Console.WriteLine(StrDup(95, "-"))

            Console.Write("Enter the engine size in litres of fuel: ")
            engineSizeLtr = Console.ReadLine
            If engineSizeLtr >= 0 And engineSizeLtr <= 0.5 Then : priceChangePerc = priceChangePerc - 5
            ElseIf engineSizeLtr > 0.5 And engineSizeLtr <= 1.0 Then : priceChangePerc = priceChangePerc + 0
            ElseIf engineSizeLtr > 1.0 And engineSizeLtr <= 2.5 Then : priceChangePerc = priceChangePerc + 5
            ElseIf engineSizeLtr > 2.5 Then : priceChangePerc = priceChangePerc + 10
            Else

                Console.WriteLine("Please enter a valid engine size.")
            End If
        End While

        While ValueInThousands < 0

            Console.Write("Enter the value of the car (in thousands): ")
            ValueInThousands = Console.ReadLine
            If ValueInThousands > 0 And ValueInThousands < 0.5 Then : priceChangePerc = priceChangePerc - 5
            ElseIf ValueInThousands >= 0.5 And ValueInThousands <= 2 Then : priceChangePerc = priceChangePerc + 0
            ElseIf ValueInThousands > 2 And ValueInThousands <= 10 Then : priceChangePerc = priceChangePerc + 5
            ElseIf ValueInThousands > 10 And ValueInThousands <= 20 Then : priceChangePerc = priceChangePerc + 10
            ElseIf ValueInThousands > 20 Then : priceChangePerc = priceChangePerc + 15
            Else

                Console.WriteLine("Please enter a valid price.")
            End If
        End While

        While locationFlag = False

            Console.Write("Enter the location where the car is kept overnight (Garage/Drive/Street): ")
            locationKept = Console.ReadLine
            If UCase(locationKept) = "GARAGE" Then
                locationFlag = True
                priceChangePerc = priceChangePerc - 5
            ElseIf UCase(locationKept) = "DRIVE" Then
                locationFlag = True
                priceChangePerc = priceChangePerc + 0
            ElseIf UCase(locationKept) = "STREET" Then
                locationFlag = True
                priceChangePerc = priceChangePerc + 5
            Else

                Console.WriteLine("Please enter a valid location (Garage/Drive/Street).")
            End If
        End While

        While ThousandKilometerDriven < 0

            Console.Write("Enter the kilometers driven per year (in thousands): ")
            ThousandKilometerDriven = Console.ReadLine
            If ThousandKilometerDriven >= 0 And ThousandKilometerDriven < 5 Then : priceChangePerc = priceChangePerc - 5
            ElseIf ThousandKilometerDriven >= 5 And ThousandKilometerDriven <= 20 Then : priceChangePerc = priceChangePerc + 0
            ElseIf ThousandKilometerDriven > 20 Then : priceChangePerc = priceChangePerc + 5
            Else

                Console.WriteLine("Please enter a valid value for the thousands of kilometers driven.")
            End If
        End While

        While driverAge < 18

            Console.Write("Enter the age of the driver: ")
            driverAge = Console.ReadLine
            If driverAge >= 18 And driverAge <= 20 Then : priceChangePerc = priceChangePerc + 100
            ElseIf driverAge >= 21 And driverAge <= 25 Then : priceChangePerc = priceChangePerc + 50
            ElseIf driverAge >= 26 And driverAge <= 30 Then : priceChangePerc = priceChangePerc + 25
            ElseIf driverAge >= 31 And driverAge <= 70 Then : priceChangePerc = priceChangePerc + 0
            ElseIf driverAge >= 71 And driverAge <= 80 Then : priceChangePerc = priceChangePerc + 10
            ElseIf driverAge > 80 Then : priceChangePerc = priceChangePerc + 20
            Else

                Console.WriteLine("Please enter a valid age.")
            End If
        End While

        newPrice = basePrice + (priceChangePerc / 100) * basePrice

        While yearsWithoutClaim < 0

            Console.Write("Enter the number of years without an insurance claim: ")
            yearsWithoutClaim = Console.ReadLine
            Select Case yearsWithoutClaim
                Case 0 : discountPerc = 0
                Case 1 : discountPerc = 10
                Case 2 : discountPerc = 20
                Case 3 : discountPerc = 30
                Case 4 : discountPerc = 40
                Case 5 : discountPerc = 50
                Case 6 : discountPerc = 60
                Case Is > 6 : discountPerc = 70
                Case Else

                    Console.WriteLine("Please enter a valid argument.")
            End Select
        End While

        'ADDITIONAL CODE FOR TASK 3 BEGINS HERE'

        Console.Write("Would you like to add another driver? (Y/N) ")
        addDriverChoice = Console.ReadLine
        If UCase(addDriverChoice) = "Y" Then
            newDriverAge = 0
            While newDriverAge < 18

                Console.Write("Enter the age of the second driver: ")
                newDriverAge = Console.ReadLine
                If newDriverAge >= 18 And newDriverAge <= 20 Then : priceChangePerc = priceChangePerc + 100
                ElseIf newDriverAge >= 21 And newDriverAge <= 25 Then : priceChangePerc = priceChangePerc + 50
                ElseIf newDriverAge >= 26 And newDriverAge <= 30 Then : priceChangePerc = priceChangePerc + 25
                ElseIf newDriverAge >= 31 And newDriverAge <= 70 Then : priceChangePerc = priceChangePerc + 0
                ElseIf newDriverAge >= 71 And newDriverAge <= 80 Then : priceChangePerc = priceChangePerc + 10
                ElseIf newDriverAge > 80 Then : priceChangePerc = priceChangePerc + 20
                Else

                    Console.WriteLine("Please enter a valid age.")
                End If
            End While

        End If
        'ADDITIONAL CODE FOR TASK 3 ENDS HERE'

        newPrice = newPrice - ((discountPerc / 100) * newPrice)

        Console.WriteLine("The total percentage change in the base price of insurance is: " & priceChangePerc & "%")

        Console.WriteLine("The percentage discount due to years without claim is: " & discountPerc & "%")

        'ADDITIONAL CODE FOR TASK 2 BEGINS HERE
        If driverAge >= 26 And driverAge <= 70 Then
            If yearsWithoutClaim >= 2 Then
                newCustDiscountPerc = 10
            End If
        End If

        Console.WriteLine("The amount of money saved by applying the 'new customer discount' is: $" & (newPrice * (newCustDiscountPerc / 100)))

        newPrice = newPrice - ((newCustDiscountPerc / 100) * newPrice)
        'ADDITIONAL CODE FOR TASK 2 ENDS HERE

        Console.WriteLine("The price to insure your car is: $" & newPrice)
        Console.ReadKey()
    End Sub
End Module