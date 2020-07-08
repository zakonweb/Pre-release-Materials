items = 17

newSaleItem = ["", "", "", "", "", "", ""]
newSaleItemPrice = ["", "", "", "", "", "", ""]

category = ["Case", "Case", "RAM", "RAM", "RAM", "Main Hard Disk Drive", "Main Hard Disk Drive",
            "Main Hard Disk Drive", "Solid State Drive", "Solid State Drive", "Second Hard Disk Drive",
            "Second Hard Disk Drive", "Second Hard Disk Drive", "Optical Drive", "Optical Drive",
            "Operating System", "Operating System"]

itemCode = ["A1", "A2", "B1", "B2", "B3", "C1", "C2", "C3", "D1", "D2", "E1", "E2", "E3", "F1", "F2", "G1", "G2"]

itemDescription = ["Case Compact", "Case Tower", "RAM 8 GB", "RAM 16 GB", "RAM 32 GB",
                   "Main Hard Disk Drive 1 TB HDD", "Main Hard Disk Drive 2 TB HDD", "Main Hard Disk Drive 4 TB HDD"
    , "Solid State Drive 240 GB SSD", "Solid State Drive 480 GB SSD",
                   "Second Hard Disk Drive 1 TB HDD", "Second Hard Disk Drive 2 TB HDD",
                   "Second Hard Disk Drive 4 TB HDD", "Optical Drive DVD/Blu-Ray Player",
                   "Optical Drive DVD/Blu-Ray Re-writer", "Operating System Standard Version",
                   "Operating System Professional Version"]

price = [75.0, 150.0, 79.99, 149.99, 299.99, 49.99, 89.99, 129.99, 59.99, 119.99, 49.99, 89.99, 129.99, 50.0, 100.0,
         100.0, 175.0]

def task1():
    print("Item code   Item Description                         Item price  Category")
    print("-" * 95)
    for i in range(8):
        print(itemCode[i] + " " * 9 + itemDescription[i] + " " * (43 - len(itemDescription[i])) + "{}".format(price[i])
              + " " * (14 - len(str(price[i]))) + category[i])

    print("")
    print("")
    print("New sale initiated - Default basic set of components costing $200 is added.")
    print("One case, one RAM and one Main Hard Disk Drive is required to be added.")
    print("")
    print("")
    print("Item code   Item Description                         Item price  Category")
    print("-" * 95)
    for i in range(2):
        print(itemCode[i] + " " * 9 + itemDescription[i] + " " * (43 - len(itemDescription[i])) + "{}".format(price[i])
              + " " * (14 - len(str(price[i]))) + category[i])

    itemID = ""
    while itemID != "A1" and itemID != "A2":
        print("")
        itemID = input("Choose a Case Item Code: ")
        if itemID != "A1" and itemID != "A2":
            print("Choose either A1 or A2")

    if itemID == "A1":
        newSaleItem[0] = itemDescription[0]
        newSaleItemPrice[0] = price[0]
    elif itemID == "A2":
        newSaleItem[0] = itemDescription[1]
        newSaleItemPrice[0] = itemDescription[1]

    print("")
    print("")
    print("Item code   Item Description                         Item price  Category")
    print("-" * 95)
    for i in range(2, 5):
        print(itemCode[i] + " " * 9 + itemDescription[i] + " " * (43 - len(itemDescription[i])) + "{}".format(price[i])
              + " " * (14 - len(str(price[i]))) + category[i])

    while itemID != "B1" and itemID != "B2" and itemID != "B3":
        itemID = input("Choose a RAM Item Code: ")

        if itemID != "B1" and itemID != "B2" and itemID != "B3":
            print("Choose either B1, B2 or B3")

    if itemID == "B1":
        newSaleItem[1] = itemDescription[2]
        newSaleItemPrice[1] = price[2]
    elif itemID == "B2":
        newSaleItem[1] = itemDescription[3]
        newSaleItemPrice[1] = price[3]
    elif itemID == "B3":
        newSaleItem[1] = itemDescription[4]
        newSaleItemPrice[1] = price[4]

    print("")
    print("")
    print("Item code   Item Description                         Item price  Category")
    print("-" * 95)
    for i in range(5, 8):
        print(itemCode[i] + " " * 9 + itemDescription[i] + " " * (43 - len(itemDescription[i])) + "{}".format(price[i])
              + " " * (14 - len(str(price[i]))) + category[i])

    while itemID != "C1" and itemID != "C2" and itemID != "C3":
        itemID = input("Chose a Main Hard Disk Drive Item Code: ")

        if itemID != "C1" and itemID != "C2" and itemID != "C3":
            print("Choose either C1, C2 or C3")

    if itemID == "C1":
        newSaleItem[2] = itemDescription[5]
        newSaleItemPrice[2] = price[5]
    elif itemID == "C2":
        newSaleItem[2] = itemDescription[6]
        newSaleItemPrice[2] = price[6]
    elif itemID == "C3":
        newSaleItem[2] = itemDescription[7]
        newSaleItemPrice[2] = price[7]

    itemCount = 3

    computerPrice = 200
    print("")
    print("Computer Invoice")
    print("")
    print("Item Description                         Item price")
    print("-" * 50)
    for i in range(3):
        print(newSaleItem[i] + " " * (42 - len(newSaleItem[i])) + str(newSaleItemPrice[i]))
        computerPrice = computerPrice + newSaleItemPrice[i]

    print("")
    print("Total price of the computer: " + str(computerPrice))

