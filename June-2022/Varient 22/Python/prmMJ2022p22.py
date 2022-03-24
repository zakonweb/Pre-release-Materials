displayCount = 0
ticketTypes = ["One Adult", "One Child", "One Senior", "Family (Two Adults/Seniors, Three Children)",
               "Group (Six+ People, price per person)"]
ticketPricesOneDay = [20.00, 12.00, 16.00, 60.00, 15.00]
ticketPricesTwoDays = [30.00, 18.00, 24.00, 90.00, 22.50]
extraAttractions = ["Lion Feeding", "Penguin Feeding", "Evening Barbeque (two-day tickets only)"]
extraAttractionsPrices = [2.50, 2.00, 5.00]
days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"]


# Task 1

def task1():
    print("One-Day Tickets:")
    print("----------------------")
    for displayCount in range(5):
        print(str(displayCount + 1) + ". " + ticketTypes[displayCount] + ": $" + str(ticketPricesOneDay[displayCount]))

    print("")

    print("Two-Day Tickets:")
    print("----------------------")
    for displayCount in range(5):
        print(str(displayCount + 1) + ". " + ticketTypes[displayCount] + ": $" + str(ticketPricesTwoDays[displayCount]))

    print("")

    print("Extra Attractions:")
    print("----------------------")
    for displayCount in range(3):
        print(str(displayCount + 1) + ". " + extraAttractions[displayCount] + ": $" + str(
            extraAttractionsPrices[displayCount]))

    print("")

    print("Available Days:")
    print("----------------------")
    for displayCount in range(7):
        print(str(displayCount + 1) + ". " + days[displayCount])


# TASK 2 and 3

