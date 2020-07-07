Module Task1
    'The following four 1D arrays can store different pieces of data about stock items in a shop:
    'Array identifier 	Data type
    '----------------   ---------
    'Category           STRING
    'ItemCode 		    STRING
    'ItemDescription 	STRING
    'Price 			    REAL

    Const items = 17
    Dim Category(items) As String
    Dim ItemCode(items) As String
    Dim ItemDescription(items) As String
    Dim Price(items) As Single

    Dim newSaleItem(7) As String
    Dim newSaleItemPrice(7) As Decimal

    Dim myOption As Char = ""
    Dim ItemID As String = ""
    Dim myPrice As String = ""
    Dim ComputerPrice As Decimal = 0
    Dim itemCount As Integer = 0

    Sub Main()
        Dim Choice As Integer = 0

        While Choice <> 4
            Console.Clear()
            Console.WriteLine("OL Computer Science 2210/P22, Pre Release Material (Variant 2) -- Oct/Nov 2020")
            Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
            Console.WriteLine(StrDup(95, "-"))
            Console.WriteLine("1. Task 1 - Setting up the system and ordering the main items..")
            Console.WriteLine("2. Task 2 – Ordering additional items..")
            Console.WriteLine("3. Task 3 – Offering discounts.")
            Console.WriteLine("4. Quit")
            Console.Write("Enter choice [1-4]... ") : Choice = Console.ReadLine

            Select Case Choice
                Case 1 : Call Task1()
                Case 2 : Call Task2()
                Case 3 : Call Task3()
                Case 4 'Quit App
                Case Else
                    Console.WriteLine("Wrong choice. Please chose an option between 1-4.")
                    Console.ReadKey()
            End Select
        End While

    End Sub

    Sub Task1()
        'Task 1 – Setting up the system and ordering the main items.
        'Write a program to:
        '• use arrays to store the item code, description and price
        '• allow a customer to choose one case, one RAM and one Main Hard Disk Drive
        '• calculate the price of the computer using the cost of the chosen items and the basic set of components
        '• store and output the chosen items and the price of the computer.

        'Initialise all SC arrays used
        Dim x As Integer
        For x = 1 To items
            Category(x) = ""
            ItemCode(x) = ""
            ItemDescription(x) = ""
            Price(x) = 0
        Next

        'Auto populate the SD arrays using predetermined values
        Category(1) = "Case"
        Category(2) = "Case"
        Category(3) = "RAM"
        Category(4) = "RAM"
        Category(5) = "RAM"
        Category(6) = "Main Hard Disk Drive"
        Category(7) = "Main Hard Disk Drive"
        Category(8) = "Main Hard Disk Drive"
        Category(9) = "Solid State Drive"
        Category(10) = "Solid State Drive"
        Category(11) = "Second Hard Disk Drive"
        Category(12) = "Second Hard Disk Drive"
        Category(13) = "Second Hard Disk Drive"
        Category(14) = "Optical Drive"
        Category(15) = "Optical Drive"
        Category(16) = "Operating System"
        Category(17) = "Operating System"

        ItemCode(1) = "A1"
        ItemCode(2) = "A2"
        ItemCode(3) = "B1"
        ItemCode(4) = "B2"
        ItemCode(5) = "B3"
        ItemCode(6) = "C1"
        ItemCode(7) = "C2"
        ItemCode(8) = "C3"
        ItemCode(9) = "D1"
        ItemCode(10) = "D2"
        ItemCode(11) = "E1"
        ItemCode(12) = "E2"
        ItemCode(13) = "E3"
        ItemCode(14) = "F1"
        ItemCode(15) = "F2"
        ItemCode(16) = "G1"
        ItemCode(17) = "G2"

        ItemDescription(1) = "Case Compact"
        ItemDescription(2) = "Case Tower"
        ItemDescription(3) = "RAM 8 GB"
        ItemDescription(4) = "RAM 16 GB"
        ItemDescription(5) = "RAM 32 GB"
        ItemDescription(6) = "Main Hard Disk Drive 1 TB HDD"
        ItemDescription(7) = "Main Hard Disk Drive 2 TB HDD"
        ItemDescription(8) = "Main Hard Disk Drive 4 TB HDD"
        ItemDescription(9) = "Solid State Drive 240 GB SSD"
        ItemDescription(10) = "Solid State Drive 480 GB SSD"
        ItemDescription(11) = "Second Hard Disk Drive 1 TB HDD"
        ItemDescription(12) = "Second Hard Disk Drive 2 TB HDD"
        ItemDescription(13) = "Second Hard Disk Drive 4 TB HDD"
        ItemDescription(14) = "Optical Drive DVD/Blu-Ray Player"
        ItemDescription(15) = "Optical Drive DVD/Blu-Ray Re-writer"
        ItemDescription(16) = "Operating System Standard Version"
        ItemDescription(17) = "Operating System Professional Version"

        Price(1) = 75.0
        Price(2) = 150.0
        Price(3) = 79.99
        Price(4) = 149.99
        Price(5) = 299.99
        Price(6) = 49.99
        Price(7) = 89.99
        Price(8) = 129.99
        Price(9) = 59.99
        Price(10) = 119.99
        Price(11) = 49.99
        Price(12) = 89.99
        Price(13) = 129.99
        Price(14) = 50.0
        Price(15) = 100.0
        Price(16) = 100.0
        Price(17) = 175.0
        Console.WriteLine("All arrays are populated successfully.")

        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Category")
        Console.WriteLine(StrDup(95, "-"))
        For x = 1 To 8
            Console.Write(ItemCode(x) + Space(9))
            Console.Write(ItemDescription(x) & Space(40 - Len(ItemDescription(x))))
            myPrice = Format(Price(x), "##########.00")
            Console.Write(myPrice & Space(12 - Len(myPrice)))
            Console.WriteLine(Category(x))
        Next

        Console.WriteLine("New sale initiated - Default basic set of components costing $200 is added.")
        Console.WriteLine("One case, one RAM and one Main Hard Disk Drive is required to be added.")

        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Category")
        Console.WriteLine(StrDup(95, "-"))
        For x = 1 To 2
            Console.Write(ItemCode(x) + Space(9))
            Console.Write(ItemDescription(x) & Space(40 - Len(ItemDescription(x))))
            myPrice = Format(Price(x), "##########.00")
            Console.Write(myPrice & Space(12 - Len(myPrice)))
            Console.WriteLine(Category(x))
        Next
        While ItemID <> "A1" And ItemID <> "A2"
            Console.Write("Chose a Case Item Code: ")
            ItemID = Console.ReadLine

            If ItemID <> "A1" Or ItemID <> "A2" Then
                Console.WriteLine("Chose either A1 or A2.")
            End If
        End While

        If ItemID = "A1" Then
            newSaleItem(1) = ItemDescription(1)
            newSaleItemPrice(1) = Price(1)
        End If

        If ItemID = "A2" Then
            newSaleItem(1) = ItemDescription(2)
            newSaleItemPrice(1) = Price(2)
        End If

        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Category")
        Console.WriteLine(StrDup(95, "-"))
        For x = 3 To 5
            Console.Write(ItemCode(x) + Space(9))
            Console.Write(ItemDescription(x) & Space(40 - Len(ItemDescription(x))))
            myPrice = Format(Price(x), "##########.00")
            Console.Write(myPrice & Space(12 - Len(myPrice)))
            Console.WriteLine(Category(x))
        Next
        While ItemID <> "B1" And ItemID <> "B2" And ItemID <> "B3"
            Console.Write("Chose a RAM Item Code: ")
            ItemID = Console.ReadLine

            If ItemID <> "B1" Or ItemID <> "B2" Or ItemID <> "B3" Then
                Console.WriteLine("Chose either B1, B2 or B3.")
            End If
        End While

        If ItemID = "B1" Then
            newSaleItem(2) = ItemDescription(3)
            newSaleItemPrice(2) = Price(3)
        End If

        If ItemID = "B2" Then
            newSaleItem(2) = ItemDescription(4)
            newSaleItemPrice(2) = Price(4)
        End If

        If ItemID = "B3" Then
            newSaleItem(2) = ItemDescription(4)
            newSaleItemPrice(2) = Price(5)
        End If


        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Category")
        Console.WriteLine(StrDup(95, "-"))
        For x = 6 To 8
            Console.Write(ItemCode(x) + Space(9))
            Console.Write(ItemDescription(x) & Space(40 - Len(ItemDescription(x))))
            myPrice = Format(Price(x), "##########.00")
            Console.Write(myPrice & Space(12 - Len(myPrice)))
            Console.WriteLine(Category(x))
        Next
        While ItemID <> "C1" And ItemID <> "C2" And ItemID <> "C3"
            Console.Write("Chose a Main Hard Disk Drive Item Code: ")
            ItemID = Console.ReadLine

            If ItemID <> "C1" Or ItemID <> "C2" Or ItemID <> "C3" Then
                Console.WriteLine("Chose either C1, C2 or C3.")
            End If
        End While

        If ItemID = "C1" Then
            newSaleItem(3) = ItemDescription(6)
            newSaleItemPrice(3) = Price(6)
        End If

        If ItemID = "C2" Then
            newSaleItem(3) = ItemDescription(7)
            newSaleItemPrice(3) = Price(7)
        End If

        If ItemID = "C3" Then
            newSaleItem(3) = ItemDescription(8)
            newSaleItemPrice(3) = Price(8)
        End If
        itemCount = 3

        Console.Clear()
        ComputerPrice = 200
        Console.WriteLine("Computer Invoice")
        Console.Write("Item description                        ")
        Console.WriteLine("Item price  ")
        Console.WriteLine(StrDup(50, "-"))

        For x = 1 To 3
            Console.Write(newSaleItem(x) & Space(40 - Len(newSaleItem(x))))
            myPrice = Format(newSaleItemPrice(x), "##########.00")
            Console.WriteLine(myPrice)
            ComputerPrice = ComputerPrice + newSaleItemPrice(x)
        Next
        Console.Write("Basic set of components" & Space(17))
        myPrice = Format(200, "##########.00")
        Console.WriteLine(myPrice)

        Console.WriteLine(StrDup(50, "-"))
        Console.WriteLine("Total price of the computer: " & ComputerPrice)
        Console.ReadKey()
    End Sub


    Sub Task2()
        'Task 2 – Ordering additional items.
        'Extend TASK 1 to:
        '• allow a customer to choose whether to purchase any items from the other categories – if so, which item(s)
        '• update the price of the computer
        '• store and output the additional items and the new price of the computer.

        Console.Clear()
        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Category")
        Console.WriteLine(StrDup(95, "-"))
        For x = 9 To 17
            Console.Write(ItemCode(x) + Space(9))
            Console.Write(ItemDescription(x) & Space(40 - Len(ItemDescription(x))))
            myPrice = Format(Price(x), "##########.00")
            Console.Write(myPrice & Space(12 - Len(myPrice)))
            Console.WriteLine(Category(x))
        Next
        myOption = ""
        While UCase(myOption) <> "N"
            Console.Write("Do you want to buy additional components? (Y/N)... ")
            myOption = Console.ReadLine

            If UCase(myOption) = "Y" Then
                ItemID = ""
                While Not (ItemID = "D1" Or ItemID = "D2" Or ItemID = "E1" Or _
                    ItemID = "E2" Or ItemID = "E3" Or ItemID = "F1" Or _
                    ItemID = "F2" Or ItemID = "G1" Or ItemID = "G2")

                    Console.Write("Chose an additonal Item Code: ")
                    ItemID = Console.ReadLine

                    If Not (ItemID = "D1" Or ItemID = "D2" Or ItemID = "E1" Or _
                    ItemID = "E2" Or ItemID = "E3" Or ItemID = "F1" Or _
                    ItemID = "F2" Or ItemID = "G1" Or ItemID = "G2") Then
                        Console.WriteLine("Chose either D1, D2, E1, E2, E3, F1, F2, G1 or G2.")
                    End If
                End While
                itemCount = itemCount + 1
                Select Case ItemID
                    Case "D1"
                        newSaleItemPrice(itemCount) = Price(9)
                        newSaleItem(itemCount) = ItemDescription(9)
                    Case "D2"
                        newSaleItemPrice(itemCount) = Price(10)
                        newSaleItem(itemCount) = ItemDescription(10)
                    Case "E1"
                        newSaleItemPrice(itemCount) = Price(11)
                        newSaleItem(itemCount) = ItemDescription(11)
                    Case "E2"
                        newSaleItemPrice(itemCount) = Price(12)
                        newSaleItem(itemCount) = ItemDescription(12)
                    Case "E3"
                        newSaleItemPrice(itemCount) = Price(13)
                        newSaleItem(itemCount) = ItemDescription(13)
                    Case "F1"
                        newSaleItemPrice(itemCount) = Price(14)
                        newSaleItem(itemCount) = ItemDescription(14)
                    Case "F2"
                        newSaleItemPrice(itemCount) = Price(15)
                        newSaleItem(itemCount) = ItemDescription(15)
                    Case "G1"
                        newSaleItemPrice(itemCount) = Price(16)
                        newSaleItem(itemCount) = ItemDescription(16)
                    Case "G2"
                        newSaleItemPrice(itemCount) = Price(17)
                        newSaleItem(itemCount) = ItemDescription(17)
                End Select

            End If
        End While

        Console.Clear()
        ComputerPrice = 200
        Console.WriteLine("Computer Invoice")
        Console.Write("Item description                        ")
        Console.WriteLine("Item price  ")
        Console.WriteLine(StrDup(50, "-"))

        For x = 1 To 7
            If newSaleItem(x) <> "" Then
                Console.Write(newSaleItem(x) & Space(40 - Len(newSaleItem(x))))
                myPrice = Format(newSaleItemPrice(x), "##########.00")
                Console.WriteLine(myPrice)
                ComputerPrice = ComputerPrice + newSaleItemPrice(x)
            End If
        Next
        Console.Write("Basic set of components" & Space(17))
        myPrice = Format(200, "##########.00")
        Console.WriteLine(myPrice)

        Console.WriteLine(StrDup(50, "-"))
        Console.WriteLine("Total price of the computer: " & ComputerPrice)
        Console.ReadKey()
    End Sub

    Sub Task3()
        'Task 3 – Offering discounts.
        'Extend TASK 2 to:
        '• apply a 5% discount to the price of the computer if the customer has bought only one additional item
        '• apply a 10% discount to the price of the computer if the customer has bought two or more additional items
        '• output the amount of money saved and the new price of the computer after the discount.

        Console.Clear()
        ComputerPrice = 200

        Console.WriteLine("Computer Invoice")
        Console.Write("Item description                        ")
        Console.WriteLine("Item price  ")
        Console.WriteLine(StrDup(50, "-"))

        For x = 1 To 7
            If newSaleItem(x) <> "" Then
                Console.Write(newSaleItem(x) & Space(40 - Len(newSaleItem(x))))
                myPrice = Format(newSaleItemPrice(x), "##########.00")
                Console.WriteLine(myPrice)
                ComputerPrice = ComputerPrice + newSaleItemPrice(x)
            End If
        Next
        Console.Write("Basic set of components" & Space(17))
        myPrice = Format(200, "##########.00")
        Console.WriteLine(myPrice)

        Console.WriteLine(StrDup(50, "-"))
        Console.WriteLine("Total price of the computer: " & ComputerPrice)

        If itemCount = 3 Then
            Console.WriteLine("No discount applied.")
        ElseIf itemCount = 4 Then
            Console.WriteLine("5% discount applied.")
            ComputerPrice = ComputerPrice * 0.95
        ElseIf itemCount > 4 Then
            Console.WriteLine("10% discount applied.")
            ComputerPrice = ComputerPrice * 0.9
        End If
        Console.WriteLine()
        Console.WriteLine("Total price of the computer after discount: " & ComputerPrice)
        Console.ReadKey()
    End Sub

End Module
