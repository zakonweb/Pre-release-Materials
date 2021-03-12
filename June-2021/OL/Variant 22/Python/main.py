def task1():
    # DECLARE leaveTickets : ARRAY[0:3] OF INTEGER
    # DECLARE returnTickets : ARRAY[0:3] OF INTEGER
    # DECLARE leavePassengers : ARRAY[0:3] OF INTEGER
    # DECLARE returnPassengers : ARRAY[0:3] OF INTEGER
    # DECLARE leaveTotal : ARRAY[0:3] OF INTEGER
    # DECLARE returnTotal : ARRAY[0:3] OF INTEGER

    leaveTickets = [480, 480, 480, 480]
    returnTickets = [480, 480, 480, 620]

    leavePasssengers = [0, 0, 0, 0]
    returnPassengers = [0, 0, 0, 0]

    leaveTotal = [0, 0, 0, 0]
    returnTotal = [0, 0, 0, 0]


    print("Departure train - 09:00. Tickets left: " + str(leaveTickets[0]))
    print("Departure train - 11:00. Tickets left: " + str(leaveTickets[1]))
    print("Departure train - 13:00. Tickets left: " + str(leaveTickets[2]))
    print("Departure train - 15:00. Tickets left: " + str(leaveTickets[3]))
    print("")
    print("Return train - 10:00. Tickets left: " + str(returnTickets[0]))
    print("Return train - 12:00. Tickets left: " + str(returnTickets[1]))
    print("Return train - 14:00. Tickets left: " + str(returnTickets[2]))
    print("Return train - 16:00. Tickets left: " + str(returnTickets[3]))
    print("")





def task2():
    # DECLARE continueFlag : BOOLEAN
    # DECLARE discountFlag : BOOLEAN
    # DECLARE departureFlag : BOOLEAN
    # DECLARE returnFlag : BOOLEAN
    #
    # DECLARE continueFlagStr : STRING
    # DECLARE departureJourney : STRING
    # DECLARE returnJourney : STRING
    #
    # DECLARE numPassengers : INTEGER
    # DECLARE discount : INTEGER
    # DECLARE numPassengersTemp : INTEGER
    # DECLARE cost : INTEGER

    continueFlag = True
    while continueFlag:
        print("")
        print("")
        numPassengers = int(input("Enter the number of people travelling: "))
        print("")

        discountFlag = True

        discount = 0
        numPassengersTemp = numPassengers
        while discountFlag and discount < 8:
            if numPassengersTemp - 10 >= 0:
                discount = discount + 1
                numPassengersTemp = numPassengersTemp - 10
            else:
                discountFlag = False

        departureFlag = True
        while departureFlag:
            departureJourney = input("Choose the departure timings (0900/1100/1300/1500): ")

            if departureJourney == "0900":
                if leaveTickets[0] - numPassengers < 0:
                    print("Not enough seats left on this train.")
                    print("")
                else:
                    leaveTickets[0] = leaveTickets[0] - numPassengers
                    leavePasssengers[0] = leavePasssengers[0] + numPassengers

                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    leaveTotal[0] = leaveTotal[0] + cost
                    departureFlag = False

            elif departureJourney == "1100":
                if leaveTickets[1] - numPassengers < 0:
                    print("Not enough seats left on this train.")
                    print("")
                else:
                    leaveTickets[1] = leaveTickets[1] - numPassengers
                    leavePasssengers[1] = leavePasssengers[1] + numPassengers
                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    leaveTotal[1] = leaveTotal[1] + cost
                    departureFlag = False

            elif departureJourney == "1300":
                if leaveTickets[2] - numPassengers < 0:
                    print("Not enough seats left on this train.")
                    print("")
                else:
                    leaveTickets[2] = leaveTickets[2] - numPassengers
                    leavePasssengers[2] = leavePasssengers[2] + numPassengers
                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    leaveTotal[2] = leaveTotal[2] + cost
                    departureFlag = False

            elif departureJourney == "1500":
                if leaveTickets[3] - numPassengers < 0:
                    print("Not enough seats left on this train.")
                    print("")
                else:
                    leaveTickets[3] = leaveTickets[3] - numPassengers
                    leavePasssengers[3] = leavePasssengers[3] + numPassengers
                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    leaveTotal[3] = leaveTotal[3] + cost
                    departureFlag = False

            else:
                print("Invalid response. Please choose one of 0900/1100/1300/1500")
                print("")
                print("")

        returnFlag = True
        while returnFlag:
            returnJourney = input("Choose the return timings (1000/1200/1400/1600): ")

            if returnJourney == "1000":
                if returnTickets[0] - numPassengers < 0:
                    print("Not enough tickets left on this train.")
                    print("")
                else:
                    returnTickets[0] = returnTickets[0] - numPassengers
                    returnPassengers[0] = returnPassengers[0] + numPassengers
                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    returnTotal = returnTotal[0] + cost
                    returnFlag = False

            elif returnJourney == "1200":
                if returnTickets[1] - numPassengers < 0:
                    print("Not enough tickets left on this train.")
                    print("")
                else:
                    returnTickets[1] = returnTickets[1] - numPassengers
                    returnPassengers[1] = returnPassengers[1] + numPassengers
                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    returnTotal[1] = returnTotal[1] + cost
                    returnFlag = False

            elif returnJourney == "1400":
                if returnTickets[2] - numPassengers < 0:
                    print("Not enough tickets left on this train.")
                    print("")
                else:
                    returnTickets[2] = returnTickets[2] - numPassengers
                    returnPassengers[2] = returnPassengers[2] + numPassengers
                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    returnTotal[2] = returnTotal[2] + cost
                    returnFlag = False

            elif returnJourney == "1600":
                if returnTickets[3] - numPassengers < 0:
                    print("Not enough tickets left on this train.")
                    print("")
                else:
                    returnTickets[3] = returnTickets[3] - numPassengers
                    returnPassengers[3] = returnPassengers[3] + numPassengers
                    cost = 25 * (numPassengers - discount)
                    print("Total tickets price: " + str(cost))
                    returnTotal[3] = returnTotal[3] + cost
                    returnFlag = False

            else:
                print("Invalid response. Please choose one of 1000/1200/1400/1600.")
                print("")
                print("")

        print("Departure train - 09:00. Tickets left: " + str(leaveTickets[0]))
        print("Departure train - 11:00. Tickets left: " + str(leaveTickets[1]))
        print("Departure train - 13:00. Tickets left: " + str(leaveTickets[2]))
        print("Departure train - 15:00. Tickets left: " + str(leaveTickets[3]))
        print("")
        print("Return train - 10:00. Tickets left: " + str(returnTickets[0]))
        print("Return train - 12:00. Tickets left: " + str(returnTickets[1]))
        print("Return train - 14:00. Tickets left: " + str(returnTickets[2]))
        print("Return train - 16:00. Tickets left: " + str(returnTickets[3]))
        print("")
        print("")
        print("")
        print("")

        continueFlagStr = input("Are there more tickets to buy? (Y/N): ")
        if continueFlagStr == "Y":
            continueFlag = True
        elif continueFlagStr == "N":
            continueFlag = False
        else:
            print("Enter a correct value")

    print("")
    print("")


