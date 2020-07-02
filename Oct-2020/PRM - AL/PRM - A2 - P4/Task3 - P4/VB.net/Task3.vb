Module LinkedList
    'NullPointer should be set to -1 if using array element with index 0
    Const NULLPOINTER = -1

    'Declare record type to store Destination and pointer
    Structure ListNode
        Dim Destination As String
        Dim Pointer As Integer
    End Structure

    Dim List(7) As ListNode
    Dim StartPointer As Integer
    Dim FreeListPtr As Integer

    Sub Main()
        Dim Choice As Char
        Dim Destination As String
        Dim CurrentNodePtr As Integer
        InitialiseList()
        Choice = GetOption()
        Do While Choice <> "5"

            Select Case Choice
                Case "1"
                    Console.Write("Enter the destination: ")
                    Destination = Console.ReadLine()
                    InsertNode(Destination)
                    OutputAllNodes()
                Case "2"
                    Console.Write("Enter the destination: ")
                    Destination = Console.ReadLine()
                    DeleteNode(Destination)
                    OutputAllNodes()
                Case "3"
                    Console.Write("Enter the destination: ")
                    Destination = Console.ReadLine()
                    CurrentNodePtr = FindNode(Destination)
                Case "4"
                    OutputAllNodes()
                    Console.WriteLine(StartPointer & " " & FreeListPtr)
                    For i = 0 To 7
                        Console.WriteLine(i & " " & List(i).Destination & " " & List(i).Pointer)
                    Next
            End Select
            Choice = GetOption()
        Loop
    End Sub

    Sub InitialiseList()
        StartPointer = NULLPOINTER ' set start pointer
        FreeListPtr = 0 ' set starting position of free list
        For Index = 0 To 7 'link all nodes to make free list
            List(Index).Pointer = Index + 1
        Next
        List(7).Pointer = NULLPOINTER 'last node of free list
    End Sub

    Function FindNode(ByVal DestinationItem As String) As Integer ' returns pointer to node
        Dim CurrentNodePtr As Integer
        CurrentNodePtr = StartPointer ' start at beginning of list
        Try
            Do While CurrentNodePtr <> NULLPOINTER And List(CurrentNodePtr).Destination <> DestinationItem
                ' not end of list,item not found
                ' follow the pointer to the next node
                CurrentNodePtr = List(CurrentNodePtr).Pointer
            Loop
            Console.WriteLine("Destination found...")
            Console.WriteLine(CurrentNodePtr & " " & List(CurrentNodePtr).Destination)
        Catch ex As Exception
            Console.WriteLine("Destination not found")
        End Try
        Console.Write("Press any key to continue...")
        Console.ReadKey()

        Return (CurrentNodePtr) ' returns NullPointer if item not found
    End Function

    Sub DeleteNode(ByVal DestinationItem As String)
        Dim ThisNodePtr, PreviousNodePtr As Integer
        ThisNodePtr = StartPointer
        Try
            ' start at beginning of list
            Do While ThisNodePtr <> NULLPOINTER And List(ThisNodePtr).Destination <> DestinationItem
                ' while not end of list and item not found
                PreviousNodePtr = ThisNodePtr ' remember this node
                ' follow the pointer to the next node
                ThisNodePtr = List(ThisNodePtr).Pointer
            Loop
        Catch ex As Exception
            Console.WriteLine("Destination does not exist in list")
            Console.Write("Press any key to continue...")
            Console.ReadKey()
        End Try
        If ThisNodePtr <> NULLPOINTER Then ' node exists in list
            If ThisNodePtr = StartPointer Then ' first node to be deleted
                StartPointer = List(StartPointer).Pointer
            Else
                List(PreviousNodePtr).Pointer = List(ThisNodePtr).Pointer
            End If
            List(ThisNodePtr).Pointer = FreeListPtr
            FreeListPtr = ThisNodePtr
        End If
    End Sub

    Sub InsertNode(ByVal NewItem As String)
        Dim ThisNodePtr, NewNodePtr, PreviousNodePtr As Integer
        If FreeListPtr <> NULLPOINTER Then
            ' there is space in the array
            ' take node from free list and store Destination item
            NewNodePtr = FreeListPtr
            List(NewNodePtr).Destination = NewItem
            FreeListPtr = List(FreeListPtr).Pointer
            ' find insertion point
            PreviousNodePtr = NULLPOINTER
            ThisNodePtr = StartPointer ' start at beginning of list
            Try
                Do While (ThisNodePtr <> NULLPOINTER) And (List(ThisNodePtr).Destination < NewItem)
                    ' while not end of list
                    PreviousNodePtr = ThisNodePtr ' remember this node
                    ' follow the pointer to the next node
                    ThisNodePtr = List(ThisNodePtr).Pointer
                Loop
            Catch ex As Exception
            End Try
            If PreviousNodePtr = NULLPOINTER Then ' insert new node at start of list
                List(NewNodePtr).Pointer = StartPointer
                StartPointer = NewNodePtr
            Else ' insert new node between previous node and this node
                List(NewNodePtr).Pointer = List(PreviousNodePtr).Pointer
                List(PreviousNodePtr).Pointer = NewNodePtr
            End If
        Else
            Console.WriteLine("no space for more Destination")
            Console.Write("Press any key to continue...")
            Console.ReadKey()
        End If
    End Sub

    Sub OutputAllNodes()
        Dim CurrentNodePtr As Integer
        CurrentNodePtr = StartPointer ' start at beginning of list
        If StartPointer = NULLPOINTER Then
            Console.WriteLine("No Destination in list")
        End If
        Do While CurrentNodePtr <> NULLPOINTER ' while not end of list
            Console.WriteLine(CurrentNodePtr & " " & List(CurrentNodePtr).Destination)
            ' follow the pointer to the next node
            CurrentNodePtr = List(CurrentNodePtr).Pointer
        Loop

        Console.Write("Press any key to continue...")
        Console.ReadKey()
    End Sub

    Function GetOption()
        Dim Choice As Char
        Console.Clear()
        Console.WriteLine("A2 Computer Science 9608, Pre Release Material (All Variants) -- Oct/Nov 2020")
        Console.WriteLine("Simulator by Zak; http://www.zakonweb.com")
        Console.WriteLine("Menu Task3 - Linked List")
        Console.WriteLine(StrDup(50, "-"))
        Console.WriteLine("1: Insert a destination")
        Console.WriteLine("2: Delete a destination")
        Console.WriteLine("3: Find a destination")
        Console.WriteLine("4: Output destination linked list")
        Console.WriteLine("5: End program")
        Console.Write("Enter your choice: ")
        Choice = Console.ReadLine()
        Return (Choice)
    End Function
End Module