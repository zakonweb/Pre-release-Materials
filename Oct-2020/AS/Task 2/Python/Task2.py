# TASK 2 – Programs containing several components
# The stock data described in Task 1 are now to be stored in a text file.
# Each line of the file will correspond to one stock item.

# TASK 2.1
# Define a format in which each line of the text file can store the
# different pieces of data about one stock item.
# Consider whether there is a requirement for data type conversion.

# WE WILL BE USING FOLLOWING STATEMENT
# StockRecord = ItemCode & "#" & ItemDescription & "#" &
# NUM_TO_STRING(Price) & "#" & NUM_TO_STRING(NumberInStock)
# WHERE:
# # sign will be used : a delimeter between four fields to
# create a single string for saving to file
# NUM_TO_STRING() FUNCTION will be used for casting from REAL
# AND INTEGER to STRING data types

import os

StockRecord = StockField = "" # DECLARE StockRecord, StockField : STRING
SRec = [] # DECLARE SRec: ARRAY[1:15] OF STRING
ItemCode = "" # DECLARE ItemCode : STRING
ItemDescription = "" # DECLARE ItemDescription : STRING
Price = 0.0 # DECLARE Price : REAL
NumberInStock = 0 # DECLARE NumberInStock : INTEGER


def Main():
    # TASK 2.4
    # Consider the different modes when opening a file.
    # Discuss the difference between creating a file AND
    # amENDing the contents.
    # ExtEND the program to include a menu-driven interface that
    # will perform the following tasks:
    # A. Add a new stock item to the text file. Include validation of
    # the different pieces of information as
    # appropriate. For example, item code data may be a fixed format.
    # B. Search for a stock item with a specific item code. Output the
    # other pieces of data together with suitable supporting text.
    # C. Search for all stock items with a specific item description,
    # with output : for task B.
    # D. Output a list of all stock items with a price greater than a given amount.

    choice = 0  # DECLARE choice : INTEGER
    while choice != 8:
        print("AS Computer Science 9608, Pre Release Material (All Variants) -- Oct/Nov 2020")
        print("Simulator by Zak; http:# www.zakonweb.com")
        print("-" * 90)
        print("MENU - TASK 2")
        print("1: APPEND record to the file")
        print("2: READ all records from the file")
        print("3: DELETE a record from the file")
        print("4: EDIT a record in the file")
        print("5: SEARCH item code from the file")
        print("6: SEARCH item description from the file")
        print("7: Display records above a given price")
        print("8: EXIT")
        choice = int(input("Enter your choice... "))

        if choice == 1: AppendRecord()
        if choice == 2: DisplayAllRecords()
        if choice == 3: DeleteRecord()
        if choice == 4: EditRecord()
        if choice == 5: Task24B()
        if choice == 6: Task24C()
        if choice == 7: Task24D()
        if choice > 8 or choice < 1:  # Quit Program
            print("Wrong choice made... Press enter key to continue.")

def Task24B():
    # B. Search for a stock item with a specific item code. Output the
    # other pieces of data together with suitable supporting text.

    code = "" # DECLARE code : STRING = ""
    isFound = False # DECLARE isFound : BOOLEAN = False

    while ValidItemCode(code) != True:
        code = input("Enter item code (Format:A9) to search for: ")

    isFound = SearchItemCode(code)
    if not isFound:
        print(code + " is NOT found in stock file.")
    else:
        print(code + " is found in stock file.")

def Task24C():
    # C. Search for all stock items with a specific item description,
    # with output : for task B.

    Description = "" # DECLARE Description : STRING = ""
    isStrict = '' # DECLARE isStrict : CHARACTER = ''
    Strict = False # DECLARE Strict : BOOLEAN
    isFound = False # DECLARE isFound : BOOLEAN = False

    Description = input("Enter item description to search for: ")

    isStrict = input("REPEAT you want strict searching (Y/N): ")
    if isStrict.upper() == 'Y': Strict = True

    isFound = SearchItemDescription(Description, Strict)
    if isFound == False:
        print(Description + " is NOT found in stock.")

def Task24D():
    # D. Output a list of all stock items with a price greater than a given amount.
    price = 0.0 # DECLARE price : REAL = 0

    price = float(input("Enter item price: "))
    DisplayRecordsAbovePrice(price)