def task2():
    itemCount = 0
    print("")
    print("")
    print("Item code   Item Description                         Item price  Category")
    print("-" * 95)
    for i in range(8, 17):
        print(itemCode[i] + " " * 9 + itemDescription[i] + " " * (43 - len(itemDescription[i])) + "{}".format(price[i])
              + " " * (14 - len(str(price[i]))) + category[i])

    myOption = ""
    while myOption.upper() != "N":
        myOption = input("Would you like to buy additional components? (Y/N): ")

        if myOption.upper() == "Y":
            ItemID = ""
            while not (ItemID == "D1" or ItemID == "D2" or ItemID == "E1" or
                ItemID == "E2" or ItemID == "E3" or ItemID == "F1" or
                ItemID == "F2" or ItemID == "G1" or ItemID == "G2"):
                ItemID = input("Choose an additional Item Code: ")

                if not (ItemID == "D1" or ItemID == "D2" or ItemID == "E1" or
                ItemID == "E2" or ItemID == "E3" or ItemID == "F1" or
                ItemID == "F2" or ItemID == "G1" or ItemID == "G2"):
                    print("Choose either D1, D2, E1, E2, E3, F1, F2, G1 or G2.")

            itemCount = itemCount + 1

            if ItemID == "D1":
                newSaleItemPrice[itemCount - 1] = price[8]
                newSaleItem[itemCount - 1] = itemDescription[8]
            elif ItemID == "D2":
                newSaleItemPrice[itemCount - 1] = price[9]
                newSaleItem[itemCount - 1] = itemDescription[9]
            elif ItemID == "E1":
                newSaleItemPrice[itemCount - 1] = price[10]
                newSaleItem[itemCount - 1] = itemDescription[10]
            elif ItemID == "E2":
                newSaleItemPrice[itemCount - 1] = price[11]
                newSaleItem[itemCount - 1] = itemDescription[11]
            elif ItemID == "E3":
                newSaleItemPrice[itemCount - 1] = price[12]
                newSaleItem[itemCount - 1] = itemDescription[12]
            elif ItemID == "F1":
                newSaleItemPrice[itemCount - 1] = price[13]
                newSaleItem[itemCount - 1] = itemDescription[13]
            elif ItemID == "F2":
                newSaleItemPrice[itemCount - 1] = price[14]
                newSaleItem[itemCount - 1] = itemDescription[14]
            elif ItemID == "G1":
                newSaleItemPrice[itemCount - 1] = price[15]
                newSaleItem[itemCount - 1] = itemDescription[15]
            elif ItemID == "G2":
                newSaleItemPrice[itemCount - 1] = price[16]
                newSaleItem[itemCount - 1] = itemDescription[16]

    computerPrice = 200

    print("")
    print("Computer Invoice")
    print("")
    print("Item Description                         Item price")
    print("-" * 50)
    for i in range(7):
        if newSaleItem[i] != "":
            print(str(newSaleItem[i]) + " " * (42 - len(str(newSaleItem[i]))) + str(newSaleItemPrice[i]))
            computerPrice = computerPrice + newSaleItemPrice[i]

    print("")
    print("Total price of the computer: {}".format(computerPrice))

def task3():
    itemCount = 0
    computerPrice = 200
    print("")
    print("Computer Invoice")
    print("")
    print("Item Description                         Item price")
    print("-" * 50)
    for i in range(7):
        if newSaleItem[i] != "":
            print(str(newSaleItem[i]) + " " * (42 - len(str(newSaleItem[i]))) + str(newSaleItemPrice[i]))
            computerPrice = computerPrice + newSaleItemPrice[i]
            itemCount = itemCount + 1

    print("Total price of the computer: {}".format(computerPrice))

    if itemCount == 3:
        print("No discount applied.")
    elif itemCount == 4:
        print("5% discount applied.")
        computerPrice = computerPrice * 0.95
    elif itemCount > 4:
        print("10% discount applied.")
        computerPrice = computerPrice * 0.9

    print("Total price of computer after discount: {}".format(computerPrice))

def main():
	print("OL Computer Science")
	print("Pre Release Material (Variants 2) -- Oct/Nov 2020")
	print("Simulator by Zak; http://www.zakonweb.com")
	print("-" * 90)
    print("1. Task 1 - Setting up the system and ordering the main items..")
    print("2. Task 2 – Ordering additional items..")
    print("3. Task 3 – Offering discounts.")
    print("4. Quit")
    choice = int(input("Enter your choice [1-4]: "))

    if choice == 1: task1()
    elif choice == 2: task2()
    elif choice == 3: task3()
    elif choice == 4: pass
    else: print("Wrong choice. Please chose an option between 1-4.")
	
main()
