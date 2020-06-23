Module Task1
    'TASK 1 – Algorithms, arrays and pseudocode
    'The following four 1D arrays can store different pieces of data about stock items in a shop:
    'Array identifier 	Data type
    'ItemCode 		    STRING
    'ItemDescription 	STRING
    'Price 			    REAL
    'NumberInStock      INTEGER

    Const items = 17
    Dim ItemCode(items) As String
    Dim ItemDescription(items) As String
    Dim Price(items) As Single
    Dim NumberInStock(items) As Integer

    Sub Main()
        Dim Choice As Integer = 0
        Call Initialise()
        While Choice <> 8
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608, Pre Release Material (All Varients) -- Oct/Nov 2020")
            Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
            Console.WriteLine(StrDup(95, "-"))
            Console.WriteLine("MENU - TASK 1")
            Console.WriteLine("1. Enter data into arrays.")
            Console.WriteLine("2. Populate arrays automatically.")
            Console.WriteLine("3. Display complete data captured in arrays.")
            Console.WriteLine("4. Task 1.1: Search for a specific value in ItemDescription.")
            Console.WriteLine("5. Task 1.2: Search for multiple instances of the value.")
            Console.WriteLine("6. Task 1.3: Search & output the corresponding values from all arrays.")
            Console.WriteLine("7. Task 1.4: Display all the information about items in stock below a given level.")
            Console.WriteLine("8. Quit")
            Console.Write("Enter choice [1-8]... ") : Choice = Console.ReadLine

            Select Case Choice
                Case 1 : Call PopulateDataEntry()
                Case 2 : Call PopulateAuto()
                Case 3 : Call DisplayAllRecords()
                Case 4 : Call Task11()
                Case 5 : Call Task12()
                Case 6 : Call Task13()
                Case 7 : Call Task14()
                Case 8 'Quit App
                Case Else
                    Console.WriteLine("Wrong choice. Please chose an option between 1-8.")
                    Console.ReadKey()
            End Select
        End While

    End Sub

    Sub Task11()
        'TASK 1.1
        'Design an algorithm to search for a specific value in ItemDescription and, 
        'if found, to output the array index where the value is found. 
        'Output a suitable message if the value is not found.

        Dim Descripotion As String = ""
        Dim isStrict As Char = ""
        Dim Strict As Boolean
        Dim Position As Integer = 0

        Console.Write("Enter item description to search for: ")
        Descripotion = Console.ReadLine

        Console.Write("Do you want strict searching (Y/N): ")
        isStrict = UCase(Console.ReadLine)
        If isStrict = "Y" Then Strict = True

        Position = SearchUniqueItemDescription(Descripotion, Strict)
        If Position = 0 Then
            Console.WriteLine(Descripotion & " is not found in stock.")
        Else
            Console.WriteLine(Descripotion & " is found in stock at location: " & Str(Position))
        End If
        Console.ReadKey()

    End Sub

    Sub Task12()
        'TASK 1.2
        'Consider the difference between algorithms that search 
        'for a single or multiple instance of the value.

        Dim Description As String = ""

        Console.Write("Enter item description to search for:")
        Description = Console.ReadLine

        Call SearchMultipleItemDescription(Description)
    End Sub

    Sub Task13()
        'TASK 1.3
        'Extend the algorithm from Task 1.1 to output 
        'the corresponding values from the other arrays.

        Dim Descripotion As String = ""
        Dim isStrict As Char = ""
        Dim Strict As Boolean
        Dim Position As Integer = 0

        Console.Write("Enter item description to search for: ")
        Descripotion = Console.ReadLine

        Console.Write("Do you want strict searching (Y/N): ")
        isStrict = UCase(Console.ReadLine)
        If isStrict = "Y" Then Strict = True

        Position = SearchUniqueItemDescription(Descripotion, Strict)
        If Position = 0 Then
            Console.WriteLine(Descripotion & " is not found in stock.")
        Else
            Console.WriteLine()
            Console.WriteLine(Descripotion & " is found in stock at location: " & Str(Position))
            Console.WriteLine("Item code: " & ItemCode(Position))
            Console.WriteLine("Item description: " & ItemDescription(Position))
            Console.WriteLine("Item price: " & Str(Price(Position)))
            Console.WriteLine("Item number in stock (quantity): " & NumberInStock(Position))
        End If
        Console.ReadKey()

    End Sub

    Sub Task14()
        'TASK 1.4
        'Write program code to produce a report displaying
        Dim StockLevel As Integer = 0

        Console.Write("Enter item level to search for: ")
        StockLevel = Int(Console.ReadLine)

        Call DisplayRecordsBelowLevel(StockLevel)
    End Sub

    Sub Initialise()
        'Initialise all SC arrays used
        Dim x As Integer
        For x = 1 To items
            ItemCode(x) = ""
            ItemDescription(x) = ""
            Price(x) = 0
            NumberInStock(x) = 0
        Next
    End Sub

    Sub PopulateDataEntry()
        'Populate all arrays in corresponding records' data entry manner
        Dim x As Integer = 0

        Console.Clear()
        For x = 1 To items
            Console.WriteLine("Item Number: " & Str(x))
            Console.WriteLine("--------------")

            Console.Write("Enter item code: ")
            ItemCode(x) = Console.ReadLine

            Console.Write("Enter item description: ")
            ItemDescription(x) = Console.ReadLine

            Console.Write("Enter item price: ")
            Price(x) = Console.ReadLine

            Console.Write("Enter item number in stock (quantity): ")
            NumberInStock(x) = Console.ReadLine

            Console.WriteLine()
        Next
    End Sub

    Sub PopulateAuto()
        'Auto populate the SD arrays using predetermined values
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
        ItemDescription(8) = "RAM 8 GB"
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

        NumberInStock(1) = 85
        NumberInStock(2) = 100
        NumberInStock(3) = 95
        NumberInStock(4) = 49
        NumberInStock(5) = 65
        NumberInStock(6) = 52
        NumberInStock(7) = 87
        NumberInStock(8) = 12
        NumberInStock(9) = 50
        NumberInStock(10) = 83
        NumberInStock(11) = 32
        NumberInStock(12) = 15
        NumberInStock(13) = 56
        NumberInStock(14) = 41
        NumberInStock(15) = 25
        NumberInStock(16) = 73
        NumberInStock(17) = 22

        Console.WriteLine("All arrays are populated successfully.")
        Call DisplayAllRecords()
    End Sub

    Function SearchUniqueItemDescription(Description As String, Strict As Boolean) As Integer
        Dim Position As Integer = 0
        Dim x As Integer = 0
        Dim isFound As Boolean = False

        For x = 1 To items
            If Strict = True Then
                If ItemDescription(x) = Description Then isFound = True
            Else
                If UCase(ItemDescription(x)) = UCase(Description) Then isFound = True
            End If

            If isFound = True Then
                Position = x
                Exit For
            End If
        Next

        If isFound = True Then
            Return Position
        Else
            Return 0
        End If
    End Function

    Sub SearchMultipleItemDescription(Description As String)
        Dim x As Integer = 0
        Dim isFound As Boolean = False

        For x = 1 To items
            If UCase(ItemDescription(x)) = UCase(Description) Then
                isFound = True
                Console.WriteLine()
                Console.WriteLine("Item code: " & ItemCode(x))
                Console.WriteLine("Item description: " & ItemDescription(x))
                Console.WriteLine("Item price: " & Str(Price(x)))
                Console.WriteLine("Item number in stock (quantity): " & NumberInStock(x))
            End If
        Next

        If isFound = False Then
            Console.WriteLine("Item: " & Description & " is not found.")
        End If

        Console.ReadKey()
    End Sub

    Sub DisplayAllRecords()
        Dim x As Integer = 0
        Dim myPrice As String = ""

        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Item number in stock (quantity)")
        Console.WriteLine(StrDup(95, "-"))
        For x = 1 To items
            Console.Write(ItemCode(x) + Space(9))
            Console.Write(ItemDescription(x) & Space(40 - Len(ItemDescription(x))))
            myPrice = Format(Price(x), "##########.00")
            Console.Write(myPrice & Space(12 - Len(myPrice)))
            Console.WriteLine(NumberInStock(x))
        Next
        Console.ReadKey()
    End Sub

    Sub DisplayRecordsBelowLevel(Level As Integer)
        Dim x As Integer = 0
        Dim myPrice As String = ""

        Console.Clear()
        Console.WriteLine("Records below level: " & Level)
        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Item number in stock (quantity)")
        Console.WriteLine(StrDup(95, "-"))
        For x = 1 To items
            If NumberInStock(x) < Level Then
                Console.Write(ItemCode(x) + Space(9))
                Console.Write(ItemDescription(x) & Space(40 - Len(ItemDescription(x))))
                myPrice = Format(Price(x), "##########.00")
                Console.Write(myPrice & Space(12 - Len(myPrice)))
                Console.WriteLine(NumberInStock(x))
            End If
        Next
        Console.ReadKey()
    End Sub

End Module