def AppendRecord():
    # TASK 2.2
    # Design an algorithm to input the four pieces of data
    # about a stock item, form a STRING according to your
    # format design, AND write the STRING to the text file.

    # TASK 2.3
    # Write program code to implement your algorithm.

    StockRecord = ""
    ItemCode = ""
    ItemDescription = ""
    Price = 0.0
    NumberInStock = 0

    # Task 2.4
    # A. Add a new stock item to the text file. Include validation of
    # the different pieces of information as
    # appropriate. For example, item code data may be a fixed format.

    while ValidItemCode(ItemCode) != True:
        ItemCode = input("Enter item code(Format:A9): ")

    ItemDescription = input("Enter item description: ")
    Price = float(input("Enter item price: "))
    NumberInStock = int(input("Enter item number in stock (quantity): "))
    StockRecord = (ItemCode + "#" + ItemDescription + "#" +
	str(Price).strip() + "#" + str(NumberInStock).strip())

    sf = open("StockFile.txt", "a")
    sf.write(StockRecord + "\n")
    sf.close()

    input("Record appended successfully... Press enter key to continue.")


def DeleteRecord():
    IC = ""  # DECLARE IC : STRING
    isFound = False  # DECLARE isFound : BOOLEAN

    ItemCode = ""
    ItemDescription = ""
    Price = 0.0
    NumberInStock = 0

    while ValidItemCode(IC) != True:
        IC = input("Enter Item Code (Format: A9) to Delete :")

    sf = open("StockFile.txt", "r")
    tf = open("tempFile.txt", "w")
    for StockRecord in sf:
        SRec = StockRecord.split("#")

        ItemCode = SRec[0].strip()
        ItemDescription = SRec[1].strip()
        Price = float(SRec[2])
        SR = SRec[3]
        SR = SR[:-2]
        NumberInStock = int(SR)

        if IC == ItemCode:
            isFound = True
        else:
            tf.write(StockRecord)
    sf.close()
    tf.close()

    os.remove("StockFile.txt")
    os.rename("tempFile.txt", "StockFile.txt")

    if isFound:
        input("Record deleted successfully... Press enter key to continue.")
    else:
        input("Record was NOT found... Press enter key to continue.")


def EditRecord():
    IC = Description = SR = ""  # DECLARE IC, Description, SR : STRING
    Tprice = 0.0  # DECLARE Tprice : REAL
    StockQty = 0  # DECLARE StockQty : INTEGER
    flag = False  # DECLARE flag : BOOLEAN

    ItemCode = ""
    ItemDescription = ""
    Price = 0.0
    NumberInStock = 0

    while ValidItemCode(IC) != True:
        IC = input("Enter item code (Format:A9): ")

    Description = input("Enter item description: ")
    Tprice = float(input("Enter item price: "))
    StockQty = int(input("Enter item number in stock (quantity): "))

    sf = open("StockFile.txt", "r")
    tf = open("tempFile.txt", "w")
    for StockRecord in sf:
        SRec = StockRecord.split("#")

        ItemCode = SRec[0].strip()
        ItemDescription = SRec[1].strip()
        Price = float(SRec[2])
        NumberInStock = (SRec[3])

        if IC == ItemCode:
            SR = (IC + "#" + Description + "#" +
                           str(Tprice).strip() + "#" + str(StockQty).strip())
            tf.write(SR + "\n")
            flag = True
        else:
            SR = (ItemCode + "#" + ItemDescription + "#" +
                           str(Price).strip() + "#" + str(NumberInStock).strip())
            tf.write(SR + "\n")
    sf.close()
    tf.close()

    os.remove("StockFile.txt")
    os.rename("tempFile.txt", "StockFile.txt")

    if flag:
        input("Record edited successfully... Press enter key to continue.")
    else:
        input("Record was not found... Press enter key to continue.")

