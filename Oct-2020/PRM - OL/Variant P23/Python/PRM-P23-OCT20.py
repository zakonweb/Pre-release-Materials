baguetteSize = [0, 0]
baguetteSizeName = ["15cm", "30cm"]

breadType = [0, 0, 0]
breadTypeName = ["White", "Brown", "Seeded"]

fillings = [0, 0, 0, 0, 0, 0]
fillingsName = ["Beef", "Chicken", "Cheese", "Egg", "Tuna", "Turkey"]

salad = [0, 0, 0, 0, 0]
saladName = ["Lettuce", "Tomato", "Sweetcorn", "Cucumber", "Peppers"]
saladChoiceList = ["", "", ""]

orderNo = 0

moreOrder = True
changeOrder = True

while moreOrder:
	print("OL Computer Science")
	print("Pre Release Material (Variants 3) -- Oct/Nov 2020")
	print("Simulator by Zak; http://www.zakonweb.com")
	print("-" * 90)
    while changeOrder:
        print("""Baguette sizes:
                1. 15cm
                2. 30cm """)

        sizeFlag = False
        while not sizeFlag:
            sizeChoice = int(input("Enter your choice [1-2]: "))
            if sizeChoice < 1 or sizeChoice > 2:
                print("Please enter a valid choice of size [1-2].")
            else:
                baguetteSize[sizeChoice - 1] = + 1
                sizeFlag = True

        print("""Bread types:
                1. White
                2. Brown
                3. Seeded """)

        breadFlag = False
        while not breadFlag:
            breadChoice = int(input("Enter your choice [1-3]: "))
            if breadChoice < 1 or breadChoice > 3:
                print("Please enter a valid choice of bread [1-3].")
            else:
                breadType[breadChoice - 1] = breadType[breadChoice - 1] + 1
                breadFlag = True

        print("""Baguette fillings:
                1. Beef
                2. Chicken
                3. Cheese
                4. Egg
                5. Tuna
                6. Turkey """)

        fillingFlag = False
        while not fillingFlag:
            fillingChoice = int(input("Enter your choice [1-6]: "))
            if fillingChoice < 1 or fillingChoice > 6:
                print("Please enter a valid choice of filling [1-6].")
            else:
                fillings[fillingChoice - 1] = fillings[fillingChoice - 1] + 1
                fillingFlag = True

        saladCount = 0

        print("""Salad options:
                1. Lettuce
                2. Tomato
                3. Sweetcorn
                4. Cucumber
                5. Peppers """)

        addSalad = input("Would you like to add salads to your baguette? (Y/N): ")
        if addSalad.upper() == "Y":
            saladFlag = False
            more = True

            while not saladFlag or (saladCount < 3 and more):
                saladChoice = int(
                    input("You may choose up to {} more salads. Enter your next choice [1-5]: ".format(3 - saladCount)))
                if saladChoice < 1 or saladChoice > 5:
                    print("Please enter a valid choice of salad [1-5].")
                else:
                    salad[saladChoice - 1] = salad[saladChoice - 1] + 1
                    saladFlag = True
                    saladChoiceList[saladCount] = saladChoice
                    saladCount = saladCount + 1

                    if saladCount < 3:
                        moreChoice = input("Would you like to add another salad? (Y/N): ")
                        if moreChoice.upper() == "Y":
                            more = True
                        else:
                            more = False

        sizeDisplay = baguetteSizeName[sizeChoice - 1]
        bread = breadTypeName[breadChoice - 1]
        filling = fillingsName[fillingChoice - 1]

        print("Your ordered baguette:")
        print("")
        print("Size:")
        print(sizeDisplay)
        print("Bread:")
        print(bread)
        print("Filling:")
        print(filling)
        print("Salad(s):")
        for i in range(3):
            if saladChoiceList[i] != "":
                print(saladName[saladChoiceList[i] - 1])

        print("")
        confirmOrderChoice = input("Confirm order? (Y/N): ")
        if confirmOrderChoice.upper() == "N":
            confirmOrder = False

            changeOrder = False
            cancelOrder = False

            while not changeOrder and not cancelOrder:
                changeOrderChoice = input("Would you like to change your order or cancel it? (Change/Cancel): ")
                if changeOrderChoice.upper() == "CHANGE":
                    changeOrder = True
                elif changeOrderChoice.upper() == "CANCEL":
                    cancelOrder = True
                else:
                    print("Please enter a valid value.")

        elif confirmOrderChoice.upper() == "Y":
            cancelOrder = False
            changeOrder = False
            orderNo = orderNo + 1
            print("")
            print("Your order number is: {}".format(orderNo))

    print("")
    moreOrderChoice = input("Would you like to order another baguette? (Y/N): ")
    if moreOrderChoice.upper() == "Y":
        moreOrder = True
    else:
        moreOrder = False


def task23():
    # TASK 2 BEGINS HERE

    totalBaguettesSold = orderNo

    totalSize15 = baguetteSize[0]
    totalSize30 = baguetteSize[1]

    totalBreadWhite = breadType[0]
    totalBreadBrown = breadType[1]
    totalBreadSeeded = breadType[2]

    totalFillingBeef = fillings[0]
    totalFillingChicken = fillings[1]
    totalFillingCheese = fillings[2]
    totalFillingEgg = fillings[3]
    totalFillingTuna = fillings[4]
    totalFillingTurkey = fillings[5]

    mostFilling = -10000
    leastFilling = 10000

    for i in range(6):
        if fillings[i] > mostFilling:
            mostFilling = fillings[i]
            mostPopularName = fillingsName[i]
        elif fillings[i] < leastFilling:
            leastFilling = fillings[i]
            leastPopularName = fillingsName[i]

    mostPopularPerc = (mostFilling / totalBaguettesSold) * 100
    leastPopularPerc = (leastFilling / totalBaguettesSold) * 100

    print("")
    print("The most popular baguette filling was {} with an order of {}%".format(mostPopularName, mostPopularPerc))
    print("The least popular baguette filling was {} with an order of {}%".format(leastPopularName, leastPopularPerc))


task23()