# TASK 3

def task3():
    # DECLARE totalPassengers : INTEGER
    # DECLARE totalMoney : INTEGER
    # DECLARE mostPassengers : INTEGER
    # DECLARE leaveMost : BOOLEAN
    # DECLARE returnMost : BOOLEAN
    # DECLARE index : INTEGER

    print("Number of passengers on the 0900 Departure train: " + str(leavePasssengers[0]))
    print("Total money taken for the 0900 Departure train: " + str(leaveTotal[0]))
    print("")
    print("Number of passengers on the 1100 Departure train: " + str(leavePasssengers[1]))
    print("Total money taken for the 1100 Departure train: " + str(leaveTotal[1]))
    print("")
    print("Number of passengers on the 1300 Departure train: " + str(leavePasssengers[2]))
    print("Total money taken for the 1300 Departure train: " + str(leaveTotal[2]))
    print("")
    print("Number of passengers on the 1500 Departure train: " + str(leavePasssengers[3]))
    print("Total money taken for the 1500 Departure train: " + str(leaveTotal[3]))
    print("")
    print("Number of passengers on the 1000 Return train: " + str(returnPassengers[0]))
    print("Total money taken for the 1000 Return train: " + str(returnTotal[0]))
    print("")
    print("Number of passengers on the 1200 Return train: " + str(returnPassengers[1]))
    print("Total money taken for the 1200 Return train: " + str(returnTotal[1]))
    print("")
    print("Number of passengers on the 1400 Return train: " + str(returnPassengers[2]))
    print("Total money taken for the 1400 Return train: " + str(returnTotal[2]))
    print("")
    print("Number of passengers on the 1600 Return train: " + str(returnPassengers[3]))
    print("Total money taken for the 1600 Return train: " + str(returnTotal[3]))


    totalPassengers = 0
    totalMoney = 0


    for i in range(4):
        totalPassengers = totalPassengers + leavePasssengers[i]
        totalPassengers = totalPassengers + returnPassengers[i]
        totalMoney = totalMoney + leaveTotal[i]
        totalMoney = totalMoney + returnTotal[i]


    mostPassengers = -1000
    leaveMost = False
    returnMost = False

    index = None

    for i in range(4):
        if leavePasssengers[i] > mostPassengers:
            mostPassengers = leavePasssengers[i]
            index = i
            leaveMost = True
            returnMost = False
        if returnPassengers[i] > mostPassengers:
            mostPassengers = returnPassengers[i]
            index = i
            returnMost = True
            leaveMost = False


    if index == 0 and leaveMost:
        print("The 0900 Departure train had the most passengers.")
    elif index == 0 and returnMost:
        print("The 1000 Return train had the most passengers.")
    elif index == 1 and leaveMost:
        print("The 1100 Departure train had the most passengers.")
    elif index == 1 and returnMost:
        print("The 1200 Return train had the most passengers.")
    elif index == 2 and leaveMost:
        print("The 1300 Departure train had the most passengers.")
    elif index == 2 and returnMost:
        print("The 1400 Return train had the most passengers.")
    elif index == 3 and leaveMost:
        print("The 1500 Departure train had the most passengers")
    elif index == 3 and returnMost:
        print("The 1600 Return train had the most passengers.")

    print("Total money taken for the day: " + str(totalMoney))
    print("Total passengers travelling for the day: " + str(totalPassengers))


def main():
    print("OL Computer Science")
    print("Pre Release Material (Variants 2) -- Oct/Nov 2020")
    print("Simulator by Zak; http://www.zakonweb.com")
    print("-" * 90)
    print("1. Task 1 - Start-of-the-day display.")
    print("2. Task 2 – Purchasing tickets.")
    print("3. Task 3 – Day-end display.")
    print("4. Quit")
    print("")
    choice = int(input("Enter your choice [1-4]: "))
    if choice == 1:
        task1()
    elif choice == 2:
        task2()
    elif choice == 3:
        task3()
    elif choice == 4:
        pass
    else:
        print("Wrong choice. Please chose an option between 1-4.")


main()