def DisplayRecordsAbovePrice(Level):
    x = 0 # DECLARE x : INTEGER
    myPrice = "" # DECLARE myPrice : STRING

    print("Records above price level: ", Level)
    print("Item code  ", end='')
    print("Item description                        ", end='')
    print("Item price  ", end='')
    print("Item number in Stock (quantity)")
    print("-" * 95)

    sf = open("StockFile.txt", "r")
    for StockRecord in sf:
        SRec = StockRecord.split("#")

        ItemCode = SRec[0].strip()
        ItemDescription = SRec[1].strip()
        Price = float(SRec[2])
        NumberInStock = int(SRec[3])

        if Price > Level:
            print(ItemCode + (" " * 9), end='')
            print(ItemDescription + (" " * (40 - len(ItemDescription))), end='')
            myPrice = ("%12.2f" % Price).strip()
            print(myPrice + (" " * (12 - len(myPrice))), end='')
            print(NumberInStock)
    sf.close()
    input("Press enter key to continue...")

def DisplayAllRecords():
    x = 0 # DECLARE x : INTEGER
    myPrice = "" # DECLARE myPrice : STRING

    print("Records above price level: ")
    print("Item code  ", end='')
    print("Item description                        ", end='')
    print("Item price  ", end='')
    print("Item number in Stock (quantity)")
    print("-" * 95)

    sf = open("StockFile.txt", "r")
    for StockRecord in sf:
        SRec = StockRecord.split("#")

        ItemCode = SRec[0].strip()
        # ItemCode = ItemCode[1:]
        ItemDescription = SRec[1].strip()
        Price = float(SRec[2])
        # SR = SRec[3]
        # SR = SR[:-2]
        NumberInStock = int(SRec[3])

        print(ItemCode + (" " * 9), end='')
        print(ItemDescription + (" " * (40 - len(ItemDescription))), end='')
        myPrice = ("%12.2f" % Price).strip()
        print(myPrice + (" " * (12 - len(myPrice))), end='')
        print(NumberInStock)
    sf.close()
    input("Press enter key to continue...")

def SearchItemCode(IC):
    flag = False # DECLARE flag : BOOLEAN
    myPrice = "" # DECLARE myPrice : STRING

    ItemCode = ""
    ItemDescription = ""
    Price = 0.0
    NumberInStock = 0
    myPrice = ""
    flag = False

    sf = open("StockFile.txt", "r")
    for StockRecord in sf:
        SRec = StockRecord.split("#")

        ItemCode = SRec[0].strip()
        ItemDescription = SRec[1].strip()
        Price = float(SRec[2])
        NumberInStock = int(SRec[3])

        if IC == ItemCode:
            flag = True

            print("Item code  ", end='')
            print("Item description                        ", end='')
            print("Item price  ", end='')
            print("Item number in Stock (quantity)")
            print("-" * 95)

            print(ItemCode + (" " * 9), end='')
            print(ItemDescription + (" " * (40 - len(ItemDescription))), end='')
            myPrice = ("%12.2f" % Price).strip()
            print(myPrice + (" " * (12 - len(myPrice))), end='')
            print(NumberInStock)
    sf.close()
    input("Press enter key to continue...")
    return flag

def SearchItemDescription(description, Strict):
    isFound = False # DECLARE isFound : BOOLEAN
    myPrice = "" # DECLARE myPrice : STRING

    ItemCode = ""
    ItemDescription = ""
    Price = 0.0
    NumberInStock = 0

    sf = open("StockFile.txt", "r")
    print("Item code  ", end='')
    print("Item description                        ", end='')
    print("Item price  ", end='')
    print("Item number in Stock (quantity)")
    print("-" * 95)

    for StockRecord in sf:
        SRec = StockRecord.split("#")

        ItemCode = SRec[0].strip()
        ItemDescription = SRec[1].strip()
        Price = float(SRec[2])
        NumberInStock = int(SRec[3])

        if Strict == True:
            if ItemDescription == description: isFound = True
        else:
            if ItemDescription.upper() == description.upper() : isFound = True

        if isFound == True:
            if ItemDescription.upper() == description.upper():
                print(ItemCode + (" " * 9), end='')
                print(ItemDescription + (" " * (40 - len(ItemDescription))), end='')
                myPrice = ("%12.2f" % Price).strip()
                print(myPrice + (" " * (12 - len(myPrice))), end='')
                print(NumberInStock)
    sf.close()
    input("Press enter key to continue...")
    return isFound

def ValidItemCode(Code):
    if (len(Code) == 2 and
        (Code[0] >= "A" and Code[0] <= "Z") and
        Code[-1].isnumeric()):
            return True
    else:
        return False

Main()