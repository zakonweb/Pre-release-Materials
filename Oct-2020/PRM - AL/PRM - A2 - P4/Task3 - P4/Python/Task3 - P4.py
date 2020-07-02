# NullPointer should be set to -1 if using array element with index 0
NULLPOINTER = -1  # Const NULLPOINTER = -1

# Declare record type to store Destination and pointer
# Structure
Destination = ""  # Dim Destination As String
Pointer = 0  # Dim Pointer As Integer
# End Structure

List = []  # Dim List(7) As ListNode
Pointers = []

StartPointer = NULLPOINTER  # Dim StartPointer As Integer
FreeListPtr = 0  # Dim FreeListPtr As Integer


def main():
    global List, Pointers
    choice = 0  # DECLARE Choice : INTEGER = 0

    InitialiseList()
    while choice != 5:
        print("A2/P4 Computer Science 9608")
        print("Pre Release Material (All Variants) -- Oct/Nov 2020")
        print("Simulator by Zak; http://www.zakonweb.com")
        print("-" * 90)
        print("MENU - TASK 3")
        print("1: Insert a destination")
        print("2: Delete a destination")
        print("3: Find a destination")
        print("4: Output destination linked list")
        print("5: End program")

        choice = int(input("Enter choice [1-5]... "))

        if choice == 1:
            Destination = input("Enter the destination: ")
            InsertNode(Destination)
            OutputAllNodes()
        if choice == 2:
            Destination = input("Enter the destination: ")
            DeleteNode(Destination)
            OutputAllNodes()
        if choice == 3:
            Destination = input("Enter the destination: ")
            CurrentNodePtr = FindNode(Destination)
        if choice == 4:
            OutputAllNodes()
            print(str(StartPointer) + " " + str(FreeListPtr))
            for i in range(0, 7):
                if List[i] == None: break
                print(str(i) + " " + List[i] + " " + str(Pointers[i]))
        if choice > 5 or choice < 1:
            print("Wrong choice. Please chose an option between 1-5.")
            input()


def InitialiseList():
    global StartPointer, FreeListPtr, NULLPOINTER, List, Pointers
    StartPointer = NULLPOINTER  # set start pointer
    FreeListPtr = 0  # set starting position of free list
    for Index in range(0, 7):  # link all nodes to make free list
        List.append("")
        Pointers.append(Index + 1)
    Pointers[6] = NULLPOINTER  # last node of free list

def FindNode(DestinationItem):  # returns pointer to node
    global StartPointer, FreeListPtr, NULLPOINTER, List, Pointers

    CurrentNodePtr = 0  # DECLARE CurrentNodePtr As Integer
    CurrentNodePtr = StartPointer  # start at beginning of list
    while CurrentNodePtr != NULLPOINTER and List[CurrentNodePtr] != DestinationItem:
        # not end of list,item not found
        # follow the pointer to the next node
        CurrentNodePtr = Pointers[CurrentNodePtr]

    if List[CurrentNodePtr] == DestinationItem:
        print("Destination found...")
        print(str(CurrentNodePtr) + " " + List[CurrentNodePtr])
    else:
        print("Destination not found.")

    input("Press enter key to continue...")
    return CurrentNodePtr  # returns NullPointer if item not found


def DeleteNode(DestinationItem):
    global StartPointer, FreeListPtr, NULLPOINTER, List, Pointers

    ThisNodePtr = PreviousNodePtr = 0  # Dim ThisNodePtr, PreviousNodePtr As Integer
    ThisNodePtr = StartPointer
    try:
        # start at beginning of list
        while ThisNodePtr != NULLPOINTER and List[ThisNodePtr] != DestinationItem:
            # while not end of list and item not found
            PreviousNodePtr = ThisNodePtr  # remember this node
            # follow the pointer to the next node
            ThisNodePtr = Pointers[ThisNodePtr]
    except:
        print("Destination does not exist in list")
        input("Press enter key to continue...")
    if ThisNodePtr != NULLPOINTER:  # node exists in list
        if ThisNodePtr == StartPointer:  # first node to be deleted
            StartPointer = Pointers[StartPointer]
        else:
            Pointers[PreviousNodePtr] = Pointers[ThisNodePtr]
        Pointers[ThisNodePtr] = FreeListPtr
        FreeListPtr = ThisNodePtr

def InsertNode(NewItem):
    global StartPointer, FreeListPtr, NULLPOINTER, List, Pointers

    # DECLARE ThisNodePtr, NewNodePtr, PreviousNodePtr As Integer
    ThisNodePtr = NewNodePtr = PreviousNodePtr = 0

    if FreeListPtr != NULLPOINTER:
        # there is space in the array
        # take node from free list and store Destination item
        NewNodePtr = FreeListPtr
        List[NewNodePtr] = NewItem
        FreeListPtr = Pointers[FreeListPtr]

        # find insertion point
        PreviousNodePtr = NULLPOINTER
        ThisNodePtr = StartPointer  # start at beginning of list
        try:
            while ThisNodePtr != NULLPOINTER and List[ThisNodePtr] < NewItem:
                # while not end of list
                PreviousNodePtr = ThisNodePtr  # remember this node
                # follow the pointer to the next node
                ThisNodePtr = Pointers[ThisNodePtr]
        except:
            pass

        if PreviousNodePtr == NULLPOINTER:  # insert new node at start of list
            Pointers[NewNodePtr] = StartPointer
            StartPointer = NewNodePtr
        else:  # insert new node between previous node and this node
            Pointers[NewNodePtr] = Pointers[PreviousNodePtr]
            Pointers[PreviousNodePtr] = NewNodePtr
    else:
        print("No space for more Destination")
        print("Press enter key to continue...")

def OutputAllNodes():
    global StartPointer, FreeListPtr, NULLPOINTER, List, Pointers

    CurrentNodePtr = 0 # DECLARE CurrentNodePtr As Integer
    CurrentNodePtr = StartPointer # start at beginning of list
    if StartPointer == NULLPOINTER:
        print("No Destination in list")
    while CurrentNodePtr != NULLPOINTER: # while not end of list
        print(str(CurrentNodePtr) + " " + str(List[CurrentNodePtr]))
        # follow the pointer to the next node
        CurrentNodePtr = Pointers[CurrentNodePtr]
    input("Press enter key to continue...")
    
main()
