Module Task2
    'TASK 2 – Programs containing several components
    'The stock data described in Task 1 are now to be stored in a text file.
    'Each line of the file will correspond to one stock item.

    'TASK 2.1
    'Define a format in which each line of the text file can store the 
    'different pieces of data about one stock item.
    'Consider whether there is a requirement for data type conversion.

    'WE WILL BE USING FOLLOWING STATEMENT
    'StockRecord = ItemCode & "#" & ItemDescription & "#" & CStr(Price) & "#" & CStr(NumberInStock)
    'WHERE:
    '# sign will be used as a delimeter between four fields to 
    'create a single string for saving to file
    'CStr() function will be used for casting from Single 
    'and Integer to string data types

    Dim StockRecord, StockField As String
    Dim SRec() As String
    Dim ItemCode As String
    Dim ItemDescription As String
    Dim Price As Single
    Dim NumberInStock As Integer

    Sub Main()
        'TASK 2.4
        'Consider the different modes when opening a file.
        'Discuss the difference between creating a file and 
        'amending the contents.
        'Extend the program to include a menu-driven interface that 
        'will perform the following tasks:
        'A. Add a new stock item to the text file. Include validation of 
        'the different pieces of information as
        'appropriate. For example, item code data may be a fixed format.
        'B. Search for a stock item with a specific item code. Output the 
        'other pieces of data together with suitable supporting text.
        'C. Search for all stock items with a specific item description, 
        'with output as for task B.
        'D. Output a list of all stock items with a price greater than a given amount.

        Dim choice As Integer
        choice = 0
        While choice <> 8
            Console.Clear()
            Console.WriteLine("AS Computer Science 9608, Pre Release Material (All Varients) -- Oct/Nov 2020")
            Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
            Console.WriteLine(StrDup(95, "-"))
            Console.WriteLine("MENU - TASK 2")
            Console.WriteLine("1: APPEND record to the file")
            Console.WriteLine("2: READ all records from the file")
            Console.WriteLine("3: DELETE a record from the file")
            Console.WriteLine("4: EDIT a record in the file")
            Console.WriteLine("5: SEARCH item code from the file")
            Console.WriteLine("6: SEARCH item description from the file")
            Console.WriteLine("7: Display records above a given price")
            Console.WriteLine("8: Exit")
            Console.Write("Enter your choice... ")
            choice = Console.ReadLine
            Select Case choice
                Case 1 : Call AppendRecord()
                Case 2 : Call DisplayAllRecords()
                Case 3 : Call DeleteRecord()
                Case 4 : Call EditRecord()
                Case 5 : Call Task24B()
                Case 6 : Call Task24C()
                Case 7 : Call Task24D()
                Case 8 'Quit Program
                Case Else
                    Console.WriteLine("Wrong choice made... Press any key to continue.")
                    Console.ReadKey()
            End Select
        End While
    End Sub

    Sub Task24B()
        'B. Search for a stock item with a specific item code. Output the 
        'other pieces of data together with suitable supporting text.

        Dim code As String = ""
        Dim isFound As Boolean = False

        Do
            Console.Write("Enter item code (Format:A9) to search for: ")
            code = Console.ReadLine
        Loop Until ValidItemCode(code) = True

        isFound = SearchItemCode(code)
        If isFound = False Then
            Console.WriteLine(code & " is not found in stock file.")
        Else
            Console.WriteLine(code & " is found in stock file.")
        End If
        Console.ReadKey()

    End Sub

    Sub Task24C()
        'C. Search for all stock items with a specific item description, 
        'with output as for task B.

        Dim Description As String = ""
        Dim isStrict As Char = ""
        Dim Strict As Boolean
        Dim isFound As Boolean = False

        Console.Write("Enter item description to search for: ")
        Description = Console.ReadLine

        Console.Write("Do you want strict searching (Y/N): ")
        isStrict = UCase(Console.ReadLine)
        If isStrict = "Y" Then Strict = True

        isFound = SearchItemDescription(Description, Strict)
        If isFound = False Then
            Console.WriteLine(Description & " is not found in stock.")
            Console.ReadKey()
        End If

    End Sub

    Sub Task24D()
        'D. Output a list of all stock items with a price greater than a given amount.
        Dim price As Single = 0

        Console.Write("Enter item price: ")
        price = CSng(Console.ReadLine)

        Call DisplayRecordsAbovePrice(price)
    End Sub

    Private Sub AppendRecord()
        'TASK 2.2
        'Design an algorithm to input the four pieces of data 
        'about a stock item, form a string according to your
        'format design, and write the string to the text file.

        'TASK 2.3
        'Write program code to implement your algorithm.

        StockRecord = ""
        ItemCode = ""
        ItemDescription = ""
        Price = 0.0
        NumberInStock = 0

        'Task 2.4
        'A. Add a new stock item to the text file. Include validation of 
        'the different pieces of information as
        'appropriate. For example, item code data may be a fixed format.

        Do
            Console.Write("Enter item code(Format:A9): ")
            ItemCode = Console.ReadLine
        Loop Until ValidItemCode(ItemCode) = True

        Console.Write("Enter item description: ")
        ItemDescription = Console.ReadLine

        Console.Write("Enter item price: ")
        Price = Console.ReadLine

        Console.Write("Enter item number in stock (quantity): ")
        NumberInStock = Console.ReadLine

        StockRecord = ItemCode & "#" & ItemDescription & "#" & CStr(Price) & "#" & CStr(NumberInStock)

        FileOpen(1, "StockFile.txt", OpenMode.Append)
        WriteLine(1, StockRecord)
        FileClose(1)

        Console.WriteLine("Record appended successfully... Press any key to continue.")
        Console.ReadKey()
    End Sub

    Private Sub DeleteRecord()
        Dim IC As String
        Dim isFound As Boolean = False

        ItemCode = ""
        ItemDescription = ""
        Price = 0.0
        NumberInStock = 0

        Do
            Console.Write("Enter Item Code (Format: A9) to Delete :")
            IC = Console.ReadLine()
        Loop Until ValidItemCode(IC) = True

        FileOpen(1, "StockFile.txt", OpenMode.Input)
        FileOpen(2, "tempFile.txt", OpenMode.Append)
        Do While Not EOF(1)
            Input(1, StockRecord)
            SRec = StockRecord.Split("#")
            ItemCode = trim(SRec(0))
            ItemDescription = trim(SRec(1))
            Price = SRec(2)
            NumberInStock = SRec(3)

            If IC = ItemCode Then
                isFound = True
            Else
                WriteLine(2, StockRecord)
            End If
        Loop

        FileClose(1)
        FileClose(2)
        Kill("StockFile.txt")
        My.Computer.FileSystem.RenameFile("tempFile.txt", "StockFile.txt")

        If isFound = True Then
            Console.WriteLine("Record deleted successfully... Press any key to continue.")
        Else
            Console.WriteLine("Record was not found... Press any key to continue.")
        End If

        Console.ReadKey()
    End Sub

    Private Sub EditRecord()
        Dim IC, Description As String
        Dim Tprice As Single
        Dim StockQty As Integer
        Dim flag As Boolean

        ItemCode = ""
        ItemDescription = ""
        Price = 0.0
        NumberInStock = 0

        flag = False
        Do
            Console.Write("Enter item code (Format:A9): ")
            IC = Console.ReadLine
        Loop Until ValidItemCode(IC) = True

        Console.Write("Enter item description: ")
        Description = Console.ReadLine

        Console.Write("Enter item price: ")
        Tprice = CSng(Console.ReadLine)

        Console.Write("Enter item number in stock (quantity): ")
        StockQty = CInt(Console.ReadLine)

        FileOpen(1, "StockFile.txt", OpenMode.Input)
        FileOpen(2, "tempFile.txt", OpenMode.Append)
        While Not EOF(1)
            Input(1, StockRecord)
            SRec = StockRecord.Split("#")
            ItemCode = trim(SRec(0))
            ItemDescription = trim(SRec(1))
            Price = SRec(2)
            NumberInStock = SRec(3)

            If IC = ItemCode Then
                StockRecord = IC & "#" & Description & "#" & CStr(Tprice) & "#" & CStr(StockQty)
                WriteLine(2, StockRecord)
                flag = True
            Else
                StockRecord = ItemCode & "#" & ItemDescription & "#" & CStr(Price) & "#" & CStr(NumberInStock)
                WriteLine(2, StockRecord)
            End If
        End While
        FileClose(1)
        FileClose(2)
        Kill("StockFile.txt")
        My.Computer.FileSystem.RenameFile("tempFile.txt", "StockFile.txt")

        If flag = False Then
            Console.WriteLine("Record not found.")
            Console.ReadKey()
        Else
            Console.WriteLine("Record edited successfully... Press any key to continue.")
            Console.ReadKey()
        End If
    End Sub

    Sub DisplayRecordsAbovePrice(Level As Integer)
        Dim x As Integer = 0
        Dim myPrice As String = ""

        Console.Clear()
        Console.WriteLine("Records above price level: " & Level)
        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Item number in stock (quantity)")
        Console.WriteLine(StrDup(95, "-"))

        FileOpen(1, "StockFile.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, StockRecord)
            SRec = StockRecord.Split("#")
            ItemCode = trim(SRec(0))
            ItemDescription = trim(SRec(1))
            Price = SRec(2)
            NumberInStock = SRec(3)

            If Price > Level Then
                Console.Write(ItemCode + Space(9))
                Console.Write(ItemDescription & Space(40 - Len(ItemDescription)))
                myPrice = Format(Price, "##########.00")
                Console.Write(myPrice & Space(12 - Len(myPrice)))
                Console.WriteLine(NumberInStock)
            End If
        End While

        FileClose(1)
        Console.ReadKey()
    End Sub

    Sub DisplayAllRecords()
        Dim x As Integer = 0
        Dim myPrice As String = ""

        Console.Clear()
        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Item number in stock (quantity)")
        Console.WriteLine(StrDup(95, "-"))

        FileOpen(1, "StockFile.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, StockRecord)
            SRec = StockRecord.Split("#")
            ItemCode = trim(SRec(0))
            ItemDescription = trim(SRec(1))
            Price = SRec(2)
            NumberInStock = SRec(3)

            Console.Write(ItemCode + Space(9))
            Console.Write(ItemDescription & Space(40 - Len(ItemDescription)))
            myPrice = Format(Price, "##########.00")
            Console.Write(myPrice & Space(12 - Len(myPrice)))
            Console.WriteLine(NumberInStock)

        End While

        FileClose(1)
        Console.ReadKey()
    End Sub

    Function SearchItemCode(IC As String) As Boolean
        Dim flag As Boolean
        Dim myPrice As String

        ItemCode = ""
        ItemDescription = ""
        Price = 0.0
        NumberInStock = 0
        myPrice = ""
        flag = False

        FileOpen(1, "StockFile.txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, StockRecord)
            SRec = StockRecord.Split("#")
            ItemCode = trim(SRec(0))
            ItemDescription = trim(SRec(1))
            Price = SRec(2)
            NumberInStock = SRec(3)

            If IC = ItemCode Then
                flag = True

                Console.Write("Item code  ")
                Console.Write("Item description                        ")
                Console.Write("Item price  ")
                Console.WriteLine("Item number in stock (quantity)")
                Console.WriteLine(StrDup(95, "-"))

                Console.Write(ItemCode + Space(9))
                Console.Write(ItemDescription & Space(40 - Len(ItemDescription)))
                myPrice = Format(Price, "##########.00")
                Console.Write(myPrice & Space(12 - Len(myPrice)))
                Console.WriteLine(NumberInStock)
                Exit While
            End If
        End While

        FileClose(1)
        Return flag
    End Function

    Function SearchItemDescription(description As String, Strict As Boolean) As Boolean

        Dim isFound As Boolean
        Dim myPrice As String

        ItemCode = ""
        ItemDescription = ""
        Price = 0.0
        NumberInStock = 0
        myPrice = ""
        isFound = False

        FileOpen(1, "StockFile.txt", OpenMode.Input)

        Console.Write("Item code  ")
        Console.Write("Item description                        ")
        Console.Write("Item price  ")
        Console.WriteLine("Item number in stock (quantity)")
        Console.WriteLine(StrDup(95, "-"))

        While Not EOF(1)
            Input(1, StockRecord)
            SRec = StockRecord.Split("#")
            ItemCode = trim(SRec(0))
            ItemDescription = trim(SRec(1))
            Price = SRec(2)
            NumberInStock = SRec(3)

            If Strict = True Then
                If ItemDescription = description Then isFound = True
            Else
                If UCase(ItemDescription) = UCase(description) Then isFound = True
            End If

            If isFound = True Then
                If UCase(ItemDescription) = UCase(description) Then
                    Console.Write(ItemCode + Space(9))
                    Console.Write(ItemDescription & Space(40 - Len(ItemDescription)))
                    myPrice = Format(Price, "##########.00")
                    Console.Write(myPrice & Space(12 - Len(myPrice)))
                    Console.WriteLine(NumberInStock)
                End If
            End If
        End While
        FileClose(1)

        If isFound = True Then
            Console.ReadKey()
        End If
        Return isFound
    End Function

    Function ValidItemCode(Code As String) As Boolean
        If Len(Code) = 2 And _
            (Left(Code, 1) >= "A" And Left(Code, 1) <= "Z") And _
            IsNumeric(Right(Code, 1)) Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
