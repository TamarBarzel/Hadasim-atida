import math
def get_integer_input(prompt):
    while True:
        try:
            value = int(input(prompt))
            return value
        except ValueError:
            print("Invalid input. Please enter an integer.")
            return None


def print_rectangle():
    height = get_integer_input("Enter the height of the rectangle: ")
    if height is None:
        return

    width = get_integer_input("Enter the width of the rectangle: ")
    if width is None:
        return

    if height < 2 or width < 1:
        print("Invalid input. Height must be greater or equal to 2 and width must be greater than 0.")
        return

    if height == width:
        print("It's a square.")
        print("Area:", height * width)
    elif height - width > 5 or width - height > 5:
        print("It's a rectangle.")
        print("Area:", height * width)
    else:
        print("It's a rectangle.")
        print("Perimeter:", 2 * (height + width))


def print_triangle():
    base = get_integer_input("Enter the base (width) of the equilateral triangle: ")
    height = get_integer_input("Enter the height of the equilateral triangle: ")

    if height < 2 or base < 1:
        print("Invalid input. Height must be greater or equal to 2 and width must be greater than 0.")
        return

    print("You must select an option from the options below")
    print("1. Calculate perimeter")
    print("2. Print triangle")
    triangle_choice = input("Enter your choice: ")

    if triangle_choice == '1':
        side_squared= height**2 + (base/2)**2
        side_length = math.sqrt(side_squared)
        perimeter = base +(2*side_length)
        print("Perimeter:", perimeter)
    elif triangle_choice == '2':
        if base % 2 == 0 or base > 2 * height or base =='3' and height=='3':
            print("Cannot print triangle.")
            return
        print(" " * ((base - 1) // 2) + "*")
        if height==2:
            print("*" * base)





        else:
            x=base//2-1  #כמה קפיצות בכמות הכוכביות
            y = (height - 2) / x  # כמה שורות לכל קפיצה במספר הכוכביות
            y=int(y)
            remainder = (height - 2) % x  # חישוב שארית עבור הוספת שורות מתחת לשורה העליונה
            remainder = int(remainder)
            if remainder!=0:
                for i in range(remainder):
                    print(" " * ((base - 3) // 2) + "***")

            num_stars = 3
            res=int(((height-2)-remainder)/y)
            count_space = 3
            for j in range(res):
                for k in range(y):
                    print(" " * ((base - count_space) // 2) +"*" * num_stars)
                num_stars+=2
                count_space+=2
            print("*" * base)
    else:
        print("Invalid choice. Returning to the main menu.")


while True:
    print("\nChoose an option:")
    print("1. Rectangle")
    print("2. Triangle")
    print("3. Exit")

    choice = input("Enter your choice: ")

    if choice == '1':
        print_rectangle()
    elif choice == '2':
        print_triangle()
    elif choice == '3':
        print("Exiting the program.")
        break
    else:
        print("Invalid choice. Please choose again.")
