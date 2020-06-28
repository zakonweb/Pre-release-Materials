# TASK 1 – Algorithms, arrays and pseudocode
# The following four 1D arrays can store different
# pieces of data about Stock items in a shop:
# Array identifier 	Data type
# ItemCode 		    STRING
# ItemDescription 	STRING
# Price 			    REAL
# NumberInStock      INTEGER

# import only system from os
from os import system, name

# CONSTANT
items = 17

ItemCode = [] # DECLARE ItemCode: ARRAY[] OF STRING
ItemDescription = [] # DECLARE ItemDescription: ARRAY[] OF STRING
Price = [] # DECLARE Price: ARRAY[] OF REAL
NumberInStock = [] # DECLARE NumberInStock: ARRAY[] OF INTEGER

def main():
    choice = 0  # DECLARE Choice : INTEGER = 0

    Initialise()
    while choice != 8:
        clear()
        print("AS Computer Science 9608")
        print("Pre Release Material (All Variants) -- Oct/Nov 2020")
        print("Simulator by Zak; http://www.zakonweb.com")
        print("-" * 90)
        print("MENU - TASK 1")
        print("1. Enter data into arrays.")
        print("2. Populate arrays automatically.")
        print("3. Display complete data captured in arrays.")
        print("4. Task 1.1: Search for a specific value in ItemDescription.")
        print("5. Task 1.2: Search for multiple instances of the value.")
        print("6. Task 1.3: Search & output the corresponding values from all arrays.")
        print("7. Task 1.4: Display all the information about items in Stock below a given level.")
        print("8. Quit")
        choice = int(input("Enter choice [1-8]... "))

        if choice == 1: PopulateDataEntry()
        if choice == 2: PopulateAuto()
        if choice == 3: DisplayAllRecords()
        if choice == 4: Task11()
        if choice == 5: Task12()
        if choice == 6: Task13()
        if choice == 7: Task14()
        if choice > 8 or choice < 1:
            print("Wrong choice. Please chose an option between 1-8.")
            input()

def Task11():
    # TASK 1.1
    # Design an algorithm to search for a specific value
    # in ItemDescription and, if found, to print(the array
    # index where the value is found.
    # print a suitable message IF the value is not found.

    Description = ""  # DECLARE Description : STRING
    isStrict = ''  # DECLARE isStrict : CHARACTER
    Strict = False  # DECLARE Strict : BOOLEAN
    Position = 0  # DECLARE Position : INTEGER

    Description = input("Enter item description to search for: ")
    isStrict = input("Do you want strict searching (Y/N)? ")
    if isStrict.upper() == 'Y': Strict = True

    Position = SearchUniqueItemDescription(Description, Strict)
    if Position == 0:
        print(Description + " is not found in Stock.")
    else:
        print(Description + " is found in Stock at location: ", end='')
        print(str(Position))

    input("Press any key to continue...")

def Task12():
    # TASK 1.2
    # Consider the difference between algorithms that search
    # FOR a REAL or multiple instance of the value.

    Description = "" # DECLARE Description : STRING = ""
    Description = input("Enter item description to search for: ")
    SearchMultipleItemDescription(Description)

def Task13():
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock

    # TASK 1.3
    # end the algorithm from Task 1.1 TO print
    # the corresponding values from the other arrays.

    Description = ""  # DECLARE Description : STRING
    isStrict = ''  # DECLARE isStrict : CHARACTER
    Strict = False  # DECLARE Strict : BOOLEAN
    Position = 0  # DECLARE Position : INTEGER

    Description = input("Enter item description to search for: ")
    isStrict = input("Do you want strict searching (Y/N): ")
    if isStrict.upper() == 'Y': Strict = True

    Position = SearchUniqueItemDescription(Description, Strict)
    if Position == 0:
        print(Description + " is not found in Stock.")
    else:
        print(Description + " is found in Stock at location: " + str(Position))
        print("Item code: " + ItemCode[Position])
        print("Item description: " + ItemDescription[Position])
        print("Item price: " + str(Price[Position]))
        print("Item number in Stock (quantity): " + str(NumberInStock[Position]))

    input("Press any key to continue...")

def Task14():
    # TASK 1.4
    # Write program code TO produce a report displaying

    StockLevel = 0  # DECLARE StockLevel : INTEGER
    StockLevel = int(input("Enter item level to search for: "))
    DisplayRecordsBelowLevel(StockLevel)

def Initialise():
    # Initialise all SD arrays used
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock

    ItemCode.clear()
    ItemDescription.clear()
    Price.clear()
    NumberInStock.clear()

def PopulateDataEntry():
    # Populate all arrays in corresponding records' data entry manner
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock
    Initialise()

    x = 0  # DECLARE x : INTEGER

    for x in range(0,items):
        print("Item Number: ", x+1)
        print("--------------")
        ItemCode.append(input("Enter item code: "))
        ItemDescription.append(input("Enter item description: "))
        Price.append(float(input("Enter item price: ")))
        NumberInStock.append(int(input("Enter item number in Stock (quantity): ")))
        print()

