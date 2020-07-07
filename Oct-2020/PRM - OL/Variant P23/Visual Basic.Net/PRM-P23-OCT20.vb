Module Program
    Dim baguetteSize(2) As Integer
    Dim baguetteSizeName(2) As String

    Dim breadType(3) As Integer
    Dim breadTypeName(3) As String

    Dim fillings(6) As Integer
    Dim fillingsName(6) As String

    Dim salad(5) As Integer
    Dim saladName(5) As String
    Dim saladChoiceList(3) As String

    Dim sizeFlag As Boolean
    Dim breadFlag As Boolean
    Dim fillingFlag As Boolean
    Dim saladFlag As Boolean
    Dim changeOrder As Boolean
    Dim cancelOrder As Boolean
    Dim moreOrder As Boolean

    Dim orderNo As Integer

    Dim sizeChoice As Integer
    Dim breadChoice As Integer
    Dim fillingChoice As Integer
    Dim saladChoice As Integer
    Dim size As String

    Dim saladCount As Integer = 0

    Dim addSalad As String
    Dim more As String
    Dim sizeDisplay As String
    Dim bread As String
    Dim filling As String
    Dim confirmOrder As String
    Dim changeOrderChoice As String
    Dim cancelOrderChoice As String
    Dim moreOrderChoice As String

    Sub Initialise()
        For Count = 1 To 2
            baguetteSize(Count) = 0
        Next

        For Count = 1 To 3
            breadType(Count) = 0
        Next

        For Count = 1 To 6
            fillings(Count) = 0
        Next

        For Count = 1 To 5
            salad(Count) = 0
        Next

        baguetteSizeName(1) = "15cm"
        baguetteSizeName(2) = "30cm"

        breadTypeName(1) = "White"
        breadTypeName(2) = "Brown"
        breadTypeName(3) = "Seeded"

        fillingsName(1) = "Beef"
        fillingsName(2) = "Chicken"
        fillingsName(3) = "Cheese"
        fillingsName(4) = "Egg"
        fillingsName(5) = "Tuna"
        fillingsName(6) = "Turkey"

        saladName(1) = "Lettuce"
        saladName(2) = "Tomato"
        saladName(3) = "Sweetcorn"
        saladName(4) = "Cucumber"
        saladName(5) = "Peppers"

        saladChoiceList(1) = ""
        saladChoiceList(2) = ""
        saladChoiceList(3) = ""

        orderNo = 0
    End Sub

    Sub Main()

        Call Initialise()

        moreOrder = True
        changeOrder = True

        While moreOrder = True
            While changeOrder = True
                Console.Clear()
                Console.WriteLine("OL Computer Science 2210/P23, Pre Release Material (Variant 3) -- Oct/Nov 2020")
                Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
                Console.WriteLine(StrDup(95, "-"))
                Console.WriteLine("Baguette sizes:")
                Console.WriteLine("1. 15cm")
                Console.WriteLine("2. 30cm")

                sizeFlag = False

                While sizeFlag = False
                    Console.Write("Enter your choice [1-2]: ")
                    sizeChoice = Console.ReadLine

                    If sizeChoice < 1 Or sizeChoice > 2 Then
                        Console.WriteLine("Please enter a valid choice of size [1-2].")
                        Console.WriteLine("")
                    Else
                        baguetteSize(sizeChoice) = baguetteSize(sizeChoice) + 1
                        sizeFlag = True
                    End If

                End While

                Console.WriteLine("")
                Console.WriteLine("Bread types:")
                Console.WriteLine("1. White")
                Console.WriteLine("2. Brown")
                Console.WriteLine("3. Seeded")

                breadFlag = False

                While breadFlag = False
                    Console.Write("Enter your choice [1-3]: ")
                    breadChoice = Console.ReadLine

                    If breadChoice < 1 Or breadChoice > 3 Then
                        Console.WriteLine("Please enter a valid choice of bread [1-3].")
                        Console.WriteLine("")
                    Else
                        breadType(breadChoice) = breadType(breadChoice) + 1
                        breadFlag = True
                    End If

                End While

                Console.WriteLine("")
                Console.WriteLine("Baguette fillings:")
                Console.WriteLine("1. Beef")
                Console.WriteLine("2. Chicken")
                Console.WriteLine("3. Cheese")
                Console.WriteLine("4. Egg")
                Console.WriteLine("5. Tuna")
                Console.WriteLine("6. Turkey")

                fillingFlag = False

                While fillingFlag = False

                    Console.Write("Enter your choice [1-6]: ")
                    fillingChoice = Console.ReadLine

                    If fillingChoice < 1 Or fillingChoice > 6 Then
                        Console.WriteLine("")
                        Console.WriteLine("Please enter a valid choice of filling [1-6].")
                    Else
                        fillings(fillingChoice) = fillings(fillingChoice) + 1
                        fillingFlag = True
                    End If

                End While

                saladCount = 0

                Console.WriteLine("")
                Console.WriteLine("Salad options:")
                Console.WriteLine("1. Lettuce")
                Console.WriteLine("2. Tomato")
                Console.WriteLine("3. Sweetcorn")
                Console.WriteLine("4. Cucumber")
                Console.WriteLine("5. Peppers")

                Console.Write("Would you like to add salads to your baguette? (Y/N): ")
                addSalad = Console.ReadLine

                If UCase(addSalad) = "Y" Then
                    saladFlag = False
                    more = True

                    While saladFlag = False Or (saladCount < 3 And more = True)

                        Console.WriteLine("")
                        Console.Write("You may choose up to " & (3 - saladCount) & " more salad(s). Enter your next choice [1-5]: ")
                        saladChoice = Console.ReadLine

                        If saladChoice < 1 Or saladChoice > 5 Then
                            Console.WriteLine("")
                            Console.WriteLine("Please enter a valid choice of salad [1-5].")
                        Else
                            salad(saladChoice) = salad(saladChoice) + 1
                            saladFlag = True
                            saladCount = saladCount + 1
                            saladChoiceList(saladCount) = saladChoice

                            If saladCount < 3 Then
                                Console.WriteLine("")
                                Console.Write("Would you like to add another salad? (Y/N): ")
                                more = Console.ReadLine
                                If UCase(more) = "Y" Then
                                    more = True
                                Else
                                    more = False
                                End If
                            End If
                        End If

                    End While
                End If

                sizeDisplay = baguetteSizeName(sizeChoice)
                bread = breadTypeName(breadChoice)
                filling = fillingsName(fillingChoice)


                Console.WriteLine("")
                Console.WriteLine("Your ordered baguette:")
                Console.WriteLine("")
                Console.Write("Size: ")
                Console.WriteLine(sizeDisplay)
                Console.Write("Bread: ")
                Console.WriteLine(bread)
                Console.Write("Filling: ")
                Console.WriteLine(filling)
                Console.WriteLine("Salad(s)")

                For saladCount = 1 To 3
                    If saladChoiceList(saladCount) <> "" Then
                        Console.WriteLine(saladName(saladChoiceList(saladCount)))
                    End If
                Next

                Console.WriteLine("")
                Console.Write("Confirm order? (Y/N): ")
                confirmOrder = Console.ReadLine
                If UCase(confirmOrder) = "N" Then
                    confirmOrder = False

                    changeOrder = False
                    cancelOrder = False

                    While changeOrder = False And cancelOrder = False

                        Console.Write("Would you like to change your order or cancel it? (change/cancel): ")
                        changeOrderChoice = Console.ReadLine
                        If UCase(changeOrderChoice) = "CHANGE" Then
                            changeOrder = True
                        ElseIf UCase(changeOrderChoice) = "CANCEL" Then
                            cancelOrder = True
                        Else
                            Console.WriteLine("Please enter a valid choice: ")
                        End If
                    End While

                ElseIf UCase(confirmOrder) = "Y" Then
                    changeOrder = False
                    cancelOrder = False
                    orderNo = orderNo + 1
                    Console.WriteLine("")
                    Console.WriteLine("Your order number is: " & orderNo)
                End If
            End While

            Console.WriteLine("")
            Console.Write("Would you like to order another baguette? (Y/N): ")
            moreOrderChoice = Console.ReadLine
            If UCase(moreOrderChoice) = "Y" Then
                moreOrder = True
            Else
                moreOrder = False
                Call Task23()
            End If
        End While
        Console.ReadKey()
    End Sub

    Sub Task23()

        'Task 2 begins now

        Dim totalSize15 As Integer
        Dim totalSize30 As Integer

        Dim totalBreadWhite As Integer
        Dim totalBreadBrown As Integer
        Dim totalBreadSeeded As Integer

        Dim totalFillingBeef As Integer
        Dim totalFillingChicken As Integer
        Dim totalFillingCheese As Integer
        Dim totalFillingEgg As Integer
        Dim totalFillingTuna As Integer
        Dim totalFillingTurkey As Integer

        Dim totalBaguettesSold As Integer

        totalBaguettesSold = orderNo

        totalSize15 = baguetteSize(1)
        totalSize30 = baguetteSize(2)

        totalBreadWhite = breadType(1)
        totalBreadBrown = breadType(2)
        totalBreadSeeded = breadType(3)

        totalFillingBeef = fillings(1)
        totalFillingChicken = fillings(2)
        totalFillingCheese = fillings(3)
        totalFillingEgg = fillings(4)
        totalFillingTuna = fillings(5)
        totalFillingTurkey = fillings(6)

        Dim mostFilling As Integer
        Dim leastFilling As Integer
        Dim mostPopularPerc As Single
        Dim leastPopularPerc As Single
        Dim mostPopularName As String = ""
        Dim leastPopularName As String = ""

        'Task 3 begins now

        mostFilling = -10000
        leastFilling = 10000

        For count = 1 To 6
            If fillings(count) > mostFilling Then
                mostFilling = fillings(count)
                mostPopularName = fillingsName(count)
            ElseIf fillings(count) < leastFilling Then
                leastFilling = fillings(count)
                leastPopularName = fillingsName(count)
            End If
        Next

        mostPopularPerc = (mostFilling / orderNo) * 100
        leastPopularPerc = (leastFilling / orderNo) * 100

        Console.WriteLine("")
        Console.WriteLine("The most popular baguette filling was " & mostPopularName & " with an order of " & mostPopularPerc & "%")
        Console.WriteLine("The least popular baguette filling was " & leastPopularName & " with an order of " & leastPopularPerc & "%")
    End Sub
End Module