def task2_3():
    bookingNum = 0
    continueFlag = True

    while continueFlag:
        ticketType = 0
        bestOption = ""

        numPeople = 0
        numAdults = 0
        numChildren = -1
        numChildrenTickets = -1
        numSeniors = 0
        numFamily = 0
        numGroup = 0
        numPenguin = 0
        numLion = 0
        numBBQ = 0

        ticketChoice = 0
        extraChoice = 1
        dayChoice = 0
        taskChoice = 0

        totalPrice = 0.00

        individual = 2
        proceed = "1"

        bookingNum = bookingNum + 1

        print("")
        while dayChoice < 1 or dayChoice > 7:
            dayChoice = int(input("Please enter the day of visit from available days shown above (1-7): "))
            if dayChoice < 1 or dayChoice > 7:
                print("ERROR: Please enter a valid day from the days shown above (1-7).")
                print("")
        print(" ")
        numAdults = int(input("Please enter the number of adults visiting: "))
        while numChildren > (numAdults * 2) or numChildren == -1:
            numChildren = int(input("Please enter the number of Children visiting: "))
            if numChildren > (numAdults * 2):
                print("ERROR: Maximum 2 children allowed per adult.")
                print("")
        numSeniors = int(input("Please enter the number of seniors visiting: "))
        print("")

        while ticketType != 1 and ticketType != 2:
            ticketType = int(input("Please enter your ticket type (One-Day: enter 1, Two-Day: enter 2): "))
            if ticketType != 1 and ticketType != 2:
                print("")
                print("ERROR: Please enter a valid ticket type (One-Day: enter 1, Two-Day: enter 2).")
                print("")

        print("")
        while individual < 0 or individual > 1:
            individual = int(input("Would you like to make individual bookings? (Yes - 1, No, 0): "))
            if individual < 0 or individual > 1:
                print("ERROR: Please enter a valid input (Yes - 1, No - 0).")
                print("")
        if individual == 1:
            numAdults = int(input("Please enter the number of Adult tickets you wish to purchase: "))
            while numChildrenTickets > (numAdults * 2) or numChildrenTickets == -1:
                numChildrenTickets = int(input("Please enter the number of Children tickets you wish to purchase: "))
                if numChildrenTickets > (numAdults * 2):
                    print("ERROR: Maximum 2 children allowed per adult.")
                    print("")
            numSeniors = int(input("Please enter the number of Senior tickets you wish to purchase: "))
        else:
            numFamily = int(input("Please enter the number of Family tickets you wish to purchase: "))
            numGroup = int(input("Please enter the number of Group tickets you wish to purchase: "))

        numPeople = numAdults + numChildren + numSeniors

        if ticketType == 1:
            totalPrice = (numAdults * ticketPricesOneDay[0]) + (numChildren * ticketPricesOneDay[1]) + (
                    numSeniors * ticketPricesOneDay[2]) \
                         + (numFamily * ticketPricesOneDay[3]) + (numGroup * ticketPricesOneDay[4])
        else:
            totalPrice = (numAdults * ticketPricesTwoDays[0]) + (numChildren * ticketPricesTwoDays[1]) + (
                    numSeniors * ticketPricesTwoDays[2]) \
                         + (numFamily * ticketPricesTwoDays[3]) + (numGroup * ticketPricesTwoDays[4])

        extraChoice = input("Would you like to book an extra attraction? (Yes - 1, No - 0): ")
        if extraChoice == "1":
            numLion = int(input("Please enter the number of tickets for Lion Feeding: "))
            numPenguin = int(input("Please enter the number of tickets for Penguin Feeding: "))
            if ticketType == 2:
                numBBQ = int(input("Please enter the number of tickets for BBQ: "))
            else:
                print("BBQ Not Applicable on One-Day Tickets")
            totalPrice += (numLion * extraAttractionsPrices[0]) + (numPenguin * extraAttractionsPrices[1]) + (
                        numBBQ * extraAttractionsPrices[2])

        if (numAdults + numSeniors) % 2 == 0 and numChildren % 3 == 0 and numChildren == (2 / 3) * (numAdults + numSeniors):
            bestOption = ticketTypes[3]
        elif numPeople >= 6:
            bestOption = ticketTypes[4]
        else:
            bestOption = "Individual"
        if (bestOption == "Individual" and individual != 1) or (bestOption == ticketTypes[4] and numGroup == 0) or (
                bestOption == ticketTypes[3] and numFamily == 0):
            print("The ticket options chosen are not the best value.")
            if bestOption == "Individual":
                print("The best value option is: Individual Tickets(s)")
            elif bestOption == ticketTypes[4]:
                print("The best value option is: Group Ticket")
            elif bestOption == ticketTypes[3]:
                print("The best value option is: Family Ticket(s)")
            proceed = input("Would you like to proceed with your current booking? (Proceed - 1, Make New Booking - 0): ")

        if proceed == "0":
            continueFlag = True
        else:
            print("")
            print("BOOKING DETAILS")
            print("---------------")
            print("Booking Number:", bookingNum)
            print("Day of visit:", days[dayChoice - 1])
            if ticketType == 1:
                if individual == 1:
                    if numAdults > 0:
                        print(
                            "Ticket: Adult (One Day) | Num. of Tickets: " + str(numAdults) + " | Price Per Ticket: $" + str(
                                ticketPricesOneDay[0]))
                    if numChildrenTickets > 0:
                        print("Ticket: Child (One Day) | Num. of Tickets: " + str(
                            numChildrenTickets) + " | Price Per Ticket: $" + str(
                            ticketPricesOneDay[1]))
                    if numSeniors > 0:
                        print("Ticket: Senior (One Day) | Num. of Tickets: " + str(
                            numSeniors) + " | Price Per Ticket: $" + str(
                            ticketPricesOneDay[2]))
                else:
                    if numFamily > 0:
                        print(
                            "Ticket: Family [2 Adults/Seniors + 3 Children] (One Day) | Num. of Tickets: " + str(numFamily)
                            + " | Price Per Ticket: $" + str(ticketPricesOneDay[3]))
                    if numGroup > 0:
                        print("Ticket: Group [6+, price per person] (One Day) | Num. of Tickets: " + str(numGroup)
                              + " | Price Per Ticket: $" + str(ticketPricesOneDay[4]))
            else:
                if individual == 1:
                    if numAdults > 0:
                        print("Ticket: Adult (Two Days) | Num. of Tickets: " + str(
                            numAdults) + " | Price Per Ticket: $" + str(
                            ticketPricesTwoDays[0]))
                    if numChildren > 0:
                        print("Ticket: Child (Two Days) | Num. of Tickets: " + str(
                            numChildren) + " | Price Per Ticket: $" + str(
                            ticketPricesTwoDays[1]))
                    if numSeniors > 0:
                        print("Ticket: Senior (Two Days) | Num. of Tickets: " + str(
                            numSeniors) + " | Price Per Ticket: $" + str(
                            ticketPricesTwoDays[2]))
                else:
                    if numFamily > 0:
                        print(
                            "Ticket: Family [2 Adults/Seniors + 3 Children] (Two Days) | Num. of Tickets: " + str(numFamily)
                            + " | Price Per Ticket: $" + str(ticketPricesTwoDays[3]))
                    if numGroup > 0:
                        print("Ticket: Group [6+, price per person] (Two Days) | Num. of Tickets: " + str(numGroup)
                              + " | Price Per Ticket: $" + str(ticketPricesTwoDays[4]))
            if numLion > 0:
                print("Extra Attraction: Lion Feeding | Price per person: $" + str(extraAttractionsPrices[0]))
            if numPenguin > 0:
                print("Extra Attraction: Penguin Feeding | Price per person: $" + str(extraAttractionsPrices[1]))
            if numBBQ > 0:
                print("Extra Attraction: Evening BBQ | Price per person: $" + str(extraAttractionsPrices[2]))

            print("Total Cost: $" + str(totalPrice))

            while continueFlag != "1" and continueFlag != "0":
                print("")
                continueFlag = input("Would you like to make another booking? (Yes - 1, No - 0):")
                if continueFlag != "1" and continueFlag != "0":
                    print("ERROR: Please enter a valid response (Yes - 1, No - 0).")
                    print("")
            continueFlag = bool(int(continueFlag))


def main():
    print("OL Computer Science")
    print("Pre Release Material (Variants 2) -- May/Jun 2022")
    print("Simulator by Zak; http://www.zakonweb.com")
    print("-" * 90)
    print("1. Task 1 - Display Options.")
    print("2. Task 2 and 3 – Purchase tickets.")
    print("3. Quit.")
    print("")
    while taskChoice < 1 or taskChoice > 3:
        taskChoice = int(input("Enter your choice [1-3]: "))
        if taskChoice == 1:
            task1()
        elif taskChoice == 2:
            task2_3()
        elif taskChoice == 3:
            pass
        else:
            print("Wrong choice. Please chose an option between 1-3.")