# define our c1lear function
def clear():
    # for windows
    if name == 'nt':
        _ = system('cls')
    # for mac and linux(here, os.name is 'posix')
    else:
        _ = system('clear')

def PopulateAuto():
    # Auto populate the SD arrays using predetermined values
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock

    Initialise()  #Clean all arrays before refilling them
    ItemCode = ["A1", "A2", "B1", "B2", "B3", "C1", "C2", "C3",
                "D1", "D2", "E1", "E2", "E3", "F1", "F2", "G1", "G2"]

    ItemDescription.append("Case Compact")
    ItemDescription.append("Case Tower")
    ItemDescription.append("RAM 8 GB")
    ItemDescription.append("RAM 16 GB")
    ItemDescription.append("RAM 32 GB")
    ItemDescription.append("Main Hard Disk Drive 1 TB HDD")
    ItemDescription.append("Main Hard Disk Drive 2 TB HDD")
    ItemDescription.append("RAM 8 GB")
    ItemDescription.append("Solid State Drive 240 GB SSD")
    ItemDescription.append("Solid State Drive 480 GB SSD")
    ItemDescription.append("Second Hard Disk Drive 1 TB HDD")
    ItemDescription.append("Second Hard Disk Drive 2 TB HDD")
    ItemDescription.append("Second Hard Disk Drive 4 TB HDD")
    ItemDescription.append("Optical Drive DVD/Blu-Ray Player")
    ItemDescription.append("Optical Drive DVD/Blu-Ray Re-writer")
    ItemDescription.append("Operating System Standard Version")
    ItemDescription.append("Operating System Professional Version")

    Price = [75.0, 150.0, 79.99, 149.99, 299.99, 49.99, 89.99, 129.99,
           59.99, 119.99, 49.99, 89.99, 129.99, 50.0, 100.0, 100.0, 175.0]

    NumberInStock = [85, 100, 95, 49, 65, 52, 87, 12, 50, 83, 32, 15,
                     56, 41, 25, 73, 22]

    print("All arrays are populated successfully.")
    DisplayAllRecords()

def SearchUniqueItemDescription(Description, Strict):
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock

    Position = 0  # DECLARE Position : INTEGER
    x = 0  # DECLARE x : INTEGER
    isFound = False  # DECLARE isFound : BOOLEAN

    for x in range(0, len(ItemDescription)):
        if Strict == True:
            if ItemDescription[x] == Description: isFound = True
        else:
            if ItemDescription[x].upper() == Description.upper(): isFound = True

        if isFound == True:
            Position = x
            break

    if isFound == True:
        return Position
    else:
        return 0


def SearchMultipleItemDescription(Description):
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock

    x = 0  # DECLARE x : INTEGER
    isFound = False  # DECLARE isFound : BOOLEAN

    for x in range(0, len(ItemDescription)):
        if ItemDescription[x] == Description:
            isFound = True
            print("Item code: " + ItemCode[x])
            print("Item description: " + ItemDescription[x])
            print("Item price: " + str(Price[x]))
            print("Item number in Stock (quantity): " + str(NumberInStock[x]))
            print()

    if isFound == False: print("Item: " + Description + " is not found.")
    print("Press any key to continue...")

def  DisplayAllRecords():
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock

    x = 0  # DECLARE x : INTEGER
    myPrice = ""  # DECLARE myPrice : STRING

    print("Item code  ", end='')
    print("Item description                        ", end='')
    print("Item price  ", end='')
    print("Item number in Stock (quantity)")
    print("-" * 95)

    for x in range (0,len(ItemCode)):
        print(ItemCode[x] + (" " * 9), end='')
        print(ItemDescription[x] + (" " * (40 - len(ItemDescription[x]))), end='')
        myPrice = ("%12.2f" % Price[x]).strip()
        print(myPrice + (" " * (12 - len(myPrice))), end='')
        print(NumberInStock[x])

    input("Press any key to continue...")

def DisplayRecordsBelowLevel(Level):
    global ItemCode
    global ItemDescription
    global Price
    global NumberInStock

    x = 0  # DECLARE x : INTEGER
    myPrice = ""  # DECLARE myPrice : STRING

    print("Item code  ", end='')
    print("Item description                        ", end='')
    print("Item price  ", end='')
    print("Item number in Stock (quantity)")
    print("-" * 95)

    for x in range (0,len(NumberInStock)):
        if NumberInStock[x] < Level:
            print(ItemCode[x] + (" " * 9), end='')
            print(ItemDescription[x] + (" " * (40 - len(ItemDescription[x]))), end='')
            myPrice = ("%12.2f" % Price[x]).strip()
            print(myPrice + (" " * (12 - len(myPrice))), end='')
            print(NumberInStock[x])

    input("Press any key to continue...")

main()  #Start executing program by callin the main function